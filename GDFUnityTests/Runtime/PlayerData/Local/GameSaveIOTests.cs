using System.Collections;
using GDFUnity;

namespace PlayerData.Local
{
    public class GameSaveIOTests : BaseGameSaveIOTests
    {
        protected override IEnumerator Connect()
        {
            UnityJob task = GDF.Account.Authentication.Local.Login();
            yield return WaitJob(task);
        }
    }
}