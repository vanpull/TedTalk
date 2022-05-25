using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TedTalk.Domain.Entities;

namespace TedTalk.Domain.Repositories
{
    public interface ITedRepository
    {
        List<Ted> GetAll();
        Ted GetById(int id);
        void Add(Ted dto);
        void Update(Ted dto);
        void Delete(int id);
    }
}
