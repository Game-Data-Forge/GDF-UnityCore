using GDFFoundation;
using UnityEngine;

namespace GDFUnity
{
    static public class SystemLanguageExtension
    {
        static public GDFLanguageEnum? ToLanguageEnum(this SystemLanguage systemLanguage)
        {
            switch (systemLanguage)
            {
                // case SystemLanguage.Afrikaans:
                case SystemLanguage.Arabic:
                    return GDFLanguageEnum.Arabic;
                // case SystemLanguage.Basque:
                // case SystemLanguage.Belarusian:
                // case SystemLanguage.Bulgarian:
                case SystemLanguage.Catalan:
                    return GDFLanguageEnum.Catalan;
                case SystemLanguage.Chinese:
                    return GDFLanguageEnum.Chinese_Simplified;
                case SystemLanguage.Czech:
                    return GDFLanguageEnum.Czech;
                case SystemLanguage.Danish:
                    return GDFLanguageEnum.Danish;
                case SystemLanguage.Dutch:
                    return GDFLanguageEnum.Dutch;
                case SystemLanguage.English:
                    return GDFLanguageEnum.English;
                // case SystemLanguage.Estonian:
                // case SystemLanguage.Faroese:
                case SystemLanguage.Finnish:
                    return GDFLanguageEnum.Finnish;
                case SystemLanguage.French:
                    return GDFLanguageEnum.French;
                case SystemLanguage.German:
                    return GDFLanguageEnum.German;
                case SystemLanguage.Greek:
                    return GDFLanguageEnum.Greek;
                case SystemLanguage.Hebrew:
                    return GDFLanguageEnum.Hebrew;
                case SystemLanguage.Hindi:
                    return GDFLanguageEnum.Hindi;
                case SystemLanguage.Hungarian:
                    return GDFLanguageEnum.Hungarian;
                // case SystemLanguage.Icelandic:
                case SystemLanguage.Indonesian:
                    return GDFLanguageEnum.Indonesian;
                case SystemLanguage.Italian:
                    return GDFLanguageEnum.Italian;
                case SystemLanguage.Japanese:
                    return GDFLanguageEnum.Japanese;
                case SystemLanguage.Korean:
                    return GDFLanguageEnum.Korean;
                // case SystemLanguage.Latvian:
                // case SystemLanguage.Lithuanian:
                case SystemLanguage.Norwegian:
                    return GDFLanguageEnum.Norwegian;
                case SystemLanguage.Polish:
                    return GDFLanguageEnum.Polish;
                case SystemLanguage.Portuguese:
                    return GDFLanguageEnum.Portuguese;
                case SystemLanguage.Romanian:
                    return GDFLanguageEnum.Romanian;
                case SystemLanguage.Russian:
                    return GDFLanguageEnum.Russian;
                // case SystemLanguage.SerboCroatian:
                case SystemLanguage.Slovak:
                    return GDFLanguageEnum.Slovak;
                // case SystemLanguage.Slovenian:
                case SystemLanguage.Spanish:
                    return GDFLanguageEnum.Spanish;
                case SystemLanguage.Swedish:
                    return GDFLanguageEnum.Swedish;
                case SystemLanguage.Thai:
                    return GDFLanguageEnum.Thai;
                case SystemLanguage.Turkish:
                    return GDFLanguageEnum.Turkish;
                case SystemLanguage.Ukrainian:
                    return GDFLanguageEnum.Ukrainian;
                case SystemLanguage.Vietnamese:
                    return GDFLanguageEnum.Vietnamese;

                default:
                return null;
            }
        }
    }
}