using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class TelaCadastroMesa : TelaBase, ITelaCadastravel
    {
        private readonly Notificador _notificador;
        private readonly IRepositorio<Mesa> _repositorioMesa;
        public TelaCadastroMesa(IRepositorio<Mesa> repositorioMesa, Notificador notificador) : base("Cadastro Mesa")
        {
            this._repositorioMesa = repositorioMesa;
            this._notificador = notificador;
        }

        public void Editar()
        {
            MostrarTitulo("Editando Mesa");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma Mesa cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }


            int idMesa = ObterNumeroRegistro();

            Mesa mesaAtualizada = ObterMesa();

            bool conseguiuEditar = _repositorioMesa.Editar(idMesa, mesaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Garçom editado com sucesso!", TipoMensagem.Sucesso);
        }

        private int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o numero da mesa que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioMesa.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("Numero da mesa não foi encontrada, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        public void Excluir()
        {

            MostrarTitulo("Excluindo Mesa");

            bool temMesasRegistradas = VisualizarRegistros("Pesquisando");

            if (temMesasRegistradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma mesa cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroMesa = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioMesa.Excluir(numeroMesa);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Mesa excluída com sucesso!", TipoMensagem.Sucesso);
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Mesa");

            Mesa novaMesa = ObterMesa();

            _repositorioMesa.Inserir(novaMesa);

            _notificador.ApresentarMensagem("Mesa cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        private Mesa ObterMesa()
        {
            Console.WriteLine();
            Console.Write("Digite o numero da mesa: ");
            int numero = Int32.Parse(Console.ReadLine());

            Mesa mesa = new Mesa(numero);
            return mesa;
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
                if (tipoVisualizacao == "Tela")
                    MostrarTitulo("Visualização de Mesas Cadastradas");

                List<Mesa> mesas = _repositorioMesa.SelecionarTodos();

                if (mesas.Count == 0)
                {
                    _notificador.ApresentarMensagem("Nenhuma  mesa disponível.", TipoMensagem.Atencao);
                    return false;
                }
            Console.WriteLine("Numero das mesas cadastradas: ");
                foreach (Mesa mesa in mesas)
                    Console.Write(mesa.numero + ", ");

                Console.ReadLine();

                return true;
            }
    }
}
