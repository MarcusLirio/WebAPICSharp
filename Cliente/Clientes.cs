using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cliente
{
    public class Clientes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ClientName")]
        public string NomeCliente { get; set; }

        public Int32 ClientCNPJ { get; set; }

        public string ClientEndereco { get; set; }
    }
}
