using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class ManagementView : IWindowView<AccountWindow>
    {
        public string Name => "Management";
        public string Title => "Account management";
        public string Help => "/unity/editor-windows/account/account/management";

        private AccountWindow _window;
        private Button _logout;
        private Button _purge;
        private Button _delete;

        public ManagementView(AccountWindow window)
        {
            _window = window;

            _logout = new Button(Logout);
            _logout.text = "Sign out";
            _logout.tooltip = "Sign out from the account.";

            _purge = new Button(Purge);
            _purge.text = "Purge account data";
            _purge.tooltip = "Permanently delete the account data.";

            _delete = new Button(Delete);
            _delete.text = "Delete account";
            _delete.tooltip = "Permanently delete the account.";
        }

        public void OnActivate(AccountWindow window, WindowView<AccountWindow> view)
        {
            view.Add(_logout);
            view.Add(_purge);
            view.Add(_delete);
        }

        public void OnDeactivate(AccountWindow window, WindowView<AccountWindow> view)
        {

        }

        private void Logout()
        {
            _window.MainView.AddCriticalLoader(GDF.Account.Authentication.SignOut());
        }

        private void Delete()
        {
            if (!EditorUtility.DisplayDialog("Account deletion", "You are about to delete the current account. All data related to this account will be deleted and you will be disconnected." +
                "\nThis operation cannot be reversed. Do you wish to proceed?", "Yes", "No"))
            {
                return;
            }

            _window.MainView.AddCriticalLoader(GDF.Account.Delete());
        }
        
        private void Purge()
        {
            if (!EditorUtility.DisplayDialog("Account purge", "You are about to delete all player data of the account."+
                "\nThis operation cannot be reversed. Do you wish to proceed?", "Yes", "No"))
            {
                return;
            }
            
            _window.MainView.AddCriticalLoader(GDF.Player.Purge());
        }
    }
}
