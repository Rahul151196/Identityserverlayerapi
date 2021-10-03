using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOne.Controllers
{
    public class SecretController : Controller
    {
        [Route("/Secret")]
        [Authorize]
        public string Index()
        {
            return "I'm The Secret Message From ApiOne";    
        }
    }
}
