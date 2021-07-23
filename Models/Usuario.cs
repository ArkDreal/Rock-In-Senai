
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace RockInSenai_ARKDREAL.Models
{
    public class Usuario
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        protected string Senha { get; set; }

        private const string PATH = "Database/usuario.csv";

        [TempData]
        public string Mensagem { get; set; }

        public virtual bool Logar(string Email, string Senha)
        {
            bool entrar = false;
            List<string> csv = Usuario.ReadAllLinesCSV(PATH);

            var logado =
            csv.Find(
            x =>
             x.Split(";")[0] == Email &&
             x.Split(";")[1] == Senha
        );

            if (logado != null)
            {
                entrar = true;
               // Mensagem = "Dados incorretos, tente novamente...";//
                return entrar;
            }
            return entrar;
        }
        public Usuario()
        {
            CriarPastaEArquivo(PATH);

        }



        public void CriarPastaEArquivo(string _caminho)
        {

            string pasta = _caminho.Split("/")[0];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }
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

          internal static List<string> ReadAllLinesCSV(string v)
        {
             List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
    }
}
