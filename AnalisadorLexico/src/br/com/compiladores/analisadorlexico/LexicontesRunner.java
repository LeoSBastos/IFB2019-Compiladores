package br.com.compiladores.analisadorlexico;

import java.io.FileReader;
import java.io.IOException;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class LexicontesRunner {

	public List<FontesToken> run(String filename)  throws IOException{
		String rootPath = Paths.get("").toAbsolutePath(). toString();
        String subPath = "/src/br/com/compiladores/analisadorlexico/";

        String file = rootPath + subPath + filename;
        List<FontesToken> list = new ArrayList<>();
        AnalisadorLexicontes lexico = new AnalisadorLexicontes(new FileReader(file));
        FontesToken token;
        while((token = lexico.yylex()) != null) {
        	list.add(token);
        }
        return list;
	}
}
