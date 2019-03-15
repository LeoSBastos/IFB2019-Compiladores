using System;
using System.Collections.Generic;
using System.Linq;
namespace AnalisadorLéxico
{
    class Program
    {
        public static dynamic variaveis;
        public static dynamic constantes;
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
                string initialword = lines[row][0];
                switch (initialword)
                {
                    case "Program":
                        {
                            int col = lines[row].Count - 1;
                            if (!lines[row][col].Contains(";"))
                            {
                                me.ThrowError(row, col, ";");
                            }
                            else
                            {
                                me.ChangeTitle(lines[row][1].Trim(';'));
                                Console.WriteLine("Titulo mudou!");
                            }
                        }
                        break;
                    case "Var":
                        {
                            int col = lines[row].Count - 1;
                            if (!lines[row][col].Contains(";"))
                            {
                                col = filelines[row].Length;
                                me.ThrowError(row + 1, col, ";");
                            }
                            else
                            {
                                string tipo = lines[row][col].Trim(';').ToLower();
                                if (tipo == "real")
                                {
                                    if (lines[row][2] != ":")
                                    {
                                        me.ThrowError(row + 1, col, ":");
                                    }
                                    variaveis = new Dictionary<string, int>();
                                    List<string> nomevariaveis = lines[row][1].Replace(',', ' ').Split(" ").ToList<string>();
                                    foreach (string key in nomevariaveis)
                                    {
                                        variaveis.Add(key, 0);
                                    }
                                    foreach (string key in variaveis.Keys)
                                    {
                                        Console.WriteLine(key);
                                    }
                                }
                                if (tipo == "texto")
                                {
                                    if (lines[row][2] != ":")
                                    {
                                        me.ThrowError(row + 1, col, ":");
                                    }
                                    variaveis = new Dictionary<string, string>();
                                    List<string> nomevariaveis = lines[row][1].Replace(',', ' ').Split(" ").ToList<string>();
                                    foreach (string key in nomevariaveis)
                                    {
                                        variaveis.Add(key, null);
                                    }
                                }
                            }
                        }
                        break;
                    case "Const":
                        {
                            int col = lines[row].Count - 1;
                            if (!lines[row][col].Contains(";"))
                            {
                                col = filelines[row].Length;
                                me.ThrowError(row + 1, col, ";");
                            }
                            else
                            {
                                constantes = new Dictionary<string, dynamic>();
                            }
                        }
                        break;
                    case "Begin":
                        flags[0] = true;
                        while (initialword != "End." && row < lines.Count)
                        {
                            initialword = lines[row][0];
                            switch (initialword)
                            {
                                case string a when a.Contains("Read"):
                                    {
                                        string aux = null;
                                        bool[] flag = { false, false };
                                        foreach (char c in initialword.ToCharArray())
                                        {
                                            if (c == '(')
                                            {
                                                flag[0] = true;
                                            }
                                            else if (c == ')')
                                            {
                                                flag[1] = true;
                                            }
                                            else if (flag[0] && !flag[1])
                                            {
                                                aux += c;
                                            }
                                        }
                                        if (flag[0] && flag[1])
                                        {
                                            string test = Console.ReadLine();
                                            variaveis[aux] = Convert.ToInt32(test);
                                        }
                                        else
                                        {
                                            me.ThrowError(flag, "Read");
                                        }
                                    }
                                    break;
                                case string b when b.Contains("Write"):
                                    {
                                        string aux = null;
                                        bool[] flag = { false, false };
                                        foreach (char c in initialword.ToCharArray())
                                        {
                                            if (c == '(')
                                            {
                                                flag[0] = true;
                                            }
                                            else if (c == ')')
                                            {
                                                flag[1] = true;
                                            }
                                            else if (flag[0] && !flag[1])
                                            {
                                                aux += c;
                                            }
                                        }
                                        if (flag[0] && flag[1])
                                        {
                                            Console.WriteLine(variaveis[aux]);
                                        }
                                        else
                                        {
                                            me.ThrowError(flag, "Write");
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                            row++;
                        }
                        if (initialword == "End.")
                        {
                            flags[1] = true;
                        }
                        break;
                    case string a when a.Contains("Program") || a.Contains("Var") || a.Contains("Const"):
                        char[] charArr = a.ToCharArray();
                        for (int col = 0; col < charArr.Length; col++)
                        {
                            if (!Char.IsLetter(charArr[col]))
                            {
                                me.ThrowError(row + 1, col + 1, "char");
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
                me.ThrowError(flags, "BeginEnd");
            }
        }
    }
}