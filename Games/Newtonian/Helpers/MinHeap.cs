using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Joueur.cs.Games.Newtonian.Helpers
{
    public class MinHeap<T> : ICollection<T> where T : IComparable<T>
    {
        private List<T> _storage;

        public MinHeap()
        {
            this._storage = new List<T>();
        }

        public MinHeap(IEnumerable<T> elements) : this()
        {
            foreach (T element in elements)
            {
                this.Add(element);
            }
        }

        public IEnumerator<T> GetEnumerator() => this._storage.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Clear() => this._storage.Clear();

        public bool Contains(T item) => this._storage.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => this._storage.CopyTo(array, arrayIndex);

        public void Add(T item) => this.Push(item);

        public bool Remove(T item)
        {
            if (!this._storage.Contains(item))
                return false;

            List<T> elems = this._storage;
            this._storage = new List<T>();
            foreach (T elem in elems)
                this.Add(elem);

            return true;
        }

        public void Push(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            // Add it to the bottom of the heap
            int index = this._storage.Count;
            this._storage.Add(item);

            // Sift it up through the heap
            while (index > 0)
            {
                int parentI = this.GetParentI(index);
                T parent = this._storage[parentI];
                if (item.CompareTo(parent) < 0)
                {
                    // Swap
                    this._storage[index] = parent;
                    this._storage[parentI] = item;
                    index = parentI;
                }
                else
                {
                    // All done
                    break;
                }
            }
        }

        public T Pop()
        {
            if (!this._storage.Any())
                throw new Exception("Heap is empty");

            // Remove the first element, save it for later, and move last element to beginning
            T popped = this._storage.First();
            this._storage[0] = this._storage[this._storage.Count - 1];
            this._storage.RemoveAt(this._storage.Count - 1);

            // If it's empty now, just return the popped element
            if (!this._storage.Any())
                return popped;

            // Sift it down through the heap
            int index = 0;
            T sifting = this._storage[0];
            while (2 * index + 1 < this._storage.Count)
            {
                int leftI = 2 * index + 1;
                int rightI = 2 * index + 2;
                int smallestI;

                // Find the smallest of the two children
                if (leftI < this._storage.Count && rightI >= this._storage.Count)
                    smallestI = leftI;
                else if (this._storage[leftI].CompareTo(this._storage[rightI]) <= 0)
                    smallestI = leftI;
                else
                    smallestI = rightI;

                // Compare the current element to its smallest child
                T smallest = this._storage[smallestI];
                if (sifting.CompareTo(smallest) < 0)
                {
                    // If it's smaller than the smallest child, all done
                    break;
                }
                else
                {
                    // Swap the two elements
                    this._storage[index] = smallest;
                    this._storage[smallestI] = sifting;
                    index = smallestI;
                }
            }

            // All done sifting
            return popped;
        }

        private int GetParentI(int index) => (index - 1) / 2;

        public int Count => this._storage.Count;
        public bool IsReadOnly => false;
    }
}
