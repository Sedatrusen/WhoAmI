using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Core.Application;
using WhoAmI.Core.Common;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Answers.Command
{
    public  record CreateAnswerCommand : IRequest<Result<int>>, IMapFrom<Answer>
    {
        public required string Body { get; set; }
        public bool IsTrue { get; set; }
        public bool IsSelected { get; set; }

        public int QuestionId { get; set; }
    }

    internal class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, Result<int>>
    { private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateAnswerCommandHandler (IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
           var answer = new Answer { 
               Body = request.Body,
               IsTrue= request.IsTrue,
               IsSelected= request.IsSelected,
               QuestionId= request.QuestionId,
            };

            await unitOfWork.Repository<Answer>().AddAsync(answer);
            answer.AddDomainEvent(new AnswerCreatedEvent(answer));
            await unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(answer.Id, "Answer Created");
        }
    }
}
