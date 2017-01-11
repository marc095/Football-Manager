using FootballManager.Domain.Abstract;
using FootballManager.Domain.Entities;
using System.Linq;

namespace FootballManager.Domain.Concrete
{
    public class StadiumRepository : IRepository<FStadium>
    {
        private EFContext context = new EFContext();
        public IQueryable<FStadium> Entities
        {
            get
            {
                return this.context.FStadiums;
            }
        }

        public void Delete(int id)
        {
            FStadium stadium = this.context.FStadiums.Find(id);
            if (stadium != null)
            {
                context.FStadiums.Remove(stadium);
                context.SaveChanges();
            }
        }

        public void Save(FStadium entity)
        {
            if (entity.Id == 0)
            {
                this.context.FStadiums.Add(entity);
            }
            else
            {
                FStadium stadium = context.FStadiums.Find(entity.Id);
                if (stadium != null)
                {
                    stadium.Name = entity.Name;
                    stadium.Capacity = entity.Capacity;
                }
            }
            context.SaveChanges();
        }
    }
}
