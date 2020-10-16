using System;

namespace TransactionFeeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kindly input the amount to transfer:");
            string inputValue = Console.ReadLine();
            long value;
            if (long.TryParse(inputValue, out value))
            {
                ReadFile read = new ReadFile(value);
                var res = read.Calculatefee();
                Console.WriteLine($"N{String.Format("{0:n}", res.TotalAmount)} will be deducted from your account for sending N{String.Format("{0:n}", res.AmountSending)} with charge of N{res.TransferCharge} ");
            }
            else
            {
                Console.WriteLine("Only numbers is allowed");
            }
        }
    }
}
