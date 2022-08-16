using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EviromentalSurvey.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Required]
        public string Class { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Rollnumber { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                        .HasMany<FAQ>(s => s.FAQs)
                        .WithMany(c => c.Events)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("EventId");
                            cs.MapRightKey("FAQId");
                            cs.ToTable("EventFAQs");
                        });
            modelBuilder.Entity<Event>()
                .HasOptional(s => s.Content) 
                .WithRequired(ad => ad.Event);
            modelBuilder.Entity<Content>()
                .HasOptional(s => s.Reward) 
                .WithRequired(ad => ad.Content);

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<FAQ> FAQs { get; set; }

        public virtual DbSet<Content> Contents { get; set; }    

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Reward> Rewards { get; set; }

        public virtual DbSet<UserEvent> UserEvents { get; set; }    
    }
}