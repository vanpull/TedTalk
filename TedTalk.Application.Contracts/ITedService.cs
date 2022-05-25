using System.Collections.Generic;
using TedTalk.Application.Contracts.Dtos;

namespace TedTalk.Application.Contracts
{
    public interface ITedService : IApplicationService
    {
        List<TedDto> GetAll();
        TedDto GetById(int id);
        void Add(TedDto dto);
        void Update(TedDto dto);
        void Delete(int id);
    }
}
