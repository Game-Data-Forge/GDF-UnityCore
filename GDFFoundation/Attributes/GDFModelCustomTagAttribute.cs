// using System;
//
// namespace GDFFoundation
// {
//     /// <summary>
//     /// Attribute used to define a custom tag for a specific class.
//     /// </summary>
//     [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
//     public class GDFModelCustomTagAttribute : Attribute
//     {
//         /// <summary>
//         /// Attribute class to define a custom tag for an GDFModelType class.
//         /// </summary>
//         public string EnumName;
//
//         /// <summary>
//         /// Attribute used to define a custom tag for a model class.
//         /// </summary>
//         public GDFModelCustomTagAttribute(string sEnumName)
//         {
//             this.EnumName = sEnumName;
//         }
//
//         /// <summary>
//         /// Attribute to specify a custom tag for a class that is an GDF Model.
//         /// </summary>
//         public GDFModelCustomTagAttribute(Type sEnum)
//         {
//             this.EnumName = sEnum.Name;
//         }
//     }
// }
