using System.Collections.Generic;
using System.Threading.Tasks;
using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarksFoodApi.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SnackController : ControllerBase
    {
        private readonly ISnackService _snackService;

        public SnackController(ISnackService snackService)
        {
            _snackService = snackService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SnackOutput>>> Get()
        {
            var snacks = await _snackService.GetAllSnacks();
            return Ok(snacks);
        }
    }
}