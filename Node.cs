using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    class Node
    {
        
        public Color colour;
        public Node left;
        public Node right;
        public Node parent;
        public int value;
        public Node(int value)
        {

            this.value = value;
        }
        public Node(Color colour)
        {
            this.colour = colour;
        }
        public Node(int value, Color colour)
        {
            this.value = value;
            this.colour = colour;
        }

        
    }
}
