using Cliente;
using ClientService;
using ContatoClienteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<List<Clientes>> GetClientes()=>
            await _clienteService.GetClientesAsync();

        [HttpPost]
        public async Task<Clientes> PostCliente(Clientes clientes)
        {
            await _clienteService.CreateAsync(clientes);

            return clientes;
        }

        [HttpPut]
        public async Task<Clientes> PutCliente(string id, Clientes clientes)
        {
            await _clienteService.UpdateAsync(id, clientes);

            return clientes;
        }

        [HttpDelete]
        public async Task<Clientes> DeleteCliente(string id, Clientes clientes)
        {
            await _clienteService.RemoveAsync(id);

            return clientes;
        }
    }
}
