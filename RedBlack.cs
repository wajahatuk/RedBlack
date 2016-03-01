using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    class RedBlack
    {
        public Node root;

        /////////////Left Rotaiton////////////////

        public void LeftRotate(Node x)
        {
            Node y = x.right;
            x.right = y.left;
            if (y.left != null)
            {
                y.left.parent = x;
            }
            if (y != null)
            {
                y.parent = x.parent;
            }
            if (x.parent == null)
            {
                root = y;
            }
            if (x == x.parent.left)
            {
                x.parent.left = y;
            }
            else
            {
                x.parent.right = y;
            }
            y.left = x;
            if (x != null)
            {
                x.parent = y;
            }

        }

        ///Right Rotation (Its Nothing but just a mirror of Left Rotation)

        public void RightRotate(Node y)
        {

            Node x = y.left;
            y.left = x.right;
            if (x.right != null)
            {
                x.right.parent = y;
            }
            if (x != null)
            {
                x.parent = y.parent;
            }
            if (y.parent == null)
            {
                root = x;
            }
            if (y == y.parent.right)
            {
                y.parent.right = x;
            }
            if (y == y.parent.left)
            {
                y.parent.left = x;
            }

            x.right = y;
            if (y != null)
            {
                y.parent = x;
            }
        }

        ///////////Insertion ////////////
        public void Insert(int item)
        {

            Node newItem = new Node(item);
            if (root == null)
            {
                root = newItem;
                root.colour = Color.Black;
                return;
            }
            Node y = null;
            Node x = root;
            while (x != null)
            {
                y = x;
                if (newItem.value < x.value)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }
            newItem.parent = y;
            if (y == null)
            {
                root = newItem;
            }
            else if (newItem.value < y.value)
            {
                y.left = newItem;
            }
            else
            {
                y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            ///We will set the color Red for the new node
            newItem.colour = Color.Red;
            InsertUpdate(newItem);
        }

        ///Updating and removing the Violations. There will be 3 Cases
        /// Case 1: When Uncle is Red
        /// Case 2: When Uncle is Black
        /// Case 3: We will Rotate and Recolor

        private void InsertUpdate(Node item)
        {

            while (item != root && item.parent.colour == Color.Red)
            {

                if (item.parent == item.parent.parent.left)
                {
                    Node y = item.parent.parent.right;
                    ///Case 1:

                    if (y != null && y.colour == Color.Red)
                    {
                        item.parent.colour = Color.Black;
                        y.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        item = item.parent.parent;
                    }

                    ///Case 2: 

                    else
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }

                        ///Case 3:

                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {

                    Node x = null;
                    ///Case 1:
                    x = item.parent.parent.left;
                    if (x != null && x.colour == Color.Black)
                    {
                        item.parent.colour = Color.Red;
                        x.colour = Color.Red;
                        item.parent.parent.colour = Color.Black;
                        item = item.parent.parent;
                    }
                    ///Case 2:
                    else
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        ///Case 3:

                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        LeftRotate(item.parent.parent);

                    }

                }
                root.colour = Color.Black;
            }
        }
        //////////Deletion///////////

        public void Delete(int point)
        {
            
            Node item = Search(point);
            Node x = null;
            Node y = null;

            if (item == null)
            {
                Console.WriteLine("\nThe number you want to delete is not in the tree!\n");
                return;
            }
            if (item.left == null || item.right == null)
            {
                y = item;
            }
            else
            {
                main c = new main();
                y = c.Childrens(item);
            }
            if (y.left != null)
            {
                x = y.left;
            }
            else
            {
                x = y.right;
            }
            if (x != null)
            {
                x.parent = y;
            }
            if (y.parent == null)
            {
                root = x;
            }
            else if (y == y.parent.left)
            {
                y.parent.left = x;
            }
            else
            {
                y.parent.left = x;
            }
            if (y != item)
            {
                item.value = y.value;
            }
            if (y.colour == Color.Black)
            {
                DeleteUpdate(x);
            }

        }

        /// Similary to Insertion, after deleting we will remove the violations and recolour the tree

        private void DeleteUpdate(Node x)
        {

            while (x != null && x != root && x.colour == Color.Black)
            {
                if (x == x.parent.left)
                {
                    Node z = x.parent.right;
                    if (z.colour == Color.Red)
                    {
                        z.colour = Color.Black;
                        z.parent.colour = Color.Red;
                        LeftRotate(x.parent);
                        z = x.parent.right;
                    }
                    if (z.left.colour == Color.Black && z.right.colour == Color.Black)
                    {
                        z.colour = Color.Red;
                        x = x.parent;
                    }
                    else if (z.right.colour == Color.Black)
                    {
                        z.left.colour = Color.Black;
                        z.colour = Color.Red;
                        RightRotate(z);
                        z = x.parent.right;
                    }
                    z.colour = x.parent.colour;
                    x.parent.colour = Color.Black;
                    z.right.colour = Color.Black;
                    LeftRotate(x.parent);
                    x = root;
                }
                else
                {
                    Node z = x.parent.left;
                    if (z.colour == Color.Red)
                    {
                        z.colour = Color.Black;
                        x.parent.colour = Color.Red;
                        RightRotate(x.parent);
                        z = x.parent.left;
                    }
                    if (z.right.colour == Color.Black && z.left.colour == Color.Black)
                    {
                        z.colour = Color.Black;
                        x = x.parent;
                    }
                    else if (z.left.colour == Color.Black)
                    {
                        z.right.colour = Color.Black;
                        z.colour = Color.Red;
                        LeftRotate(z);
                        z = x.parent.left;
                    }
                    z.colour = x.parent.colour;
                    x.parent.colour = Color.Black;
                    z.left.colour = Color.Black;
                    RightRotate(x.parent);
                    x = root;
                }
            }
            if (x != null)
                x.colour = Color.Black;
        }
        /////////////////////////////Search//////////////////

        public Node Search(int point)
        {
            bool found = false;
            Node temp = root;
            Node item = null;
            while (!found)
            {
                if (temp == null)
                {
                    break;
                }
                else if (point < temp.value)
                {
                    temp = temp.left;
                }
                else if (point > temp.value)
                {
                    temp = temp.right;
                }
                else if (point == temp.value)
                {
                    found = true;
                    item = temp;
                }
            }
            if (found)
            {
                Console.WriteLine("{0} was found \n", point);
                return temp;
            }
            else
            {
                Console.WriteLine("{0} not found \n", point);
                return null;
            }
        }
        public void Display()
        {
            if (root == null)
            {
                Console.WriteLine("Sorry, There's Nothing!");
                return;
            }
            if (root != null)
            {
                InOrder(root);
            }
        }
        public void InOrder(Node current)
        {
            if (current != null)
            {
                InOrder(current.left);
                Console.Write("({0}) ", current.value);
                InOrder(current.right);
            }
        }

        /////////////////
    }
}
