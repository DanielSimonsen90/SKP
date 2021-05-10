using Dancord.Classes.Misc;
using System.Linq;
using System.Text;

namespace Dancord.Classes.Base
{
    public class BasicList<T> : DanhoLibrary.Collections.BasicList<T>, IJSON
    {
        public string File { get; set; }

        #region Interfaces
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


        #region IJSON
        public string ToJSON() =>
            "{" +
                File != null ? $"File: {File}" : "" +
                $"innerList: {ItemsToJSON()}" +
            "}";
        private string ItemsToJSON()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in innerList)
                try { sb.Append((item as IJSONID).ToJSON(true) + ","); }
                catch 
                { 
                    try { sb.Append((item as IJSON).ToJSON() + ","); } 
                    catch { sb.Append(item.ToString() + ","); } 
                }
            sb = new StringBuilder().Append(sb.ToString().Substring(0, sb.Length - 1));

            return $"[{sb}]";
        }
        #endregion

        #endregion
    }
}
