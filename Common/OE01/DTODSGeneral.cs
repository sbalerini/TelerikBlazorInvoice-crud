
namespace BlazorOE01.Common.OE01
{
    public class DTODSGeneral
    {
        public Dsgeneral dsCustomer { get; set; }
    }

    public class Dsgeneral
    {
        public TTCustomer[] ttCustomer { get; set; }
    }

    public class TTCustomer
    {
        public int CustNum { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

    }
}

