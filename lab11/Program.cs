using System;
using System.Collections;
using System.Collections.Generic;
using States;
using System.Linq;

namespace lab11
{
    class Program
    {
        static State[] allStates =
        {
            new Republic("USA", "Washington", "N. America", 9.5, 329, "Donald John Trump", 541),
            new Republic("Russia", "Moscow", "Eurasia", 17.1, 148, "V.V. Putin", 620),
            new Republic("Switzerland", "Berne", "Eurasia", 0.041, 9, "Simonetta Sommaruga", 246),
            new Republic("Mexico", "Mexico", "S. America", 1.9, 133, "Andres Manuel Lopez Obrador", 628),
            new Monarchy("Great Britian", "London", "Eurasia", 0.24, 66, "Elizabeth II", "protestantism"),
            new Monarchy("Danmark", "Copenhagen", "Eurasia", 0.043, 6, "Margrethe II", "lutheranism"),
            new Monarchy("Morocco", "Rabat", "Africa", 0.71, 34, "Muhammad VI", "islam"),
            new Kingdom("Aflines", "Droria", "Eurasia", 0.05, 3, "Guernot", "Ioneda"),
            new Kingdom("Pudrihan", "Midon", "Africa", 0.6, 5, "Acnay", "Ibby")
        };

        static void PrintMenu(string[] menuItems, int choice, string info)
        {
            Console.Clear();
            Console.Write(info);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == choice) Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static int MenuChoice(string[] menuItems, string info = "")
        {
            Console.CursorVisible = false;
            int choice = 0;
            while (true)
            {
                PrintMenu(menuItems, choice, info);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choice != 0) choice--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choice != menuItems.Length - 1) choice++;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return choice;
                }
            }
        }

        static void PrintCollection(ArrayList collection, string info = "")
        {
            Console.Write(info);
            foreach (object obj in collection)
            {
                Console.WriteLine();
                (obj as State).Print();
            }
        }

        static void PrintCollection(Stack<State> collection, string info = "")
        {
            Console.Write(info);
            foreach (State s in collection)
            {
                Console.WriteLine();
                s.Print();
            }
        }

        static State RandomState()
        {
            State peek = allStates[new Random().Next(allStates.Length)];
            return (State)peek.Clone();
        }

        static int IntInput(int lBound, int uBound, string info = "")
        {
            bool exit;
            int result;
            Console.Write(info);
            do
            {
                exit = int.TryParse(Console.ReadLine(), out result);
                if (!exit) Console.Write("Введено не целое число! Повторите ввод: ");
                else
                {
                    exit = result >= lBound && result < uBound;
                    if (!exit) Console.WriteLine("Элемент с данным индексом отсутствует в коллекции! Повторите ввод: ");
                }
            } while (!exit);
            return result;
        }

        static void Task1()
        {
            Console.WriteLine("Создание коллекции (ArrayList)...");
            // Создание массива, который будет передан в конструктор коллекции
            State[] allStates =
            {
                new Republic("USA", "Washington", "N. America", 9.5, 329, "Donald John Trump", 541),
                new Monarchy("Great Britian", "London", "Eurasia", 0.24, 66, "Elizabeth II", "protestantism"),
                new Kingdom("Aflines", "Droria", "Eurasia", 0.05, 3, "Guernot", "Ioneda")
            };
            ArrayList collection = new ArrayList(allStates);
            Console.WriteLine("Коллекция создана.");
            PrintCollection(collection, "Созданная коллекция:\n");
            Console.ReadLine();
            Console.Clear();


            string[] menu = { "Просмотреть коллекцию", "Добавить элемент в коллекцию", "Удалить элемент из коллекции", "Далее" };
            while (true)
            {
                int userChoice = MenuChoice(menu, "Выберите действие:\n") + 1;
                Console.Clear();
                if (userChoice == menu.Length) break;
                switch (userChoice)
                {
                    case 1:
                        PrintCollection(collection, "Коллекция:\n");
                        break;
                    case 2:
                        State newState = RandomState();
                        collection.Add(newState);
                        Console.WriteLine($"Государство {newState.Title} добавлено в коллекцию.");
                        break;
                    case 3:
                        if (collection.Count == 0) Console.WriteLine("Удаление элементов невозможно, т.к. коллеция пуста.");
                        else
                        {
                            int index = IntInput(0, collection.Count, "Введите индекс элемента: ");
                            collection.RemoveAt(index);
                            Console.Clear();
                            Console.WriteLine($"Элемент с идексом {index} был удалён из коллекции.");
                        }
                        break;
                }
                Console.WriteLine("Нажмите Enter, чтобы вернуться в меню");
                Console.ReadLine();
            }


            Console.WriteLine("Реализация запросов:");
            Console.WriteLine("1. Количество республик в коллекции");
            int amount = 0;
            foreach (object obj in collection) if (obj is Republic) amount++;
            Console.WriteLine(amount);
            Console.WriteLine("2. Индексы всех монархий в коллекции");
            bool exist = false;
            for (int i = 0; i < collection.Count; i++) if (collection[i] is Monarchy)
                {
                    exist = true;
                    Console.Write(i + " ");
                }
            Console.WriteLine(exist ? "" : "В коллекции нет монархий.");
            Console.WriteLine("3. Вывод на экран всех королевств из коллекции");
            exist = false;
            foreach (object obj in collection) if (obj is Kingdom)
                {
                    exist = true;
                    Console.WriteLine();
                    (obj as Kingdom).Print();
                }
            if (!exist) Console.WriteLine("В коллекции нет королевств.");
            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("Клонирование коллекции...");
            ArrayList collectionClone = new ArrayList();
            foreach (object obj in collection) collectionClone.Add((obj as State).Clone());
            PrintCollection(collectionClone, "Склонированная коллекция:\n");
            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("Сортировка (по названию государства) склонированной коллекции...");
            collectionClone.Sort();
            PrintCollection(collectionClone, "Отсортированная коллекция:\n");
            Console.ReadLine();
            Console.WriteLine("Поиск по коллекции...");
            if (collection.Count == 0) Console.WriteLine("Коллекция пуста.");
            else
            {
                State desiredState = RandomState();
                Console.WriteLine($"Поиск государства {desiredState.Title}...");
                int index = collectionClone.IndexOf((desiredState as State).Clone());
                if (index == -1) Console.WriteLine("Данное государство не входит в коллекцию.");
                else Console.WriteLine($"Индекс данного государства в коллекции - {index}");
            }
            Console.ReadLine();
            Console.Clear();
        }

        static void Task2()
        {
            Console.WriteLine("Создание коллекции (Stack<T>)...");
            Stack<State> collection = new Stack<State>();
            collection.Push(new Republic("USA", "Washington", "N. America", 9.5, 329, "Donald John Trump", 541));
            collection.Push(new Monarchy("Great Britian", "London", "Eurasia", 0.24, 66, "Elizabeth II", "protestantism"));
            collection.Push(new Kingdom("Aflines", "Droria", "Eurasia", 0.05, 3, "Guernot", "Ioneda"));
            Console.WriteLine("Коллекция создана.");
            PrintCollection(collection, "Созданная коллекция:\n");
            Console.ReadLine();
            Console.Clear();


            string[] menu = { "Просмотреть коллекцию", "Добавить элемент в коллекцию", "Удалить элемент из коллекции", "Далее" };
            while (true)
            {
                int userChoice = MenuChoice(menu, "Выберите действие:\n") + 1;
                Console.Clear();
                if (userChoice == menu.Length) break;
                switch (userChoice)
                {
                    case 1:
                        PrintCollection(collection, "Коллекция:\n");
                        break;
                    case 2:
                        State newState = RandomState();
                        collection.Push(newState);
                        Console.WriteLine($"Государство {newState.Title} добавлено в коллекцию.");
                        break;
                    case 3:
                        if (collection.Count == 0) Console.WriteLine("Удаление элементов невозможно, т.к. коллеция пуста.");
                        else
                        {
                            collection.Pop();
                            Console.WriteLine("Крайний элемент был удалён из коллекции.");
                        }
                        break;
                }
                Console.WriteLine("Нажмите Enter, чтобы вернуться в меню");
                Console.ReadLine();
            }


            Console.WriteLine("Реализация запросов:");
            Console.WriteLine("1. Количество республик в коллекции");
            int amount = 0;
            foreach (State state in collection) if (state is Republic) amount++;
            Console.WriteLine(amount);
            Console.WriteLine("2. Позиции всех монархий в коллекции");
            bool exist = false;
            int i = 0;
            foreach (State state in collection)
            {
                if (state is Monarchy)
                {
                    exist = true;
                    Console.Write(i + " ");
                }
                i++;
            }
            Console.WriteLine(exist ? "" : "В коллекции нет монархий.");
            Console.WriteLine("3. Вывод на экран всех королевств из коллекции");
            exist = false;
            foreach (State state in collection) if (state is Kingdom)
                {
                    exist = true;
                    Console.WriteLine();
                    state.Print();
                }
            if (!exist) Console.WriteLine("В коллекции нет королевств.");
            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("Клонирование коллекции...");
            Stack<State> collectionClone = new Stack<State>();
            foreach (State state in collection.Reverse()) collectionClone.Push((State)state.Clone());
            PrintCollection(collectionClone, "Склонированная коллекция:\n");
            Console.ReadLine();
            Console.WriteLine("\nПоиск по коллекции...");
            if (collection.Count == 0) Console.WriteLine("Коллекция пуста.");
            else
            {
                State desiredState = RandomState();
                Console.WriteLine($"Поиск государства {desiredState.Title}...");
                if (collectionClone.Contains(desiredState.Clone())) Console.WriteLine("Данное государство входит в коллекцию.");
                else Console.WriteLine("Данное государство не входит в коллекцию.");
            }
            Console.ReadLine();
            Console.Clear();
        }

        static void Task3()
        {
            long time;
            Console.WriteLine("Создание коллекций...");
            TestCollections tc = new TestCollections(1000);
            Console.WriteLine("Созданы 4 коллекции по 1000 элементов в каждой.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Поиск первого элемента в Коллекции1<TKey>...");
            Console.WriteLine(tc.Collection00Contains((State)tc.Collection00First.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск центрального элемента в Коллекции1<TKey>...");
            Console.WriteLine(tc.Collection00Contains((State)tc.Collection00Middle.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск последнего элемента в Коллекции1<TKey>...");
            Console.WriteLine(tc.Collection00Contains((State)tc.Collection00Last.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск элемента, не входящего в Коллекцию1<TKey>...");
            Console.WriteLine(tc.Collection00Contains(tc.NotIncluded.BaseState(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");
            Console.ReadLine();

            Console.WriteLine("Поиск первого элемента в Коллекции1<string>...");
            Console.WriteLine(tc.Collection01Contains(tc.Collection01First, out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск центрального элемента в Коллекции1<string>...");
            Console.WriteLine(tc.Collection01Contains(tc.Collection01Middle, out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск последнего элемента в Коллекции1<string>...");
            Console.WriteLine(tc.Collection01Contains(tc.Collection01Last, out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск элемента, не входящего в Коллекцию1<string>...");
            Console.WriteLine(tc.Collection01Contains(tc.NotIncluded.Title, out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");
            Console.ReadLine();

            Console.WriteLine("Поиск по ключу первого элемента в Коллекции2<TKey, TValue>...");
            Console.WriteLine(tc.Collection10ContainsKey((State)tc.Collection10First.Key.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по ключу центрального элемента в Коллекции2<TKey, TValue>...");
            Console.WriteLine(tc.Collection10ContainsKey((State)tc.Collection10Middle.Key.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по ключу последнего элемента в Коллекции2<TKey, TValue>...");
            Console.WriteLine(tc.Collection10ContainsKey((State)tc.Collection10Last.Key.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по ключу элемента, не входящего в Коллекцию2<TKey, TValue>...");
            Console.WriteLine(tc.Collection10ContainsKey(tc.NotIncluded.BaseState(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");
            Console.ReadLine();

            Console.WriteLine("Поиск по значению первого элемента в Коллекции2<TKey, TValue>...");
            Console.WriteLine(tc.Collection10ContainsValue((Republic)tc.Collection10First.Value.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по значению центрального элемента в Коллекции2<TKey, TValue>...");
            Console.WriteLine(tc.Collection10ContainsValue((Republic)tc.Collection10Middle.Value.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по значению последнего элемента в Коллекции2<TKey, TValue>...");
            Console.WriteLine(tc.Collection10ContainsValue((Republic)tc.Collection10Last.Value.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по значению элемента, не входящего в Коллекцию2<TKey, TValue>...");
            Console.WriteLine(tc.Collection10ContainsValue((Republic)tc.NotIncluded.Clone(), out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");
            Console.ReadLine();

            Console.WriteLine("Поиск по ключу первого элемента в Коллекции2<string, TValue>...");
            Console.WriteLine(tc.Collection11ContainsKey(tc.Collection10First.Key.Title, out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по ключу центрального элемента в Коллекции2<string, TValue>...");
            Console.WriteLine(tc.Collection11ContainsKey(tc.Collection10Middle.Key.Title, out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по ключу последнего элемента в Коллекции2<string, TValue>...");
            Console.WriteLine(tc.Collection11ContainsKey(tc.Collection10Last.Key.Title, out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");

            Console.WriteLine("Поиск по ключу элемента, не входящего в Коллекцию2<string, TValue>...");
            Console.WriteLine(tc.Collection11ContainsKey(tc.NotIncluded.Title, out time) ? "Найден" : "Не найден");
            Console.WriteLine($"Затраченное время (в тиках) - {time}\n");
            Console.ReadLine();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ЗАДАНИЕ 1");
            Task1();

            Console.WriteLine("ЗАДАНИЕ 2");
            Task2();

            Console.WriteLine("ЗАДАНИЕ 3");
            Task3();
        }
    }
}
