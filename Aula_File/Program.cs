using System;
using System.IO;

namespace Aula_File
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Digite o nome do arquivo: ");
            var nome = Console.ReadLine();
            
            nome = LimparNome(nome);

            var path = Path.Combine(Environment.CurrentDirectory, $"{nome}.txt");

            CriarArquivo(path);
           
        }

        static string LimparNome(string nome)
        {
            foreach (var @char in Path.GetInvalidFileNameChars())
            {
                nome = nome.Replace(@char, '-');
            }
            return nome;
        }
        static void CriarArquivo(string path)
        {
             try
            {
                using var sw = File.CreateText(path);
                sw.WriteLine("coé");
            }
            catch
            {
                Console.WriteLine("O nome do arquivo está inválido");
            }
        }
    }
}