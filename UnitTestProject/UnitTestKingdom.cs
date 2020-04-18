using Microsoft.VisualStudio.TestTools.UnitTesting;
using States;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestKingdom
    {
        [TestMethod]
        public void TestDesigner()
        {
            Kingdom k1 = new Kingdom();
            Kingdom k2 = new Kingdom("", "", "", 0, 0, "", "");
            Assert.AreEqual(k1, k2);
        }
        [TestMethod]
        public void TestClone()
        {
            Kingdom k = new Kingdom("Aflines", "Droria", "Eurasia", 0.05, 3, "Guernot", "Ioneda");
            object kClone = k.Clone();
            Assert.AreEqual(k, (Kingdom)kClone);
        }
        [TestMethod]
        public void TestKing()
        {
            Kingdom k = new Kingdom();
            k.King = "king";
            string king = "king";
            Assert.AreEqual(k.King, king);
        }
        [TestMethod]
        public void TestQueen()
        {
            Kingdom k = new Kingdom();
            k.Queen = "queen";
            string queen = "queen";
            Assert.AreEqual(k.Queen, queen);
        }
        [TestMethod]
        public void TestOnContinent()
        {
            Kingdom[] states = { new Kingdom("Aflines", "Droria", "Eurasia", 0.05, 3, "Guernot", "Ioneda"),
                new Kingdom("Pudrihan", "Midon", "Africa", 0.6, 5, "Acnay", "Ibby")};
            Kingdom[] africaKingdoms = Kingdom.OnContinent(states, "africa");
            Assert.AreEqual(africaKingdoms[0], states[1]);
        }
        [TestMethod]
        public void TestEquals1()
        {
            Kingdom k = new Kingdom();
            Monarchy m = new Monarchy();
            Assert.AreEqual(k.Equals(m), false);
        }
        [TestMethod]
        public void TestEquals2()
        {
            Kingdom k = new Kingdom();
            object o = new object();
            Assert.AreEqual(k.Equals(o), false);
        }
        [TestMethod]
        public void TestBaseState()
        {
            Kingdom k = new Kingdom("Aflines", "Droria", "Eurasia", 0.05, 3, "Guernot", "Ioneda");
            State s = new State("Aflines", "Droria", "Eurasia", 0.05, 3);
            Assert.AreEqual(k.BaseState().Equals(s), true);
        }
    }
}
