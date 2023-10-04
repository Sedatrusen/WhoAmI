using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using WhoAmI.Application.Features.Answers.Command;
using WhoAmI.Application.Features.MyUsers.Commands;
using WhoAmI.Application.Features.MyUsers.Queries.GetMyUserByEmail;
using WhoAmI.Application.Features.Questions.Commands;
using WhoAmI.Application.Features.Quizs.Command;
using WhoAmI.Application.Features.Quizs.Queries;
using WhoAmI.Core.Common;
using WhoAmI.Domain.Entities;

namespace WhoAmI.WebAPI.Controllers
{
    public class QuizController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateQuizCommand command)
        {
           
          return await _mediator.Send(command);
          
            
        }
        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<Result<GetQuizByIdDto>>> GetQuizById(int id)
        {
            return await _mediator.Send(new GetQuizByIdQuery(id));
        }
    }
}
