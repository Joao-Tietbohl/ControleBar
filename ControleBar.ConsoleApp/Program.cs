using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;

namespace ControleBar.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TelaMenuPrincipal telaMenuPrincipal = new TelaMenuPrincipal(new Notificador());

            while (true)
            {
                TelaBase telaSelecionada = telaMenuPrincipal.ObterTela();

                if (telaSelecionada is null)
                    break;

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ITelaCadastravel)
                {
                    ITelaCadastravel telaCadastroBasico = (ITelaCadastravel)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroBasico.Inserir();

                    if (opcaoSelecionada == "2")
                        telaCadastroBasico.Editar();

                    if (opcaoSelecionada == "3")
                        telaCadastroBasico.Excluir();

                    if (opcaoSelecionada == "4")
                        telaCadastroBasico.VisualizarRegistros("Tela");
                }

                if(telaSelecionada is TelaCadastroGarcom)
                {
                    TelaCadastroGarcom telaCadastroGarcom = (TelaCadastroGarcom)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroGarcom.Inserir();

                    if (opcaoSelecionada == "2")
                        telaCadastroGarcom.Editar();

                    if (opcaoSelecionada == "3")
                        telaCadastroGarcom.Excluir();

                    if (opcaoSelecionada == "4")
                        telaCadastroGarcom.VisualizarRegistros("Tela");

                    if (opcaoSelecionada == "5")
                       telaCadastroGarcom.AbrirConta();
                    
                    if(opcaoSelecionada == "6")
                        telaCadastroGarcom
                }
            }
        }
    }
}
