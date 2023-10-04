using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Repositories;
using WhoAmI.Core.Application;
using WhoAmI.Core.Common;

namespace WhoAmI.Application.Features.Answers.Queries.GetAnswerByQuestionId
{
    public class GetAnswerByQuestionIdQuery:IRequest<Result<List<GetAnswerByQuestionIdDto>>>
    {
        public int QuestionId { get; set; }
        public GetAnswerByQuestionIdQuery(int questionId) {
           QuestionId = questionId;
        }
    }

    internal class GetAnswerByQuestionIdQueryHandler : IRequestHandler<GetAnswerByQuestionIdQuery, Result<List<GetAnswerByQuestionIdDto>>>
    {
        private readonly IUnitOfWork    _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAnswerRepository            _answerRepository;

        public GetAnswerByQuestionIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IAnswerRepository answerRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _answerRepository = answerRepository;
        }

        public async Task<Result<List<GetAnswerByQuestionIdDto>>> Handle(GetAnswerByQuestionIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _answerRepository.GetAnswerByQuesitonId(request.QuestionId);
            var answers = _mapper.Map<List<GetAnswerByQuestionIdDto>>(entities);
            return await Result<List<GetAnswerByQuestionIdDto>>.SuccessAsync(answers);
        }
    }
}
