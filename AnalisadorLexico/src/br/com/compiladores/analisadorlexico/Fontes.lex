package br.com.compiladores.analisadorlexico;
import java_cup.runtime.*;

%%

%{

private FontesToken createToken(String name,String value){
	return new FontesToken(name, value, yyline, yycolumn);
}

%}
%class AnalisadorLexicontes
%type FontesToken
%line
%column

WHITE = [\n| |\t|\r]+
ID = [a-z][a-zA-Z|0-9|_]*
CHAR = [\'][0-9|a-zA-Z|\n|\t| |:|\(|\)|\,][\']
SETOP = :=
RELOP = <|>|<=|>=|=|<>
ALOP = \+|-|\*|\/|%|"and"|"or"|"not"
SPSYM = \)|\(|,|;|\{|\}
KEYWORD = "if" | "else" | "while" | "return" | "float" | "char" | "void" | "prnt" | "int" | "and" | "or" | "not" | "proc" | "var"
INT = [+-][0-9]+|[0-9]+
FLOAT = [0-9]*,[0-9]+
REALEXP = [0-9]*,[0-9]+E[+-][0-9]*,[0-9]+
SINGLECOMMENT = \*{2}[\x20-\xED]*\n
MULTICOMMENT = >{2}[\x20-\xED|\n|\r|t]+<{2}
%%


{WHITE} { return createToken("Espaco em Branco", yytext()); }
{KEYWORD} {return createToken("Palavra Reservada", yytext());}
{ID} { return createToken("Identificador", yytext());}
{SINGLECOMMENT} {return createToken("Comentario de Linha Simples", yytext()); }
{MULTICOMMENT} {return createToken("Comentario Multi-Linhas", yytext()); }
{CHAR} {return createToken("Caracter literal", yytext());}
{SETOP} {return createToken("Operador de Atribuicao",yytext());}
{RELOP} {return createToken("Operador Relacionais", yytext()); }
{ALOP} {return createToken("Operador Logico-Aritmetico", yytext()); }
{SPSYM} {return createToken("Simbolo Especial",yytext());}
{INT} { return createToken("Numero Inteiro", yytext()); }
{FLOAT} {return createToken("Numero de Ponto Flutuante", yytext()); }
{REALEXP} {return createToken("Numero Real com Expoente",yytext());}
. { throw new RuntimeException("Caractere invalido " + yytext() + " na linha " + yyline + ", coluna " +yycolumn); }