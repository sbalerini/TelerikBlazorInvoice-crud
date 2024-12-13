
namespace BlazorOE01.Common.OE01
{

    public class Rootobject
    {
        public Dsgeneral dsGeneral { get; set; }
    }

    public class Dsgeneral
    {
        public Ttinvoice[] ttinvoice { get; set; }

        public Ttestados[] ttestados { get; set; }
    }


    public class Ttinvoice
    {
        public int Invoicenum { get; set; }

        public int CustNum { get; set; }

        public int OrderNum { get; set; }
        public DateTime InvoiceDate { get; set; }

        public float Amount { get; set; }
        public float TotalPaid { get; set; }
        public float Adjustment { get; set; }
    }

    public class Ttestados
    {
        public string Estado { get; set; }

        public string Descripcion { get; set; }
    }




}

