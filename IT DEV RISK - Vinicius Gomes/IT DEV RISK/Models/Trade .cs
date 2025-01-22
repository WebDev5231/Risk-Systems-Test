using IT_DEV_RISK.Interfaces;
using System;

namespace IT_DEV_RISK.Models
{
    public class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }
        public bool IsPoliticallyExposed { get; }

        public Trade(double value, string clientSector, DateTime nextPaymentDate, bool isPoliticallyExposed)
        {
            // Padronizar o setor do cliente para primeira letra maiúscula e o restante minúsculo
            ClientSector = clientSector.Substring(0, 1).ToUpper() + clientSector.Substring(1).ToLower();

            Value = value;
            NextPaymentDate = nextPaymentDate;
            IsPoliticallyExposed = isPoliticallyExposed;
        }
    }
}
