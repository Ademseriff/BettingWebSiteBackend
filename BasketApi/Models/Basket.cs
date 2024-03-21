using Shared.Enums;

namespace BasketApi.Models
{
    public class Basket
    {
        public Guid Id { get; set; }

        public string Tc { get; set; }
        public string Team1 { get; set; }

        public string Team2 { get; set; }

        public MatchSideEnum MatchSide { get; set; }

        public string Rate { get; set; }

    }
}
