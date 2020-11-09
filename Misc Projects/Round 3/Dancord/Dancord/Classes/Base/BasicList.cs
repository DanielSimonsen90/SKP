using Dancord.Classes.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dancord.Classes.Base
{
    public class BasicList<T> : ICollection<T>, IList<T>, IJSON
    {
        #region Public Properties
        public T this[int index] { get => innerList[index]; set => innerList[index] = value; }
        public string File { get; set; }
        #endregion

        #region Private Properties
        private readonly List<T> innerList = new List<T>();
        #endregion

        #region ChannelManager Methods
        public T Find(Predicate<T> match) => innerList.Find(match);
        public T[] ToArray() => innerList.ToArray();
        #endregion

        #region Interfaces

        #region ICollection<Channel>
        public int Count => innerList.Count;
        public bool IsReadOnly => true;

        public void Add(T item) => innerList.Add(item);
        public void Add(T item, ConsoleWindow DancordConsole)
        {
            Add(item);
            if (File == string.Empty)
            {
                DancordConsole.PopoutError("File not defined", "Error while saving to file", System.Windows.MessageBoxButton.OK);
                return;
            }
            DancordFileManager.Update(File, (item as IJSONID).ToJSON(true), DancordConsole);

        }
        public void Clear() => innerList.Clear();
        public bool Contains(T item) => innerList.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => innerList.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => innerList.GetEnumerator();
        public bool Remove(T item) => innerList.Remove(item);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        #endregion

        #region IList<Channel>
        public int IndexOf(T item) => innerList.IndexOf(item);
        public void Insert(int index, T item) => innerList.Insert(index, item);
        public void RemoveAt(int index) => innerList.RemoveAt(index);
        #endregion

        #region IJSON
        public string ToJSON() =>
            "{" +
                $"File: {File}" +
                $"innerList: {ItemsToJSON()}" +
            "}";
        private string ItemsToJSON()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in innerList)
                try { sb.Append((item as IJSONID).ToJSON(true) + ","); }
                catch { sb.Append((item as IJSON).ToJSON() + ","); }
            sb = new StringBuilder().Append(sb.ToString().Substring(0, sb.Length - 1));

            return $"[{sb}]";
        }
        #endregion

        #endregion
    }
}
