﻿using LegendsOfValor_TheGuildTrials.IO.Contracts;

namespace LegendsOfValor_TheGuildTrials.IO
{
    internal class Writer : IWriter
    {
        private readonly string filePath;

        public Writer()
        {
            string resultsPath = GetProjectDirectory() + @"Utilities/Results/";
            filePath = Path.Combine(resultsPath, "Actual.txt");

            File.WriteAllText(filePath, string.Empty);
        }

        public void WriteText(string message) => File.AppendAllText(filePath, message.TrimEnd() + Environment.NewLine);

        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message) => Console.WriteLine(message);

        private string GetProjectDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            return relativePath;
        }
    }
}
