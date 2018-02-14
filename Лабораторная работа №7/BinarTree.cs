using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__7
{
    class BinarTreeNode
    {
        
        public int Data;
        public BinarTreeNode left,//адрес левого поддерева 
                     right;//адрес правого поддерева
        public BinarTreeNode()
        {
            Data = 0;
            left = null;
            right = null;
        }
        public BinarTreeNode(int d)
        {
            Data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return Data + " ";
        }
    }


}

