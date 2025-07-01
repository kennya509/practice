using GymMembershipApi.DTOs;
using GymMembershipApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymMembershipApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAllClients([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var clients = await _clientService.GetAllClientsAsync(pageNumber, pageSize);
            return Ok(clients);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

    
        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateClient(int id, [FromBody] CreateClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedClient = await _clientService.UpdateClientAsync(id, clientDto);

            if (updatedClient == null)
            {
                return NotFound();
            }

            return Ok(updatedClient); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var success = await _clientService.DeleteClientAsync(id);

            if (!success)
            {
                return NotFound(); 
            }

          
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdClient = await _clientService.CreateClientAsync(clientDto);

            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
        }
    }
}