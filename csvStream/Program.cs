using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        CriarCsv();
    }
    static void CriarCsv()
    {
        var path = Path.Combine(Environment.CurrentDirectory,
        "Saida",
        "usuarios.csv");

        var pessoas = new List<Pessoa>(){
            new Pessoa()
            {
                Nome = "Rhanielly Pereira",
                Email = "rp@email.com",
                Telefone = 2345678,
                Nascimento = new DateTime(year: 1984, month: 3, day: 20)
            },
            new Pessoa()
            {
                Nome = "Jordinaldo Alcântara",
                Email = "ja@email.com",
                Telefone = 007,
                Nascimento = new DateTime(year: 2000, month: 10, day: 10)
            },
            new Pessoa()
            {
                Nome = "Miriane Souza",
                Email = "ms@email.com",
                Telefone = 226924,
                Nascimento = new DateTime(year: 1999, month: 1, day: 1)
            }
        };

        var di = new DirectoryInfo(path);
        if (!di.Exists)
        {
            di.Create();
            path = Path.Combine(path, "usuarios.csv");
        }
        using var sw = new StreamWriter(path);
        sw.WriteLine("nome,email,telefone,nascimento");
        foreach (var pessoa in pessoas)
        {
            var linha = $"{pessoa.Nome}, {pessoa.Email}, {pessoa.Telefone}, {pessoa.Nascimento}.";
            sw.WriteLine(linha);
        }
    }
    static void LerCsv()
    {
        var path = Path.Combine(Environment.CurrentDirectory,
        "Entrada",
        "usuarios-exportacao.csv");
        using var sr = new StreamReader(path);
        var cabecalho = sr.ReadLine()?.Split(',');
        while (true)
        {
            var registro = sr.ReadLine()?.Split(',');
            if (registro == null) break;
            for (int i = 0; i < registro.Length; i++)
            {
                System.Console.WriteLine($"{cabecalho?[i]}: {registro?[i]}");
            }
            System.Console.WriteLine("------------------");
        }
    }

}
class Pessoa
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Telefone { get; set; }
    public DateTime Nascimento { get; set; }
}