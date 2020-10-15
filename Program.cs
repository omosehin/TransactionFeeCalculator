using System;

namespace TransactionFeeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the amount to transfer:");
            var amount = Convert.ToInt64(Console.ReadLine());
            ReadFile read = new ReadFile(amount);
            var res = read.Calculatefee();
            Console.WriteLine($"{res.TotalAmount} will be deducted from your account for sending {res.AmountSending} with charge of {res.TransferCharge}");

        }
    }
}
