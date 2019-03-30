package br.com.compiladores.analisadorlexico;

public class AnalisadorLexicoException extends Exception {
	int row, col;
	
	public AnalisadorLexicoException(int row, int col) {
		this.row = row;
		this.col = col;
	}
	
	public String toString() {
		return "Caracter invalido na linha "+row+" e na coluna "+col+"!";
	}
}
