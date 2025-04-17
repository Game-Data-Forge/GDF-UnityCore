namespace GDFUnityEditor
{
    /// <summary>
    /// Constants used in the GDFEditor.
    /// </summary>
    public abstract class GDFEditorConstants // TODO: Make it static instead ?
    {
        // Idemobi alert Strings
        /// <summary>
        /// The title for the idéMobi alert.
        /// </summary>
        public const string K_ALERT_IDEMOBI_TITLE = "Game-Data-Forge";

        /// <summary>
        /// Represents the idéMobi alert message constant in the GDFEditorConstants class.
        /// </summary>
        public const string K_ALERT_IDEMOBI_MESSAGE = "Game-Data-Forge is an idéMobi© package to create and manage datas in your games. You can create your owner classes and manage like standard Game-Data-Forge";

        /// <summary>
        /// Represents the message text that is displayed when the user clicks the "OK" button in an Alert window.
        /// </summary>
        public const string K_ALERT_IDEMOBI_OK = "Thanks!";

        /// <summary>
        /// K_ALERT_IDEMOBI_SEE_DOC
        /// </summary>
        public const string K_ALERT_IDEMOBI_SEE_DOC = "See online docs";

        /// <summary>
        /// Constant variable for the alert message to see the website.
        /// </summary>
        public const string K_ALERT_IDEMOBI_SEE_WEBSITE = "See website";

        /// <summary>
        /// This constant represents the URL of the Game-Data-Forge documentation.
        /// </summary>
        public const string K_ALERT_IDEMOBI_DOC_HTTP = "http://www.game-data-forge.com/";

        #region Automated requests delays

        /// <summary>
        /// Represents the interval in minutes for checking data repeat every in the GDFUnityEditorDataManager class.
        /// </summary>
        public const int CheckDataRepeatEvery = 45; // default = 300

        /// <summary>
        /// Represents the interval in seconds at which the selected data should be updated.
        /// </summary>
        public const int UpdateDataSelectedRepeatEvery = 10;

        /// <summary>
        /// The UpdateSettings variable represents the repeat interval (in seconds) for updating settings.
        /// </summary>
        public const int UpdateSettings = 60;

        #endregion
    }
}
