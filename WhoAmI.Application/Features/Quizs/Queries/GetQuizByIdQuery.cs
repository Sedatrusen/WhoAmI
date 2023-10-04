using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Application.Repositories;
using WhoAmI.Core.Application;
using WhoAmI.Core.Common;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Quizs.Queries
{
    public class GetQuizByIdQuery :IRequest<Result<GetQuizByIdDto>>
    {
        public int Id { get; set; } 
        public GetQuizByIdQuery(int id) {
        Id = id;
        }
    }

    internal class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, Result<GetQuizByIdDto>>
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public IQuestionRepository _questionRepository;
        public IAnswerRepository _answerRepository;

        public GetQuizByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<Result<GetQuizByIdDto>> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            var questionList = await _questionRepository.GetQuesitonsByQuizId(request.Id);
           
            var entity = await _unitOfWork.Repository<Quiz>().GetByIdAsync(request.Id);
            var quiz = _mapper.Map<GetQuizByIdDto>(entity);
            quiz.Questions = _mapper.Map<Collection<Question>>(questionList);
            foreach (var question in quiz.Questions)
            {
                var answerList = await _answerRepository.GetAnswerByQuesitonId(question.Id);


                question.Answers = _mapper.Map<Collection<Answer>>(answerList);
            }
            return await Result<GetQuizByIdDto>.SuccessAsync(quiz);
           
                
            
        }
    }
}
