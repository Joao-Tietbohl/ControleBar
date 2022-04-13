using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloMesa;
using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class TelaCadastroGarcom : TelaBase
    {
        private readonly TelaCadastroMesa telaCadastroMesa;
        private readonly IRepositorio<Mesa> repositorioMesa;
        private readonly IRepositorio<Garcom> _repositorioGarcom;
        private readonly Notificador _notificador;

        public TelaCadastroGarcom(IRepositorio<Garcom> repositorioGarcom, TelaCadastroMesa telaCadastroMesa,
            IRepositorio<Mesa> repositorioMesa, Notificador notificador)
            : base("Cadastro de Garçons")
        {
            this._repositorioGarcom = repositorioGarcom;
            this._notificador = notificador;
            this.telaCadastroMesa = telaCadastroMesa;
            this.repositorioMesa = repositorioMesa;
            

        }


        public void Inserir()
        {
            MostrarTitulo("Cadastro de Garçom");

            Garcom novoGarcom = ObterGarcom();

            _repositorioGarcom.Inserir(novoGarcom);

            _notificador.ApresentarMensagem("Garçom cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Garçom");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum garçom cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Garcom garcomAtualizado = ObterGarcom();

            bool conseguiuEditar = _repositorioGarcom.Editar(numeroGenero, garcomAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Garçom editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Garçom");

            bool temFuncionariosRegistrados = VisualizarRegistros("Pesquisando");

            if (temFuncionariosRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum garçom cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroGarcom = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioGarcom.Excluir(numeroGarcom);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Garçom excluído com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Garçons Cadastrados");

            List<Garcom> garcons = _repositorioGarcom.SelecionarTodos();

            if (garcons.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum garçom disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Garcom garcom in garcons)
                Console.WriteLine(garcom.ToString());

            Console.ReadLine();

            return true;
        }

        private Garcom ObterGarcom()
        {
            Console.Write("Digite o nome do garçom: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CPF do garçom: ");
            string cpf = Console.ReadLine();

            return new Garcom(nome, cpf);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do garçom que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioGarcom.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do garçom não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Abrir Conta");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public bool AbrirConta()
        {
           
           List<Mesa> mesas = repositorioMesa.SelecionarTodos();
            if(mesas.Count == 0)
            {
                Notificador notificador = new Notificador();
                notificador.ApresentarMensagem("Nenhuma mesa Cadastrada.", TipoMensagem.Atencao);
                return true;
            }

            
            VisualizarRegistros("");
            Console.WriteLine("Digite o ID do graçom? ");
            int id = Int32.Parse(Console.ReadLine());

            bool existe = _repositorioGarcom.ExisteRegistro(id);

            Garcom chamaGarcom = new Garcom();
            
            chamaGarcom.AbrirConta(repositorioMesa, telaCadastroMesa);
            return true;
            
        }
    }
}