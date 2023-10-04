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

namespace WhoAmI.Application.Features.QuizResults.Command
{
    public class CreateQuizResultCommand : IRequest<Result<int>>,IMapFrom<QuizResult>
    {
        public string AnswererName { get; set; }
        public int TrueAnswer { get; set; }
        public int FalseAnswer { get; set; }
        public int QuizId { get; set; }
    }

    internal class CreateQuizResulCommandHandler : IRequestHandler<CreateQuizResultCommand, Result<int>>
    { 
        private readonly IUnitOfWork     _unitOfWork;
        private readonly IMapper _mapper;

        public CreateQuizResulCommandHandler (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
        {
            var quizResult = new QuizResult()
            {
                AnswererName = request.AnswererName,
                TrueAnswer = request.TrueAnswer,
                FalseAnswer = request.FalseAnswer,
                QuizId = request.QuizId,
                };
            await _unitOfWork.Repository<QuizResult>().AddAsync(quizResult);
            quizResult.AddDomainEvent(new QuizResultCreatedEvent(quizResult));
            return await Result<int>.SuccessAsync(quizResult.Id,"Quiz Result Created");
        }
    }
}
