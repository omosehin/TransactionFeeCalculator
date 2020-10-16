using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TransactionFeeCalculator
{
    public class ReadFile
    {
        private readonly long _amount;

        public ReadFile(long amount)
        {
            _amount = amount;
        }
        public TransactionDetails Calculatefee()
        {
            int charge = 0;
            long TotalAmount = 0;

            var transaction = File.ReadAllText(@"C:\Users\ayobami.omosehin\Documents\TransactionFeeCalculator\Data\chargeFee.Json");
            dynamic transactionData = JsonConvert.DeserializeObject<List<TransactionFee>>(transaction);
            foreach (var item in transactionData)
            {
                if(_amount>= item.MinAmount && _amount <= item.MaxAmount)
                {
                    TotalAmount = _amount + item.FeeAmount;
                    charge = item.FeeAmount;
                }
            }

            return new TransactionDetails { AmountSending = _amount, TotalAmount = TotalAmount, TransferCharge = charge };
        }

    }
}
