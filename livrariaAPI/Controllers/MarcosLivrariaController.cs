using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using Microsoft.AspNetCore.Mvc;

namespace livrariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcosLivrariaController : ControllerBase
    {
        private readonly LivrariaContext _context;
        public MarcosLivrariaController(LivrariaContext context)
        {
            _context = context;
        }
    }
}