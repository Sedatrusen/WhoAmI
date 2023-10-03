using AutoMapper;
using MediatR;
using System.Collections.ObjectModel;
using WhoAmI.Application.Common.Mappings;
using WhoAmI.Core.Application;
using WhoAmI.Core.Common;
using WhoAmI.Domain.Entities;
using WhoAmI.Domain.Enums;

namespace WhoAmI.Application.Features.MyUsers.Commands
{
    public record CreateMyUserCommand : IRequest<Result<int>>,IMapFrom<MyUser>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Mail { get; set; }
        public required string Password { get; set; }

        public required Collection<Quiz> Quizzes { get; set; }
        public UserType UserType { get; set; }
    }


    internal class CreateMyUserCommandHandler : IRequestHandler<CreateMyUserCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateMyUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateMyUserCommand request, CancellationToken cancellationToken)
        {
            var myUser = new MyUser()
            {
                Name = request.Name,
                Surname = request.Surname,
                Mail = request.Mail,
                Password = request.Password,
                Quizzes = request.Quizzes,
                UserType= request.UserType
            };
         await   _unitOfWork.Repository<MyUser>().AddAsync(myUser);
            myUser.AddDomainEvent(new MyUserCreatedEvent(myUser));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(myUser.Id, "MyUser Created");

        }
    }
}
