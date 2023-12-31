using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BoardingWeek_1
{
    public class BinarySearchTree
    {
        #region TreeNode Class
        public class TreeNode
        {
            public int data;
            public TreeNode? left;
            public TreeNode? right;

            public TreeNode(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }
        #endregion

        public TreeNode? root;


        #region FindData

        public void Find(int data)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
            }
            else
            {
                TreeNode currentNode = root;

                while (currentNode != null)
                {
                    if (currentNode.data == data)
                    {
                        Console.WriteLine("Data is found");
                        break;
                    }
                    else if (data > currentNode.data && currentNode.right != null)
                    {
                        currentNode = currentNode.right;
                    }
                    else if (data < currentNode.data && currentNode.left != null)
                    {
                        currentNode = currentNode.left;
                    }
                }
                Console.WriteLine("Value is not found");
            }
        }

        #endregion

        #region FindDataRecursive

        //public TreeNode FindDataRecursive(int data)
        //{
        //    if(root == null)
        //    {
        //        Console.WriteLine("Tree is Empty");
        //    }
        //    else
        //    {
        //        TreeNode current = root;

        //        if(current.data == data)
        //        {
        //            Console.WriteLine("Value is found");
        //            return;
        //        }
        //        else if(current.data > data)
        //        {
        //            return left.FindDataRecursive(data);
        //        }
        //        else if(current.data < data)
        //        {
        //            return right.FindDataRecursive(data);
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    return null;
        //}

        #endregion

        #region InsertData

        public void InsertData(int data)
        {
            if (root == null)
            {
                root = new TreeNode(data);
                return;
            }
            else
            {
                TreeNode currentNode = root;

                while (currentNode != null)
                {
                    if (currentNode.data > data)
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = new TreeNode(data);
                            return;
                        }
                        else
                        {
                            currentNode = currentNode.left;
                        }
                    }
                    else
                    {
                        if (currentNode.right == null)
                        {
                            currentNode.right = new TreeNode(data);
                            return;
                        }
                        else
                        {
                            currentNode = currentNode.right;
                        }
                    }

                }
            }
        }

        #endregion

        #region DeleteData

        public void Remove(int data)
        {
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false;

            //Empty Tree
            if (current != null)
            {
                Console.WriteLine("Tree is Empty");
            }

            //Find the Node
            while (current != null && current.data != data)
            {
                parent = current;

                if (current.data > data && current.left != null)
                {
                    current = current.left;
                    isLeftChild = true;
                }
                else if (current.data < data && current.right != null)
                {
                    current = current.right;
                    isLeftChild = false;
                }
            }

            // if the current is null which is means we dont find the data
            if (current == null)
            {
                Console.WriteLine("Value is not found");
            }

            // Leaf node aka no childre
            if (current.left == null && current.right == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }
                }
            }
            // Only one child and child is left Node 
            else if (current.right == null)
            {
                if (current == root)
                {
                    root = current.left;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.left = current.left;
                    }
                    else
                    {
                        parent.right = current.left;
                    }
                }
            }
            // Only one child and child id right Node
            else if (current.left == null)
            {
                if (current == root)
                {
                    root = current.right;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.left = current.right;
                    }
                    else
                    {
                        parent.right = current.right;
                    }
                }
            }
            // have 2 childs
            else
            {
                TreeNode Successor = GetSuccessor(current);

                if(current == root)
                {
                    root = Successor;
                }
                else if(isLeftChild)
                {
                    parent.left = Successor;
                }
                else
                {
                    parent.right = Successor;
                }
            }
        }

        public TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.right;

            //starting at the right child we go down every left child node
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.left;// go to next left node
            }
            //if the succesor is not just the right node then
            if (successor != node.right)
            {
                //set the Left node on the parent node of the succesor node to the right child node of the successor in case it has one
                parentOfSuccessor.left = successor.right;
                //attach the right child node of the node being deleted to the successors right node
                successor.right = node.right;
            }
            //attach the left child node of the node being deleted to the successors leftnode node
            successor.left = node.left;

            return successor;
        }
        #endregion

        #region InOrder Traversal

        public void InOrderTraversal()
        {
            InOrderTraversalHelper(root);
        }

        public void InOrderTraversalHelper(TreeNode? currentNode)
        {
            if (currentNode != null)
            {
                InOrderTraversalHelper(currentNode.left);
                Console.Write(currentNode.data + " ");
                InOrderTraversalHelper(currentNode.right);
            }
        }

        #endregion

        #region PreOrderTraversal

        public void PreOrderTraversal()
        {
            PreOrderHelper(root);
        }

        private void PreOrderHelper(TreeNode? currentNode)
        {
            if (currentNode != null)
            {
                Console.Write(currentNode.data + " ");
                PreOrderHelper(currentNode.left);
                PreOrderHelper(currentNode.right);
            }
        }

        #endregion

        #region PostOrder Traversal

        public void PostOrderTraversal()
        {
            PostOrderHelper(root);
        }

        private void PostOrderHelper(TreeNode? currentNode)
        {
            if (currentNode != null)
            {
                PostOrderHelper(currentNode.left);
                PostOrderHelper(currentNode.right);
                Console.Write(currentNode.data + " ");
            }
        }


        #endregion

        #region Smallest Value
        public int SmallestValue()
        {
            return SmallestHelper(root);
        }

        private int SmallestHelper(TreeNode? CurrentNode)
        {
            if (CurrentNode != null)
            {
                if (CurrentNode.left == null)
                {
                    return CurrentNode.data;
                }
                else
                {
                    return SmallestHelper(CurrentNode.left);
                }
            }

            return -1;
        }

        #endregion

        #region LargestValue 

        public int LargestValue()
        {
            return LargestHelper(root);
        }

        private int LargestHelper(TreeNode? CurrentNode)
        {
            if (CurrentNode != null)
            {
                if (CurrentNode.right == null)
                {
                    return CurrentNode.data;
                }
                else
                {
                    return LargestHelper(CurrentNode.right);
                }
            }

            return -1;
        }

        #endregion
    }
}
