using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    
    enum Color
    {
        Red, Black
    }
 
        class main
        {
            static void Main(string[] args)
            {

                RedBlack t = new RedBlack();
                
                t.Insert(13);
                t.Insert(20);
                t.Insert(9);
                t.Insert(1);
                t.Insert(5);
                t.Insert(12);
                t.Insert(11);
                t.Insert(2);
                t.Display();
                t.Delete(6);
                t.Display();

                Console.ReadLine();

            }
            public Node Childrens(Node x)
             {
                 if (x.left != null)
                 {
                     while (x.left.left != null)
                     {
                         x = x.left;
                     }
                     if (x.left.right != null)
                     {
                         x = x.left.right;
                     }
                     return x;
                 }
                 else
                 {
                     Node y = x.parent;
                     while (y != null && x == y.right)
                     {
                         x = y;
                         x = y.parent;
                     }
                     return y;
                 }
             }
        }
}
