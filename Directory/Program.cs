using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        CriarDiretoriosGlobo();
        CriarArquivo();
        var origem = Path.Combine(Environment.CurrentDirectory, "USA.txt");
        var destino = Path.Combine(Environment.CurrentDirectory, "globo", "América do Norte", "USA", "USA.txt");
        //MoverArquivo(origem, destino);
        CopiarArquivo(origem, destino);
    }

    static void CopiarArquivo(string currPath, string newPath)
    {
        if (!File.Exists(currPath))
        {
            System.Console.WriteLine("Arquivo de origem não existe.");
            return;
        }
        if (File.Exists(newPath))
        {
            System.Console.WriteLine("Arquivo já existe na pasta de origem.");
            return;
        }
        File.Copy(currPath, newPath);
    }
    static void MoverArquivo(string currPath, string newPath)
    {
        if (!File.Exists(currPath))
        {
            System.Console.WriteLine("Arquivo de origem não existe.");
            return;
        }
        if (File.Exists(newPath))
        {
            System.Console.WriteLine("Arquivo já existe na pasta de origem.");
            return;
        }
        File.Move(currPath, newPath);
    }
    static void CriarArquivo()
    {
        var path = Path.Combine(Environment.CurrentDirectory, "USA.txt");
        if (!File.Exists(path))
        {
            using var sw = File.CreateText(path);
            sw.WriteLine("Vermelho");
            sw.WriteLine("Branco");
            sw.WriteLine("Azul");
            sw.WriteLine("Estrelas");
        }
    }
    static void CriarDiretoriosGlobo()
    {
        var path = Path.Combine(Environment.CurrentDirectory, "globo");
        if (!Directory.Exists(path))
        {
            var dirGlobo = Directory.CreateDirectory(path);

            var dirAmNorte = dirGlobo.CreateSubdirectory("América do Norte");
            var dirAmCentral = dirGlobo.CreateSubdirectory("América Central");
            var dirAmSul = dirGlobo.CreateSubdirectory("América do Sul");

            dirAmNorte.CreateSubdirectory("USA");
            dirAmNorte.CreateSubdirectory("México");
            dirAmNorte.CreateSubdirectory("Canadá");

            dirAmCentral.CreateSubdirectory("Costa Rica");
            dirAmCentral.CreateSubdirectory("Panama");
            dirAmCentral.CreateSubdirectory("Honduras");

            dirAmSul.CreateSubdirectory("Brasil");
            dirAmSul.CreateSubdirectory("Argentina");
            dirAmSul.CreateSubdirectory("Paraguai");
        }

    }
}
