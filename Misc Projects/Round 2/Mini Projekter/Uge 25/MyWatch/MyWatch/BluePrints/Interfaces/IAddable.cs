namespace WatchProject.BluePrints.Interfaces
{
    /// <summary>
    /// If class inherits from this, it means the class needs an Add() and a Remove()
    /// </summary>
    /// <typeparam name="T">Type to add to the list that should be provided</typeparam>
    interface IAddable<T>
    {
        /// <summary>
        /// Adds <paramref name="addedValues"/> to inner array
        /// </summary>
        /// <param name="addedValues"></param>
        void Add(params T[] addedValues);
        /// <summary>
        /// Removes <paramref name="removedValues"/> from inner array
        /// </summary>
        /// <param name="removedValues"></param>
        void Remove(params T[] removedValues);
    }
}
