﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Contato
{
    internal class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public int Dia { get => dia; set => dia = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Ano { get => ano; set => ano = value; }

        // Construtores
        public Data(int dia, int mes, int ano)
        {
            dia = dia;
            mes = mes;
            ano = ano;
            
        }
        public Data(int ano): this(0,0,ano) {}
        public Data(): this (DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year) {}

        void setData(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        //  -> retornando "dd/mm/aaaa"
        string ToString()
        {
            return dia + "/" + mes + "/" + ano;
        }


        
    }
}
