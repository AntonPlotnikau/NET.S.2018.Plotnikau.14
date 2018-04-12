using System;
using System.Collections.Generic;

namespace Collections
{
    /// <summary>
    /// Generic queue
    /// </summary>
    /// <typeparam name="T">type of elements in queue</typeparam>
    public class Queue<T>
    {
        #region Constant Fields
        /// <summary>
        /// The default capacity
        /// </summary>
        private const int DefaultCapacity = 4;

        /// <summary>
        /// The resize coefficient
        /// </summary>
        private const int ResizeCoefficient = 2;
        #endregion

        #region Private Fields
        /// <summary>
        /// The array
        /// </summary>
        private T[] array;

        /// <summary>
        /// The head
        /// </summary>
        private int head;

        /// <summary>
        /// The tail
        /// </summary>
        private int tail;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            this.array = new T[DefaultCapacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public Queue(IEnumerable<T> values)
        {
            this.array = new T[DefaultCapacity];

            foreach (T value in values) 
            {
                this.Enqueue(value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <exception cref="ArgumentOutOfRangeException">capacity is less than 1</exception>
        public Queue(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity) + "must be more than 0");
            }

            T[] array = new T[capacity];
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count of elements in queue.
        /// </value>
        public int Count { get; private set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize(this.array.Length * ResizeCoefficient);
            }

            this.array[this.tail] = item;
            if (this.tail + 1 > this.array.Length - 1)
            {
                this.tail = 0;
            }
            else
            {
                this.tail += 1;
            }

            this.Count++;
        }

        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <returns>item that was removed</returns>
        /// <exception cref="InvalidOperationException">Queue is empty</exception>
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T result = this.array[this.head];
            this.array[this.head] = default(T);
            if (this.head + 1 > this.array.Length - 1)
            {
                this.head = 0;
            }
            else
            {
                this.head += 1;
            }

            this.Count--;

            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Resizes the specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        private void Resize(int capacity)
        {
            T[] temp = this.array;
            this.array = new T[capacity];

            if (this.head < this.tail)
            {
                Array.Copy(temp, this.array, this.Count);
            }
            else
            {
                Array.Copy(temp, this.head, this.array, 0, temp.Length - this.tail);
                Array.Copy(temp, 0, this.array, temp.Length - this.head, this.tail);
            }

            this.head = 0;
            this.tail = this.Count;
        }
        #endregion
    }
}
