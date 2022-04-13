using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string nome;        
        public decimal valor;

        public string Nome => nome;
        public decimal Valor => valor;

        public Produto(string nome, decimal valor)
        {
            this.nome = nome;
            this.valor = valor;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Nome do produto: " + Nome + Environment.NewLine +
                "Valor: R$" + Valor + Environment.NewLine;
        }
    }
}
