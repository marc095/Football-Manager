using FootballManager.Domain.Abstract;
using FootballManager.Domain.Entities;
using System.Linq;

namespace FootballManager.Domain.Concrete
{
    public class CoachRepository : IRepository<Coach>
    {
        EFContext context = new EFContext();
        public IQueryable<Coach> Entities
        {
            get
            {
                return context.Coaches;
            }
        }

        public void Delete(int id)
        {
            Coach coach = this.context.Coaches.Find(id);
            if (coach != null)
            {
                context.Coaches.Remove(coach);
                context.SaveChanges();
            }
        }

        public void Save(Coach entity)
        {
            if (entity.Id == 0)
            {
                context.Coaches.Add(entity);
            }
            else
            {
                Coach coach = context.Coaches.Find(entity.Id);
                if (coach != null)
                {
                    coach.Name = entity.Name;
                    coach.Surname = entity.Surname;
                    coach.Age = entity.Age;
                    coach.TeamId = entity.TeamId;
                }
            }
            context.SaveChanges();
        }
    }
}
