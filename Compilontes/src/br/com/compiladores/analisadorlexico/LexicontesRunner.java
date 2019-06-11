package br.com.compiladores.analisadorlexico;

import java_cup.runtime.Symbol;

import java.io.FileReader;
import java.io.IOException;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class LexicontesRunner {

	public List<Symbol> run(String filename)  throws IOException{
		String rootPath = Paths.get("").toAbsolutePath().toString();
        String subPath = "/src/br/com/compiladores/";

        String file = rootPath + subPath + filename;
        List<Symbol> list = new ArrayList<>();
        AnalisadorLexicontes lexico = new AnalisadorLexicontes(new FileReader(file));
        Symbol token;
        while((token = lexico.next_token()).sym != 0) {
        	list.add(token);
        }
        return list;
	}
}
