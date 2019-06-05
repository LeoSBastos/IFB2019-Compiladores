package br.com.compiladores.analisadorlexico;

public class FontesToken {
	public String name;
	public String value;
	public Integer line;
	public Integer column;
	
	public FontesToken(String name, String value, Integer line, Integer column) {
		this.name = name;
		this.value = value;
		this.line = line;
		this.column = column;
	}
}
