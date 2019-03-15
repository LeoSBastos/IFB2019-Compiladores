using System;
using System.Collections.Generic;
using System.Linq;
namespace AnalisadorLéxico
{
    class Program
    {
        public static dynamic variaveis;
        public static dynamic constantes;
        public static int col;
        public static char[] charArr;
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
                        col = lines[row].Count - 1;
                        if (!lines[row][col].Contains(";"))
                        {
                            col = filelines[row].Length;
                            me.ThrowError(row, col, ";");
                        }
                        else
                        {
                            me.ChangeTitle(lines[row][1].Trim(';'));
                        }
                        break;
                    case "Var":
                        col = lines[row].Count - 1;
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
                        break;
                    case "Const":
                        col = lines[row].Count - 1;
                        if (!lines[row][col].Contains(";"))
                        {
                            col = filelines[row].Length;
                            me.ThrowError(row + 1, col, ";");
                        }
                        else
                        {
                            constantes = new Dictionary<string, dynamic>();
                            for (int i = 0; i < lines[row].Count; i++)
                            {
                                if (lines[row][i].Contains(";"))
                                {
                                    string rawvalue = lines[row][i].Trim(';');
                                    if (lines[row][i - 1] == "=")
                                    {
                                        if (!lines[row][i - 2].Contains(";") && lines[row][i - 2] != "Const")
                                        {
                                            bool isInt = int.TryParse(rawvalue, out int value);
                                            bool isDouble = double.TryParse(rawvalue, out double result);
                                            if (isInt)
                                            {
                                                constantes.Add(lines[row][i - 2].ToLower(), value);
                                            }
                                            else if (isDouble)
                                            {
                                                charArr = filelines[row].ToCharArray();
                                                for (col = 0; col < charArr.Length; col++)
                                                {
                                                    if (charArr[col] == '.')
                                                    {
                                                        me.ThrowError(row + 1, col, "Double");
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                constantes.Add(lines[row][i - 2].ToLower(), rawvalue);
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (string key in constantes.Keys)
                            {
                                Console.WriteLine(key);
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
                                            me.ThrowError(flag, "ReadWrite");
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
                                            me.ThrowError(flag, "ReadWrite");
                                        }
                                    }
                                    break;
                                default:
                                    List<string> keys = new List<string>(variaveis.Keys);
                                    List<string> keys2 = new List<string>(constantes.Keys);
                                    if (keys.Contains(initialword, StringComparer.OrdinalIgnoreCase))
                                    {
                                        for (int i = 0; i < lines[row].Count; i++)
                                        {
                                            if (lines[row][i].Contains(":="))
                                            {
                                                string keytosave = initialword.ToLower();
                                                dynamic totalvalue;
                                                dynamic temp = null;
                                                dynamic temp2 = null;
                                                for (; i < lines[row].Count; i++)
                                                {
                                                    switch (lines[row][i])
                                                    {
                                                        case "*":
                                                            if (keys.Contains(lines[row][i - 1]))
                                                            {
                                                                temp = variaveis[lines[row][i - 1].ToLower()];
                                                            }
                                                            else if (keys2.Contains(lines[row][i - 1]))
                                                            {
                                                                temp = constantes[lines[row][i - 1].ToLower()];
                                                            }
                                                            else
                                                            {
                                                                charArr = filelines[row].ToCharArray();
                                                                for (col = 0; col < charArr.Length; col++)
                                                                {
                                                                    if (charArr[col] == lines[row][i - 1].ToCharArray()[0])
                                                                    {
                                                                        me.ThrowError(row + 1, col, "Variavel2");
                                                                    }
                                                                }
                                                            }
                                                            if (keys.Contains(lines[row][i + 1]))
                                                            {
                                                                temp2 = variaveis[lines[row][i + 1].ToLower()];
                                                            }
                                                            else if (keys2.Contains(lines[row][i + 1]))
                                                            {
                                                                temp2 = constantes[lines[row][i + 1].ToLower()];
                                                            }
                                                            else
                                                            {
                                                                charArr = filelines[row].ToCharArray();
                                                                for (col = 0; col < charArr.Length; col++)
                                                                {
                                                                    if (charArr[col] == lines[row][i + 1].ToCharArray()[0])
                                                                    {
                                                                        me.ThrowError(row + 1, col, "Variavel2");
                                                                    }
                                                                }
                                                            }
                                                            totalvalue = temp * temp2;
                                                            variaveis.Add("temp", totalvalue);
                                                            break;
                                                        case "/":
                                                            if (keys.Contains(lines[row][i - 1]))
                                                            {
                                                                temp = variaveis[lines[row][i - 1].ToLower()];
                                                            }
                                                            else if (keys2.Contains(lines[row][i - 1]))
                                                            {
                                                                temp = constantes[lines[row][i - 1].ToLower()];
                                                            }
                                                            else
                                                            {
                                                                charArr = filelines[row].ToCharArray();
                                                                for (col = 0; col < charArr.Length; col++)
                                                                {
                                                                    if (charArr[col] == lines[row][i - 1].ToCharArray()[0])
                                                                    {
                                                                        me.ThrowError(row + 1, col, "Variavel2");
                                                                    }
                                                                }
                                                            }
                                                            if (keys.Contains(lines[row][i + 1]))
                                                            {
                                                                temp2 = variaveis[lines[row][i + 1].ToLower()];
                                                            }
                                                            else if (keys2.Contains(lines[row][i + 1]))
                                                            {
                                                                temp2 = constantes[lines[row][i + 1].ToLower()];
                                                            }
                                                            else
                                                            {
                                                                charArr = filelines[row].ToCharArray();
                                                                for (col = 0; col < charArr.Length; col++)
                                                                {
                                                                    if (charArr[col] == lines[row][i + 1].ToCharArray()[0])
                                                                    {
                                                                        me.ThrowError(row + 1, col, "Variavel2");
                                                                    }
                                                                }
                                                            }
                                                            totalvalue = temp * temp2;
                                                            variaveis.Add("temp", totalvalue);
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        me.ThrowError(row, 1, "Variavel");
                                    }
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
                        charArr = a.ToCharArray();
                        for (int col = 0; col < charArr.Length; col++)
                        {
                            if (!Char.IsLetter(charArr[col]))
                            {
                                me.ThrowError(row + 1, col + 1, "char");
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