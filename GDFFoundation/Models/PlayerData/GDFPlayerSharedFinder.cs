using System;



namespace GDFFoundation
{
    /// <summary>
    /// GDFPlayerSharedRequest is an abstract class that represents a shared request made by a player in a game.
    /// It extends the GDFPlayerData class.
    /// </summary>
    [Serializable]
    public abstract class GDFPlayerSharedRequest : GDFPlayerData
    {
    }

    /// <summary>
    /// The GDFPlayerSharedProposal class represents a proposal made by a player in a game.
    /// It is an abstract class that extends the GDFPlayerData class.
    /// </summary>
    [Serializable]
    public abstract class GDFPlayerSharedProposal : GDFPlayerData
    {
    }

    /// <summary>
    /// Provides a base class for shared finder classes that are used to search for player data in a game.
    /// </summary>
    /// <typeparam name="TR">The type of the shared request.</typeparam>
    /// <typeparam name="TP">The type of the shared proposal.</typeparam>
    /// <remarks>
    /// This class is an abstract class. Any shared finder class that inherits from this class must provide implementation for the abstract methods defined here.
    /// </remarks>
    [Serializable]
    public abstract class GDFPlayerSharedFinder<TR, TP> : GDFPlayerData where TR : GDFPlayerSharedRequest where TP : GDFPlayerSharedProposal
    {
    }
}

