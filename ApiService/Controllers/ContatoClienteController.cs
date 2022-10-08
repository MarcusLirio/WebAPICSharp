using Cliente;
using ClientService;
using ContatoClienteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoClienteController : ControllerBase
    {
        private readonly ContatoClienteServices _contatoClienteService;

        public ContatoClienteController(ContatoClienteServices contatoClienteServices)
        {
            _contatoClienteService = contatoClienteServices;
        }

        [HttpGet]
        public async Task<List<ContatoCliente>> GetContatoClientes() =>
            await _contatoClienteService.GetClientesAsync();

        [HttpPost]
        public async Task<ContatoCliente> PostContatoClientes(ContatoCliente contatoCliente)
        {
            await _contatoClienteService.CreateAsync(contatoCliente);

            return contatoCliente;
        }

        [HttpPut]
        public async Task<ContatoCliente> PutContatoClientes(string id,ContatoCliente contatoCliente)
        {
            await _contatoClienteService.UpdateAsync(id,contatoCliente);

            return contatoCliente;
        }

        [HttpDelete]
        public async Task<ContatoCliente> DeleteContatoCliente(string id, ContatoCliente contatoCliente)
        {
            await _contatoClienteService.RemoveAsync(id);

            return contatoCliente;
        }
    }
}
