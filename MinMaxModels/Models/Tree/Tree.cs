using System;
using System.Collections.Generic;
using System.Text;

namespace MinMaxModels.Models.Tree
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }
        public int Size { get; set; }

        public Tree()
        {
            this.Root = null;
            this.Size = 0;
        }

        public bool Add(int? id, T element, Node<T> father)
        {
            if (this.Size == 0)
            {
                this.Root = new Node<T>(id, null, new List<Node<T>>(), element);
                this.Size++;
                return true;
            }
            if (father != null)
            {
                var newNode = new Node<T>(id, father, new List<Node<T>>(), element);
                father.Childs.Add(newNode);
                this.Size++;
                return true;
            }
            return false;
        }

        public bool Add(Node<T> newNode)
        {
            if (this.Size == 0)
            {
                this.Root = newNode;
                this.Size++;
                return true;
            }
            if (newNode.Father != null)
            {
                newNode.Father.Childs.Add(newNode);
                this.Size++;
                return true;
            }
            return false;
        }

        public Node<T> FindById(int? id)
        {
            return SearchNode(this.Root, new Node<T>(id), "id");
        }

        public Node<T> FindByElement(T element)
        {
            return SearchNode(this.Root, new Node<T>(null, null, null, element), "element");
        }

        private Node<T> SearchNode(Node<T> actualNode, Node<T> nodeToFind, string typeSearch)
        {
            if (typeSearch == "id")
            {
                if (actualNode.id == nodeToFind.id)
                {
                    return actualNode;
                }
            }
            else
            {
                if (actualNode.Element.Equals(nodeToFind.Element))
                {
                    return actualNode;
                }
            }
            foreach (var node in actualNode.Childs)
            {
                var nodeFound = SearchNode(node, nodeToFind, typeSearch);
                if (nodeFound != null)
                {
                    return nodeFound;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return PrintTree(this.Root, "");
        }

        private string PrintTree(Node<T> actualNode, string tree)
        {
            tree += string.Format("-------------------Actual node: {0}--------------\nChilds: ", actualNode);

            if (actualNode.Childs.Count == 0)
            {
                tree += "No Childs. Leaf Node.";
            }
            else
            {
                tree += string.Join(",", actualNode.Childs);
            }
            tree += "\n";
            foreach (var node in actualNode.Childs)
            {
                tree = PrintTree(node, tree);
            }
            return tree;
        }
    }
}
