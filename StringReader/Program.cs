using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Caracteres na primeira linha yo");
        sb.AppendLine("na segunda joe");
        sb.AppendLine("e na terceira bro");

        using var sr = new StringReader(sb.ToString());
        var buffer = new char[10];
        var tamanho = 0;

        //do{
        //    System.Console.WriteLine(sr.ReadLine());
        //}while(sr.Peek() >= 0);

        do
        {
            buffer = new char[10];
            tamanho = sr.Read(buffer);
            System.Console.Write(buffer);
        }while(tamanho >= buffer.Length);
    }
}
