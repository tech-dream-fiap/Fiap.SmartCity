using Domain.Aggregates;
using Domain.Commands;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public readonly RepositoryContext _context;

        public UserController(RepositoryContext context)
        {
            _context = context;
        }
    }
}
