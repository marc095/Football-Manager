using FootballManager.Domain.Abstract;
using FootballManager.Domain.Entities;
using System.Linq;

namespace FootballManager.Domain.Concrete
{
    public class TeamRepository : IRepository<Team>
    {
        private EFContext context = new EFContext();
        public IQueryable<Team> Entities
        {
            get
            {
                return context.Teams;
            }
        }

        public void Delete(int id)
        {
            Team team = context.Teams.Find(id);
            if (team != null)
            {
                context.Teams.Remove(team);
            }
        }

        public void Save(Team entity)
        {
            if (entity.Id == 0)
            {
                context.Teams.Add(entity);
            }
            else
            {
                Team team = context.Teams.Find(entity.Id);
                if (team != null)
                {
                    team.Name = entity.Name;
                    team.CoachId = entity.CoachId;
                    team.PlayerId = entity.PlayerId;
                }
            }
            context.SaveChanges();
        }
    }
}
