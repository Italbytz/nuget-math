using Italbytz.Math.Algebra;

namespace Italbytz.Math.Tests.Algebra;

[TestClass]
public sealed class PolynomialTests
{
    [TestMethod]
    public void Evaluate_Constant_ReturnsConstant()
    {
        var p = new Polynomial(5);
        Assert.AreEqual(5.0, p.Evaluate(99));
    }

    [TestMethod]
    public void Evaluate_Linear_2xMinus3()
    {
        var p = new Polynomial(-3, 2); // −3 + 2x
        Assert.AreEqual(-3 + 2 * 4, p.Evaluate(4));
    }

    [TestMethod]
    public void Evaluate_Quadratic_AtRoots()
    {
        // (x−1)(x−3) = x² − 4x + 3  →  coefficients: 3, −4, 1
        var p = new Polynomial(3, -4, 1);
        Assert.AreEqual(0.0, p.Evaluate(1),  1e-10);
        Assert.AreEqual(0.0, p.Evaluate(3),  1e-10);
        Assert.AreEqual(3.0, p.Evaluate(0),  1e-10);
    }

    [TestMethod]
    public void Evaluate_Cubic_KnownValue()
    {
        // x³ − 6x² + 11x − 6  →  roots at 1, 2, 3
        var p = new Polynomial(-6, 11, -6, 1);
        Assert.AreEqual(0.0, p.Evaluate(1), 1e-9);
        Assert.AreEqual(0.0, p.Evaluate(2), 1e-9);
        Assert.AreEqual(0.0, p.Evaluate(3), 1e-9);
    }

    [TestMethod]
    public void Degree_MatchesHighestCoefficient()
    {
        Assert.AreEqual(2, new Polynomial(1, 0, 1).Degree);
        Assert.AreEqual(0, new Polynomial(7).Degree);
    }

    [TestMethod]
    public void Indexer_ReturnsCorrectCoefficient()
    {
        var p = new Polynomial(3, -4, 1);
        Assert.AreEqual(3.0,  p[0]);
        Assert.AreEqual(-4.0, p[1]);
        Assert.AreEqual(1.0,  p[2]);
        Assert.AreEqual(0.0,  p[5]); // out of range → 0
    }

    [TestMethod]
    public void Label_Quadratic_CorrectString()
    {
        var p = new Polynomial(3, -4, 1); // x² − 4x + 3
        Assert.AreEqual("x² − 4x + 3", p.Label);
    }

    [TestMethod]
    public void Label_Linear_CorrectString()
    {
        var p = new Polynomial(-3, 2); // 2x − 3
        Assert.AreEqual("2x − 3", p.Label);
    }
}
