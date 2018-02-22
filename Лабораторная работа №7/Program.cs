using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__7
{
    class Program
    {
        static Random rnd = new Random();
        static ListItem Head;
        static TwoListItem twoListHead = null;
        static BinarTreeNode root = null;
        static TwoListItem MakePoint(int d)
        {
            TwoListItem p = new TwoListItem(d);
            return p;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int[] Menu = null;
            string userCommand = null;
            do
            {
                Console.WriteLine("1)Работа с однонаправленным списком");
                Console.WriteLine("2)Работа с двунаправленным списком");
                Console.WriteLine("3)Работа с бинарным деревом");
                Console.WriteLine("4)Выход");
                Console.Write(">");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "1":
                        ListItemWorks();
                        break;
                    case "2":
                        TwoListItemWorks();
                        break;
                    case "3":
                        BinarTreeWorks();
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "4");
        }

        private static void ListItemWorks()
        {
            int[] Menu = null;
            string userCommand = null;
            do
            {
                Console.WriteLine("1)Сформировать однонаправленный список");
                Console.WriteLine("2)Создать список с клавиатуры");
                Console.WriteLine("3)Удалить из списка первый четный элемент");
                Console.WriteLine("4)В главное меню");
                Console.Write(">");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "1":
                        Head = null;
                        GenerateList(rnd.Next(1, 10));
                        break;
                    case "3":
                        DeleteFirstEvenItem();
                        break;
                    case "2":
                        Head = null;
                        int size = InputNumber("Введите количество элементов в списке:", x => x > 0);
                        GenerateListFromKey(size);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "4");
        }

        private static void GenerateListFromKey(int size)
        {
            for (int i = 0; i < size; i++)
            {
                int data = InputNumber($"Введите элемент {i}:", x => true);
                ListItem item = new ListItem(data);
                item.Next = Head;
                Head = item;
            }
            PrintList();
        }

        static void GenerateList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                ListItem item = new ListItem(rnd.Next(0, 100));
                item.Next = Head;
                Head = item;
            }
            PrintList();
        }
        static void PrintList()
        {
            ListItem item = Head;
            while (item != null)
            {
                Console.Write(item.Data + " ");
                item = item.Next;
            }
            Console.WriteLine();
        }
        static void DeleteFirstEvenItem()
        {
            ListItem item = Head;
            ListItem prev = Head;
            bool wasDeleted = false;
            while (item != null)
            {
                if (item.Data % 2 == 0)
                {
                    if (item != Head)
                        prev.Next = item.Next;
                    else
                        Head = item.Next;
                    wasDeleted = true;
                    break;
                }
                prev = item;
                item = item.Next;
            }

            if (!wasDeleted)
                Console.WriteLine("Отсутствие четных элементов");

            PrintList();
            
        }

        private static void TwoListItemWorks()
        {
            int[] Menu = null;
            string userCommand = null;
            do
            {
                Console.WriteLine("1)Сформировать двунаправленный список");
                Console.WriteLine("2)Добавить в список элемент с заданным номером");
                Console.WriteLine("3)В главное меню");
                Console.Write(">");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "1":
                        GenerateTwoList(rnd.Next(0, 10));
                        TwoListPrint(twoListHead);
                        break;
                    case "2":
                        int index = InputNumber("Введите номер элемента:", x=> x>=0);
                        AddItem(ref twoListHead, index);
                        TwoListPrint(twoListHead);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "3");
        }

        private static int InputNumber(string prompt, Func<int, bool> condition)
        {
            Console.WriteLine(prompt);
            bool ok = false;
            int result = 0;

            do
            {
                string input = Console.ReadLine();
                ok = int.TryParse(input, out result) && condition(result);
                if (!ok)
                {
                    Console.WriteLine($"Неверное значение'{input}'. Повторите ввод.");
                }
            } while (!ok);
            return result;
        }

        private static void AddItem(ref TwoListItem head, int number)
        {
            Random rnd = new Random();

            int info = rnd.Next(10, 100);
            Console.WriteLine("The element {0} is adding...", info);
            //создаем новый элемент
            TwoListItem NewPoint = MakePoint(info);
            if (head == null)//список пустой
            {
                head = MakePoint(rnd.Next(10, 100));
                return;
            }
            if (number == 0) //добавление в начало списка
            {
                NewPoint.next = head;
                head.pred = NewPoint;
                head = NewPoint;
                return;
            }
            //вспом. переменная для прохода по списку
            TwoListItem p = head;
            //идем по списку до нужного элемента
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.next;
            if (p == null)//элемент не найден
            {
                Console.WriteLine("Error! The size of List less than Number");
                return;
            }
            //добавляем новый элемент
            NewPoint.next = p.next;
            if (p.next != null)
                p.next.pred = NewPoint;

            p.next = NewPoint;
            NewPoint.pred = p;

            return;

        }

        private static void GenerateTwoList(int size)//добавление в начало
        {
            Random rnd = new Random();
            int info = rnd.Next(0, 11);
            TwoListItem beg = MakePoint(info);

            for (int i = 1; i < size; i++)
            {
                info = rnd.Next(0, 11);
                TwoListItem p = MakePoint(info);
                p.next = beg;
                beg.pred = p;
                beg = p;
                if (beg == null)
                {
                    Console.WriteLine("Лист пустой");
                    return;
                }

                twoListHead = p;

            }
        }

        private static void TwoListPrint(TwoListItem head)
        {
            TwoListItem p = head;

            while (p != null)
            {
                Console.Write(p);
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine();
        }

        private static void BinarTreeWorks()
        {
            int[] Menu = null;
            string userCommand = null;
            do
            {
                Console.WriteLine("1)Сформировать идеально сбалансированное дерево и преобразовать в дерево поиска");
                Console.WriteLine("2)Найти минимальный элемент дерева");
                Console.WriteLine("3)В главное меню");
                Console.Write(">");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "1":
                        BinarTreeNode p = null;
                        BinarTreeNode idealRoot = IdealTree(15, p);
                        Console.WriteLine("Идеально сбалансированное дерево:");
                        ShowTree(idealRoot, 50, Console.CursorTop);
                        Console.SetCursorPosition(0, maxTop + 1);
                        Console.WriteLine();
                        root = null;
                        GenerateSearchTree(idealRoot, ref root);
                        Console.WriteLine("Дерево поиска:");
                        ShowTree(root, 50, Console.CursorTop);
                        Console.SetCursorPosition(0, maxTop + 1);
                        break;
                    case "2":
                        int min = int.MaxValue;
                        MinimalElement(root, ref min);
                        Console.WriteLine($"Минимальный элемент:{min}.");
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "3");
        }

        private static void MinimalElement(BinarTreeNode p, ref int min)
        {
            if (p != null)
            {
                if (p.Data < min)
                    min = p.Data;
                MinimalElement(p.left, ref min);//переход к левому поддереву
                MinimalElement(p.right, ref min);//переход к правому поддереву
            }

        }

        private static void GenerateSearchTree(BinarTreeNode idealTreeRoot, ref BinarTreeNode searchTreeRoot)
        {
            if (idealTreeRoot != null)
            {
                Add(ref searchTreeRoot, idealTreeRoot.Data);
                GenerateSearchTree(idealTreeRoot.left, ref searchTreeRoot);//переход к левому поддереву
                GenerateSearchTree(idealTreeRoot.right, ref searchTreeRoot);//переход к правому поддереву
            }
        }

        static BinarTreeNode Add(ref BinarTreeNode root, int d)//добавление элемента d в дерево поиска
        {
            BinarTreeNode p = root; //корень дерева
            BinarTreeNode r = null;
            //флаг для проверки существования элемента d в дереве
            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                //элемент уже существует
                if (d == p.Data)
                    ok = true;
                else
                    if (d < p.Data) p = p.left; //пойти в левое поддерево
                        else p = p.right; //пойти в правое поддерево
            }
            if (ok) return p;//найдено, не добавляем
                             //создаем узел
            BinarTreeNode NewPoint = new BinarTreeNode(d);//выделили память
            if (r != null)
                // если d<r.key, то добавляем его в левое поддерево
                if (d < r.Data)
                    r.left = NewPoint;
                // если d>r.key, то добавляем его в правое поддерево
                else
                    r.right = NewPoint;
            else
                root = NewPoint;
            return NewPoint;
        }

        static BinarTreeNode IdealTree(int size, BinarTreeNode p)
        {
            BinarTreeNode r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            int number = rnd.Next(0, 20);
            r = new BinarTreeNode();
            r.Data = number;
            // i++;
            r.left = IdealTree(nl, r.left);
            r.right = IdealTree(nr, r.right);
            return r;
        }

        static int maxTop = 0;

        /// <summary>
        /// Печать Дерева (идеальное/поиска)
        /// </summary>
        /// <param name="node">Текущая вершина дерева</param>
        /// <param name="left">Отступ от левого края</param>
        /// <param name="top">Отступ Сверху</param>
        /// <param name="offset">Длина ветки ("Смещение")</param>
        static void ShowTree(BinarTreeNode node, int left, int top, int offset = 20) 
        {
            if (node != null)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(node.Data);

                if (node.left != null)
                {
                    Console.SetCursorPosition(left - offset, top);
                    Console.Write(DupLicate("━", offset));

                    Console.SetCursorPosition(left - offset, top);
                    Console.Write("┏");
                    ShowTree(node.left, left - offset, top + 1, offset / 2);//переход к левому поддереву
                }

                if (node.right != null)
                {
                    Console.SetCursorPosition(left + node.Data.ToString().Length, top);
                    Console.Write(DupLicate("━", offset));

                    Console.SetCursorPosition(left + offset + node.Data.ToString().Length - 1, top);
                    Console.Write("┓");
                    ShowTree(node.right, left + offset, top + 1, offset / 2);//переход к правому поддереву
                }

                if (top > maxTop)
                    maxTop = top;
            }
        }

        public static string DupLicate(string s, int n)
        {
            string result = null;
            for (int i = 0; i < n; i++)
                result += s;
            return result;
        }

    }
}
