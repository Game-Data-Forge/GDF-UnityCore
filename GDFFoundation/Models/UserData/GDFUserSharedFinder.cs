﻿using System;



namespace GDFFoundation
{
    /// <summary>
    /// Represents a shared request made by a user in the GDF system.
    /// </summary>
    [Serializable]
    public abstract class GDFUserSharedRequest : GDFUserData
    {
    }

    /// <summary>
    /// Represents a user shared proposal in the GDF system.
    /// </summary>
    /// <remarks>
    /// This class is derived from the <see cref="GDFUserData"/> class and is used for creating shared proposals.
    /// </remarks>
    [Serializable]
    public abstract class GDFUserSharedProposal : GDFUserData
    {
    }

    /// <summary>
    /// Abstract class representing a user shared finder in the GDF system.
    /// </summary>
    /// <typeparam name="TR">The type of user shared request this finder is associated with.</typeparam>
    /// <typeparam name="TP">The type of user shared proposal this finder is associated with.</typeparam>
    [Serializable]
    public abstract class GDFUserSharedFinder<TR, TP> : GDFUserData where TR : GDFUserSharedRequest where TP : GDFUserSharedProposal
    {
    }
}

