using System;
using GDFEditor;
using GDFFoundation;

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

        static private IEditorEngine StartedEngine
        {
            get
            {
                IEditorEngine engine = Engine;
                if (!engine.Launch.IsDone)
                {
                    throw GDF.Exceptions.NotLaunched;
                }
                
                if (engine.Launch.State != JobState.Success)
                {
                    throw GDF.Exceptions.LaunchFailed;
                }

                return engine;
            }
        }

        static private IEditorEngine AuthenticatedEngine
        {
            get
            {
                IEditorEngine engine = StartedEngine;
                if (engine.AuthenticationManager.Token == null)
                {
                    throw GDF.Exceptions.NotConnected;
                }

                return engine;
            }
        }

        static public Job Launch => Engine.Launch;

        static public IEditorConfiguration Configuration => Engine.Configuration;
        
        static public IEditorThreadManager Thread => StartedEngine.ThreadManager;
        static public IEditorEnvironmentManager Environment => StartedEngine.EnvironmentManager;
        static public IEditorDeviceManager Device => StartedEngine.DeviceManager;
        static public IEditorAuthenticationManager Authentication => StartedEngine.AuthenticationManager;
        static public IEditorTypeManager Types => StartedEngine.TypeManager;
        static public IEditorAccountManager Account => AuthenticatedEngine.AccountManager;
        static public IEditorPlayerDataManager Player => AuthenticatedEngine.PlayerDataManager;

        static public Job Stop()
        {
            return Engine.Stop();
        }

        static public void Kill()
        {
            Engine.Kill();
        }
    }
}
