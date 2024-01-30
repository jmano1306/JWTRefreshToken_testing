using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace JWTRefreshToken.Auth
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
   // public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ConnStr");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public virtual DbSet<Employee>? Employees { get; set; }
        public virtual DbSet<RegisterModel>? RegisterModels { get; set; }
        public virtual DbSet<Response>? Responses { get; set; }
        public virtual DbSet<ResetPassword>? ResetPasswords { get; set; }
        public virtual DbSet<UserManagerResponse>? UserManagerResponses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
