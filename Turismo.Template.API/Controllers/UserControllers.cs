using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismo.Template.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        public UserControllers (IUserService service)
        {

        }

    }
}
