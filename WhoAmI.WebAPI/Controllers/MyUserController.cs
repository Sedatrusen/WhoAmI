using MediatR;
using Microsoft.AspNetCore.Mvc;
using WhoAmI.Application.Features.MyUsers.Commands;
using WhoAmI.Core.Common;

namespace WhoAmI.WebAPI.Controllers
{
    public class MyUserController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MyUserController(IMediator mediator) { 
        _mediator = mediator;
        }

        public async Task<ActionResult<Result<Guid>>> Create(CreateMyUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
