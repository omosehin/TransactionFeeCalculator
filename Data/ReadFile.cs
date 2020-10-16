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
            //var fileJson = File.ReadAllText(@"C:\Users\ayobami.omosehin\Documents\TransactionFeeCalculator\Data\chargeFee.Json");
            string relativePath = "..\\Data\\chargeFee.Json";
            string fullPathToFirstFile = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(relativePath), "chargeFee.Json"));
            string filePath = fullPathToFirstFile.Replace("\\bin\\Debug", "");
            var fileJson = File.ReadAllText(filePath);

            var transactionData = JsonConvert.DeserializeObject<List<TransactionFee>>(fileJson);
            
            return getTransferDetails(transactionData);
        }

        private TransactionDetails getTransferDetails(List<TransactionFee> transactionData)
        {
            int charge = 0;
            long TotalAmount = 0;
            foreach (var item in transactionData)
            {
                if (_amount >= item.MinAmount && _amount <= item.MaxAmount)
                {
                    TotalAmount = _amount + item.FeeAmount;
                    charge = item.FeeAmount;
                }
            }

            return new TransactionDetails { AmountSending = _amount, TotalAmount = TotalAmount, TransferCharge = charge };
        }
    }
}
