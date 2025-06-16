using System.Collections.Generic;
using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class CredentialsView : IWindowView<AccountWindow>
    {
        private class Credentials : VisualElement, IPoolItem
        {
            public Pool Pool { get; set; }

            private Label _type;
            private Label _hash;

            public Credentials()
            {
                style.flexGrow = 1;
                _type = new Label();
                _hash = new Label();

                Add(_type);
                Add(_hash);
            }

            public void SetSign(GDFAccountSign sign)
            {
                _type.text = sign.SignType.ToString();
                _hash.text = sign.SignHash;
            }

            public void Dispose()
            {
                PoolItem.Release(this);
            }

            public void OnPooled()
            {
                
            }

            public void OnReleased()
            {
                
            }
        }

        static private Pool<Credentials> _pool = new Pool<Credentials>();

        public string Name => "Credentials";
        public string Title => "Account credentials";
        public string Help => null;

        private AccountWindow _window;
        private VisualElement _body;

        public CredentialsView(AccountWindow window)
        {
            _window = window;

            _body = new VisualElement();
            _body.style.flexGrow = 1;
        }

        public void OnActivate(AccountWindow window, WindowView<AccountWindow> view)
        {
            view.Add(_body);
            Update();
        }

        public void OnDeactivate(AccountWindow window, WindowView<AccountWindow> view)
        {

        }

        private void Update()
        {
            foreach (VisualElement element in _body.hierarchy.Children())
            {
                Credentials credentials = element as Credentials;
                if (credentials == null) continue;

                credentials.Dispose();
            }
            _body.Clear();

            _window.MainView.AddCriticalLoader(GDF.Account.Credentials.Refresh(), job =>
            {
                List<GDFAccountSign> signs = GDF.Account.Credentials.Credentials;

                foreach (GDFAccountSign sign in signs)
                {
                    Credentials credentials = _pool.Get();
                    credentials.SetSign(sign);
                    _body.Add(credentials);
                }
            });
        }
    }
}
