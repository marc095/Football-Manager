using FootballManager.Domain.Abstract;
using FootballManager.Domain.Entities;
using System;
using System.Linq;

namespace FootballManager.Domain.Concrete
{
    public class TournamentRepository : IRepository<Tournament>
    {
        public IQueryable<Tournament> Entities
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Tournament entity)
        {
            throw new NotImplementedException();
        }
    }
}
