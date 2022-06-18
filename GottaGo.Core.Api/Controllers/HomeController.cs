// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using Microsoft.AspNetCore.Mvc;

namespace GottaGo.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => Ok("Hello world!");
    }
}