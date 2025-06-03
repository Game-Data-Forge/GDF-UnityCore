using System;
using GDFFoundation;
using GDFRuntime;
using UnityEngine;
using static GDFUnity.CoreAccountManager;

namespace GDFUnity
{
    public abstract class CoreAuthenticationDevice : IRuntimeAccountManager.IRuntimeAuthentication.IRuntimeDevice
    {
        public abstract Job SignIn(Country country);
    }

    public class CoreAuthenticationDevice<T> : CoreAuthenticationDevice where T : IRuntimeEngine
    {
        private T _engine;
        private CoreAccountManager _manager;

        public CoreAuthenticationDevice(T engine, CoreAccountManager manager)
        {
            _engine = engine;
            _manager = manager;
        }

        public override Job SignIn(Country country)
        {
            lock (_manager.LOCK)
            {
                _manager.EnsureUseable();

                _manager.job = Job.Run(handler =>
                {
                    using IDisposable _ = _manager.Lock();

                    handler.StepAmount = 4;

                    _manager.ResetToken(handler.Split());
                    string bearer;
                    string url;
                    DeviceSignInExchange signInPayload = new DeviceSignInExchange()
                    {
                        Channel = _engine.Configuration.Channel,
                        UniqueIdentifier = _engine.DeviceManager.Id,
                        Country = country
                    };
                    try
                    {
                        url = _manager.GenerateURL(country, "/api/v1/authentication/device/sign-in");
                        bearer = _manager.Post<string>(handler.Split(), url, signInPayload);
                    }
                    catch (APIException e)
                    {
                        if (e.StatusCode != System.Net.HttpStatusCode.Forbidden)
                        {
                            throw;
                        }

                        DeviceSignUpExchange signUpPayload = new DeviceSignUpExchange()
                        {
                            Channel = _engine.Configuration.Channel,
                            UniqueIdentifier = _engine.DeviceManager.Id,
                            Consent = true,
                            ConsentVersion = "1.0.0",
                            GameConsentVersion = "1.0.0",
                            Country = country
                        };

                        Debug.LogWarning("Game consent is hard written to 1.0.0 !");

                        url = _manager.GenerateURL(country, "/api/v1/authentication/device/sign-up");
                        bearer = _manager.Post<string>(handler.Split(), url, signUpPayload);
                    }
                    catch
                    {
                        throw;
                    }
                    _manager.SetToken(handler.Split(), new TokenStorage(country, bearer));
                }, "Device sign in");

                return _manager.job;
            }
        }
    }
}