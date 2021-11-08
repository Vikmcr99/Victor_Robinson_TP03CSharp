using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Victor_Robinson_TP03C
{
    public class BaseDados
    {
        public static List<Pessoa> listaPessoas = new List<Pessoa>();
        public static void Salvar(Pessoa novaPessoa)
        {
            listaPessoas.Add(novaPessoa);
        }

        public static IEnumerable<Pessoa> PessoasListadas()
        {
            return listaPessoas;
        }
    }
}
