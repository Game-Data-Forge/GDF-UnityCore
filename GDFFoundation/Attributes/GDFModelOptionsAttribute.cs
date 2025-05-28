#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFModelOptionsAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

// using System;
//
// namespace GDFFoundation
// {
//     /// <summary>
//     /// The GDFModelOptionsAttribute class is an attribute used to specify options for a model in GDF.
//     /// </summary>
//     [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
//     public class GDFModelOptionsAttribute : Attribute
//     {
//         /// <summary>
//         /// Represents the value of the None constant in the GDFModelOptionsAttribute class.
//         /// </summary>
//         public const string None = "";
//
//         /// The Mandatory variable is a constant string that represents a model option's module.
//         /// Usage:
//         /// GDFModelOptionsAttribute attribute = new GDFModelOptionsAttribute(Mandatory);
//         /// string module = attribute.Module; // returns "Mandatory"
//         /// Remarks:
//         /// - The Mandatory variable is defined in the GDFModelOptionsAttribute class.
//         /// - It is a public constant string with the value "Mandatory".
//         /// - It is used to indicate that a model option belongs to the "Mandatory" module.
//         /// - The module name is used to categorize and organize model options.
//         /// - The module name can be accessed through the Module property of the GDFModelOptionsAttribute class.
//         /// - The Module property is set to "Mandatory" if the module is specified as "Mandatory".
//         /// /
//         public const string Mandatory = "Mandatory";
//
//         /// <summary>
//         /// Represents a module in the GDF system.
//         /// </summary>
//         public string Module = None;
//
//         /// <summary>
//         /// Attribute for specifying options for a model class.
//         /// </summary>
//         public bool Default = true;
//
//         /// <summary>
//         /// The name of the menu associated with the model.
//         /// </summary>
//         public string MenuName = string.Empty;
//
//         /// <summary>
//         /// Represents an attribute used to specify options for a model class.
//         /// </summary>
//         public string Description = string.Empty;
//
//         /// <summary>
//         /// Represents an attribute that defines the options for an editable model.
//         /// </summary>
//         /// <seealso cref="System.Attribute" />
//         public bool Editable = true;
//
//         /// <summary>
//         /// Attribute used to specify options for a model class.
//         /// </summary>
//         public GDFModelOptionsAttribute(string sModule, string sMenuName, string sDescription, bool sDefaultActive = true, bool sEditable = false)
//         {
//             this.Module = sModule;
//             this.Description = sDescription;
//             this.MenuName = sMenuName;
//             this.Default = sDefaultActive;
//             this.Editable = sEditable;
//         }
//
//         /// <summary>
//         /// The GDFModelOptionsAttribute class is an attribute used to specify options for a model in GDF.
//         /// </summary>
//         public GDFModelOptionsAttribute(string sMenuName, string sDescription, bool sDefaultActive = true, bool sEditable = false)
//         {
//             this.Module = None;
//             this.Description = sDescription;
//             this.MenuName = sMenuName;
//             this.Default = sDefaultActive;
//             this.Editable = sEditable;
//         }
//
//         /// <summary>
//         /// Represents an attribute used to specify options for a GDF model class.
//         /// </summary>
//         /// <remarks>
//         /// The <see cref="GDFModelOptionsAttribute"/> can be applied to a class to specify various options for the GDF model.
//         /// </remarks>
//         public GDFModelOptionsAttribute(bool sDefaultActive = true)
//         {
//             this.Module = None;
//             this.Default = sDefaultActive;
//         }
//     }
// }
