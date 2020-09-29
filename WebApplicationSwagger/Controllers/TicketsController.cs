using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using TicketingSystem.API.Examples;
using TicketingSystem.API.Resource;
using TicketingSystem.Core.Models;
using TicketingSystem.Core.Services;

namespace TicketingSystem.API.Controllers
{
    [Route("api/ticket")]
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

        /// <summary>
        /// Get a specific Ticket.
        /// </summary>
        /// 
        /// <returns> Return a ticket </returns>
        /// <param name="id"></param>
        /// <response code="500">If the item not exist</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketResource>> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            var ticketResource = _mapper.Map<Ticket, TicketResource>(ticket);

            return Ok(ticketResource);
        }

        /// <summary>
        /// Get All Tickets
        /// </summary>
        /// <returns>List of all Tickets </returns>
        [HttpGet]
        [SwaggerResponseExample((int)System.Net.HttpStatusCode.OK, typeof(TicketExamples))]
        public async Task<ActionResult<IEnumerable<TicketResource>>> GetTickets()
        {
            var ticket = await _ticketService.GetAllWithUser();
            var ticketResource = _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketResource>>(ticket);

            return Ok(ticketResource);

        }

        /// <summary>
        /// Creates a Ticket
        /// </summary>
        /// <remarks>
        /// 
        ///     POST api/ticket
        ///     {
        ///         "ticketId": 0,
        ///         "dataCreated": "2020-09-29T19:11:09.590Z",
        ///         "name": "string",
        ///         "issuerUserId": 0,
        ///         "deadline": "2020-09-29T19:11:09.590Z",
        ///         "statusId": 0
        ///     }
        /// 
        /// </remarks>
        /// <param name="newTicket"></param>
        /// <returns>New Created Ticket Item</returns>
        /// <response code="201">Returns the current IDENTITY from databse</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TicketResource>> InsertTicket([FromBody] TicketResource newTicket)
        {
            var ticket = _mapper.Map<TicketResource, Ticket>(newTicket);
            var dataResult = await _ticketService.InsertTicket(ticket);

            return Ok(dataResult);
        }

        /// <summary>
        /// Partial Update Ticket
        /// </summary>
        /// <remarks>
        /// 
        ///     PATCH api/ticket/{id}
        ///     [
        ///         {
        ///             "path": "/name",
        ///             "op": "replace",
        ///             "value" : "new-ticket-name"
        ///         },
        ///         {
        ///             "path": "/userId",
        ///             "op": "replace",
        ///             "value" : "new-user-id"
        ///         }
        ///     ]
        ///     .....
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="patch"></param>
        /// <returns>Updated Ticket Item</returns>
        /// <response code="201">Returns the current Ticket after update </response>
        /// <response code="400">If the op is failed</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(TicketResource), 201)]
        public async Task<ActionResult<int>> UpdateTicket(int id, [FromBody] JsonPatchDocument<TicketResource> patch)
        {
            if(patch != null)
            {
                var tempTicket = await _ticketService.GetTicketById(id);
                var ticket = _mapper.Map<Ticket, TicketResource>(tempTicket);
                patch.ApplyTo(ticket);


                var entry = _mapper.Map<TicketResource, Ticket> (ticket);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _ticketService.UpdateTicket(id, entry);

                return new ObjectResult(entry);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

    }
}
