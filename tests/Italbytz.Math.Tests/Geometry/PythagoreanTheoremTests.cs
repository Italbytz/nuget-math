using Italbytz.Math.Geometry;

namespace Italbytz.Math.Tests.Geometry
{
    [TestClass]
    public class PythagoreanTheoremTests
    {
        [TestMethod]
        public void FromLegs_3_4_GivesHypotenuse5()
        {
            var t = RightTriangle.FromLegs(3, 4);
            Assert.AreEqual(5.0, t.C, 1e-9);
        }

        [TestMethod]
        public void FromLegs_5_12_GivesHypotenuse13()
        {
            var t = RightTriangle.FromLegs(5, 12);
            Assert.AreEqual(13.0, t.C, 1e-9);
        }

        [TestMethod]
        public void Verify_TrueFor3_4_5()
        {
            var t = new RightTriangle(3, 4, 5);
            Assert.IsTrue(t.Verify());
        }

        [TestMethod]
        public void Verify_TrueFor5_12_13()
        {
            var t = new RightTriangle(5, 12, 13);
            Assert.IsTrue(t.Verify());
        }

        [TestMethod]
        public void Verify_FalseFor3_4_6()
        {
            var t = new RightTriangle(3, 4, 6);
            Assert.IsFalse(t.Verify());
        }

        [TestMethod]
        public void FromLegAndHypotenuse_5_13_GivesSecondLeg12()
        {
            var t = RightTriangle.FromLegAndHypotenuse(leg: 5, hypotenuse: 13);
            Assert.AreEqual(12.0, t.B, 1e-9);
        }

        [TestMethod]
        public void FromLegAndHypotenuse_LegIsB_GivesCorrectA()
        {
            var t = RightTriangle.FromLegAndHypotenuse(leg: 12, hypotenuse: 13, legIsA: false);
            Assert.AreEqual(5.0, t.A, 1e-9);
        }
    }
}
