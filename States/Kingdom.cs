using System;

namespace States
{
    public class Kingdom: State
    {
        public Kingdom() : base()
        {
            King = "";
            Queen = "";
        }
        public Kingdom(string title, string capital, string continent, double area, int population, string king, string queen) : base(title, capital, continent, area, population)
        {
            King = king;
            Queen = queen;
        }
        public string King { get; set; }
        public string Queen { get; set; }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("King - " + King);
            Console.WriteLine("Queen - " + Queen);
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Kingdom k = obj as Kingdom;
                if (k == null) return false;
                return k.King == King && k.Queen == Queen;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + King.GetHashCode() + Queen.GetHashCode();
        }
        static public Kingdom[] OnContinent(State[] states, string continent)
        {
            Kingdom[] result = new Kingdom[0];
            foreach (State s in states) if (s is Kingdom && s.Continent.ToUpper() == continent.ToUpper())
                {
                    Kingdom k = s as Kingdom;
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = (Kingdom)k.Clone();
                }
            return result;
        }
        public override object Clone()
        {
            return new Kingdom(Title, Capital, Continent, Area, Population, King, Queen);
        }

        public State BaseState()
        {
            return new State(Title, Capital, Continent, Area, Population);
        }
    }
}
