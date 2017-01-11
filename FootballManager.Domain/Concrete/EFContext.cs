using FootballManager.Domain.Entities;
using System.Data.Entity;

namespace FootballManager.Domain.Concrete
{
    public class EFContext : DbContext
    {
        public EFContext() : base("FM")
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<FStadium> FStadiums { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<StadiumTeam> StadiumTeams { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database.SetInitializer<EFContext>(null);
            //relationship 1 - 1 (coach and team)
            modelBuilder.Entity<Coach>().HasOptional(c => c.Team).WithRequired(t => t.Coach);
            // 1 to many Player Team
            modelBuilder.Entity<Player>().HasOptional(p => p.Team).WithMany(t => t.Players);
            //// many to many Stadium Team
            //modelBuilder.Entity<FStadium>().HasMany<Team>(s => s.Teams).WithMany(t => t.FStadiums).Map(st =>
            //{
            //    st.MapLeftKey("StadiumRefId");
            //    st.MapRightKey("TeamRefId");
            //    st.ToTable("StadiumTeams");
            //});
            ////many to many Tournament Team
            modelBuilder.Entity<Tournament>().HasMany<Team>(t => t.Teams).WithMany(t => t.Tournaments).Map(t =>
            {
                t.MapLeftKey("TournamentId");
                t.MapRightKey("TeamId");
                t.ToTable("TournamentTeams");
            });
        }
    }
}
