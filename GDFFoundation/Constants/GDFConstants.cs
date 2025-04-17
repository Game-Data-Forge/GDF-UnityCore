using System;
using System.Globalization;

namespace GDFFoundation
{
    [Flags]
    public enum PrintAsciiKind
    {
        None = 0,
        Information = 1 << 0,
        Version = 1 << 1,
        Logo = 1 << 2,
    }
    /// <summary>
    /// Constants class for Game-Data-Forge.
    /// </summary>
    public abstract class GDFConstants
    {
        public static PrintAsciiKind PrintAscii = PrintAsciiKind.Logo|PrintAsciiKind.Information;

        /// <summary>
        /// Represents the fake project ID constant.
        /// </summary>
        public const long K_FAKE_PROJECT_ID = 11111;

        /// <summary>
        /// Represents the environment kind of the fake project.
        /// </summary>
        public const GDFEnvironmentKind K_FAKE_PROJECT_ENVIRONMENT = GDFEnvironmentKind.Development;

        /// <summary>
        /// This constant represents the fake project key.
        /// </summary>
        public const string K_FAKE_PROJECT_KEY = "78945318964df89zegter845ds1f23s4897TREFG4Q65SF4CD8SQ67F89ZR4G5DS64";

        /// <summary>
        /// Represents the fake secret key used in the project.
        /// </summary>
        public const string K_FAKE_SECRET_KEY = "zegt78945318964df89er845ds1f23s4897TREF67F89ZR4G5DS64G4Q65SF4CD8SQ";

        /// <summary>
        /// Represents a fake crucial key used in the application.
        /// </summary>
        public const string K_FAKE_CRUCIAL_KEY = "89er845ds1f23zegtREF67F89ZR4G5DS64G4Q65SF4CD8SQ78945318964dfs4897T";

        /// <summary>
        /// Represents the treat key used in a web treat configuration.
        /// </summary>
        public const string K_FAKE_TREAT_KEY = "egtREF67F889er845ds1f23z9ZR4G5DS64GCD8SQ78945318964dfs4897T4Q65SF4";


        /// <summary>
        /// Constant variable representing the random project ID.
        /// </summary>
        public static long K_RANDOM_PROJECT_ID = GDFRandom.LongNumeric(5);

        /// <summary>
        /// Represents the environment of a random project.
        /// </summary>
        public static GDFEnvironmentKind K_RANDOM_PROJECT_ENVIRONMENT = GDFEnvironmentKind.Production;

        /// <summary>
        /// Represents the randomly generated project key for the application.
        /// </summary>
        public static string K_RANDOM_PROJECT_KEY = GDFRandom.RandomGameDataForgeToken();

        /// <summary>
        /// Represents the random secret key used for encryption and decryption in Net-Worked Data framework.
        /// </summary>
        public static string K_RANDOM_SECRET_KEY = GDFRandom.RandomGameDataForgeToken();

        /// <summary>
        /// Represents the random crucial key constant used in the Game-Data-Forge framework.
        /// </summary>
        public static string K_RANDOM_CRUCIAL_KEY = GDFRandom.RandomGameDataForgeToken();

        /// <summary>
        /// Represents a randomly generated treat key used in the GDFWebTreatConfiguration class.
        /// </summary>
        /// <remarks>
        /// This variable is a constant string value that is randomly generated using the RandomGameDataForgeToken method from the GDFRandom class.
        /// </remarks>
        /// <value>
        /// The treat key value.
        /// </value>
        public static string K_RANDOM_TREAT_KEY = GDFRandom.RandomGameDataForgeToken();

        /// <summary>
        /// The K_RESOURCES constant is a string that represents the path to the localization resources in the GDFWebEditor project.
        /// </summary>
        public const string K_RESOURCES = "Resources";

        // long :0 to 18 446 744 073 709 551 615
        // ushort :	0 to 65 535 (use as range to prevent migration)
        // reference with long =>  1 | 8 446 7 |  44 073 709 551 615
        // reference => 0/1 | ushort | 10^14
        // number of row : 1 000                     : 10^3  : thousand (kilo)
        // number of row : 1 000 000                 : 10^6  : million (mega)
        // number of row : 1 000 000 000             : 10^9  : billion (giga)
        // number of row : 1 000 000 000 000         : 10^12 : trillion (tera)
        // for security use 10^12 for 
        // example for range 1244 => 1 01244 00 xxxxxxxxxxxx
        /// <summary>
        /// The reference size used for generating unique identifiers.
        /// </summary>
        public const ushort K_REFERENCE_SIZE = 12;

        /// <summary>
        /// The range of a reference area.
        /// </summary>
        public const Int64 K_REFERENCE_AREA_RANGE = 100000000000000;

        /// <summary>
        /// The global reference area for Game-Data-Forge.
        /// </summary>
        public const Int64 K_REFERENCE_AREA_GLOBAL = K_REFERENCE_AREA_RANGE * 10000;

        /// <summary>
        /// Represents the constant value for the reference unique size.
        /// </summary>
        public const ushort K_REFERENCE_UNIQUE_SIZE = 16;

        /// <summary>
        /// Constants related to the GDF assemblies.
        /// </summary>
        public const string GDF3Assemblies = "###GDF3Assemblies";

        /// <summary>
        /// Constants used in the GDFCore namespace.
        /// </summary>
        public const string GDFCore = "GDFCore";

        /// <summary>
        /// Contains various constants used in GDFCustomModels namespace.
        /// </summary>
        public const string GDFCustomModels = "GDFCustomModels";

        /// <summary>
        /// The <see cref="GDFEditionToolbox"/> class contains constants used in the GDFFoundation library.
        /// </summary>
        public const string GDFEditionToolbox = "GDFEditionToolbox";

        /// <summary>
        /// The GDFEngine class contains constants and configurations for the GDFFoundation framework.
        /// </summary>
        public const string GDFEngine = "GDFEngine";

        /// <summary>
        /// The <see cref="GDFFoundation"/> class contains various constants used in the GDFFoundation namespace.
        /// </summary>
        public const string GDFFoundation = "GDFFoundation";

        /// <summary>
        /// The GDFStandardModels class holds constants and configuration information for the standard models in the Game-Data-Forge framework.
        /// </summary>
        public const string GDFStandardModels = "GDFStandardModels";

        /// <summary>
        /// Class containing constants used in the GDFDevTeam project.
        /// </summary>
        public const string GDFDevTeam = "GDFDevTeam";

        /// <summary>
        /// The GDFUnity class contains various constants and settings for Unity projects using Net-Worked Data.
        /// </summary>
        public const string GDFUnity = "GDFUnity";

        /// <summary>
        /// Custom edition specific constants for the Unity platform.
        /// </summary>
        public const string GDFUnityCustomEdition = "GDFUnityCustomEdition";

        /// <summary>
        /// Class containing constants used by GDFUnityEditor.
        /// </summary>
        public const string GDFUnityEditor = "GDFUnityEditor";

        /// <summary>
        /// Represents the GDFUnityEditorTest constant.
        /// </summary>
        public const string GDFUnityEditorTest = "GDFUnityEditorTest";

        /// <summary>
        /// The GDFUnityRuntime class contains constants and utility methods related to the Unity runtime environment.
        /// </summary>
        public const string GDFUnityRuntime = "GDFUnityRuntime";

        /// <summary>
        /// This class contains constants used by the GDFUnityRuntimeTest project.
        /// </summary>
        public const string GDFUnityRuntimeTest = "GDFUnityRuntimeTest";

        /// <summary>
        /// Constants used in the <see cref="GDFUnityStandardEdition"/> namespace.
        /// </summary>
        public const string GDFUnityStandardEdition = "GDFUnityStandardEdition";

        /// <summary>
        /// Represents the GDFWeb constant.
        /// </summary>
        public const string GDFWeb = "GDFWeb";

        /// <summary>
        /// The GDFCluster class contains various constants used in the GDF software.
        /// </summary>
        public const string GDFCluster = "GDFCluster";

        /// <summary>
        /// Editor_CheckRightsRepeatEvery constant. Represents the time interval in seconds for checking user rights repeatedly in the editor.
        /// </summary>
        public const int Editor_CheckRightsRepeatEvery = 60;

        /// <summary>
        /// The Editor_CheckDatasRepeatEvery variable determines the interval at which data checks are performed in the editor.
        /// This variable is set to 30, indicating that data checks are performed every 30 seconds.
        /// </summary>
        public const int Editor_CheckDatasRepeatEvery = 30;

        /// <summary>
        /// The Editor_UpdateDataSelectedRepeatEvery variable determines the repeat interval for updating selected data in the editor.
        /// </summary>
        public const int Editor_UpdateDataSelectedRepeatEvery = 10;

        /// <summary>
        /// Constants related to the editor's removal locker.
        /// </summary>
        public const int Editor_RemoveLockerAfter = 600;

        /// <summary>
        /// Represents the URL constant for the Net-Worked Data (GDF) platform.
        /// This constant is used to specify the base URL for all API calls and web requests within the GDF platform.
        /// </summary>
        public static string K_GDFURL = "https://www.game-data-forge.com";

        /// <summary>
        /// The K_GDF constant is a string representing the value "Game-Data-Forge"
        /// </summary>
        public static string K_GDF = "Game-Data-Forge";

        /// <summary>
        /// The K_IDEMOBI constant represents the string value "idéMobi".
        /// </summary>
        public static string K_IDEMOBI = "idéMobi";

        public const string C_EMPTY_STRING = "";

        /// <summary>
        /// The character used to represent a minus sign.
        /// </summary>
        public const string K_MINUS = "-";

        /// <summary>
        /// Constant representing the hashtag symbol (#).
        /// </summary>
        public const string K_HASHTAG = "#";

        /// <summary>
        /// The constant value for variable K_A.
        /// </summary>
        /// <remarks>
        /// This is defined in the GDFConstants class in the GDFFoundation namespace.
        /// </remarks>
        public const string K_A = "A";

        /// <summary>
        /// Represents the newline character sequence.
        /// </summary>
        public const string K_ReturnLine = "\n";

        /// <summary>
        /// Provides constant values and settings related to the Game-Data-Forge (GDF) configuration extension.
        /// </summary>
        public const string K_GDFConfigExtension = ".json";

        /// <summary>
        /// Represents the file path for the GDF Unity Editor configuration file.
        /// </summary>
        public const string K_GDFConfigUnityEditorPath = "GDFConfigUnityEditor" + K_GDFConfigExtension;

        /// <summary>
        /// Represents the path of the Unity runtime configuration file for the Game-Data-Forge (GDF) framework.
        /// </summary>
        public const string K_GDFConfigUnityRuntimePath = "GDFConfigUnityRuntime" + K_GDFConfigExtension;

        /// <summary>
        /// GDFConstants class contains various constant values used throughout the application.
        /// </summary>
        public const string K_GDFConfigClusterPath = "appsettings" + K_GDFConfigExtension;

        /// <summary>
        /// Represents the length of a token.
        /// </summary>
        public const int K_TOKEN_LENGHT = 64;

        /// <summary>
        /// Represents the length of a stat key.
        /// </summary>
        public const int K_STAT_KEY_LENGHT = 16;

        /// <summary>
        /// This class contains constants used in the GDFFoundation namespace.
        /// </summary>
        public static string K_EMPTY_STRING = string.Empty;

        /// <summary>
        /// Represents the format for displaying country-specific information.
        /// </summary>
        public static CultureInfo FormatCountry = CultureInfo.InvariantCulture;

        /// <summary>
        /// The formatting string used for floating point numbers.
        /// </summary>
        public static string FloatFormat = "F5";

        /// <summary>
        /// Represents the format used for storing floating point numbers in SQL databases.
        /// </summary>
        public static string FloatSQLFormat = "5";

        /// <summary>
        /// Represents the format string used to format double values.
        /// </summary>
        /// <remarks>
        /// The format string should adhere to the standard .NET formatting rules for double values.
        /// </remarks>
        public static string DoubleFormat = "F5";

        /// <summary>
        /// The DoubleSQLFormat class contains a constant string that represents the format to apply when converting a double value to an SQL string.
        /// </summary>
        public static string DoubleSQLFormat = "5";

        /// <summary>
        /// Constants related to development name.
        /// </summary>
        public static string K_DEVELOPMENT_NAME = "Preview";

        /// <summary>
        /// The name of the qualification.
        /// </summary>
        public static string K_QUALIFICATION_NAME = "Qualification";

        /// <summary>
        /// A class that contains constants related to pre-production environment.
        /// </summary>
        public static string K_PREPRODUCTION_NAME = "Preprod";

        /// <summary>
        /// The name of the playtest.
        /// </summary>
        public static string K_PLAYTEST_NAME = "Playtest";

        /// <summary>
        /// This class contains constants related to production environments.
        /// </summary>
        public static string K_PRODUCTION_NAME = "Prod";

        /// <summary>
        /// Represents the name of the post-production phase.
        /// </summary>
        public static string K_POSTPRODUCTION_NAME = "Postprod";

        /// <summary>
        /// Represents the standard separator used for text CSV protection and unprotection.
        /// </summary>
        public static string kStandardSeparator = "|";

        /// <summary>
        /// Substitute for the standard separator used in CSV text processing.
        /// </summary>
        public static string kStandardSeparatorSubstitute = "@0#";

        /// <summary>
        /// Represents a string constant indicating "none".
        /// </summary>
        public static string kFieldNone = "none";

        /// <summary>
        /// Empty field constant value.
        /// </summary>
        public static string kFieldEmpty = "empty";

        /// <summary>
        /// Represents the constant value for a non-empty field.
        /// </summary>
        public static string kFieldNotEmpty = "not empty";

        /// <summary>
        /// The character used as a field separator A.
        /// </summary>
        public static char kFieldSeparatorA_char = '•';

        /// <summary>
        /// This variable represents the field separator B character.
        /// </summary>
        public static char kFieldSeparatorB_char = ':';

        /// <summary>
        /// Constant representing the field separator character '_'.
        /// </summary>
        public static char kFieldSeparatorC_char = '_';

        /// <summary>
        /// The character used as field separator D.
        /// </summary>
        public static char kFieldSeparatorD_char = '∆';

        /// <summary>
        /// Constant representing the character field separator E.
        /// </summary>
        public static char kFieldSeparatorE_char = '∂';

        /// <summary>
        /// Represents the character used as the field separator F.
        /// </summary>
        public static char kFieldSeparatorF_char = ';';

        /// <summary>
        /// The field separator A.
        /// </summary>
        public static string kFieldSeparatorA = string.Empty + kFieldSeparatorA_char;

        /// <summary>
        /// Represents the field separator B character used in string manipulation.
        /// </summary>
        public static string kFieldSeparatorB = string.Empty + kFieldSeparatorB_char;

        /// <summary>
        /// Constants class for Field Separator Characters.
        /// </summary>
        public static string kFieldSeparatorC = string.Empty + kFieldSeparatorC_char;

        /// <summary>
        /// Represents the field separator D used in the Game-Data-Forge framework.
        /// </summary>
        /// <remarks>
        /// This field separator is used to separate multiple values within a single string field.
        /// It has the Unicode character '∆' (U+2206) and is added as a string representation in the constant variable <see cref="GDFConstants.kFieldSeparatorD"/>.
        /// </remarks>
        public static string kFieldSeparatorD = string.Empty + kFieldSeparatorD_char;

        /// <summary>
        /// The field separator E character used in string manipulation.
        /// </summary>
        public static string kFieldSeparatorE = string.Empty + kFieldSeparatorE_char;

        /// <summary>
        /// Field separator F used in various string manipulation operations.
        /// </summary>
        public static string kFieldSeparatorF = string.Empty + kFieldSeparatorF_char;

        /// <summary>
        /// Substitute string used to replace instances of <see cref="GDFConstants.kFieldSeparatorA"/>
        /// when cleaning and protecting strings.
        /// </summary>
        public static string kFieldSeparatorASubstitute = "@1#";

        /// <summary>
        /// Represents the substitute string for the second field separator in a text that needs to be cleaned.
        /// </summary>
        public static string kFieldSeparatorBSubstitute = "@2#";

        public static string kFieldSeparatorCSubstitute = "@3#";

        /// <summary>
        /// Represents the substitute string for the field separator D.
        /// </summary>
        public static string kFieldSeparatorDSubstitute = "@4#";

        /// <summary>
        /// A substitute for the field separator character '∂'.
        /// </summary>
        public static string kFieldSeparatorESubstitute = "@5#";

        /// <summary>
        /// The constant key for the valid salt preference.
        /// </summary>
        public static string kPrefSaltValidKey = "SaltValid";

        /// <summary>
        /// Represents the key used to store the salt value A in the preferences.
        /// </summary>
        public static string kPrefSaltAKey = "SaltA";

        /// <summary>
        /// Represents the key for the 'SaltB' preference salt value.
        /// </summary>
        public static string kPrefSaltBKey = "SaltB";

        public const int K_STORAGE_SYNC_LIMIT = 30;

        public const int K_STORAGE_BLOCK_SIZE_LENGTH = 2048;
        
        public const int K_DEVICE_IDENTIFIER_LENGTH_MIN = 32;
        public const int K_O_AUTH_ACCESS_TOKEN_LENGTH_MIN = 12;
        public const int K_PASSWORD_LENGTH_MIN = 12;
        public const int K_PASSWORD_LENGTH_MAX = 128;
        public const int K_EMAIL_LENGTH_MIN = 6;
        public const int K_EMAIL_LENGTH_MAX = 128;
        public const int K_LOGIN_LENGTH_MIN = 6;
        public const int K_LOGIN_LENGTH_MAX = 128;
        public const int K_CHANNEL_MIN = 0;
        public const int K_CHANNEL_MAX = 99;
        
        
        public const string K_PASSWORD_EREG_PATTERN = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9\s]).+$";
        public const string K_PASSWORD_REQUIRE = "one uppercase, one lowercase, one number and one special (not a letter, number or space)";
        public const string K_EMAIL_EREG_PATTERN = @"^(?!.*\.\.)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public const string K_UNICITY_EXCEPTION_CATEGORY = "UNY";
        public const string K_ACCOUNT_EXCEPTION_CATEGORY = "ACC";
        public const string K_SIGN_EXCEPTION_CATEGORY = "SIG";
        public const string K_CONSENT_EXCEPTION_CATEGORY = "CSN";
        public const string K_SERVICE_EXCEPTION_CATEGORY = "SRV";
        public const string K_TOKEN_EXCEPTION_CATEGORY = "TKN";
        public const string K_PROJECT_EXCEPTION_CATEGORY = "PRJ";
        public const string K_DASHBOARD_EXCEPTION_CATEGORY = "DSH";
        public const string K_SYNC_EXCEPTION_CATEGORY = "SYC";

        public const int K_UNICITY_EXCEPTION_INDEX = 10000;
        public const int K_ACCOUNT_EXCEPTION_INDEX = 21000;
        public const int K_SIGN_EXCEPTION_INDEX = 22000;
        public const int K_CONSENT_EXCEPTION_INDEX = 23000;
        public const int K_SERVICE_EXCEPTION_INDEX = 24000;
        public const int K_TOKEN_EXCEPTION_INDEX = 25000;
        public const int K_PROJECT_EXCEPTION_INDEX = 30000;
        public const int K_DASHBOARD_EXCEPTION_INDEX = 40000;
        public const int K_SYNC_EXCEPTION_INDEX = 90000;
    }
}