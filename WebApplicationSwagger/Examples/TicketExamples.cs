using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

using TicketingSystem.API.Resource;

namespace TicketingSystem.API.Examples
{
    public class TicketExamples : IExamplesProvider<object>
    {
        public object GetExamples()
        {
            return new List<TicketResource> {
                new TicketResource
                {
                    Name = "Help - 1",
                    DateCreated = DateTime.Now,
                    Deadline = DateTime.Now,
                    IssuerUserId = 1,
                    StatusId = 1,
                    TicketId = 1
                },
                new TicketResource
                {
                    Name = "Help - 2",
                    DateCreated = DateTime.Now,
                    Deadline = DateTime.Now,
                    IssuerUserId = 1,
                    StatusId = 1,
                    TicketId = 1
                },
            };
        }
    }
}
