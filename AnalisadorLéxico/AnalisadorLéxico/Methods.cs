using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnalisadorLéxico
{
    public class Methods
    {
        public string[] ReadFile(string filename)
        {
            string workdir = Directory.GetCurrentDirectory();
            string path = Directory.GetParent(workdir).Parent.Parent.FullName + "\\files\\" + filename;
            string[] lines = File.ReadAllLines(@path);
            return lines;
        }
        public List<List<string>> LinesToWords(string[] lines)
        {
            List<List<string>> words = new List<List<string>>();
            foreach (string line in lines)
            {
                words.Add(line.Trim(new char[] { ' ', '\t' }).Split(" ").ToList<string>());
            }
            return words;
        }
        public void ChangeTitle(string title)
        {
            Console.Title = title;
        }
    }
}
