using Italbytz.Math.Abstractions.Geometry;

namespace Italbytz.Math.Geometry
{
    public class RightTriangle : IRightTriangle
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public RightTriangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static RightTriangle FromLegs(double a, double b)
            => new RightTriangle(a, b, global::System.Math.Sqrt(a * a + b * b));

        public static RightTriangle FromLegAndHypotenuse(double leg, double hypotenuse, bool legIsA = true)
        {
            double other = global::System.Math.Sqrt(hypotenuse * hypotenuse - leg * leg);
            return legIsA
                ? new RightTriangle(leg, other, hypotenuse)
                : new RightTriangle(other, leg, hypotenuse);
        }

        public bool Verify()
        {
            const double epsilon = 1e-9;
            return global::System.Math.Abs(A * A + B * B - C * C) < epsilon;
        }
    }
}
