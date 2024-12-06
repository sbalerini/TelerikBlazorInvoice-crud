
namespace BlazorOE01.Common.OE01
{

    public class Rootobject
    {
        public Dsgeneral dsGeneral { get; set; }
    }

    public class Dsgeneral
    {
        public Ttinvoice[] ttinvoice { get; set; }
    }

    public class Ttinvoice
    {
        public int Invoicenum { get; set; }

        public int CustNum { get; set; }
        public float Amount { get; set; }
        public float TotalPaid { get; set; }
        public float Adjustment { get; set; }
        public float ShipCharge { get; set; }
    }


}

