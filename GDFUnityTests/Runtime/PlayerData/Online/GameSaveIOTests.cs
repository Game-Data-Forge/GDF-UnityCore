using System.Collections;
using GDFFoundation;
using GDFUnity;

namespace PlayerData.Online
{
    public class GameSaveIOTests : BaseGameSaveIOTests
    {
        Country country = Country.FR;

        protected override IEnumerator Connect()
        {
            UnityJob task = GDF.Account.Authentication.Device.Login(country);
            yield return WaitJob(task);
        }
    }
}