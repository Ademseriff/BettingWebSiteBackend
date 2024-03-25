using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Shared.Enums;

namespace PlayedCouponsApi.Models
{
    public class Basket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string PaidMoney { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string TotalMoney { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string TotalRate { get; set; }

        public StateEnum state { get; set; }
        public List<BasketContentList> contentLists { get; set; }
    }
}
