using Microsoft.EntityFrameworkCore;
using System;

namespace OWTContactsAPI.Models
{
	public class ContactsAPIContext : DbContext
	{
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<ContactSkill> ContactSkills { get; set; }
		public DbSet<Skill> Skills { get; set; }

		public ContactsAPIContext(DbContextOptions<ContactsAPIContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=ContactsAPI.DB;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ContactSkill>()
				.HasKey(cs => new { cs.ContactId, cs.SkillId });
			modelBuilder.Entity<ContactSkill>()
				.HasOne(cs => cs.Contact)
				.WithMany(c => c.ContactSkills)
				.HasForeignKey(cs => cs.ContactId);
			modelBuilder.Entity<ContactSkill>()
				.HasOne(cs => cs.Skill)
				.WithMany(s => s.ContactSkills)
				.HasForeignKey(cs => cs.SkillId);

			// Data seed

			modelBuilder.Entity<Contact>()
				.HasData(
					new Contact
					{
						ContactId = 1,
						FirstName = "Jeshua",
						LastName = "Park",
						Address = "Chemin de la Prairie 36, 1007 Lausanne",
						Email = "jp@jeshua.ch",
						MobilePhoneNumber = "07544412213"
					},
					new Contact
					{
						ContactId = 2,
						FirstName = "Fatima",
						LastName = "Diallo",
						Address = "Rue de Marterey 4",
						Email = "fatou@gmail.com",
						MobilePhoneNumber = "0758954545"
					},
					new Contact
					{
						ContactId = 3,
						FirstName = "Modahmed-Ali",
						LastName = "Kurai",
						Address = "Avenu du Mauborget 13",
						Email = "m.a.k@hotmail.ch",
						MobilePhoneNumber = "0751111122"
					}
			);

			modelBuilder.Entity<ExpertizeLevel>()
				.HasData(
					new ExpertizeLevel
					{
						ExpertizeLevelId = 1,
						Name = "Beginner",
						NumericValue = 0
					},
					new ExpertizeLevel
					{
						ExpertizeLevelId = 2,
						Name = "Intermediate",
						NumericValue = 1
					},
					new ExpertizeLevel
					{
						ExpertizeLevelId = 3,
						Name = "Expert",
						NumericValue = 2
					}
			);

			modelBuilder.Entity<Skill>()
				.HasData(
					new Skill
					{
						SkillId = 1,
						Name = "C# Programming"
					},
					new Skill
					{
						SkillId = 2,
						Name = "SOLID Principles"
					},
					new Skill
					{
						SkillId = 3,
						Name = "Obect Oriented Programming"
					}
			);

			modelBuilder.Entity<ContactSkill>()
				.HasData(
					new ContactSkill
					{
						SkillId = 1,
						ContactId = 2,
						ExpertizeLevelId = 1
					},
					new ContactSkill
					{
						SkillId = 3,
						ContactId = 1,
						ExpertizeLevelId = 3
					},
					new ContactSkill
					{
						SkillId = 3,
						ContactId = 2,
						ExpertizeLevelId = 2
					}
				);
		}
	}
}
