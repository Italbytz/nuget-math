using Italbytz.Math.Abstractions.Algebra;

namespace Italbytz.Math.Algebra;

/// <summary>
/// A polynomial p(x) = c₀ + c₁·x + c₂·x² + … + cₙ·xⁿ.
/// Coefficients are given in ascending order: index 0 = constant term.
/// </summary>
public sealed class Polynomial : IFunction
{
    private readonly double[] _coefficients;

    /// <param name="coefficients">
    /// Coefficients in ascending degree order.
    /// E.g. <c>new Polynomial(1, -3, 2)</c> represents 2x² − 3x + 1.
    /// </param>
    public Polynomial(params double[] coefficients)
    {
        if (coefficients is null || coefficients.Length == 0)
            throw new ArgumentException("At least one coefficient required.", nameof(coefficients));
        _coefficients = coefficients;
    }

    /// <inheritdoc/>
    public double Evaluate(double x)
    {
        double result = 0;
        double power  = 1;
        foreach (double c in _coefficients)
        {
            result += c * power;
            power  *= x;
        }
        return result;
    }

    /// <summary>Degree of the polynomial.</summary>
    public int Degree => _coefficients.Length - 1;

    /// <summary>Coefficient at degree <paramref name="n"/> (0 = constant term).</summary>
    public double this[int n] => n < _coefficients.Length ? _coefficients[n] : 0.0;

    /// <inheritdoc/>
    public string Label => BuildLabel();

    private string BuildLabel()
    {
        var terms = new List<string>();
        for (int i = _coefficients.Length - 1; i >= 0; i--)
        {
            double c = _coefficients[i];
            if (c == 0) continue;

            string coeff = i == _coefficients.Length - 1
                ? FormatLeadingCoeff(c, i)
                : FormatCoeff(c, i);
            terms.Add(coeff);
        }
        return terms.Count == 0 ? "0" : string.Join(" ", terms);
    }

    private static string FormatLeadingCoeff(double c, int degree)
    {
        string cStr = c == 1 && degree > 0 ? "" : c == -1 && degree > 0 ? "−" : FormatNum(c);
        return cStr + VarPart(degree);
    }

    private static string FormatCoeff(double c, int degree)
    {
        string sign = c > 0 ? "+ " : "− ";
        double abs  = global::System.Math.Abs(c);
        string cStr = abs == 1 && degree > 0 ? "" : FormatNum(abs);
        return sign + cStr + VarPart(degree);
    }

    private static string VarPart(int degree) => degree switch
    {
        0 => "",
        1 => "x",
        2 => "x²",
        3 => "x³",
        4 => "x⁴",
        _ => $"x^{degree}"
    };

    private static string FormatNum(double v) =>
        v == global::System.Math.Floor(v) ? ((long)v).ToString() : v.ToString("G4");
}
