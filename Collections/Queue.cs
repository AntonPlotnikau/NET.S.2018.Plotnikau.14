using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    /// <summary>
    /// Generic queue
    /// </summary>
    /// <typeparam name="T">type of elements in queue</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public class Queue<T> : IEnumerable<T>
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
        /// Initializes a new instance of the <see cref="Queue{T}" /> class.
        /// </summary>
        public Queue()
        {
            this.array = new T[DefaultCapacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}" /> class.
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
        /// Initializes a new instance of the <see cref="Queue{T}" /> class.
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

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        private int Version { get; set; }
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
            this.Version++;
        }

        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <returns>
        /// item that was removed
        /// </returns>
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
            this.Version--;

            return result;
        }
        #endregion

        #region IEnumerable<T> interface implementation

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        #region Struct Enumerator
        /// <summary>
        /// Enumerator for iterating
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
        private struct Enumerator : IEnumerator<T>
        {
            /// <summary>
            /// The queue
            /// </summary>
            private readonly Queue<T> queue;

            /// <summary>
            /// The version
            /// </summary>
            private readonly int version;

            /// <summary>
            /// The index
            /// </summary>
            private int index;

            /// <summary>
            /// The current element
            /// </summary>
            private T currentElement;

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> struct.
            /// </summary>
            /// <param name="queue">The queue.</param>
            /// <exception cref="ArgumentNullException">queue is null</exception>
            public Enumerator(Queue<T> queue)
            {
                this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
                this.version = queue.Version;
                this.index = -1;
                this.currentElement = default(T);
            }

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            /// <exception cref="InvalidOperationException">
            /// Iteration do not started!
            /// or
            /// Iteration was ended!
            /// </exception>
            public T Current
            {
                get
                {
                    if (this.index == -1)
                    {
                        throw new InvalidOperationException("Iteration do not started!");
                    }

                    if (this.index == this.queue.Count)
                    {
                        throw new InvalidOperationException("Iteration was ended!");
                    }

                    return this.currentElement;
                }
            }

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose() { }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            ///   <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="InvalidOperationException">Queue was changed!</exception>
            public bool MoveNext()
            {
                if (this.version != this.queue.Version)
                {
                    throw new InvalidOperationException("Queue was changed!");
                }

                bool result;

                if (this.index == -1)
                {
                    this.index = 0;
                    result = this.index >= this.queue.Count - 1;

                    if (result)
                    {
                        this.currentElement = this.queue.array[this.index];
                    }

                    return result;
                }

                if (this.index == this.queue.Count)
                {
                    return false;
                }

                result = ++this.index >= 0;

                this.currentElement = result ? this.queue.array[this.index] : default(T);

                return result;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            /// <exception cref="InvalidOperationException">Queue was changed!</exception>
            public void Reset()
            {
                if (this.version != this.queue.Version)
                {
                    throw new InvalidOperationException("Queue was changed!");
                }

                this.index = -1;

                this.currentElement = default(T);
            }
        }
        #endregion

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
