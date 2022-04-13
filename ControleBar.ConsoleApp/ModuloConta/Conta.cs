using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Mesa mesa;
        public Comanda comanda;
        public decimal gorjeta;

        public Mesa Mesa => mesa;
        public decimal Gorjeta => gorjeta;
        public Comanda Comanda => comanda;


        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Mesa da conta: " + Mesa + Environment.NewLine +
                "Comanda: " + comanda.produtosConsumidos.ToString() + Environment.NewLine;
        }

        public Conta(Mesa mesa)
        {
            this.mesa = mesa;
            this.comanda = null;
        }
    }
}
