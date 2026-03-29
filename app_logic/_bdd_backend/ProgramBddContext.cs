using Microsoft.EntityFrameworkCore;

namespace Project.app_logic._bdd_backend;

public partial class ProgramBddContext : DbContext
{
    public DbSet<Media> Medias { get; set; }

    public ProgramBddContext()
    {
    }

    public ProgramBddContext(DbContextOptions<ProgramBddContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B46NBR4\\SQLEXPRESS;Database=programBdd;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
