using System;
using System.Collections.Generic;

namespace TransferenciaBancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            
            // Conta minhaConta = new Conta(TipoConta.PessoaFisica,0,0,"Caio Barbosa");
            // Console.WriteLine(minhaConta.ToString());
            //string opcaoUser = ObterOpcaoUsuario();
            string opcaoUser;

            do{
                opcaoUser = ObterOpcaoUsuario();

                switch(opcaoUser){
                    case "1":
                        ListarContas();    
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }while(opcaoUser!="X");

            
        }

        private static void Transferir()
        {
            Console.WriteLine("|Fazer uma Transferencia|");
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = int.Parse(Console.ReadLine());

            if(!ChecarValidadeDaConta(indiceContaOrigem) || !ChecarValidadeDaConta(indiceContaDestino)){
                Console.Write("Algum dos numero de conta é inválido");
                return;
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\tResumo da Transferencia");
            Console.WriteLine("---------------------------------------");
            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
            Console.WriteLine("---------------------------------------");
        }

        private static void Sacar()
        {

            Console.WriteLine("|Fazer um Saque|");
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = int.Parse(Console.ReadLine());

            if(!ChecarValidadeDaConta(indiceConta)){
                Console.Write("Numero de conta inválido");
                return;
            }

            listaContas[indiceConta].Sacar(valorSaque);
            
        }

        private static void Depositar()
        {
             Console.WriteLine("|Fazer um Deposito|");
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = int.Parse(Console.ReadLine());

            if(!ChecarValidadeDaConta(indiceConta)){
                Console.Write("Numero de conta inválido");
                return;
            }

            listaContas[indiceConta].Depositar(valorDeposito);
        }
        private static void ListarContas()
        {
            int cont = listaContas.Count;

            if(listaContas.Count ==0){
                Console.Write("Nenhuma conta Cadastrada");
            }

            Console.WriteLine("|Listando Contas|");

            for(int i =0; i < cont; i++){

                Console.Write("#{0} - ", (i));
                Console.WriteLine(listaContas[i]);
               
            }

        }

        private static void InserirConta()
        {
              Console.WriteLine();
              Console.WriteLine("Inserir nova conta");

              Console.Write("Digite 1 para conta Fisica ou 2 para Juridica: ");
              int entradaTipoConta = int.Parse(Console.ReadLine());

              Console.Write("Digite o nome do cliente: ");
              string entradaNome = Console.ReadLine();

              Console.Write("Digite o saldo inicial: ");
              double entradaSaldo = double.Parse(Console.ReadLine());

              Console.Write("Digite o crédito: ");
              double entradaCredito = double.Parse(Console.ReadLine());

              Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta , 
                                        saldo: entradaSaldo, 
                                        credito: entradaCredito, 
                                        nome: entradaNome);

              listaContas.Add(novaConta);
        }

        private static bool ChecarValidadeDaConta(int index){

            if(index >= listaContas.Count || index < 0){
                return false;
            }

            return true;
        }

        public static string ObterOpcaoUsuario(){

              Console.WriteLine();
              Console.WriteLine("----------------------");
              Console.WriteLine("|Bem vindo ao BadBank|");
              Console.WriteLine("----------------------");
              Console.WriteLine("\nInforme a opção desejada: ");

              Console.WriteLine("1 - Listar contas");
              Console.WriteLine("2 - Inserir nova conta");
              Console.WriteLine("3 - Transferir");
              Console.WriteLine("4 - Sacar");
              Console.WriteLine("5 - Depositar ");
              Console.WriteLine("C - Limpar Tela ");
              Console.WriteLine("X - Sair ");
              Console.WriteLine();

              Console.Write("Opção: ");
              string opcaoUser = Console.ReadLine().ToUpper();
              Console.WriteLine();
              return opcaoUser;

          }
    }
}
