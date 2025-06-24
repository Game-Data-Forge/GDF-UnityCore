using System;
using System.Collections.Generic;
using System.Linq;
using GDFFoundation;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class LoadingView : VisualElement
    {
        static private Texture2D _logo = null;
        static private Texture2D _Logo {
            get
            {
                if (_logo == null)
                {
                    if (EditorGUIUtility.isProSkin)
                    {
                        _logo = (Texture2D)AssetDatabase.LoadAssetAtPath<Texture>("Assets/GDFNuGet/GDFUnityEditor/Editor/Images/d_GDF3WindowLogo.png");
                    }
                    else
                    {
                        _logo = (Texture2D)AssetDatabase.LoadAssetAtPath<Texture>("Assets/GDFNuGet/GDFUnityEditor/Editor/Images/GDF3WindowLogo.png");
                    }
                }

                return _logo;
            }
        }

        public enum Display
        {
            PreLoader = 0,
            Body = 1
        }

        private struct Operation
        {
            public IJob task;
            public Action<IJob> onDone;
            public string Title => task.Name;
            public float Progress => task.Progress;

            public Operation(IJob task, Action<IJob> onDone)
            {
                this.task = task;
                this.onDone = onDone;
            }

            public void Invoke()
            {
                try
                {
                    using (task)
                    {
                        onDone?.Invoke(task);
                    }
                }
                catch {}
            }

            public void Display(ScrollView scrollView, Card card)
            {
                if (task.State == JobState.Success)
                {
                    card.SetState(true, $"{Title}: Operation success !");
                }
                else if (task.Error != null)
                {
                    card.SetState(false, $"{Title}: {task.Error.Message}");
                }
                else
                {
                    card.SetState(false, $"{Title}: Operation failed !");
                }
                scrollView.Insert(0, card);
            }
        }

        private class Card : VisualElement, IPoolItem
        {
            public Pool Pool { get; set; }

            private VisualElement _state;
            private TextElement _message;

            public Card()
            {
                style.flexDirection = FlexDirection.Row;
                style.flexGrow = 1;
                style.paddingBottom = 2;
                style.paddingTop = 2;
                style.paddingLeft = 2;
                style.paddingRight = 2;

                _state = new VisualElement();

                _message = new TextElement();
                _message.style.flexGrow = 1;

                Add(_state);
                Add(_message);
            }

            public void SetState(bool ok, string message)
            {
                if (ok)
                {
                    _state.style.IconContent("console.infoicon.sml");
                }
                else
                {
                    _state.style.IconContent("console.erroricon.sml");
                }
                _message.text = message;
            }

            public void OnPooled()
            {
                style.display = DisplayStyle.Flex;
            }

            public void OnReleased()
            {
                style.display = DisplayStyle.None;
            }

            public void Dispose()
            {
                PoolItem.Release(this);
            }
        }

        static private Pool<Card> pool = new Pool<Card> ();

        public event Action<Display> onDisplayChanged;
        private List<Operation> _operations = new List<Operation>();
        private Spinner _spinner;
        private ProgressBar _progress;
        private VisualElement _mainFrame;
        private VisualElement _body;
        private ScrollView _footer;
        private PreLoader _preLoader;
        private Display _mainDisplay = Display.Body;

        public Display MainDisplay
        {
            get => _mainDisplay;
            set
            {
                if (_preLoader == null)
                {
                    return;
                }

                _mainDisplay = value;
                if (_mainDisplay == Display.Body)
                {
                    _body.style.display = DisplayStyle.Flex;
                    _preLoader.style.display = DisplayStyle.None;
                }
                else
                {
                    _body.style.display = DisplayStyle.None;
                    _preLoader.style.display = DisplayStyle.Flex;
                    _preLoader.PreLoad();
                }

                onDisplayChanged?.Invoke(value);
            }
        }

        public LoadingView(VisualElement body) : base()
        {
            style.flexGrow = 1;

            TwoPaneSplitView splitView = new TwoPaneSplitView(1, 40, TwoPaneSplitViewOrientation.Vertical);

            _body = body;

            VisualElement footer = new VisualElement();
            footer.style.minHeight = 40;

            Toolbar toolbar = new Toolbar();
            ToolbarButton clear = new ToolbarButton(() =>
            {
                foreach (Card card in _footer.Children().Cast<Card>())
                {
                    card.Dispose();
                }
                _footer.Clear();
            });
            clear.text = "Clear";

            _spinner = new Spinner();
            _spinner.style.visibility = Visibility.Hidden;
            _spinner.onSpinUpdate += CheckOperations;

            _progress = new ProgressBar();
            _progress.style.visibility = Visibility.Hidden;
            _progress.lowValue = 0;
            _progress.highValue = 1;
            _progress.style.flexGrow = 1;

            toolbar.Add(_spinner);
            toolbar.Add(_progress);
            toolbar.Add(clear);
            footer.Add(toolbar);

            VisualElement footerBody = new VisualElement();
            footerBody.style.flexDirection = FlexDirection.Row;

            VisualElement logo = new VisualElement();
            logo.style.backgroundImage = Background.FromTexture2D(_Logo);
            logo.style.backgroundSize = new BackgroundSize(20, 20);
            logo.style.position = Position.Absolute;
            logo.style.top = 0;
            logo.style.right = 0;
            logo.style.width = 20;
            logo.style.height = 20;

            _footer = new ScrollView(ScrollViewMode.Vertical);
            _footer.style.flexGrow = 1;
            _footer.style.flexShrink = 0;

            footerBody.Add(_footer);

            footer.Add(footerBody);

            _mainFrame = new VisualElement();
            _mainFrame.style.minHeight = 50;
            _mainFrame.Add(_body);

            splitView.Add(_mainFrame);
            splitView.Add(footer);

            Add(splitView);
        }

        public LoadingView() : this (new VisualElement())
        {

        }

        public void AddBody(VisualElement element)
        {
            _body.Add(element);
        }

        public new void Clear()
        {
            _body.Clear();
        }

        public void AddCriticalLoader(IJob task, Action<IJob> onDone = null)
        {
            SetBodyEnabled(false);
            AddLoader(task, job =>
            {
                try
                {
                    onDone?.Invoke(job);
                }
                finally
                {
                    SetBodyEnabled(true);
                }
            });
        }

        public void AddLoader(IJob task, Action<IJob> onDone)
        {
            _spinner.style.visibility = Visibility.Visible;
            _progress.style.visibility = Visibility.Visible;
            _spinner.Spin();
            _operations.Add(new Operation(task, onDone));
            if (_operations.Count == 1)
            {
                UpdateProgressBar();
            }
        }

        public void AddPreloader(PreLoader preLoader)
        {
            if (preLoader == null) return;

            _preLoader = preLoader;
            _preLoader.SetView(this);
            _mainFrame.Add(_preLoader);

            if (!_preLoader.IsLoaded)
            {
                MainDisplay = Display.PreLoader;
            }
            else
            {
                MainDisplay = Display.Body;
            }
        }

        private void SetBodyEnabled(bool value)
        {
            _body.SetEnabled(value);
        }
        
        private void CheckOperations(float _)
        {
            if (_operations.Count == 0)
            {
                _spinner.style.visibility = Visibility.Hidden;
                _progress.style.visibility = Visibility.Hidden;
                _spinner.Stop();
            }

            for (int i = _operations.Count - 1; i >= 0; i--)
            {
                if (_operations[i].task.IsDone)
                {
                    _operations[i].Invoke();
                    _operations[i].Display(_footer, pool.Get());
                    _operations.RemoveAt(i);
                }
            }

            UpdateProgressBar();
        }

        protected void UpdateProgressBar()
        {
            if (_operations.Count > 0)
            {
                _progress.title = _operations[0].Title;
                _progress.value = _operations[0].Progress;

                if (_operations.Count > 1)
                {
                    _progress.title += $" ({_operations.Count})";
                }
            }
        }
    }
}