using Microsoft.EntityFrameworkCore;
using SN.Entity;

namespace SN.DAL
{
    public class SocialNonogramsContext: DbContext
    {
        public SocialNonogramsContext()
        {
            
        }

        public SocialNonogramsContext(DbContextOptions<SocialNonogramsContext> options) : base(options)
        {
            
        }
        
        public DbSet<FinishedGameEntity> FinishedGames { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GridStateEntity> GridStates { get; set; }
        public DbSet<RankEntity> Ranks { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<UnfinishedGameEntity> UnfinishedGames { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=SocialNonogramsDb-2;Trusted_Connection=True;");
        }
    }
}