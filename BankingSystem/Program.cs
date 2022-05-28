using System;

namespace BankingSystem
{
    public class Program
    {
        static List<Account> listAccounts = new List<Account>();
        public static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        EnterAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear(); break;

                    default:
                        throw new AbandonedMutexException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void ListAccounts()
        {
            Console.WriteLine("Listar Contas");

            if (listAccounts.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for (int i = 0; i < listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(account);
            }
        }

        private static void EnterAccount()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite [1] para conta Fisica ou [2] para Conta Juridica: ");
            short accountTypeEntry = short.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string nameEntry = Console.ReadLine();

            Console.Write("Digite o  saldo inicial: ");
            double balanceEntry = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double creditEntry = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountType: (AccountType)accountTypeEntry,
                                             balance: balanceEntry,
                                             credit: creditEntry,
                                             name: nameEntry);
            listAccounts.Add(newAccount);
        }

        private static void Transfer()
        {
            Console.Write("Digite o numero  da conta de origem: ");
            short originCounterIdenx = short.Parse(Console.ReadLine());

            Console.Write("Digite o numero  da conta de destino: ");
            short fateCounterIdenx = short.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double transferValue = double.Parse(Console.ReadLine());

            listAccounts[originCounterIdenx].Transfer(transferValue, listAccounts[fateCounterIdenx]);
        }
        private static void Withdraw()
        {
            Console.Write("Digite o numero da conta: ");
            short indexAccount = short.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            listAccounts[indexAccount].Withdraw(withdrawValue);
        }
        private static void Deposit()
        {
            Console.Write("Digite o numero da conta: ");
            short indexAccount = short.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double depositValue = double.Parse(Console.ReadLine());

            listAccounts[indexAccount].Deposit(depositValue);
        }
        private static string GetUserOption()
        {
            Console.WriteLine("\nR9 Bank a seu dispor!");
            Console.WriteLine("Informe opção desejada: ");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar ");
            Console.WriteLine("C - Limpar Tela ");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}