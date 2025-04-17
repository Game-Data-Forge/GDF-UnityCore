using System;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFRuntime;

namespace GDFUnity
{
    static public class GDF
    {
        static public class Exceptions
        {
            static public GDFException EngineCannotChangeInstance => new GDFException("ENG", 1, "Cannot changed engine instance ! Instance already set...");
            static public GDFException BuilderMissing => new GDFException("ENG", 2, "Cannot fetch engine ! Instance missing...");
            static public GDFException NotConnected => new GDFException("ENG", 3, "Not connected to an account ! Feature inaccessible...");
        }

        static private Func<IRuntimeEngine> _instance = null;
        static public Func<IRuntimeEngine> Instance
        {
            set
            {
                if (_instance != null)
                {
                    throw Exceptions.EngineCannotChangeInstance;
                }
                _instance = value;
            }
        }

        static private IRuntimeEngine Engine
        {
            get
            {
                if (_instance == null)
                {
                    throw Exceptions.BuilderMissing;
                }

                return _instance();
            }
        }

        static public Task Launch => Engine.Launch;

        static public IRuntimeConfiguration Configuration => Engine.Configuration;
        
        static public IRuntimeThreadManager Thread => Engine.ThreadManager;
        static public IRuntimeEnvironmentManager Environment => Engine.EnvironmentManager;
        static public IRuntimeDeviceManager Device => Engine.DeviceManager;
        static public IRuntimeAuthenticationManager Authentication => Engine.AuthenticationManager;
        static public IRuntimePlayerDataManager Player
        {
            get
            {
                if (Engine.AuthenticationManager.Token == null)
                {
                    throw Exceptions.NotConnected;
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
