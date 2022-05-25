using AutoMapper;
using TedTalk.Application.Contracts;

namespace TedTalk.Application
{
    public abstract class ApplicationService : IApplicationService
    {
        private readonly IMapper _mapper;

        public ApplicationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected IMapper Mapper => _mapper;
    }
}
