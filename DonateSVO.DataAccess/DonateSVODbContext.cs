using DonateSVO.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonateSVO.DataAccess;

public class DonateSvoDbContext : DbContext
{
    public DonateSvoDbContext(DbContextOptions<DonateSvoDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<GatheringEntity> Gatherings { get; set; }
}
