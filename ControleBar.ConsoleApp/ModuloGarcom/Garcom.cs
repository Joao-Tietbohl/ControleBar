using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloConta;
using ControleBar.ConsoleApp.ModuloMesa;
using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public decimal Gorjeta { get; set; } = 0m;

        public List<Conta> contas;

        public Garcom()
        {

        }
        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Nome do garçom: " + Nome + Environment.NewLine +
                "Gorjetas recebidas: R$" + Gorjeta + Environment.NewLine;
        }

        public void ReceberGorjeta(decimal gorjetaCalculada)
        {
            Gorjeta += gorjetaCalculada;
        }


        public void AbrirConta(IRepositorio<Mesa> repositorioMesa, TelaCadastroMesa telaCadastroMesa)
        {
            Conta conta = ObterConta(repositorioMesa, telaCadastroMesa);
            contas.Add(conta);
            Notificador notificador = new Notificador();
            notificador.ApresentarMensagem("Conta aberta com sucesso", TipoMensagem.Sucesso);
        }

        private Conta ObterConta(IRepositorio<Mesa> repositorioMesa, TelaCadastroMesa telaCadastroMesa)
        {
            Console.WriteLine();

            telaCadastroMesa.VisualizarRegistros("");
            Console.WriteLine("Qual o ID da mesa da conta? ");
            int id = Int32.Parse(Console.ReadLine());
            bool existeRegistro = repositorioMesa.ExisteRegistro(id);
            while(existeRegistro == false)
            {
                Console.WriteLine();
                Console.WriteLine("ID inválido. Digite novamente: ");
                id = Int32.Parse(Console.ReadLine());
                existeRegistro = repositorioMesa.ExisteRegistro(id);
            }
            
            Mesa mesa = repositorioMesa.SelecionarRegistro(id);
            Conta conta = new Conta(mesa);

            return conta;

        }

        

        public bool VisualizarContas()
        {
            if (contas.Count == 0)
                return false;

            foreach (Conta item in contas)
            {
                Console.WriteLine(item.ToString());
            }
            return true;
        }

        public bool AdicionarPedidos()
        {
            Console.WriteLine();
            bool existemContas = VisualizarContas();
            if (existemContas == false)
                return true;

            Console.WriteLine("Digite o ID da conta: ");
            int id = Int32.Parse(Console.ReadLine());

            Conta contaAdicionar = contas.Find(x => x.id == id);

            Console.WriteLine();
            Console.WriteLine("Qual produto voce quer adicionar");



            return true;

        }
    }
}
