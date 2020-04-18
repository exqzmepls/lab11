using Microsoft.VisualStudio.TestTools.UnitTesting;
using States;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestMonarchy
    {
        [TestMethod]
        public void TestDesigner()
        {
            Monarchy m1 = new Monarchy();
            Monarchy m2 = new Monarchy("", "", "", 0, 0, "", "");
            Assert.AreEqual(m1, m2);
        }
        [TestMethod]
        public void TestClone()
        {
            Monarchy gb = new Monarchy("Great Britian", "London", "Eurasia", 0.24, 66, "Elizabeth II", "protestantism");
            object gbClone = gb.Clone();
            Assert.AreEqual(gb, (Monarchy)gbClone);
        }
        [TestMethod]
        public void TestMonarch()
        {
            Monarchy m = new Monarchy();
            m.Monarch = "monarch";
            string monarch = "monarch";
            Assert.AreEqual(m.Monarch, monarch);
        }
        [TestMethod]
        public void TestMainReligion()
        {
            Monarchy m = new Monarchy();
            m.MainReligion = "religion";
            string religion = "religion";
            Assert.AreEqual(m.MainReligion, religion);
        }
        [TestMethod]
        public void TestAreaLessThan()
        {
            Monarchy[] states = { new Monarchy("Great Britian", "London", "Eurasia", 0.24, 66, "Elizabeth II", "protestantism"),
                new Monarchy("Danmark", "Copenhagen", "Eurasia", 0.043, 6, "Margrethe II", "lutheranism")};
            Monarchy[] smallStates = Monarchy.AreaLessThan(states, 0.1);
            Assert.AreEqual(smallStates[0], states[1]);
        }
        [TestMethod]
        public void TestEquals()
        {
            Monarchy m = new Monarchy();
            Kingdom k = new Kingdom();
            Assert.AreEqual(m.Equals(k), false);
        }
        [TestMethod]
        public void TestBaseState()
        {
            Monarchy m = new Monarchy("Great Britian", "London", "Eurasia", 0.24, 66, "Elizabeth II", "protestantism");
            State s = new State("Great Britian", "London", "Eurasia", 0.24, 66);
            Assert.AreEqual(m.BaseState().Equals(s), true);
        }
    }
}
