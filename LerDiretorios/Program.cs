using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var path = @"C:\Users\lasco\dotnetProjects\Directory\globo";
        //LerDiretorios(path);
        LerArquivos(path);
    }
    static void LerArquivos(string path)
    {
        if (Directory.Exists(path))
        {
            var arquivos = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (var file in arquivos)
            {
                var fileInfo = new FileInfo(file);
                System.Console.WriteLine($"Nome: {fileInfo.Name}");
                System.Console.WriteLine($"Tamanho: {fileInfo.Length}");
                System.Console.WriteLine($"Ultimo acesso: {fileInfo.LastAccessTime}");

                System.Console.WriteLine("------------------------");
            }
        }
        else System.Console.WriteLine("O diretório não existe.");
    }
    static void LerDiretorios(string path)
    {
        if (Directory.Exists(path))
        {
            var diretorios = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            foreach (var dir in diretorios)
            {
                var dirInfo = new DirectoryInfo(dir);
                System.Console.WriteLine($"Nome: {dirInfo.Name}");
                System.Console.WriteLine($"Raíz: {dirInfo.Root}");
                if (dirInfo.Parent != null) System.Console.WriteLine($"Pai: {dirInfo.Parent.Name}");

                System.Console.WriteLine("------------------------");
            }
        }
        else System.Console.WriteLine("O diretório não existe.");
    }
}