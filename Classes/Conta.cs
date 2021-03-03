using System;

namespace DIO.Bank
{
    public class Conta
    {
        //Atributos da classe Conta
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        //Construtor
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        //Método Sacar
        public bool Sacar(double valorSaque)
        {
        // Validação de saldo suficiente
            if(this.Saldo - valorSaque < (this.Credito*-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            // 0 e 1 é referente ao que vem a seguir, 0 = this.Nome, 1 = this.Saldo
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        //Método Depositar
        public void Depositar(double valorDeposito)
        {
	        this.Saldo += valorDeposito;
	
	        Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        //Método Transferência
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
	        if(this.Sacar(valorTransferencia)){
	        contaDestino.Depositar(valorTransferencia);
            }
        }

        //Método para retornar String
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " || ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }
    }
}