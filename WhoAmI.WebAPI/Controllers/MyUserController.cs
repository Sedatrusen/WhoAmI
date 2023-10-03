using MediatR;
using Microsoft.AspNetCore.Mvc;
using WhoAmI.Application.Features.MyUsers.Commands;
using WhoAmI.Application.Features.MyUsers.Queries.GetMyUserByEmail;
using WhoAmI.Core.Common;

namespace WhoAmI.WebAPI.Controllers
{
    public class MyUserController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MyUserController(IMediator mediator) { 
        _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateMyUserCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<Result<GetMyUserByEmailDto>>> GetPlayersByClub(string userMail)
        {
            return await _mediator.Send(new GetMyUserByEmailQuery(userMail));
        }
    }
}
