using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public GetQuizByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IQuestionRepository questionRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public async Task<Result<GetQuizByIdDto>> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
          var questionList = _questionRepository.GetQuesitonsByQuizId(request.Id);
            var entity = _unitOfWork.Repository<Quiz>().GetByIdAsync(request.Id);
             var quiz = _mapper.Map<GetQuizByIdDto>(entity);
            quiz.Questions = _mapper.Map<Collection<Question>>(questionList);

            return await Result<GetQuizByIdDto>.SuccessAsync(quiz);
           
                
            
        }
    }
}
