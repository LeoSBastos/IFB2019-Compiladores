# IFB2019-Compiladores

Trabalho realizado para matéria de Compiladores do 7º semestre do curso de Ciência da Computação do Instituto Federal de Brasília - Campus Taguatinga.


## Definições da Linguagem

* Nome da linguagem: Fontes
  
* Um identificador (string que serve para dar nomes às variáveis e funções) é dado por
esta expressão regular: [a-z]\([a-zA-Z_]|[0-9])\* \
Observação: Lexemas deste token só podem iniciar com letra minúscula. Depois, podem
apresentar letras de qualquer caso, underline ou dígitos.
* Operadores relacionais: < | > | <= | >= | = | <>
* Operadores lógico-aritméticos (alguns são palavras reservadas também): + | - | * | / | % | and | or | not
* Operador de atribuição: :=
* Símbolos especiais: ) | ( | , | ; | { | }
* Palavras-chave reservadas: if | else | while | return | float | char | void | prnt | int | and | or | not | proc | var
* Valores inteiros literais: [0-9]+
* Valores inteiros literais com sinal. Exemplo. -68
* Valores reais (de ponto flutuante) literais: [0-9]\*,[0-9]+ | [0-9]+,[0-9]\*
* Valores reais (de ponto flutuante) literais e expoente. Exemplo. 23,55E-65,35
* Valores caracteres literais: “([0-9]|[a-zA-Z]|\n|\t| |:|(|)|,)”

## Ferramentas utilizadas
* Linguagem utilizada: Java
* Ferramenta utilizada para Análise Léxica: JFlex
* Ferramenta utilizada para Análise Sintática: Java CUP

## Status do projeto
* Análise Léxica construída, teste pendente
* Estudando como utilizar Java CUP

## Dificuldades
* Pouca informação em detalhes e com explicações recente para a utilização dos frameworks separados e/ou em conjuntos.
