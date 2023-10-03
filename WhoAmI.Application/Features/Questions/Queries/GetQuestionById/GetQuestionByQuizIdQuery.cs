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
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Questions.Queries.GetQuestionById
{
    public class GetQuestionByQuizIdQuery : IRequest<Result<GetQuesitonByQuizIdDto>>
    {
        public int Id { get; set; } 

        public GetQuestionByQuizIdQuery(int id) {
          Id = id;
        }
    }


    internal class GetQuesitonByIdQueryHandler :IRequestHandler<GetQuestionByQuizIdQuery, Result<GetQuesitonByQuizIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuesitonByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper,IQuestionRepository questionRepository)
        {
           _mapper = mapper;
           _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
        }

        public async Task<Result<GetQuesitonByQuizIdDto>> Handle(GetQuestionByQuizIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _questionRepository.GetQuesitonsByQuizId(request.Id);
            var question = _mapper.Map<GetQuesitonByQuizIdDto>(entity);
            return await Result<GetQuesitonByQuizIdDto>.SuccessAsync(question);
        }
    }
}
