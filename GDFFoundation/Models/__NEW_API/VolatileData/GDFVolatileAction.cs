#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVolatileAction.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using GDFFoundation;

#endregion

namespace GDFStandardModels
{
    /// <summary>
    ///     This class represents a volatile action in a specific scene of a game.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileAction : GDFVolatileData
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a volatile action in the system.
        /// </summary>
        public string ActionFor { set; get; } = string.Empty;

        /// <summary>
        ///     Represents a volatile action in a scene.
        /// </summary>
        public string Scene { set; get; } = string.Empty;

        /// <summary>
        ///     The X-coordinate of the screen position.
        /// </summary>
        public float ScreenPositionX { set; get; } = 0;

        /// <summary>
        ///     The Y position of the screen where the action occurs.
        /// </summary>
        /// <remarks>
        ///     The ScreenPositionY property represents the vertical position of the screen where the action occurs.
        /// </remarks>
        public float ScreenPositionY { set; get; } = 0;

        /// <summary>
        ///     Represents the X coordinate of the screen position.
        /// </summary>
        public float ScreenX { set; get; } = 0;

        /// <summary>
        ///     Represents the Y coordinate of the screen position.
        /// </summary>
        public float ScreenY { set; get; } = 0;

        /// <summary>
        ///     The X coordinate of the world position.
        /// </summary>
        public float WorldPositionX { set; get; } = 0;

        /// <summary>
        ///     Gets or sets the Y world position of the volatile action.
        /// </summary>
        public float WorldPositionY { set; get; } = 0;

        /// <summary>
        ///     The Z-coordinate of the world position.
        /// </summary>
        public float WorldPositionZ { set; get; } = 0;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     The GDFVolatileAction class represents a volatile action in a specific scene for a specific target.
        /// </summary>
        public GDFVolatileAction()
            : base()
        {
        }

        /// <summary>
        ///     The GDFVolatileAction class represents a volatile action in a specific scene.
        /// </summary>
        public GDFVolatileAction(
            IGDFVolatileAgent sVolatileManager,
            string sCategory,
            string sScene,
            string sActionFor,
            GDFVector2 sScreen,
            GDFVector2 sScreenPosition,
            GDFVector3 sWorldPosition,
            string sInformation
        )
            : base(sVolatileManager, sCategory, sInformation)
        {
            Scene = sScene;
            ActionFor = sActionFor;

            ScreenX = sScreen.X;
            ScreenY = sScreen.Y;

            ScreenPositionX = sScreenPosition.X;
            ScreenPositionY = sScreenPosition.Y;

            WorldPositionX = sWorldPosition.X;
            WorldPositionY = sWorldPosition.Y;
            WorldPositionZ = sWorldPosition.Z;
        }

        /// <summary>
        ///     Represents a volatile action in an application.
        /// </summary>
        public GDFVolatileAction(
            IGDFVolatileAgent sVolatileManager,
            Enum sCategory,
            string sScene,
            string sActionFor,
            GDFVector2 sScreen,
            GDFVector2 sScreenPosition,
            GDFVector3 sWorldPosition,
            string sInformation
        )
            : base(sVolatileManager, sCategory, sInformation)
        {
            Scene = sScene;
            ActionFor = sActionFor;

            ScreenX = sScreen.X;
            ScreenY = sScreen.Y;

            ScreenPositionX = sScreenPosition.X;
            ScreenPositionY = sScreenPosition.Y;

            WorldPositionX = sWorldPosition.X;
            WorldPositionY = sWorldPosition.Y;
            WorldPositionZ = sWorldPosition.Z;
        }

        #endregion
    }
}