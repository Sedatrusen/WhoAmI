using MediatR;
using Microsoft.AspNetCore.Mvc;
using WhoAmI.Application.Features.Answers.Command;
using WhoAmI.Application.Features.MyUsers.Commands;
using WhoAmI.Application.Features.MyUsers.Queries.GetMyUserByEmail;
using WhoAmI.Application.Features.Questions.Commands;
using WhoAmI.Application.Features.Quizs.Command;
using WhoAmI.Application.Features.Quizs.Queries;
using WhoAmI.Core.Common;

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
            var quizId = await _mediator.Send(command);
            foreach (var item in command.Questions)
            {
                CreatedQuestionCommand createdQuestionCommand = new CreatedQuestionCommand()
                {
                    Answers = item.Answers,
                    Body = item.Body,
                    QuizId = quizId.Data
                };
               var questionId =  await _mediator.Send(createdQuestionCommand);
                foreach (var answer in item.Answers) {
                CreateAnswerCommand createAnswerCommand = new CreateAnswerCommand() { Body = answer.Body,
                 IsSelected = answer.IsSelected,
                 IsTrue = answer.IsTrue,
                 QuestionId= questionId.Data };
                }
            }

            return Result<int>.Success();
            
        }
        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<Result<GetQuizByIdDto>>> GetQuizById(int id)
        {
            return await _mediator.Send(new GetQuizByIdQuery(id));
        }
    }
}
