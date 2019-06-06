package br.com.compiladores.analisadorsintatico;

import br.com.compiladores.analisadorlexico.AnalisadorLexicontes;

import java.io.FileReader;
import java.nio.file.Paths;
public class SintaticontesRunner {
    public static void main(String[] args) {
        String rootPath = Paths.get("").toAbsolutePath().toString();
        String subPath = "/src/br/com/compiladores/";
        String sourcecode = rootPath + subPath + "programa2.font";

        try {
            AnalisadorSintaticontes p = new AnalisadorSintaticontes(new AnalisadorLexicontes(new FileReader(sourcecode)));
            Object result = p.parse().value;

            System.out.println("Compilação Fontosa");
        } catch (Exception e){
            e.printStackTrace();
        }
    }
}
