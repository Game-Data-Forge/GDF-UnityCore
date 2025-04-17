using System;
using System.Net;
using System.Text.RegularExpressions;
using GDFFoundation;
using GDFFoundation.Tasks;

namespace GDFUnity.Editor
{
    public class SettingsManager : APIManager
    {
        static private readonly Regex ADDRESS_REGEX = new Regex(@"^https?:\/\/([0-9a-zA-Z]+)(\.[0-9a-zA-Z]+|-[0-9a-zA-Z]+)*(:[0-9]{1,5})?\/?$");
        
        static private readonly Regex ROLE_REGEX = new Regex(@"^([0-9a-zA-Z_-]){128}$");

        static public class Exceptions
        {
            static public APIException InvalidDashboardAddress => new APIException(HttpStatusCode.BadRequest, "API", 3, "Dashboard address is not of valid format");
            static public APIException InvalidRoleTokenFormat => new APIException(HttpStatusCode.Unauthorized, "API", 3, "Invalid role token format");
        }

        public bool IsValidAddress(string address)
        {
            if (address == null)
            {
                return false;
            }
            return ADDRESS_REGEX.IsMatch(address);
        }

        public ITask<DateTime> ContactDashboard(string dashboardAddress)
        {
            string taskName = "Connect to dashboard";
            if (!IsValidAddress(dashboardAddress))
            {
                return Task<DateTime>.Failure(Exceptions.InvalidDashboardAddress, taskName);
            }

            return Task<DateTime>.Run((handler) => {
                UriBuilder builder = new UriBuilder(dashboardAddress);
                builder.Path = "/api/v1/date";

                return Get<DateTime>(handler, builder.ToString());

            }, taskName);
        }
        
        public ITask<GDFProjectConfiguration> RequestConfigurationUpdate(string dashboardAddress, string role)
        {
            string operationName = "Retrieve project configuration";
            if (!IsValidAddress(dashboardAddress))
            {
                return Task<GDFProjectConfiguration>.Failure(Exceptions.InvalidDashboardAddress, operationName);
            }

            if (!ROLE_REGEX.IsMatch(role))
            {
                return Task<GDFProjectConfiguration>.Failure(Exceptions.InvalidRoleTokenFormat, operationName);
            }

            return Task<GDFProjectConfiguration>.Run((handler) => {
                UriBuilder builder = new UriBuilder(dashboardAddress);
                builder.Path = $"/api/v1/role/{role}";

                return Get<GDFProjectConfiguration>(handler, builder.ToString());

            }, operationName);
        }
    }
}