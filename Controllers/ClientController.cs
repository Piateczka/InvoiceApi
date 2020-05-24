using System;
using System.Collections.Generic;
using AutoMapper;
using InvoiceApi.Models;
using InvoiceApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApi.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {

        DatabaseContext _context;
        private readonly IMapper _mapper;
        public ClientController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Route("[controller]/[action]")]
        [HttpGet]
        public IEnumerable<ClientDTO> GetClients() => _mapper.Map<IEnumerable<ClientDTO>>(_context.getClient());

        [HttpGet]
        [Route("[controller]/[action]&query={name}")]
        public List<ClientDTO> FindClientByName(string name) => _mapper.Map<List<ClientDTO>>(_context.FindClientByName(name));


        [HttpDelete]
        [Route("[controller]/[action]/{id}")]
        public List<ClientDTO> DeleteClient(int id) => _mapper.Map<List<ClientDTO>>(_context.DeleteClient(id));



        [HttpGet]
        [Route("[controller]/[action]&query={nip}")]
        public List<ClientDTO> FindClientByNip(string nip) => _mapper.Map<List<ClientDTO>>(_context.FindClientByNip(nip));

        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public ClientDTO GetClient(int id) => _mapper.Map<ClientDTO>(_context.GetClientById(id));

        [HttpPost]
        [Route("[controller]/[action]")]
        public IActionResult AddClient([FromBody]ClientDTO C)
        {
            var client = _mapper.Map<Client>(C);
            _context.AddClient(client);
            return Ok();
        }
        [HttpPut]
        [Route("[controller]/[action]/{id}")]
        public IActionResult UpdateClient(int id, [FromBody]ClientDTO c)
        {
            var client = _mapper.Map<Client>(c);
            client.ClientId = id;
            _context.UpdateClient(client);
            return Ok();
        }
    }
}