using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Core.Application;
using WhoAmI.Core.Common;
using WhoAmI.Domain.Entities;

namespace WhoAmI.Application.Features.Questions.Queries.GetQuestionById
{
    public class GetQuestionByIdQuery : IRequest<Result<GetQuesitonByIdDto>>
    {
        public int Id { get; set; } 

        public GetQuestionByIdQuery(int id) {
          Id = id;
        }
    }


    internal class GetQuesitonByIdQueryHandler :IRequestHandler<GetQuestionByIdQuery, Result<GetQuesitonByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetQuesitonByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _mapper = mapper;
           _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetQuesitonByIdDto>> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Question>().GetByIdAsync(request.Id);
            var question = _mapper.Map<GetQuesitonByIdDto>(entity);
            return await Result<GetQuesitonByIdDto>.SuccessAsync(question);
        }
    }
}
