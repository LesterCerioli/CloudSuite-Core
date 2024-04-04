
using NetDevPack.Domain;

namespace CloudSuite.Domain.ValueObjects
{
    public class Method : ValueObject
    {

        public bool? PIX {  get; private set; }

        public bool? BankSlip {  get; private set; }

        public Method(bool? pIX, bool? bankSlip)
        {
            PIX = pIX;
            BankSlip = bankSlip;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
