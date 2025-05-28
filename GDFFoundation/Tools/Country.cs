﻿#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj Country.cs create at 2025/05/12 10:05:34
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace GDFFoundation
{
    static public class CountryTool
    {
        #region Static fields and properties

        static public readonly Dictionary<Country, string> COUNTRIES;

        #endregion

        #region Static methods


        #endregion

        #region Instance constructors and destructors

        static CountryTool()
        {
            COUNTRIES = CountryExtension.cache.Where(x => x.Key != Country.None).ToDictionary(x => x.Key, x => x.Value.name);
        }

        #endregion
    }
}