using System;
using System.Collections.Generic;
using System.IO;

namespace RockInSenai_ARKDREAL.Models
{
    public class Musico : Usuario
    {
        public int OMB { get; set; }
        private const string PATH = "Database/musico.csv";

        public override bool Logar(string Email, string Senha)
        {
            List<string> csv = Musico.ReadAllLinesCSV("Database/musico.csv");

            var logado =
          csv.Find(
              x =>
              x.Split(";")[1] == Email &&
              x.Split(";")[2] == Senha

          );

            if (logado == null)
            {
                logado =
                csv.Find(
                x =>
                x.Split(";")[3] == Email &&
                x.Split(";")[2] == Senha

                );
            }

            if (logado == null)
            {
                return false;
            }

            return true;
        }

        private string PrepararLinha(Musico m)
        {
            return $"{m.Nome};{m.Email};{m.Senha};";
        }
        public void Create(Musico m)
        {
            string[] linha = { PrepararLinha(m) };
            File.AppendAllLines(PATH, linha);
        }

        internal static List<string> ReadAllLinesCSV(string v)
        {
            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
    }

}