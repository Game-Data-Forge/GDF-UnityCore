using GDFEditor;
using GDFFoundation;

namespace GDFUnity.Editor
{
    public class EditorAccountManager : CoreAccountManager<EditorAccountAuthentication, EditorAccountCredentials>, IEditorAccountManager
    {
        IEditorAccountManager.IEditorAuthentication IEditorAccountManager.Authentication => _authentication;
        IEditorAccountManager.IEditorCredentials IEditorAccountManager.Credentials => _credentials;

        MemoryJwtToken IEditorAccountManager.Token => Token;

        public EditorAccountManager(IEditorEngine engine) : base(engine)
        {
            _authentication = new EditorAccountAuthentication(engine, this);
            _credentials = new EditorAccountCredentials(this);
        }
    }
}