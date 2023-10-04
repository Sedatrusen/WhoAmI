using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Application.Features.Questions.Commands;
using WhoAmI.Core.Application;
using WhoAmI.Core.Common;
using WhoAmI.Domain.Entities;
using WhoAmI.Domain.Enums;

namespace WhoAmI.Application.Features.Quizs.Command
{
    public class CreateQuizCommand : IRequest<Result<int>>,IMapFrom<Quiz>
    {
        public int UserId { get; set; }
        public required Collection<Question> Questions { get; set; }
        public QuizType QuizType { get; set; }
    }


    internal class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, Result<int>>
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IMapper mapper { get; set; }
        public IMediator mediator { get; set; }

        public CreateQuizCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<Result<int>> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new Quiz()
            {
                UserId = request.UserId,
                QuizType = request.QuizType,
                Questions = request.Questions,

            };
             await _unitOfWork.Repository<Quiz>().AddAsync(quiz);
           


            quiz.AddDomainEvent(new QuizCreatedEvent(quiz));
            await _unitOfWork.Save(cancellationToken);


           return await Result<int>.SuccessAsync(quiz.Id,"Quiz Created");

        
        }
    }
}
