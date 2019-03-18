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
          int flen;
          bool[] flags = {false, false};
          if(filelines.Length<original.Length){
            flen = original.Length;
          }
          else{
            if(filelines.Length == original.Length){
              flags[0]=true;
            }
            flen = filelines.Length;
          }
          for (int row = 0; row < flen; row++)
          {
            if(!flags[0]){
              if(filelines.Length<flen){
                me.ThrowError("a",0);
              }
              else if(original.Length<flen){
                me.ThrowError("b",0);
              }
            }
            if(filelines[row] == original[row]){
                continue;
            }
            else {
              char[] charArrLinha = filelines[row].ToCharArray();
              char[] charArrOriginal = original[row].ToCharArray();
              int len;
              if(charArrLinha.Length<charArrOriginal.Length){
                len = charArrLinha.Length;
              }
              else {
                if(charArrLinha.Length==charArrOriginal.Length){
                  flags[1]=true;
                }
                len = charArrOriginal.Length;
              }
              for(int i = 0; i<len; i++){
                if(!flags[1]){
                  if(charArrLinha.Length<len){
                    me.ThrowError("c",row);
                  }
                  else if(charArrOriginal.Length<len){
                    me.ThrowError("d",row);
                  }
                }
                if(charArrLinha[i] != charArrOriginal[i]){
                      me.ThrowError(row+1, i+1);
                }
              }
            }
          }
          Console.WriteLine("O programa é o mesmo!");
        }
    }
}
