using System;
using MongoDB.Driver;
using Cliente;
using Microsoft.Extensions.Options;
using ClienteDataBaseSetting;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClientService
{
    public class ClienteService
    {
        private readonly IMongoCollection<Clientes> _clientesCollection;

        public ClienteService(IOptions<ClientDataBaseSetting> clientService)
        {
            var mongoClient = new MongoClient(clientService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(clientService.Value.DataBaseClient);

            _clientesCollection = mongoDatabase.GetCollection <Clientes>(clientService.Value.ClientCollectionName);
        }

        public async Task<List<Clientes>> GetClientesAsync() =>
            await _clientesCollection.Find(x => true).ToListAsync();

        public async Task<Clientes> GetClientesAsync(string id) =>
            await _clientesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Clientes clientes) =>
            await _clientesCollection.InsertOneAsync(clientes);

        public async Task UpdateAsync(string id, Clientes clientes) =>
            await _clientesCollection.ReplaceOneAsync(x => x.Id == id, clientes);

        public async Task RemoveAsync(string id) =>
            await _clientesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
