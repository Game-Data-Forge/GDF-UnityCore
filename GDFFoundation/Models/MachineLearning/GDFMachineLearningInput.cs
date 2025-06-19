#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFMachineLearningInpout.cs create at 2025/06/16 12:06:04
// ©2024-2025 idéMobi SARL FRANCE

#endregion

using System.Collections.Generic;

// Use ML.NET to use these classes 
namespace GDFFoundation.MachineLearning
{
    public abstract class GDFMachineLearningOutput{}
    public abstract class GDFMachineLearningContext{}
    public abstract class GDFMachineLearningInput{ }
    public interface IGDFMachineLearningGeneric<I, C, O>
        where I : GDFMachineLearningInput
        where C : GDFMachineLearningContext
        where O : GDFMachineLearningOutput
    {
        void Train(IEnumerable<(I, C, O)> dataset);
        O Predict(I input, C context);
    }
}