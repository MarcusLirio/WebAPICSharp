using System;
using MongoDB.Driver;
using Cliente;
using Microsoft.Extensions.Options;
using ClienteDataBaseSetting;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ContatoClienteService
{
    public class ContatoClienteServices
    {
        private readonly IMongoCollection<ContatoCliente> _ContatoClienteCollection;

        public ContatoClienteServices(IOptions<ClientDataBaseSetting> contatoClienteService)
        {
            var mongoClient = new MongoClient(contatoClienteService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(contatoClienteService.Value.DataBaseClient);

            _ContatoClienteCollection = mongoDatabase.GetCollection<ContatoCliente>(contatoClienteService.Value.ContatoCollection);
        }

        public async Task<List<ContatoCliente>> GetClientesAsync() =>
            await _ContatoClienteCollection.Find(x => true).ToListAsync();

        public async Task<ContatoCliente> GetClientesAsync(string id) =>
            await _ContatoClienteCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ContatoCliente clientes) =>
            await _ContatoClienteCollection.InsertOneAsync(clientes);

        public async Task UpdateAsync(string id, ContatoCliente contatoCliente) =>
            await _ContatoClienteCollection.ReplaceOneAsync(x => x.Id == id, contatoCliente);

        public async Task RemoveAsync(string id) =>
            await _ContatoClienteCollection.DeleteOneAsync(x => x.Id == id);
    }
}
