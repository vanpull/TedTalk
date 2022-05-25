using AutoMapper;
using System.Collections.Generic;
using TedTalk.Application.Contracts;
using TedTalk.Application.Contracts.Dtos;
using TedTalk.Domain.Entities;
using TedTalk.Domain.Repositories;

namespace TedTalk.Application
{
    public class TedService : ApplicationService, ITedService
    {
        private readonly ITedRepository _tedRepository;

        public TedService(ITedRepository tedRepository, IMapper mapper) : base(mapper)
        {
           _tedRepository = tedRepository;
        }

        public void Add(TedDto tedDto)
        {
            var ted = Mapper.Map<Ted>(tedDto);
            _tedRepository.Add(ted);
        }

        public void Delete(int id)
        {
            _tedRepository.Delete(id);
        }

        public List<TedDto> GetAll()
        {
            var teds = _tedRepository.GetAll();
            var tedDto = Mapper.Map<List<TedDto>>(teds);
            return tedDto;
        }

        public TedDto GetById(int id)
        {
            var teds = _tedRepository.GetById(id);
            var tedDto = Mapper.Map<TedDto>(teds);
            return tedDto;
        }

        public void Update(TedDto tedDto)
        {
            var ted = Mapper.Map<Ted>(tedDto);
            _tedRepository.Update(ted);
        }
    }
}
