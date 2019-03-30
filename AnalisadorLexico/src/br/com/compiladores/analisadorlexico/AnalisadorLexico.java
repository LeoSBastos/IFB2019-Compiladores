package br.com.compiladores.analisadorlexico;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.LinkedHashSet;
import java.util.Set;

import javax.swing.JOptionPane;

public class AnalisadorLexico {

	static boolean flag = true;
	static boolean flag2 = false;
	static void igual(Character c1, Character c2) {
		if (Character.isLetter(c1)) {
			Character.toLowerCase(c1);
		}
		if (Character.isLetter(c2)) {
			Character.toLowerCase(c2);
		}
		if (c1.equals(c2)) {
			flag2 = true;
		}
	}

	static void erro(int row, int col) throws AnalisadorLexicoException {
		if (!flag2) {
			flag = false;
			throw new AnalisadorLexicoException(row, col);
		}
	}

	public static void main(String[] args) {
		String filename = JOptionPane.showInputDialog("Digite o nome do arquivo a ser lido: ");
		String line, line2;
		Set<Character> DictSet = new LinkedHashSet<>();
		try {
			FileReader fr = new FileReader("base.txt");
			FileReader fr2 = new FileReader(filename);
			BufferedReader br = new BufferedReader(fr);
			BufferedReader br2 = new BufferedReader(fr2);
			while ((line = br.readLine()) != null) {
				line.chars().forEachOrdered(i -> DictSet.add((char) i));
			}
			for (int i = 0; (line2 = br2.readLine()) != null; i++) {
				for (int j = 0; j < line2.length(); j++) {
					for (char c : DictSet) {
						flag2=false;
						igual(line2.charAt(j), c);
						if (flag2) {
							break;
						}
					}
					try {
						erro(i, j+1);
					} catch (AnalisadorLexicoException e) {
						e.printStackTrace();
					}
				}
			}
			if (flag) {
				System.out.println("Arquivo esta com todos os caracteres validos.");
			}
			br.close();
			br2.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

}
