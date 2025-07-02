using GymMembershipApi.BLL.Services;
using GymMembershipApi.BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace practice.Controllers
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
            return client == null ? NotFound() : Ok(client);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientDto createClientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdClient = await _clientService.CreateClientAsync(createClientDto);
            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedClient = await _clientService.UpdateClientAsync(id, updateDto);

            if (updatedClient == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            return Ok(updatedClient);
        }

        
        
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var success = await _clientService.DeleteClientAsync(id);

            if (!success)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            return NoContent(); 
        }
    }
}