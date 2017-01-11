using FootballManager.Domain.Abstract;
using FootballManager.Domain.Entities;
using System.Linq;

namespace FootballManager.Domain.Concrete
{
    public class PlayerRepository : IRepository<Player>
    {
        private EFContext context = new EFContext();

        public IQueryable<Entities.Player> Entities
        {
            get { return context.Players; }
        }
        public void Save(Entities.Player entity)
        {
            if (entity.Id == 0)
            {
                context.Players.Add(entity);
            }
            else
            {
                Player updatePlayer = context.Players.Find(entity.Id);
                if (updatePlayer != null)
                {
                    updatePlayer.Name = entity.Name;
                    updatePlayer.Surname = entity.Surname;
                    updatePlayer.Age = entity.Age;
                    updatePlayer.PlayerNumber = entity.PlayerNumber;
                    updatePlayer.TeamId = entity.TeamId;
                    updatePlayer.Country = entity.Country;
                    updatePlayer.DayBirth = entity.DayBirth;
                    updatePlayer.ImageUrl = entity.ImageUrl;
                }
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Player delete = context.Players.Find(id);
            if (delete != null)
            {
                context.Players.Remove(delete);
                context.SaveChanges();
            }
        }
    }
}
