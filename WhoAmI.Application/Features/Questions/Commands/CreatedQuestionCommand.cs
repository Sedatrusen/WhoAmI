using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Application.Features.Answers.Command;
using WhoAmI.Core.Application;
using WhoAmI.Core.Common;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Questions.Commands
{
    public record CreatedQuestionCommand : IRequest<Result<int>>, IMapFrom<Question>
    {
        public required string Body { get; set; }
        public required Collection<Answer> Answers { get; set; }

        public required int QuizId { get; set; }
    }

    internal class CreatedQuestionCommandHandler : IRequestHandler<CreatedQuestionCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreatedQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Result<int>> Handle(CreatedQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question()
            {
                Body = request.Body,
                QuizId = request.QuizId,
                Answers = request.Answers,
            };

          await _unitOfWork.Repository<Question>().AddAsync(question);
           
            
            question.AddDomainEvent(new QuestionCreatedEvent(question));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(question.Id, "Quesiton Created.");
        }
    }
}
