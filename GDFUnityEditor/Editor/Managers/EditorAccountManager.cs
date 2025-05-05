using GDFEditor;
using GDFFoundation;
using GDFFoundation.Tasks;
using UnityEngine;

namespace GDFUnity.Editor
{
    public class EditorAccountManager : RuntimeAccountManager, IEditorAccountManager
    {
        public EditorAccountManager(IEditorEngine engine) : base(engine)
        {
        }
    }
}