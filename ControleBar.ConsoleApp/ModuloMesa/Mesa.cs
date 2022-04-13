using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        //public List<Cliente> ocupantes; 
        //public decimal conta;
        //public bool ocupada;
        public int numero;

        public Mesa(int numero)
        {
            this.numero = numero;
        }
    }
}