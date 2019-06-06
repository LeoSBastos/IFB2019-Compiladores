package br.com.compiladores.analisadorlexico;
import java_cup.runtime.Symbol;
import br.com.compiladores.analisadorsintatico.Sym;
%%
%cup
%public
%unicode
%class AnalisadorLexicontes
%line
%column

%{
    private Symbol symbol(int type, Object o){
      return new Symbol(type, yyline+1, yycolumn+1, o);
    }
    private Symbol symbol(int type){
          return new Symbol(type, yyline+1, yycolumn+1);
        }
%}
IGNORE = [\n|\t|\r]
SPACE = [ ]
//Identificador
ID = [a-z][a-zA-Z_|0-9]*

//Caracter literal
CHAR = \'[0-9|a-zA-Z|\n|\t| |:|\(|\)|,]\'

//Simbolos
SETOP = :=
LTH = <
MTH = >
LEQ = <=
MEQ = >=
EQ= =
DIFF= <>
PLUS = \+
MINUS = -
TIMES = \*
DIV = \/
MOD = %
AND = "and"
OR = "or"
NOT = "not"
LPAR = \(
RPAR = \)
VIRG = ,
PVIRG = ;
LCHA = \{
RCHA = \}
//Numeros
INT = [+-]{1}[0-9]+|[0-9]+
FLOAT = [[0-9]*,[0-9]+] | [[0-9]*,[0-9]+E[+-]{1}[0-9]*,[0-9]+]

//Comentarios
SINGLECOMMENT = \*{2}[\x20-\xED]*[\n|\r]
MULTICOMMENT = >{2}[\x20-\xED|\x09-\x0D]+<{2}

//Palavras chaves
KW_IF = "if"
KW_ELSE = "else"
KW_WHILE = "while"
KW_RETURN = "return"
KW_FLOAT = "float"
KW_CHAR = "char"
KW_VOID = "void"
KW_PRINT = "prnt"
KW_INT = "int"
KW_FUNCTION = "proc"
KW_VAR = "var"
%%

<YYINITIAL>{

{KW_IF} { return symbol(Sym.IF,yytext()); }
{KW_ELSE} { return symbol(Sym.ELSE,yytext()); }
{KW_WHILE} { return symbol(Sym.WHILE,yytext()); }
{KW_RETURN} { return symbol(Sym.RETURN,yytext()); }
{KW_FLOAT} { return symbol(Sym.FLOAT,yytext()); }
{KW_CHAR} { return symbol(Sym.CHAR,yytext()); }
{KW_VOID} { return symbol(Sym.VOID,yytext()); }
{KW_PRINT} { return symbol(Sym.PRINT,yytext()); }
{KW_INT} { return symbol(Sym.INT,yytext()); }
{KW_FUNCTION} { return symbol(Sym.PROC,yytext()); }
{KW_VAR} { return symbol(Sym.VAR,yytext()); }
{ID} { return symbol(Sym.ID,yytext());}
{CHAR} {return symbol(Sym.CHARL,yytext());}
{SETOP} {return symbol(Sym.SETOP,yytext());}
{LTH} {return symbol(Sym.LTH,yytext());}
{MTH} {return symbol(Sym.MTH,yytext());}
{LEQ} {return symbol(Sym.LEQ,yytext());}
{MEQ} {return symbol(Sym.MEQ,yytext());}
{EQ} {return symbol(Sym.EQ,yytext());}
{DIFF} {return symbol(Sym.DIFF,yytext());}
{PLUS} {return symbol(Sym.PLUS,yytext());}
{MINUS} {return symbol(Sym.MINUS,yytext());}
{TIMES} {return symbol(Sym.TIMES,yytext());}
{DIV} {return symbol(Sym.DIV,yytext());}
{MOD} {return symbol(Sym.MOD,yytext());}
{AND} {return symbol(Sym.ADD,yytext());}
{OR} {return symbol(Sym.OR,yytext());}
{NOT} {return symbol(Sym.NOT,yytext());}
{LPAR} {return symbol(Sym.LPAR,yytext());}
{RPAR} {return symbol(Sym.RPAR,yytext());}
{VIRG} {return symbol(Sym.VIRG,yytext());}
{PVIRG} {return symbol(Sym.PVIRG,yytext());}
{LCHA} {return symbol(Sym.LCHA,yytext());}
{RCHA} {return symbol(Sym.RCHA,yytext());}
{INT} { return symbol(Sym.INTL,yytext()); }
{FLOAT} {return symbol(Sym.FLOATL,yytext()); }
{SINGLECOMMENT} {}
{MULTICOMMENT} {}
{IGNORE} {}
{SPACE} {}
}
<<EOF>> {return symbol(Sym.EOF);}

[^] {throw new Error("Caractere invalido " + yytext() + " na linha " + (yyline+1) + ", coluna " + (yycolumn+1));}