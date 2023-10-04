using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Repositories;
using WhoAmI.Core.Common;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.QuizResults.Queries
{
    public class GetQuizResultByQuizIdQuery : IRequest<Result<List<GetQuizResultByQuizIdDto>>>
    {
        public int id;
        public GetQuizResultByQuizIdQuery(int id)
        {
            this.id = id;
        }
    }


    internal class GetQuizResultByQuizIdQueryHandler : IRequestHandler<GetQuizResultByQuizIdQuery, Result<List<GetQuizResultByQuizIdDto>>>
    {
        private readonly IQuizResultRepository _quizResultRepository;
        private readonly IMapper _mapper;

        public GetQuizResultByQuizIdQueryHandler(IMapper mapper, IQuizResultRepository quizResultRepository  ) {
            _quizResultRepository = quizResultRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetQuizResultByQuizIdDto>>> Handle(GetQuizResultByQuizIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _quizResultRepository.GetAllQuizResultsByQuizIdAsync(request.id);
            var quizResult = _mapper.Map<List<GetQuizResultByQuizIdDto>>(entity);
            return await Result<List<GetQuizResultByQuizIdDto>>.SuccessAsync(quizResult);
        }
    }
}
