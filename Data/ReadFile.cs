using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TransactionFeeCalculator
{
    public class ReadFile
    {
        private readonly long _amount;

        public ReadFile(long Amount)
        {
            _amount = Amount;
        }
        public TransactionDetails Calculatefee()
        {
            int charge = 0;
            long TotalAmount = 0;
            var amount = _amount;

            var transaction = File.ReadAllText(@"C:\Users\ayobami.omosehin\Documents\TransactionFeeCalculator\Data\chargeFee.Json");
            dynamic transactionData = JsonConvert.DeserializeObject<List<TransactionFee>>(transaction);
            foreach (var item in transactionData)
            {
                if(amount> item.MinAmount && amount < item.MaxAmount)
                {
                    TotalAmount = amount + item.FeeAmount;
                    charge = item.FeeAmount;
                }
            }

            return new TransactionDetails { AmountSending = amount, TotalAmount = TotalAmount, TransferCharge = charge };
        }

    }
}
