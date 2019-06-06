package br.com.compiladores.analisadorlexico;


import br.com.compiladores.analisadorsintatico.Sym;
import java_cup.runtime.Symbol;

import java.io.FileReader;
import java.io.IOException;
import java.nio.file.Paths;

public class Teste {
    public static void main(String[] args) throws IOException {

        String rootPath = Paths.get("").toAbsolutePath().toString();
        String subPath = "/src/br/com/compiladores/";

        String file = rootPath + subPath + "/programa.font";

        AnalisadorLexicontes lexico = new AnalisadorLexicontes(new FileReader(file));
        Symbol token;

        while ((token = lexico.next_token()) != null) {
            System.out.println("<" + Sym.terminalNames[token.sym] + ", " + token.value + "> (" + token.left + " - " + token.right + ")");
        }
    }
}
