using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var path = @"C:\Users\lasco\dotnetProjects\Directory\globo";

        using var fsw = new FileSystemWatcher(path);
        fsw.Created += OnCreated;
        fsw.Renamed += OnRenamed;
        fsw.Deleted += OnDeleted;

        fsw.EnableRaisingEvents = true;
        fsw.IncludeSubdirectories = true;
        System.Console.WriteLine("pressione [enter] para finalizar ....");
        Console.ReadLine();
    }

    private static void OnDeleted(object sender, FileSystemEventArgs e)
    {
        System.Console.WriteLine($"Foi deletado o arquivo {e.Name}");
    }

    private static void OnRenamed(object sender, RenamedEventArgs e)
    {
        System.Console.WriteLine($"O arquivo {e.OldName} foi renomeado para {e.Name}");
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        System.Console.WriteLine($"Foi criado o arquivo {e.Name}");
    }
}