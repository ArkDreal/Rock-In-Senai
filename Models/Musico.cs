using System;
using System.Collections.Generic;
using System.IO;

namespace RockInSenai_ARKDREAL.Models
{
    public class Musico : Usuario
    {
        public int OMB{ get; set; }
        private const string PATH = "Database/musico.csv";

        public override bool Logar(string Email, string Senha)
        {
            return
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
            throw new NotImplementedException();
        }
    }

}