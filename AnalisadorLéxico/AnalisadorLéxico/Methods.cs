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
            dynamic lines = null;
            try
            {
                lines = File.ReadAllLines(filename);
            }finally{
              if (lines == null)
              {
                  Console.WriteLine("Arquivo não existe ou fora da pasta files");
                  Environment.Exit(1);
              }
            }
            return lines;
        }
        public void ThrowError(int row, int col)
        {
            Console.WriteLine($"ERRO! Caracter invalido na linha {row} e na coluna {col}!");
            Environment.Exit(1);
        }
        public void ThrowError(string caso, int row)
        {
          switch(caso){
            case "a":
              Console.WriteLine("ERRO! Arquivo selecionado tem menos linhas do que deveria");
              Environment.Exit(1);
              break;
            case "b":
              Console.WriteLine("ERRO! Arquivo selecionado tem mais linhas do que deveria");
              Environment.Exit(1);
              break;
            case "c":
              Console.WriteLine($"ERRO! Linha {row} tem menos caracteres do que deveria");
              Environment.Exit(1);
              break;
            case "d":
              Console.WriteLine($"ERRO! Linha {row} tem mais caracteres do que deveria");
              Environment.Exit(1);
              break;
          }
        }
    }
}
