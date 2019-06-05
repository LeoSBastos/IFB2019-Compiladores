package br.com.compiladores.analisadorlexico;

import java.io.File;
import java.nio.file.Paths;

public class FontesGenerator {

	public static void main(String[] args) {
		 String rootPath = Paths.get("").toAbsolutePath(). toString();
	        String subPath = "/src/br/com/compiladores/analisadorlexico/fontes/";

	        String file = rootPath + subPath + "Fontes.lex";

	        File sourceCode = new File(file);

	        jflex.Main.generate(sourceCode);


	}

}
