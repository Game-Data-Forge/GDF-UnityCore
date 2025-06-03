using System.Collections.Generic;
using GDFFoundation;
using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountProviderCredentials : AccountViewProvider
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

        public override string Name => "Credentials";
        public override string Title => "Account credentials";
        public override string Help => null;

        private AccountWindow _window;
        private VisualElement _body;

        public AccountProviderCredentials(AccountWindow window)
        {
            _window = window;

            _body = new VisualElement();
            _body.style.flexGrow = 1;
        }

        public override void OnActivate(AccountView view, VisualElement rootElement)
        {
            rootElement.Add(_body);
            Update();
        }

        public override void OnDeactivate(AccountView view, VisualElement rootElement)
        {

        }

        private void Update()
        {
            _window.rootVisualElement.SetEnabled(false);
            foreach (VisualElement element in _body.hierarchy.Children())
            {
                Credentials credentials = element as Credentials;
                if (credentials == null) continue;

                credentials.Dispose();
            }
            _body.Clear();

            _window.mainView.AddLoader(GDF.Account.Credentials.Refresh(), job =>
            {
                List<GDFAccountSign> signs = GDF.Account.Credentials.Credentials;

                foreach (GDFAccountSign sign in signs)
                {
                    Credentials credentials = _pool.Get();
                    credentials.SetSign(sign);
                    _body.Add(credentials);
                }

                _window.rootVisualElement.SetEnabled(true);
            });
        }
    }
}
