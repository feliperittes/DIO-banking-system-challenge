using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            AccountType = accountType;
            Balance = balance;
            Credit = credit;
            Name = name;
        }

        //Metodo Saque
        public bool Withdraw(double withdrawValue)
        {
            //Validação Saldo suficiente
            if (Balance - withdrawValue < (Credit * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            Balance -= withdrawValue;
            Console.WriteLine($"Saldo atual da conta {Name} é {Balance.ToString("C")}");
            return true;
        }

        //Metodo Deposito
        public void Deposit(double depositValue)
        {
            Balance += depositValue;

            Console.WriteLine($"Saldo atual da conta de {Name} é {Balance.ToString("C")}");
        }

        //Metodo tranferencia
        public void Transfer(double transfervalue, Account destinationAccount)
        {
            if (Withdraw(transfervalue))
            {
                destinationAccount.Deposit(transfervalue);
            }
        }
        public override string ToString()
        {
            string back = "";
            back += "TipoConta " + AccountType + " | ";
            back += "Nome " + Name + " | ";
            back += "Saldo " + Balance.ToString("C") + " | ";
            back += "Credito " + Credit.ToString("C");
            return back;
        }
    }
}

