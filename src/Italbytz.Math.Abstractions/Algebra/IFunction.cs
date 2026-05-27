namespace Italbytz.Math.Abstractions.Algebra;

/// <summary>
/// A real-valued function of one variable.
/// </summary>
public interface IFunction
{
    /// <summary>Evaluates the function at <paramref name="x"/>.</summary>
    double Evaluate(double x);

    /// <summary>Human-readable representation, e.g. "2x² − 3x + 1".</summary>
    string Label { get; }
}
