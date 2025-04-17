namespace GDFUnityEditor
{
    /// <summary>
    /// The GDFConstantsUnityEditor class contains constants used in the UnityEditor for the GDF package.
    /// </summary>
    public abstract class GDFConstantsUnityEditor
    {
        /// <summary>
        /// The _pro constant is used in multiple classes within the GDFUnityEditor namespace.
        /// It is a string constant that is appended to various other strings to distinguish
        /// them as "pro" versions.
        /// </summary>
        public const string _pro = "_pro";

        /// <summary>
        /// Constant for the benchmark color green in the Unity editor.
        /// </summary>
        public const string K_EDITOR_BENCHMARK_GREEN = "K_EDITOR_BENCHMARK_GREEN";

        /// <summary>
        /// The constant representing the key for the red benchmark in the editor.
        /// </summary>
        public const string K_EDITOR_BENCHMARK_RED = "K_EDITOR_BENCHMARK_RED";

        /// The constant value for K_EDITOR_BENCHMARK_ORANGE.
        /// This constant is defined in the GDFConstantsUnityEditor class.
        /// It is used for editor benchmarking purposes.
        /// /
        public const string K_EDITOR_BENCHMARK_ORANGE = "K_EDITOR_BENCHMARK_ORANGE";

        /// <summary>
        /// Represents the constant for the blue benchmark color in the editor.
        /// </summary>
        public const string K_EDITOR_BENCHMARK_BLUE = "K_EDITOR_BENCHMARK_BLUE";

        /// <summary>
        /// Constant for the value of K_EDITOR_BENCHMARK_GREEN_PRO.
        /// </summary>
        public const string K_EDITOR_BENCHMARK_GREEN_PRO = "K_EDITOR_BENCHMARK_GREEN_PRO";

        /// <summary>
        /// The constant variable for the 'K_EDITOR_BENCHMARK_RED_PRO' key.
        /// </summary>
        public const string K_EDITOR_BENCHMARK_RED_PRO = "K_EDITOR_BENCHMARK_RED_PRO";

        /// *Type**: string
        /// *Description**: This constant represents the value "K_EDITOR_BENCHMARK_ORANGE_PRO" which is used in the GDFUnityEditor namespace. It is a part of the GDFConstantsUnityEditor class and is used for benchmarking purposes in the orange Pro version of the editor.
        public const string K_EDITOR_BENCHMARK_ORANGE_PRO = "K_EDITOR_BENCHMARK_ORANGE_PRO";

        /// <summary>
        /// The constant variable for the benchmark color blue in the editor.
        /// </summary>
        public const string K_EDITOR_BENCHMARK_BLUE_PRO = "K_EDITOR_BENCHMARK_BLUE_PRO";

        //public const string K_EDITOR_CLIPBOARD_LAST_LOG = "K_EDITOR_CLIPBOARD_LAST_LOG";
        /// <summary>
        /// The flag indicating whether the editor benchmark is enabled.
        /// </summary>
        public const string K_EDITOR_BENCHMARK_IS_ENABLE = "K_EDITOR_BENCHMARK_IS_ENABLE";

        /// <summary>
        /// Constant string representing the key for showing the start of a benchmark in the editor.
        /// </summary>
        public const string K_EDITOR_BENCHMARK_SHOW_START = "K_EDITOR_BENCHMARK_SHOW_START";

        /// <summary>
        /// The benchmark limit for the Unity Editor.
        /// </summary>
        /// <remarks>
        /// This constant is used to define a benchmark limit for the Unity Editor.
        /// It specifies the maximum value for benchmark measurements in the editor.
        /// </remarks>
        public const string K_EDITOR_BENCHMARK_LIMIT = "K_EDITOR_BENCHMARK_LIMIT";
        //public const string K_EDITOR_SHOW_COMPILE = "K_EDITOR_SHOW_COMPILE";
        /// <summary>
        /// Represents the key for the logo content to be displayed in the editor.
        /// </summary>
        /// <remarks>
        /// This string constant is used within the GDFUnityEditor namespace to define the key
        /// for the logo content that will be displayed in the editor. It is used in various
        /// classes within the namespace for logo-related functionality.
        /// </remarks>
        public const string K_EDITOR_SHOW_LOGO_CONTENT = "K_EDITOR_SHOW_LOGO_CONTENT";

        /// <summary>
        /// This class contains constant strings related to the K_EDITOR_USER_BUILDER feature.
        /// </summary>
        public const string K_EDITOR_USER_BUILDER = "GDF_USER_BUILDER";

        /// <summary>
        /// Width of the editor panel.
        /// </summary>
        public const string K_EDITOR_PANEL_WIDTH = "K_EDITOR_PANEL_WIDTH";

        /// <summary>
        /// The build environment in the Unity Editor.
        /// </summary>
        public const string K_EDITOR_BUILD_ENVIRONMENT = "EditorBuildEnvironment";

        /// <summary>
        /// Represents the constant variable for the editor build rename.
        /// </summary>
        public const string K_EDITOR_BUILD_RENAME = "EditorBuildRename";

        /// <summary>
        /// Constant for the database update during the editor build.
        /// </summary>
        public const string K_EDITOR_BUILD_DATABASE_UPDATE = "EditorBuildDatabaseUpdate";

        /// <summary>
        /// Represents various window styles used in the K_EDITOR_WINDOW.
        /// </summary>
        public const string K_EDITOR_WINDOW_STYLE = "EditorWindoStyle";



        // App Configurations Strings
        /// <summary>
        /// Project configuration for connection with server
        /// </summary>
        public const string K_APP_CONFIGURATION_HELPBOX = "Project configuration for connection with server";

        /// <summary>
        /// The K_APP_CONFIGURATION_MENU_NAME constant is used within the GDFUnityEditor namespace.
        /// It represents the name for the application configuration menu in the Unity Editor.
        /// </summary>
        public const string K_APP_CONFIGURATION_MENU_NAME = "Environments configurations";
        //public const string K_APP_CONFIGURATION_DEV = "Development";
        //public const string K_APP_CONFIGURATION_PREPROD = "PreProduction";
        //public const string K_APP_CONFIGURATION_PROD = "Production";
        /// <summary>
        /// The save button text for the app configuration.
        /// </summary>
        public const string K_APP_CONFIGURATION_SAVE_BUTTON = "Save configurations";

        /// <summary>
        /// This variable is used for configuring the language area in the app.
        /// </summary>
        public const string K_APP_CONFIGURATION_LANGUAGE_AREA = "Languages configurations";

        /// <summary>
        /// The area of the app configuration related to environment settings.
        /// </summary>
        public const string K_APP_CONFIGURATION_ENVIRONMENT_AREA = "Environment's configurations";

        /// <summary>
        /// Project configuration for connection with server
        /// </summary>
        public const string K_APP_CONFIGURATION_BUNDLENAMEE_AREA = "Bundle name's localization";

        /// <summary>
        /// Project localization area in the app configuration.
        /// </summary>
        public const string K_APP_CONFIGURATION_DEV_LOCALALIZATION_AREA = "Project localization";

        /// <summary>
        /// Choose project localization.
        /// </summary>
        public const string K_APP_CONFIGURATION_DEV_LOCALALIZATION_CHOOSE = "Choose project localization";

        /// <summary>
        /// Title for the environment chooser.
        /// </summary>
        public const string K_APP_CHOOSER_ENVIRONMENT_TITLE = "Chooser";

        /// <summary>
        /// Macro define title.
        /// </summary>
        public const string K_APP_MACRO_DEFINE_TITLE = "Macro define";

        /// <summary>
        /// This class contains constant string values related to the app model manager title.
        /// </summary>
        public const string K_APP_MODEL_MANAGER_TITLE = "Model manager";

        /// <summary>
        /// The title string for the cluster sizer in the application.
        /// </summary>
        public const string K_APP_CLUSTER_SIZER_TITLE = "Cluster sizer";

        /// <summary>
        /// Synchronize your datas in the good environment.
        /// </summary>
        public const string K_APP_SYNC_ENVIRONMENT = "Synchronize your datas in the good environment";

        /// <summary>
        /// The title used for synchronizing datas in the current environment.
        /// </summary>
        public const string K_APP_SYNC_ENVIRONMENT_TITLE = "Sync";

        /// <summary>
        /// The title for the app configuration.
        /// </summary>
        public const string K_APP_CONFIGURATION_TITLE = "App configuration";

        /// <summary>
        /// The title for the web service management.
        /// </summary>
        public const string K_WEBSERVICE_MANAGEMENT_TITLE = "Webservices management";

        /// <summary>
        /// Title for the data selector.
        /// </summary>
        public const string K_DATA_SELECTOR_TITLE = "Selector";

        /// <summary>
        /// The title for the data selector.
        /// </summary>
        public const string K_DATA_SELECTOR_TITLE_FOR = "Selector for ";

        /// <summary>
        /// Title for the Localization Configuration.
        /// </summary>
        public const string K_LOCALIZATION_CONFIGURATION_TITLE = "Localization";

        /// <summary>
        /// Title for project configuration.
        /// </summary>
        public const string K_PROJECT_CONFIGURATION_TITLE = "Project";

        /// <summary>
        /// Represents the title of the user configuration.
        /// </summary>
        public const string K_USER_CONFIGURATION_TITLE = "User Prefs";

        /// <summary>
        /// Represents the title of the credentials configuration.
        /// </summary>
        public const string K_CREDENTIALS_CONFIGURATION_TITLE = "Credentials";

        /// <summary>
        /// Represents the title of the environments configuration.
        /// </summary>
        public const string K_ENVIRONMENTS_CONFIGURATION_TITLE = "Data Tracks";

        /// <summary>
        /// The title for the Data Inspector in the application.
        /// </summary>
        public const string K_APP_SYNC_INSPECTOR_TITLE = "Data inspector";

        /// <summary>
        /// Error message indicating that the alert salt is not properly memorized. You should record the configurations and recompile the project.
        /// </summary>
        public const string K_ALERT_SALT_SHORT_ERROR = "ALERT SALT ARE NOT MEMORIZE : RECCORD CONFIGURATIONS AND RECOMPILE!";

        /// <summary>
        /// This constant represents the label for the "Generate salts" button in the application.
        /// </summary>
        public const string K_APP_CLASS_SALT_REGENERATE = "Generate salts";

        /// <summary>
        /// Title used for iDemoBi alerts.
        /// </summary>
        public const string K_ALERT_IDEMOBI_TITLE = "GameDataForge";

        /// <summary>
        /// The password key used for storing and retrieving the password.
        /// </summary>
        public const string K_CREDENTIALS_PASSWORD = "PasswordKey_31564873413687653";

        /// <summary>
        /// Passphrase used for credentials encryption and decryption.
        /// </summary>
        public const string K_CREDENTIALS_PASSPHRASE = "PassphraseKey_455454542687653";

        /// <summary>
        /// Constant representing the key for the passphrase used in credentials.
        /// </summary>
        /// <remarks>
        /// This constant is used in the context of credentials management. The passphrase is a secret
        /// combination of characters used to encrypt and decrypt sensitive data, such as passwords
        /// and user information. It is important to keep this passphrase secure and not disclose it.
        /// </remarks>
        public const string K_CREDENTIALS_PASSPHRASE_USED = "PassphraseUsedKey_455454542687653";

        /// <summary>
        /// The vector string key used for credentials.
        /// </summary>
        public const string K_CREDENTIALS_VECTOR = "VectorStringKey_79877414532159874";

        /// <summary>
        /// Indicates whether passwords should be shown in logs.
        /// </summary>
        public const string K_CREDENTIALS_SHOW_PASSWORDS_IN_LOG = "ShowPasswordInLogKey_79585254215";

        /// <summary>
        /// The key to save the credentials for authentication.
        /// </summary>
        public const string K_CREDENTIALS_SAVE = "SaveCredentialsKey_7895452114789523654";

        /// <summary>
        /// Represents the tag key used for credentials in the application.
        /// </summary>
        public const string K_CREDENTIALS_TAG = "TagCredentialsKey_55687768543186454";

        /// <summary>
        /// The title key for the credentials. Use this key to access the title of the credentials in the application.
        /// </summary>
        public const string K_CREDENTIALS_TITLE = "TitleCredentialsKey_4687415685742157";
    }
}
