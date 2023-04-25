using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
public class MyWebAPIDBContext : DbContext
{
    public MyWebAPIDBContext(DbContextOptions<MyWebAPIDBContext> options)
        : base(options)
    {
    }

    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<Breakfast> BreakfastFoods { get; set; }
    public DbSet<Weather> Weathers { get; set; }
}