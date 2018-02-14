using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__7
{
    class TwoListItem
    {
        public int Data;
        public TwoListItem next, //адрес следующего элемента
                     pred;//адрес предыдущего элемента
        public TwoListItem()
        {
            Data = 0;
            next = null;
            pred = null;
        }
        public TwoListItem(int d)//конструктор с параметрами
        {
            Data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return Data + " ";
        }


    }
}
