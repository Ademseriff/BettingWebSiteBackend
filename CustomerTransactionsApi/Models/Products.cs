namespace CustomerTransactionsApi.Models
{
    public class Products
    {
        public Guid Id { get; set; }

        public string HumanIdentity { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string EMail { get; set; }

        public string TotalPrice { get; set; }
    }
}
