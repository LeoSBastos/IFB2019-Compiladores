using System;
using System.Collections.Generic;
namespace AnalisadorLéxico
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods me = new Methods();
            Console.WriteLine("Escreva o nome do seu arquivo: ");
            string[] filelines = me.ReadFile(Console.ReadLine());
            List<List<String>> lines = me.LinesToWords(filelines);
            bool[] flags = { false, false };
            Console.Clear();
            for (int row = 0; row < lines.Count; row++)
            {
                switch (lines[row][0])
                {
                    case "Program":
                        if (lines[row][1].Contains(";"))
                        {
                            me.ChangeTitle(lines[row][1].Trim(';'));
                            Console.WriteLine("Titulo mudou!");
                        }
                        else
                        {
                            row++;
                            int col = filelines[row].Length;
                            Console.WriteLine($"ERRO! Ponto e virgula não incluido na linha {row} e na coluna {col}!");
                            return;
                        }
                        break;
                    case "Begin":
                        flags[0] = true;
                        break;
                    case "End.":
                        flags[1] = true;
                        break;
                    case string a when a.Contains("Program!"):
                        char[] charArr = a.ToCharArray();
                        for (int col = 0; col < charArr.Length; col++)
                        {
                            if (!Char.IsLetter(charArr[col]))
                            {
                                row++;
                                col++;
                                Console.WriteLine($"ERRO! Caracter não suportado na linha {row} e na coluna {col}!");
                                return;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            if (!flags[0] || !flags[1])
            {
                if (flags[0])
                {
                    Console.WriteLine("ERRO! Falta o End. do programa!");
                    return;
                }
                else if (flags[1])
                {
                    Console.WriteLine("ERRO! Falta o Begin do programa!");
                    return;
                }
                else
                {
                    Console.WriteLine("ERRO! Falta o Begin e o End. do programa!");
                    return;
                }
            }
        }
    }
}
