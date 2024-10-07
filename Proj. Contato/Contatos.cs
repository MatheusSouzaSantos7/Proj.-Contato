using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Contato
{
    internal class Contatos
    {
        private readonly List<Contato> agenda = new List<Contato>();

        public bool adicionar(Contato c)
        {
            agenda.Add(c);
            return true;    
        }

        public Contato pesquisar(Contato c)
        {
            foreach (var contato in agenda)
            {
                if (Equals(contato, c));
                    return contato;
            }
            return null;
        }

        public bool Alterar(Contato c)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (Equals(agenda[i], c))
                {
                    agenda[i] = c; // Substitui o contato
                    return true;
                }
            }
            return false; // Retorna false se o contato não for encontrado
        }

        public bool remover(Contato c)
        {
            return agenda.Remove(c); // Remove o contato e retorna true se encontrado e removido, false caso contrário  
        }

        // Retorna a lista de contatos
        public List<Contato> Listar()
        {
            return agenda;
        }
    }
}
