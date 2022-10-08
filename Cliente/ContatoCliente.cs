using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace Cliente
{
    public class ContatoCliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ContatoCliente")]
        public string ClienteNome  { get; set; }

        public Int32 ClienteNumero { get; set; }

        public string ClienteEmail { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }

        public DateTime DataDelecao { get; set; }
    }
}
