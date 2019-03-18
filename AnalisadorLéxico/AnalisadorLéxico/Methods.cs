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
            dynamic lines;
            try
            {
                lines = File.ReadAllLines(@path);
            }
            catch (Exception e)
            {
                lines = null;
            }
            if (lines == null)
            {
                Console.WriteLine("Arquivo não existe ou fora da pasta files");
                Environment.Exit(1);
            }
            return lines;
        }
        public void ThrowError(int row, int col)
        {
            Console.WriteLine($"ERRO! Caracter invalido na linha {row} e na coluna {col}!");
            Environment.Exit(1);
            break;
        }
    }
}
