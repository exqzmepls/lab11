using Microsoft.VisualStudio.TestTools.UnitTesting;
using States;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestRepublic
    {
        [TestMethod]
        public void TestDesigner()
        {
            Republic r1 = new Republic();
            Republic r2 = new Republic("", "", "", 0, 0, "", 0);
            Assert.AreEqual(r1, r2);
        }
        [TestMethod]
        public void TestClone()
        {
            Republic r = new Republic("USA", "Washington", "N. America", 9.5, 329, "Donald John Trump", 541);
            object rClone = r.Clone();
            Assert.AreEqual(r, (Republic)rClone);
        }
        [TestMethod]
        public void TestPresident()
        {
            Republic r = new Republic();
            r.President = "president";
            string president = "president";
            Assert.AreEqual(r.President, president);
        }
        [TestMethod]
        public void TestParlamentSize()
        {
            Republic r = new Republic();
            r.ParlamentSize = 100;
            int parlamentSize = 100;
            Assert.AreEqual(r.ParlamentSize, parlamentSize);
        }
        [TestMethod]
        public void TestParlamentSizeBellowZero()
        {
            Republic r = new Republic();
            r.ParlamentSize = -100;
            int parlamentSize = 0;
            Assert.AreEqual(r.ParlamentSize, parlamentSize);
        }
        [TestMethod]
        public void TestPopulationMoreThan()
        {
            Republic[] states = { new Republic("Russia", "Moscow", "Eurasia", 17.1, 148, "V.V. Putin", 620),
                new Republic("Switzerland", "Berne", "Eurasia", 0.041, 9, "Simonetta Sommaruga", 246)};
            Republic[] bigRepublics = Republic.PopulationMoreThan(states, 100);
            Assert.AreEqual(bigRepublics[0], states[0]);
        }
        [TestMethod]
        public void TestEquals1()
        {
            Republic r = new Republic();
            Monarchy m = new Monarchy();
            Assert.AreEqual(r.Equals(m), false);
        }
        [TestMethod]
        public void TestEquals2()
        {
            Republic r = new Republic();
            object o = new object();
            Assert.AreEqual(r.Equals(o), false);
        }
        [TestMethod]
        public void TestBaseState()
        {
            Republic r = new Republic("Russia", "Moscow", "Eurasia", 17.1, 148, "V.V. Putin", 620);
            State s = new State("Russia", "Moscow", "Eurasia", 17.1, 148);
            Assert.AreEqual(r.BaseState().Equals(s), true);
        }
    }
}