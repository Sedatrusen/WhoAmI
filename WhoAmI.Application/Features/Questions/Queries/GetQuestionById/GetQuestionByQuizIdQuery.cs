using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Features.Answers.Queries.GetAnswerByQuestionId;
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
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public GetQuesitonByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper,IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<Result<GetQuesitonByQuizIdDto>> Handle(GetQuestionByQuizIdQuery request, CancellationToken cancellationToken)
        {
            var answerEntity = await _answerRepository.GetAnswerByQuesitonId(request.Id);

            var AnswerList = _mapper.Map<List<GetAnswerByQuestionIdDto>>(answerEntity);
            var entity = await _questionRepository.GetQuesitonsByQuizId(request.Id);
            
            var question = _mapper.Map<GetQuesitonByQuizIdDto>(entity);
            question.Answers =_mapper.Map<Collection<Answer>>(AnswerList);
            
            return await Result<GetQuesitonByQuizIdDto>.SuccessAsync(question);
        }
    }
}
