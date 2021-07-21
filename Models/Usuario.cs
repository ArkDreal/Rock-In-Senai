  
using System.Collections.Generic;
using System.IO;

namespace RockInSenai_ARKDREAL.Models
{
    public class Usuario
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        protected string Senha { get; set; }

        private const string PATH = "Database/usuario.csv";

        public Usuario()
        {
            CriarPastaEArquivo(PATH);
        }

        public virtual bool Logar(){
            bool logado = false;
            return logado;
        }
        
        public void CriarPastaEArquivo(string _caminho){

            string pasta   = _caminho.Split("/")[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }

            if(!File.Exists(_caminho)){
                File.Create(_caminho).Close();
            }
        }

        public void Create(Usuario u)
        {
            string[] linha = { PrepararLinha(u) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Usuario u)
        {
            return $"{u.Nome};{u.Email};{u.Senha};";
        }

        public List<Usuario> LerTodas()
        {
            List<Usuario> jogadores = new List<Usuario>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Usuario jogador = new Usuario();
                jogador.Senha = linha[0];
                jogador.Nome = linha[1];
                jogador.Email = linha[2];
              

                jogadores.Add(jogador);
            }
            return jogadores;
        }
    }
}
