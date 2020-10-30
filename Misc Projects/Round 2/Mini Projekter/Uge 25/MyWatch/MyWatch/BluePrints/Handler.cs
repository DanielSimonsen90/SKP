using System.Collections.Generic;
using System.Linq;
using WatchProject.BluePrints.Interfaces;

namespace WatchProject.BluePrints
{
    /// <summary>
    /// Handler if a collection of <typeparamref name="T"/> is needed
    /// </summary>
    /// <typeparam name="T">Type to collect</typeparam>
    internal abstract class Handler<T> : IAddable<T>
    {
        /// <summary>
        /// Interacts with <see cref="innerList"/> to return T value
        /// </summary>
        /// <param name="index">Index of item to get</param>
        /// <returns>T item from <see cref="innerList"/></returns>
        public T this[int index] { get  => innerList[index]; set => innerList[index] = value; }

        /// <summary>
        /// Inner list to contain all T elements
        /// </summary>
        protected readonly List<T> innerList = new List<T>();
        /// <summary>
        /// If there are no elements in <see cref="innerList"/>, return true else false
        /// </summary>
        public bool IsEmpty => innerList.Count < 1;
        /// <summary>
        /// Returns <see cref="innerList"/>.Count
        /// </summary>
        public int Length => innerList.Count;

        #region IAddable
        public void Add(params T[] addedValues) => innerList.AddRange(from T type in addedValues select type);
        public void Remove(params T[] removedValues)
        {
            foreach (T type in removedValues)
                if (innerList.Contains(type))
                    innerList.Remove(type);
        }
        #endregion
        
        /// <summary>
        /// Clears <see cref="innerList"/>
        /// </summary>
        public void Clear() => innerList.Clear();
    }
}
