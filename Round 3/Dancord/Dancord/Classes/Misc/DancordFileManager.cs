using System;
using System.Collections.Generic;
using System.IO;

namespace Dancord.Classes.Misc
{
    class DancordFileManager
    {
        private static readonly object x = new object();
        public static void Create(string file, ConsoleWindow DancordConsole)
        {
            string path = $"../../Databases/{file}.txt";
            if (File.Exists(path)) return;

            lock (x)
            {
                File.Create(path).Close();
                File.WriteAllText(path, $"--- === Created at {DateTime.Now.ToLocalTime()} === ---\n");
                DancordConsole.Log($"Created {file} at {path}.");
            }
        }
        public static void Update(string file, string update, ConsoleWindow DancordConsole)
        {
            string path = $"../../Databases/{file}.txt";
            if (!File.Exists(path)) Create(file, DancordConsole);

            lock (x)
            {
                File.AppendAllLines(path, new string[] { update });
                DancordConsole.Log($"Updated {file}.txt with the following:", update);
            }

        }
    }
}