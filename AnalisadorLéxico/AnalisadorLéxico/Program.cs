using System;
using System.Collections.Generic;
using System.Linq;
namespace AnalisadorLéxico
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods me = new Methods();
            Console.WriteLine("Escreva o nome do seu arquivo: ");
            string[] filelines = me.ReadFile(Console.ReadLine());
            string[] original = me.ReadFile("equals.txt");
            Console.Clear();
            for (int row = 0; row < lines.Count; row++)
            {
                if(filelines[row] = original[row]){
                    continue;
                }
                else {
                    char[] charArrLinha = filelines[row].ToCharArray();
                    char[] charArrOriginal = original[row].ToCharArray();
                    if(charArrLinha.Length<charArrOriginal.Length){
                        int len = charArrLinha.Length;
                    }
                    else {
                        int len = charArrOriginal.Length;
                    }
                    for(int i = 0; i<len; i++){
                        if(charArrLinha[i] != charArrOriginal[i]){
                            me.ThrowError(row+1, i+1);
                        }
                    }
                }
            }
        }
    }
}
