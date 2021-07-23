using System.Collections.Generic;
using System.IO;

namespace RockInSenai_ARKDREAL.Models
{
    public class Participante : Usuario
    {
        private const string PATH = "Database/.csv";

        public void ConfirmarChegada()
        {
            
        }
        public void ConfirmarChegada(string ConfirmarChegada)
        {
            
        }

        private string PrepararLinha(Participante p)
        {
            return $"{p.Nome};{p.Email};{p.Senha};";
        }
        public void Create(Participante p)
        {
            string[] linha = { PrepararLinha(p) };
            File.AppendAllLines(PATH, linha);
        }
    }
}