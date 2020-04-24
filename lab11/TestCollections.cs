using States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace lab11
{
    public class TestCollections
    {
        static private Republic[] republics = 
        {
            new Republic("USA", "Washington", "N. America", 9.5, 329, "Donald John Trump", 541),
            new Republic("Russia", "Moscow", "Eurasia", 17.1, 148, "V.V. Putin", 620),
            new Republic("Switzerland", "Berne", "Eurasia", 0.041, 9, "Simonetta Sommaruga", 246),
            new Republic("Mexico", "Mexico", "S. America", 1.9, 133, "Andres Manuel Lopez Obrador", 628),
        };
        /*static private State[] otherStates =
        {
            new Monarchy("Great Britian", "London", "Eurasia", 0.24, 66, "Elizabeth II", "protestantism"),
            new Monarchy("Danmark", "Copenhagen", "Eurasia", 0.043, 6, "Margrethe II", "lutheranism"),
            new Monarchy("Morocco", "Rabat", "Africa", 0.71, 34, "Muhammad VI", "islam"),
            new Kingdom("Aflines", "Droria", "Eurasia", 0.05, 3, "Guernot", "Ioneda"),
            new Kingdom("Pudrihan", "Midon", "Africa", 0.6, 5, "Acnay", "Ibby")
        };*/

        private LinkedList<State> collection00 = new LinkedList<State>();
        private LinkedList<string> collection01 = new LinkedList<string>();
        private SortedDictionary<State, Republic> collection10 = new SortedDictionary<State, Republic>();
        private SortedDictionary<string, Republic> collection11 = new SortedDictionary<string, Republic>();

        public TestCollections(int count)
        {
            if (count < 5)
            {
                throw new Exception("Очень мало элементов для создания коллекций.");
            }
            else
            {
                Republic main = republics[new Random().Next(republics.Length)];
                Republic current = (Republic)main.Clone();
                for (int i = 0; i < count; i++)
                {
                    current.Title = main.Title + i.ToString();
                    Collection00AddLast(current.BaseState());
                    Collection01AddLast(current.Title);
                    Collection10Add((Republic)current.Clone());
                    Collection11Add((Republic)current.Clone());
                }
            }
        }

        public State Collection00First
        {
            get { return collection00.First.Value; }
        }

        public State Collection00Middle
        {
            get
            {
                int i = 0;
                foreach(State state in collection00)
                {
                    if (i++ == collection00.Count / 2) return state;
                }
                return null;
            }
        }

        public State Collection00Last
        {
            get { return collection00.Last.Value; }
        }

        public string Collection01First
        {
            get { return collection01.First.Value; }
        }

        public string Collection01Middle
        {
            get
            {
                int i = 0;
                foreach (string state in collection01)
                {
                    if (i++ == collection01.Count / 2) return state;
                }
                return null;
            }
        }

        public string Collection01Last
        {
            get { return collection01.Last.Value; }
        }

        public KeyValuePair<State, Republic> Collection10First
        {
            get
            {
                foreach(KeyValuePair<State, Republic> state in collection10)
                {
                    return state;
                }
                return new KeyValuePair<State, Republic>(null, null);
            }
        }

        public KeyValuePair<State, Republic> Collection10Middle
        {
            get
            {
                int i = 0;
                foreach (KeyValuePair<State, Republic> state in collection10)
                {
                    if (i++ == collection10.Count / 2) return state;
                }
                return new KeyValuePair<State, Republic>(null, null);
            }
        }

        public KeyValuePair<State, Republic> Collection10Last
        {
            get
            {
                foreach (KeyValuePair<State, Republic> state in collection10.Reverse())
                {
                    return state;
                }
                return new KeyValuePair<State, Republic>(null, null);
            }
        }

        public KeyValuePair<string, Republic> Collection11First
        {
            get
            {
                foreach (KeyValuePair<string, Republic> state in collection11)
                {
                    return state;
                }
                return new KeyValuePair<string, Republic>(null, null);
            }
        }

        public KeyValuePair<string, Republic> Collection11Middle
        {
            get
            {
                int i = 0;
                foreach (KeyValuePair<string, Republic> state in collection11)
                {
                    if (i++ == collection11.Count / 2) return state;
                }
                return new KeyValuePair<string, Republic>(null, null);
            }
        }

        public KeyValuePair<string, Republic> Collection11Last
        {
            get
            {
                foreach (KeyValuePair<string, Republic> state in collection11.Reverse())
                {
                    return state;
                }
                return new KeyValuePair<string, Republic>(null, null);
            }
        }

        public Republic NotIncluded
        {
            get { return republics[new Random().Next(republics.Length)]; }
        }

        public bool Collection00Contains(State state, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool result = collection00.Contains(state.Clone());
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }

        public bool Collection01Contains(string state, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool result = collection01.Contains(state);
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }

        public bool Collection10ContainsKey(State state, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool result = collection10.ContainsKey((State)state.Clone());
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }

        public bool Collection10ContainsValue(Republic republic, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool result = collection10.ContainsValue((Republic)republic.Clone());
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }

        public bool Collection11ContainsKey(string state, out long ticks)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool result = collection11.ContainsKey(state);
            sw.Stop();
            ticks = sw.ElapsedTicks;
            return result;
        }

        public void Collection00AddLast(State newState)
        {
            collection00.AddLast(newState);
        }

        public bool Collection00RemoveLast()
        {
            try
            {
                collection00.RemoveLast();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public void Collection01AddLast(string newString)
        {
            collection01.AddLast(newString);
        }

        public bool Collection01RemoveLast()
        {
            try
            {
                collection01.RemoveLast();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public bool Collection10Add(Republic republic)
        {
            try
            {
                collection10.Add(republic.BaseState(), republic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Collection10Remove(State key)
        {
            try
            {
                collection10.Remove(key);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Collection11Add(Republic republic)
        {
            try
            {
                collection11.Add(republic.Title, republic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Collection11Remove(string key)
        {
            try
            {
                collection11.Remove(key);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
