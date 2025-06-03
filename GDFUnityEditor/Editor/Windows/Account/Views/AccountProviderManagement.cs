using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountProviderManagement : AccountViewProvider
    {
        public override string Name => "Management";
        public override string Title => "Account management";
        public override string Help => null;

        private AccountWindow _window;
        private Button _purge;
        private Button _delete;

        public AccountProviderManagement(AccountWindow window)
        {
            _window = window;

            _purge = new Button(Purge);
            _purge.text = "Purge account data";
            _purge.tooltip = "Permanently delete the account data";

            _delete = new Button(Delete);
            _delete.text = "Delete account";
            _delete.tooltip = "Permanently delete the account";
        }

        public override void OnActivate(AccountView view, VisualElement rootElement)
        {
            rootElement.Add(_purge);
            rootElement.Add(_delete);
        }

        public override void OnDeactivate(AccountView view, VisualElement rootElement)
        {

        }

        private void Delete()
        {
            if (!EditorUtility.DisplayDialog("Account deletion", "You are about to delete the current account. All data related to this account will be deleted and you will be disconnected." +
                "\nThis operation cannot be reversed. Do you wish to proceed?", "Yes", "No"))
            {
                return;
            }

            _window.rootVisualElement.SetEnabled(false);

            _window.mainView.AddLoader(GDF.Account.Delete(), _ =>
            {
                _window.rootVisualElement.SetEnabled(true);
            });
        }
        
        private void Purge()
        {
            if (!EditorUtility.DisplayDialog("Account purge", "You are about to delete all player data of the account."+
                "\nThis operation cannot be reversed. Do you wish to proceed?", "Yes", "No"))
            {
                return;
            }
            
            _window.rootVisualElement.SetEnabled(false);

            _window.mainView.AddLoader(GDF.Player.Purge(), _ => {
                _window.rootVisualElement.SetEnabled(true);
            });
        }
    }
}
