using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloCliente
{
    public class TelaCadastroCliente : TelaBase, ITelaCadastravel
    {
       /* private readonly IRepositorio<Cliente> _repositorioCliente;
        private readonly Notificador _notificador;

        public TelaCadastroCliente(IRepositorio<Cliente> _repositorioCliente, Notificador _notificador) : base("Cadastro de Clientes")
        {
            _repositorioCliente = _repositorioCliente;
            _notificador = _notificador;
        }

        public void Editar()
        {
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        public void Inserir()
        {

            MostrarTitulo("Cadastro de CLiente");

            Cliente novoCliente = ObterCliente();

            _repositorioCliente.Inserir(novoCliente);

            _notificador.ApresentarMensagem("Cliente cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            throw new NotImplementedException();
        }

        private Cliente ObterCliente()
        {
            Console.WriteLine();
            Console.Write("Digite o nome do Cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Qual a mesa do cliente?: ");
            Console.Write("Mesas vagas: ");
            Cliente cliente = new Cliente();
            return cliente;
        }
       */
    }
}
