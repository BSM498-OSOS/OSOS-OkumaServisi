using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entity.Concrete
{
    [BsonIgnoreExtraElements]
    public class Reading : IEntity
    {
        [BsonElement("Obis000")]
        public int Obis000 { get; set; }

       /* [BsonElement("Obis080")]
        public int Obis080 { get; set; }

        [BsonElement("Obis091")]
        public string Obis091 { get; set; }*/

        [BsonElement("Obis092")]
        public DateTime Obis092 { get; set; }

       /* [BsonElement("Obis095")]
        public int Obis095 { get; set; }*/

        [BsonElement("Obis180")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public decimal Obis180 { get; set; }

        /*[BsonElement("Obis181")]
        public decimal Obis181 { get; set; }

        [BsonElement("Obis182")]
        public decimal Obis182 { get; set; }

        [BsonElement("Obis183")]
        public decimal Obis183 { get; set; }

        [BsonElement("Obis18mn")]
        public decimal[]? Obis18mn { get; set; }

        [BsonElement("Obis580")]
        public decimal Obis580 { get; set; }

        [BsonElement("Obis580mn")]
        public decimal[]? Obis580mn { get; set; }

        [BsonElement("Obis880")]
        public decimal Obis880 { get; set; }

        [BsonElement("Obis880mn")]
        public decimal[]? Obis880mn { get; set; }

        [BsonElement("Obis160")]
        public Obis160 Obis160 { get; set; }

        [BsonElement("Obis160n")]
        public Obis160[]? Obis160n { get; set; }

        [BsonElement("Obis010")]
        public int Obis010 { get; set; }

        [BsonElement("Obis012n")]
        public DateTime[]? Obis012n { get; set; }

        [BsonElement("Obis9613")]
        public DateTime Obis9613 { get; set; }

        [BsonElement("Obis9622")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Obis9622 { get; set; }

        [BsonElement("Obis9625")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Obis9625 { get; set; }

        [BsonElement("Obis9661")]
        public int Obis9661 { get; set; }

        [BsonElement("Obis9650")]
        public string Obis9650 { get; set; }

        [BsonElement("Obis9651")]
        public string Obis9651 { get; set; }

        [BsonElement("Obis9652")]
        public string Obis9652 { get; set; }

        [BsonElement("Obis9660")]
        public int Obis9660 { get; set; }

        [BsonElement("Obis9661T")]
        public int Obis9661T { get; set; }

        [BsonElement("Obis9662")]
        public int Obis9662 { get; set; }

        [BsonElement("Obis9670")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Obis9670 { get; set; }

        [BsonElement("Obis9671")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Obis9671 { get; set; }

        [BsonElement("Obis9671n")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime[]? Obis9671n { get; set; }

        [BsonElement("Obis9670K")]
        public int Obis9670K { get; set; }

        [BsonElement("Obis9671K")]
        public int Obis9671K { get; set; }

        [BsonElement("Obis9672K")]
        public int Obis9672K { get; set; }

        [BsonElement("Obis9673K")]
        public int Obis9673K { get; set; }

        [BsonElement("Obis9674")]
        public int Obis9674 { get; set; }

        [BsonElement("Obis96770n")]
        public Obis9677[]? Obis96770n { get; set; }

        [BsonElement("Obis96771n")]
        public Obis9677[]? Obis96771n { get; set; }

        [BsonElement("Obis96772n")]
        public Obis9677[]? Obis96772n { get; set; }

        [BsonElement("Obis96773n")]
        public Obis9677[]? Obis96773n { get; set; }

        [BsonElement("Obis96774n")]
        public Obis9677[]? Obis96774n { get; set; }

        [BsonElement("Obis96775n")]
        public Obis9677[]? Obis96775n { get; set; }*/

    }

    public class Obis160 : IEntity
    {
        [BsonElement("PDemant")]
        public decimal PDemant { get; set; }

        [BsonElement("PDemantDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime PDemantDate { get; set; }
    }

    public class Obis9677 : IEntity
    {
        [BsonElement("Start")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Start { get; set; }

        [BsonElement("End")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime End { get; set; }
    }

}