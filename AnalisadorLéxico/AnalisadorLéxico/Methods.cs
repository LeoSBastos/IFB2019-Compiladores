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
            Console.WriteLine($"ERRO! Ponto e virgula não incluido na linha {row} e na coluna {col}!");
            Environment.Exit(1);
            break;
        }

        public void ThrowError(bool[] flags, string caso)
        {
            switch (caso)
            {
                case "ReadWrite":
                    if (flags[0])
                    {
                        Console.WriteLine("ERRO! Falta o ) do programa!");
                        Environment.Exit(1);
                    }
                    else if (flags[1])
                    {
                        Console.WriteLine("ERRO! Falta o ( do programa!");
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("ERRO! Falta o ( e o ) do método!");
                        Environment.Exit(1);
                    }
                    break;
                case "BeginEnd":
                    if (flags[0])
                    {
                        Console.WriteLine("ERRO! Falta o End. do programa!");
                        Environment.Exit(1);
                    }
                    else if (flags[1])
                    {
                        Console.WriteLine("ERRO! Falta o Begin do programa!");
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("ERRO! Falta o Begin e o End. do programa!");
                        Environment.Exit(1);
                    }
                    break;
            }
        }
    }
}
