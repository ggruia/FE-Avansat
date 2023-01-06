using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAssociationAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace StudentAssociationAPI.Data
{
    public class Context : IdentityDbContext <User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet<Application> Applications { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Commitee> Commitees { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<AssociationMembership> AssociationMemberships { get; set; }
        public DbSet<BoardMembership> BoardMemberships { get; set; }
        public DbSet<CommiteeMembership> CommiteeMemberships { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Base
            base.OnModelCreating(builder);


            // Association - PK
            builder.Entity<Association>()
                .HasKey(a => a.Id);


            // Commitee (M) --- (1) Association
            builder.Entity<Commitee>()
                .HasOne(c => c.Association)
                .WithMany(a => a.Commitees)
                .HasForeignKey(c => c.AssociationId)
                .OnDelete(DeleteBehavior.Cascade);


            // Event (M) --- (1) Commitee
            builder.Entity<Event>()
                .HasOne(e => e.Commitee)
                .WithMany(c => c.Events)
                .OnDelete(DeleteBehavior.Cascade);


            // CommiteeMembership (1) --- (1) Member
            builder.Entity<CommiteeMembership>()
                .HasOne(cm => cm.Member)
                .WithOne(m => m.CommiteeMembership)
                .OnDelete(DeleteBehavior.Cascade);

            // CommiteeMembership (M) --- (1) Commitee
            builder.Entity<CommiteeMembership>()
                .HasOne(cm => cm.Commitee)
                .WithMany(c => c.CommiteeMemberships)
                .HasForeignKey(cm => cm.CommiteeId)
                .OnDelete(DeleteBehavior.Cascade);



            // (M) --- (M)
            // BoardMembership (M) --- (1) Association
            builder.Entity<BoardMembership>()
                .HasOne(bm => bm.Association)
                .WithMany(a => a.BoardMemberships)
                .HasForeignKey(bm => bm.AssociationId)
                .OnDelete(DeleteBehavior.Cascade);

            // BoardMembership (M) --- (1) Member
            builder.Entity<BoardMembership>()
                .HasOne(bm => bm.Member)
                .WithMany(m => m.BoardMemberships)
                .HasForeignKey(bm => bm.MemberId)
                .OnDelete(DeleteBehavior.Cascade);



            // (M) --- (M)
            // AssociationMembership (M) --- (1) Association
            builder.Entity<AssociationMembership>()
                .HasOne(am => am.Association)
                .WithMany(a => a.AssociationMemberships)
                .HasForeignKey(am => am.AssociationId)
                .OnDelete(DeleteBehavior.Cascade);

            // AssociationMembership (M) --- (1) Member
            builder.Entity<AssociationMembership>()
                .HasOne(am => am.Member)
                .WithMany(m => m.AssociationMemberships)
                .HasForeignKey(am => am.MemberId)
                .OnDelete(DeleteBehavior.Cascade);



            // (M) --- (M)
            // Application (M) --- (1) Member
            builder.Entity<Application>()
                .HasOne(app => app.Member)
                .WithMany(m => m.Applications)
                .HasForeignKey(app => app.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // Application (M) --- (1) Association
            builder.Entity<Application>()
                .HasOne(app => app.Association)
                .WithMany(a => a.Applications)
                .HasForeignKey(app => app.AssociationId)
                .OnDelete(DeleteBehavior.Cascade);



            // (M) --- (M)
            // EventRegistration (M) --- (1) Member
            builder.Entity<EventRegistration>()
                .HasOne(er => er.Member)
                .WithMany(m => m.EventRegistrations)
                .HasForeignKey(er => er.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            // EventRegistration (M) --- (1) Event
            builder.Entity<EventRegistration>()
                .HasOne(er => er.Event)
                .WithMany(e => e.EventRegistrations)
                .HasForeignKey(er => er.EventId)
                .OnDelete(DeleteBehavior.Cascade);



            // User (1) --- (1) Member
            builder.Entity<User>()
                .HasOne(m => m.Member)
                .WithOne(u => u.User)
                .HasForeignKey<Member>(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);



            builder.Entity<User>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<Role>(entity => entity.Property(m => m.Id).HasMaxLength(85));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));


            builder.Entity<Association>().HasData(
                new Association
                {
                    Id = "1",
                    Name = "ASMI",
                    Description = "<< Oameni obisnuiti >>  ~ Hadirca Dionisie"
                },
                new Association
                {
                    Id = "2",
                    Name = "Asociatia Evanghelistilor",
                    Description = "<< Oameni evlaviosi >>  ~ Hadirca Dionisie"
                },
                new Association
                {
                    Id = "3",
                    Name = "AS Stiinte Aplicate",
                    Description = "<< Nu cunosc acesti oameni >>  ~ Hadirca Dionisie"
                },
                new Association
                {
                    Id = "4",
                    Name = "Asociatia Fizicienilor Romani",
                    Description = "<< Daca ai avea Facebook ai sti >>  ~ Hadirca Dionisie"
                });

            builder.Entity<Commitee>().HasData(
                new Commitee
                {
                    Id = "1",
                    Name = "Management & Fundraising",
                    AssociationId = "1",
                    InaugurationDate = DateTime.Parse("2019-10-07"),
                    Description = "Principalul nostru obiectiv este sa imbunatatim conditiile in care decurg evenimentele asociatiei. Acest lucru il realizam prin supervizarea desfasurarii proiectelor ASMI si dezvoltarea acestora pe mai departe, dar si intrand in contact direct cu diverse firme (din domeniul IT si nu numai), cu care incheiem contracte de sponsorizare."
                },
                new Commitee
                {
                    Id = "2",
                    Name = "Design & PR",
                    AssociationId = "1",
                    InaugurationDate = DateTime.Parse("2016-06-23"),
                    Description = "Daca am putea descrie acest departament in doua cuvinte acelea sigur ar fi \"imaginea asociatiei\". Imagineaza-ti pentru cateva secunde cum ar arata un proiect fara afise, postari pe Facebook sau pe Instagram, de exemplu Recrutarile sau ce zici de o petrecere? Exact, informatia ar ajunge la mult mai putini oameni, sau cei care ar sti nu ar veni, deoarece nu i-a atras nimic auzind o informatie doar prin viu grai."
                },
                new Commitee
                {
                    Id = "3",
                    Name = "Educational",
                    AssociationId = "1",
                    InaugurationDate = DateTime.Parse("2017-01-25"),
                    Description = "Departamentul Educational are ca scop imbunatatirea calitatii vietii academice a studentilor, reprezentand o punte de legatura intre acestia si Conducerea Facultatii. Cu ce se ocupa mai exact Edu? Proiecte precum Admiterea, Tutoriate, Ziua Portilor Deschise, Ratusca si, mai recent, Practica sunt organizate de voluntarii nostri, care sunt motivati sa ajute studentii sa aiba o experienta a anilor de Facultate cat mai placuta."
                },
                new Commitee
                {
                    Id = "4",
                    Name = "Human Resources",
                    AssociationId = "1",
                    InaugurationDate = DateTime.Parse("2016-07-21"),
                    Description = "Noi suntem, in cateva cuvinte, \"inima asociatiei\"! Ne ocupam de integrarea bobocilor ce ni se alatura in fiecare toamna si primavara, astfel incat ei sa ajunga sa se simta cu adevarat parte din familia noastra, dar si de bunastarea tuturor voluntarilor, prin organizarea de joculete interactive si de activitati de socializare."
                },
                new Commitee
                {
                    Id = "5",
                    Name = "Planner",
                    AssociationId = "3",
                    InaugurationDate = DateTime.Parse("2020-09-10"),
                    Description = "In cadrul acestui comitet are loc un mix de energie, originalitate si motivatie, conferit de prezenta si implicarea tinerilor. Datorita acestora, ideea de comunitate capata noi valente."
                },
                new Commitee
                {
                    Id = "6",
                    Name = "RIUF",
                    AssociationId = "3",
                    InaugurationDate = DateTime.Parse("2021-05-05"),
                    Description = "RIUF - The Romanian International University Fair, cel mai mare eveniment educational, international de universitati din Europa de Sud Est este locul in care peste 220.000 de elevi, studenti, profesori si parinti au discutat cu reprezentantii din peste 150 de universitati din intreaga lume."
                });


            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = null
                },
                new Role
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = null
                });

            builder.Entity<Event>().HasData(
                new Event
                {
                    Id = "1",
                    Name = "Event 1",
                    Location = "Campus UB",
                    Description = "Description 1",
                    StartTime = DateTime.Parse("2021-08-05"),
                    EndTime = DateTime.Parse("2021-08-07"),
                    CommiteeId = "1",
                    IsCanceled = false
                },
                new Event
                {
                    Id = "2",
                    Name = "Event 2",
                    Location = "Campus UB",
                    Description = "Description 2",
                    StartTime = DateTime.Parse("2021-08-09"),
                    EndTime = DateTime.Parse("2021-08-11"),
                    CommiteeId = "1",
                    IsCanceled = true
                },
                new Event
                {
                    Id = "3",
                    Name = "Event 3",
                    Location = "Campus UB",
                    Description = "Description 3",
                    StartTime = DateTime.Parse("2021-02-05"),
                    EndTime = DateTime.Parse("2021-03-07"),
                    CommiteeId = "2",
                    IsCanceled = false
                });
        }
    }
}
