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
                Console.WriteLine("2)Удалить из списка первый четный элемент");
                Console.WriteLine("3)В главное меню");
                Console.Write(">");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "1":
                        GenerateList(rnd.Next(0, 10));
                        break;
                    case "2":
                        DeleteFirstEvenItem();
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "3");
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
            while (item != null)
            {
                if (item.Data % 2 == 0)
                {
                    if (item != Head)
                        prev.Next = item.Next;
                    else
                        Head = item.Next;
                    break;
                }
                prev = item;
                item = item.Next;
            }
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
                        AddItem(twoListHead, 0);
                        TwoListPrint(twoListHead);
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "3");
        }

        private static void AddItem(TwoListItem head, int number)
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
                Console.WriteLine("1)Сформировать бинарное дерево");
                Console.WriteLine("2)Подсчитать количество листьев");
                Console.WriteLine("3)В главное меню");
                Console.Write(">");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "1":
                        root = GenerateTree(rnd.Next(0, 10));
                        ShowTree(root, 40, Console.CursorTop);
                        Console.SetCursorPosition(0, 20);
                        break;
                    case "2":
                        int count = 0;
                        CountLeaves(root, ref count);
                        Console.WriteLine($"Количество листьев:{count}.");
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "3");
        }

        private static void CountLeaves(BinarTreeNode p, ref int count)
        {
            if (p != null)
            {
                if (p.left == null && p.right == null)
                    count++;

                CountLeaves(p.left, ref count);//переход к левому поддереву
                CountLeaves(p.right, ref count);//переход к правому поддереву
            }
        }

        private static BinarTreeNode GenerateTree(int size)
        {
            BinarTreeNode p = new BinarTreeNode(rnd.Next(0, 20));

            for (int i = 0; i < size; i++)
            {
                Add(p, rnd.Next(0, 20));
            }

            return p;
        }

        static BinarTreeNode Add(BinarTreeNode root, int d)//добавление элемента d в дерево поиска
        {
            BinarTreeNode p = root; //корень дерева
            BinarTreeNode r = null;
            //флаг для проверки существования элемента d в дереве
            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                //элемент уже существует
                if (d == p.Data) ok = true;
                else
            if (d < p.Data) p = p.left; //пойти в левое поддерево
                else p = p.right; //пойти в правое поддерево
            }
            if (ok) return p;//найдено, не добавляем
                             //создаем узел
            BinarTreeNode NewPoint = new BinarTreeNode(d);//выделили память
                                                          // если d<r.key, то добавляем его в левое поддерево
            if (d < r.Data) r.left = NewPoint;
            // если d>r.key, то добавляем его в правое поддерево
            else r.right = NewPoint;
            return NewPoint;
        }

        static BinarTreeNode IdealTree(int size, BinarTreeNode p)
        {
            BinarTreeNode r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            int number = Convert.ToInt32(Console.ReadLine());
            r = new BinarTreeNode();
            r.Data = number;
           // i++;
            r.left = IdealTree(nl, r.left);
            r.right = IdealTree(nr, r.right);
            return r;
        }

        static void ShowTree(BinarTreeNode p, int l, int t)
        {
            const int offset = 3;
            if (p != null)
            {
                Console.SetCursorPosition(l, t);
                Console.Write(p.Data);

                if (p.left != null)
                {
                    Console.SetCursorPosition(l - offset, t);
                    Console.Write(DupLicate("━", offset));

                    Console.SetCursorPosition(l - offset, t);
                    Console.Write("┏");
                    ShowTree(p.left, l - offset, t + 1);//переход к левому поддереву
                }

                if (p.right != null)
                {
                    Console.SetCursorPosition(l+ p.Data.ToString().Length, t);
                    Console.Write(DupLicate("━", offset));

                    Console.SetCursorPosition(l + offset+p.Data.ToString().Length-1, t);
                    Console.Write("┓");
                    ShowTree(p.right, l + offset, t + 1);//переход к правому поддереву
                }
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
