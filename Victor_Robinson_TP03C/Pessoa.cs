using System;
using System.Collections.Generic;
using System.Text;

namespace Victor_Robinson_TP03C
{
    public class Pessoa
    {
        private string _nome;
        private string _sobrenome;
        private DateTime _nascimento;

        public Pessoa(string nome, string sobrenome, DateTime nascimento)
        {
            _nome = nome;
            _sobrenome = sobrenome;
            _nascimento = nascimento;
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Sobrenome
        {
            get { return _sobrenome; }
            set { _sobrenome = value; }
        }

        public DateTime Nascimento
        {
            get { return _nascimento; }
            set { _nascimento = value; }
        }
    }
}
