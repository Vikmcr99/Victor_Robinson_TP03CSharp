using System;
using System.Linq;

namespace Victor_Robinson_TP03C
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine("---------- Gerenciador de Aniversários ----------");
            Console.WriteLine("");
            Console.WriteLine(" 1 - Adicionar Pessoa\n 2 - Pesquisar Pessoa\n 3 - Ver as Pessoas Cadastradas\n 4 - Sair");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    AdicionarPessoa();
                    break;
                case "2":
                    OpcoesPesquisar();
                    break;
                case "3":
                    MostrarPessoas();
                    break;
                case "4":
                    Console.WriteLine("Fechando Console........");
                    break;
                default:
                    Console.WriteLine("Opção invalida! tente novamente");
                    Console.Clear();
                    MenuPrincipal();
                    break;
            }
        }


        private static void AdicionarPessoa()
        {
            Console.Clear();

            Console.WriteLine("Informe o Nome da pessoa que deseja adicionar: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe agora o Sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.WriteLine("Informe a Data de Nascimento(DD/MM/YY): ");
            DateTime nascimento = DateTime.Parse(Console.ReadLine());


            if (nascimento.Month >= DateTime.Now.Month)
            {
                DateTime proxNiver = new DateTime(DateTime.Now.Year, nascimento.Month, nascimento.Day);
                TimeSpan aniversario = proxNiver.Subtract(DateTime.Today);
                Console.WriteLine("Faltam " + aniversario.Days + " dias para o aniversário de " + nome);
            }
            else
            {
                DateTime proxNiver = new DateTime(DateTime.Now.Year, nascimento.Month, nascimento.Day);
                TimeSpan aniversario = proxNiver.Subtract(DateTime.Today);
                Console.WriteLine("Faltam " + (365 + aniversario.Days) + " dias para o aniversário de " + nome);
            }

            Pessoa p1 = new Pessoa(nome, sobrenome, nascimento);
            BaseDados.Salvar(p1);
            MenuPrincipal();
        }

        private static void MostrarPessoas()
        {
            Console.Clear();

            if (BaseDados.PessoasListadas() == null)
                Console.WriteLine("Parece que ninguem foi cadastrado ainda!");
            else
            {
                foreach (var pessoa in BaseDados.PessoasListadas())
                {
                    Console.WriteLine($" Nome: {pessoa.Nome} " +
                        $" Nascido em: {pessoa.Nascimento} ");
                }
            }
            MenuPrincipal();
        }

        public static void OpcoesPesquisar()
        {
            Console.Clear();

            Console.WriteLine("---------- Pesquisar Pessoa ----------");
            Console.WriteLine("");
            Console.WriteLine("Selecione a forma de pesquisar abaixo:  ");
            Console.WriteLine(" 1 - Pesquisar  pelo Nome\n 2 - Pesquisar pela Data de Nascimento(DD/MM/YY) ");

            string opcao = Console.ReadLine();


            switch (opcao)
            {
                case "1":
                    PesquisaPeloNome();
                    break;
                case "2":
                    PesquisaPelaData();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    OpcoesPesquisar();
                    break;
            }
        }

        private static void PesquisaPelaData()
        {
            Console.Clear();

            Console.WriteLine("Informe a data no formato (DD/MM/YY): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            var pelaData = BaseDados.PessoasListadas().Where(pessoa => pessoa.Nascimento == dataNascimento);

            if (pelaData != null)
            {
                Console.WriteLine("Pessoa encontrada!");

                foreach (var pessoa in pelaData)
                {
                    Console.WriteLine(" Nome: " + pessoa.Nome + " " + pessoa.Sobrenome);
                    Console.WriteLine(" Nascido em: " + pessoa.Nascimento);
                }
            }
            else
                Console.WriteLine("Ops, Não foi encontrada nenhuma pessoa com esta Data");

            MenuPrincipal();
        }

        private static void PesquisaPeloNome()
        {
            Console.Clear();

            Console.WriteLine("Informe o Nome da pessoa que deseja pesquisar: ");
            string nome = Console.ReadLine();

            var peloNome = BaseDados.PessoasListadas().Where(pessoa => pessoa.Nome.Contains(nome, StringComparison.CurrentCultureIgnoreCase)|| pessoa.Sobrenome.Contains(nome, StringComparison.CurrentCultureIgnoreCase));

            if (peloNome != null)
            {
                Console.WriteLine("Pessoa encontrada!");

                foreach (var pessoa in peloNome)
                {
                    Console.WriteLine(" Nome: " + pessoa.Nome + " " + pessoa.Sobrenome);
                    Console.WriteLine(" Nascido em: " + pessoa.Nascimento);
                }
            }
            else
            {
                Console.WriteLine("Ops, Não foi encontrada nenhuma pessoa com este Nome");
            }

            MenuPrincipal();
        }
    }
}
