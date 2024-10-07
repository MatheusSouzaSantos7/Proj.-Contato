using System;
using System.Collections.Generic;

namespace Proj.Contato
{
    internal class Contato
    {
        // Atributos
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones;

        // Métodos Construtores
        public Contato(string nome, string email, Data dtNasc, Telefone telefone)
        {
            this.nome = nome;
            this.email = email;
            this.dtNasc = dtNasc;
            this.telefones = new List<Telefone>();
            this.adicionarTelefone(telefone);
        }

        public Contato(string nome, string email, Data dtNasc) : this(nome, email, dtNasc, new Telefone()) { }

        
        public int getIdade()
        {
            Data dataAtual = new Data(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            int idade = dataAtual.Ano - dtNasc.Ano;

            
            if (dataAtual.Mes < dtNasc.Mes || (dataAtual.Mes == dtNasc.Mes && dataAtual.Dia < dtNasc.Dia))
            {
                idade--;
            }

            return idade;
        }

        
        public void adicionarTelefone(Telefone t)
        {
            telefones.Add(t);
        }

        
        public string getTelefonePrincipal()
        {
            foreach (var telefone in telefones)
            {
                if (telefone.Principal)
                {
                    return telefone.Numero;
                }
            }
            return "Telefone principal não encontrado";
        }

        
        public override string ToString()
        {
            return $"Nome: {nome}\n" +
                   $"Email: {email}\n" +
                   $"Data de Nascimento: {dtNasc}\n" +
                   $"Idade: {getIdade()} anos\n" +
                   $"Telefone principal: {getTelefonePrincipal()}";
        }


        public override bool Equals(object obj)
        {
            return this.getTelefonePrincipal() == ((Contato)obj).getTelefonePrincipal();
        }



    }
}
