#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDownPayload.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     GDFDownPayload class represents the payload object for the down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayload
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a list of GDFAccountService objects.
        /// </summary>
        public List<GDFAccountService> AccountServiceList { set; get; } = new List<GDFAccountService>();

        #endregion
    }
}