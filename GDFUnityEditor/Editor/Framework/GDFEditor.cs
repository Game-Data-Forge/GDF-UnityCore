using System;
using GDFEditor;
using GDFFoundation.Tasks;

namespace GDFUnity.Editor
{
    static public class GDFEditor
    {
        static private Func<IEditorEngine> _instance = null;
        static public Func<IEditorEngine> Instance
        {
            set
            {
                if (_instance != null)
                {
                    throw GDF.Exceptions.EngineCannotChangeInstance;
                }
                _instance = value;
            }
        }

        static private IEditorEngine Engine
        {
            get
            {
                if (_instance == null)
                {
                    throw GDF.Exceptions.BuilderMissing;
                }

                return _instance();
            }
        }

        static public Task Launch => Engine.Launch;

        static public IEditorConfiguration Configuration => Engine.Configuration;
        
        static public IEditorThreadManager Thread => Engine.ThreadManager;
        static public IEditorEnvironmentManager Environment => Engine.EnvironmentManager;
        static public IEditorDeviceManager Device => Engine.DeviceManager;
        static public IEditorAuthenticationManager Authentication => Engine.AuthenticationManager;
        static public IEditorTypeManager Types => Engine.TypeManager;
        static public IEditorPlayerDataManager Player
        {
            get
            {
                if (Engine.AuthenticationManager.Token == null)
                {
                    throw GDF.Exceptions.NotConnected;
                }
                return Engine.PlayerDataManager;
            }
        }

        static public Task Stop()
        {
            return Engine.Stop();
        }

        static public void Kill()
        {
            Engine.Kill();
        }
    }
}
