using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    /// <summary>
    /// Binary search tree collection
    /// </summary>
    /// <typeparam name="T">type of data</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        #region Private Fields
        /// <summary>
        /// The node
        /// </summary>
        private TreeNode<T> node;

        /// <summary>
        /// The comparer
        /// </summary>
        private Comparison<T> comparer;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                this.comparer = Comparer<T>.Default.Compare;
            }
            else
            {
                this.comparer = comparer.Compare;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public BinarySearchTree(Comparison<T> comparer)
        { 
            this.comparer = comparer ?? Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            this.comparer = Comparer<T>.Default.Compare;
        }
        #endregion

        #region Public Metthods
        /// <summary>
        /// Inserts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="ArgumentNullException">data is null</exception>
        public void Insert(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (this.node == null)
            {
                this.node = new TreeNode<T>(data);
                return;
            }

            this.Insert(this.node, data);
        }

        /// <summary>
        /// Inserts the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <exception cref="ArgumentNullException">values are null</exception>
        public void Insert(IEnumerable<T> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (T value in values) 
            {
                this.Insert(value);
            }
        }

        /// <summary>
        /// Preorder way of iteration.
        /// </summary>
        /// <returns>series of elements</returns>
        /// <exception cref="ArgumentException">There are no elements in tree</exception>
        public IEnumerable<T> PreOrder()
        {
            if (this.node == null)
            {
                throw new ArgumentException("There are no elements in tree");
            }

            return this.PreOrder(this.node);
        }

        /// <summary>
        /// Inorder way of iteration.
        /// </summary>
        /// <returns>series of elements</returns>
        /// <exception cref="ArgumentException">There are no elements in tree</exception>
        public IEnumerable<T> InOrder()
        {
            if (this.node == null)
            {
                throw new ArgumentException("There are no elements in tree");
            }

            return this.InOrder(this.node);
        }

        /// <summary>
        /// Postorder way of iteration.
        /// </summary>
        /// <returns>series of elements</returns>
        /// <exception cref="ArgumentException">There are no elements in tree</exception>
        public IEnumerable<T> PostOrder()
        {
            if (this.node == null)
            {
                throw new ArgumentException("There are no elements in tree");
            }

            return this.PostOrder(this.node);
        }
        #endregion

        #region IEnumerable implementation
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
            => this.InOrder().GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
        #endregion

        #region Private Methods
        /// <summary>
        /// Inserts the data in the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="data">The data.</param>
        private void Insert(TreeNode<T> node, T data)
        {
            if (node == null)
            {
                node = new TreeNode<T>(data);
            }
            else if (this.comparer(data, node.Data) < 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new TreeNode<T>(data);
                }
                else
                {
                    this.Insert(node.LeftNode, data);
                }
            }
            else
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new TreeNode<T>(data);
                }
                else
                {
                    this.Insert(node.RightNode, data);
                }
            }
        }

        /// <summary>
        /// Preorder way of iteration.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>series of elements</returns>
        private IEnumerable<T> PreOrder(TreeNode<T> node)
        {
            yield return node.Data;

            if (node.LeftNode != null)
            {
                foreach (T data in this.PreOrder(node.LeftNode))
                {
                    yield return data;
                }
            }

            if (node.RightNode != null)
            {
                foreach (T data in this.PreOrder(node.RightNode))
                {
                    yield return data;
                }
            }
        }

        /// <summary>
        /// Inorder way of iteration.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>series of elements</returns>
        private IEnumerable<T> InOrder(TreeNode<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (T data in this.InOrder(node.LeftNode)) 
                {
                    yield return data;
                }
            }

            yield return node.Data;

            if (node.RightNode != null)
            {
                foreach (T data in this.InOrder(node.RightNode))
                {
                    yield return data;
                }
            }
        }

        /// <summary>
        /// Postorder way of iteration.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>series of elements</returns>
        private IEnumerable<T> PostOrder(TreeNode<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (T data in this.PostOrder(node.LeftNode))
                {
                    yield return data;
                }
            }

            if (node.RightNode != null)
            {
                foreach (T data in this.PostOrder(node.RightNode))
                {
                    yield return data;
                }
            }

            yield return node.Data;
        }
        #endregion

        #region Nested types
        /// <summary>
        /// node of the tree
        /// </summary>
        /// <typeparam name="T">type of data</typeparam>
        /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
        private class TreeNode<T>
        {
            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="TreeNode{T}"/> class.
            /// </summary>
            /// <param name="data">The data.</param>
            public TreeNode(T data)
            {
                this.Data = data;
            }
            #endregion

            #region Properties
            /// <summary>
            /// Gets the data.
            /// </summary>
            /// <value>
            /// The data.
            /// </value>
            public T Data { get; }

            /// <summary>
            /// Gets or sets the left node.
            /// </summary>
            /// <value>
            /// The left node.
            /// </value>
            public TreeNode<T> LeftNode { get; set; }

            /// <summary>
            /// Gets or sets the right node.
            /// </summary>
            /// <value>
            /// The right node.
            /// </value>
            public TreeNode<T> RightNode { get; set; }
            #endregion
        }
        #endregion
    }
}
