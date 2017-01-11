using FootballManager.Domain.Abstract;
using FootballManager.Domain.Entities;
using System.Linq;

namespace FootballManager.Domain.Concrete
{
    public class StadiumTeamRepository : IRepository<StadiumTeam>
    {
        EFContext context = new EFContext();

        public IQueryable<StadiumTeam> Entities
        {
            get
            {
                return context.StadiumTeams;
            }
        }

        public void Delete(int id)
        {
            StadiumTeam delete = context.StadiumTeams.Find(id);
            if (delete != null)
            {
                context.StadiumTeams.Remove(delete);
                context.SaveChanges();
            }
        }
        public void Save() { context.SaveChanges(); }
        public void Save(StadiumTeam entity)
        {
            if (entity.Id == 0)
            {
                context.StadiumTeams.Add(entity);
            }
            else
            {
                StadiumTeam update = context.StadiumTeams.Find(entity.Id);
                if (update != null)
                {
                    update.TeamId = entity.TeamId;
                    update.FStadiumId = entity.FStadiumId;
                }
            }
            context.SaveChanges();
        }
        public void ChangeState(StadiumTeam stadium)
        {
            context.Entry(stadium).State = System.Data.Entity.EntityState.Deleted;
        }
        public void Add(StadiumTeam stadium)
        {
            context.StadiumTeams.Add(stadium);
        }
    }
}
