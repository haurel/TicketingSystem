using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TicketingSystem.API.Resource;
using TicketingSystem.Core.Models;
using TicketingSystem.Core.Services;

namespace TicketingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketsController(ITicketService ticketService, IMapper mapper)
        {
            this._ticketService = ticketService;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketResource>> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            var ticketResource = _mapper.Map<Ticket, TicketResource>(ticket);

            return Ok(ticketResource);
        }


    }
}
