using System;
using System.Collections.Generic;
using System.Text;

namespace MinMaxModels.Models.Tree
{
    public class Node<T>
    {
        public int? id { get; set; }
        public T Element { get; set; }
        public List<Node<T>> Childs { get; set; }
        public Node<T> Father { get; set; }

        public Node(int? id)
        {
            if (id != null)
            {
                this.id = id;
            }
        }
        public Node(int? id, Node<T> father, List<Node<T>> childs) : this(id)
        {
            this.Father = father;
            this.Childs = childs;
        }
        public Node(int? id, Node<T> father, List<Node<T>> childs, T element) : this(id, father, childs)
        {
            this.Element = element;
        }
        public override string ToString()
        {
            return this.Element.ToString();
        }
    }
}
