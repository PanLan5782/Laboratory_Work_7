using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__7
{
    class ListItem
    {
        public int Data;//информационное поле
        public ListItem Next;//адресное поле
        public ListItem()//конструктор без параметров
        {
            Data = 0;
            Next = null;
        }
        public ListItem(int d)//конструктор с параметрами
        {
            Data = d;
            Next = null;
        }
        public override string ToString()
        {
            return Data + " ";
        }

    }
}
