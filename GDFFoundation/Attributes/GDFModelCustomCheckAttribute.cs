#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFModelCustomCheckAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

// using System;
//
// namespace GDFFoundation
// {
//     /// <summary>
//     /// Custom attribute used to define custom checks for a model class.
//     /// </summary>
//     [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
//     public class GDFModelCustomCheckAttribute : Attribute
//     {
//         public string FlagsName;
//
//         /// <summary>
//         /// Represents an attribute that is used to specify a custom check for an GDF model class.
//         /// </summary>
//         /// <remarks>
//         /// The <see cref="GDFModelCustomCheckAttribute"/> class is an attribute that can be applied to an GDF model class to define a custom check.
//         /// It allows you to specify the name of the flag that should be evaluated to determine if the check passes or fails.
//         /// </remarks>
//         public GDFModelCustomCheckAttribute(string sFlagsName)
//         {
//             this.FlagsName = sFlagsName;
//         }
//
//         /// <summary>
//         /// Represents an attribute that can be applied to a class to specify a custom check for a model.
//         /// </summary>
//         /// <remarks>
//         /// This attribute is used to mark a class as a custom check for a model. It should be applied to the class
//         /// that contains the logic for performing the custom check. The FlagsName property should be set to the
//         /// name of the flags property in the model class that indicates whether the custom check should be
//         /// performed.
//         /// </remarks>
//         public GDFModelCustomCheckAttribute(Type sFlags)
//         {
//             this.FlagsName = sFlags.Name;
//         }
//     }
// }
