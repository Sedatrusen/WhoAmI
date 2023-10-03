using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoAmI.Application.Repositories;
using WhoAmI.Core.Application;
using WhoAmI.Core.Common;

namespace WhoAmI.Application.Features.MyUsers.Queries.GetMyUserByEmail
{
    public record GetMyUserByEmailQuery : IRequest<Result<GetMyUserByEmailDto>>
    {
        public string Email { get; set; }

        public GetMyUserByEmailQuery(string email)
        {
            Email = email;
        }
    }

    internal class GetMyUserByEmailQueryHandler : IRequestHandler<GetMyUserByEmailQuery, Result<GetMyUserByEmailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetMyUserByEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper,IMyUserRepository userRepository )
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
            _userRepository = userRepository;

        }

        public async Task<Result<GetMyUserByEmailDto>> Handle(GetMyUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetMyUserByEmailAsync(request.Email);
            var user = _mapper.Map<GetMyUserByEmailDto>(entity);
            return await Result<GetMyUserByEmailDto>.SuccessAsync(user);
        }
    }
}
