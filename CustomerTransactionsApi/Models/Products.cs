namespace CustomerTransactionsApi.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string HumanIdentity { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string TotalPrice { get; set; }
    }
}
