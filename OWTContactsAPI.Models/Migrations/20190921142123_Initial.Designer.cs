﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OWTContactsAPI.Models;

namespace OWTContactsAPI.Models.Migrations
{
    [DbContext(typeof(ContactsAPIContext))]
    [Migration("20190921142123_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OWTContactsAPI.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsConcurrencyToken()
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsConcurrencyToken()
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsConcurrencyToken()
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsConcurrencyToken()
                        .IsRequired();

                    b.Property<string>("MobilePhoneNumber")
                        .IsConcurrencyToken()
                        .IsRequired();

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new { ContactId = 1, Address = "Chemin de la Prairie 36, 1007 Lausanne", Email = "jp@jeshua.ch", FirstName = "Jeshua", LastName = "Park", MobilePhoneNumber = "07544412213" },
                        new { ContactId = 2, Address = "Rue de Marterey 4", Email = "fatou@gmail.com", FirstName = "Fatima", LastName = "Diallo", MobilePhoneNumber = "0758954545" },
                        new { ContactId = 3, Address = "Avenu du Mauborget 13", Email = "m.a.k@hotmail.ch", FirstName = "Modahmed-Ali", LastName = "Kurai", MobilePhoneNumber = "0751111122" }
                    );
                });

            modelBuilder.Entity("OWTContactsAPI.Models.ContactSkill", b =>
                {
                    b.Property<int>("ContactId");

                    b.Property<int>("SkillId");

                    b.Property<int>("ExpertizeLevelId")
                        .IsConcurrencyToken();

                    b.HasKey("ContactId", "SkillId");

                    b.HasIndex("ExpertizeLevelId");

                    b.HasIndex("SkillId");

                    b.ToTable("ContactSkills");

                    b.HasData(
                        new { ContactId = 2, SkillId = 1, ExpertizeLevelId = 1 },
                        new { ContactId = 1, SkillId = 3, ExpertizeLevelId = 3 },
                        new { ContactId = 2, SkillId = 3, ExpertizeLevelId = 2 }
                    );
                });

            modelBuilder.Entity("OWTContactsAPI.Models.ExpertizeLevel", b =>
                {
                    b.Property<int>("ExpertizeLevelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("NumericValue");

                    b.HasKey("ExpertizeLevelId");

                    b.ToTable("ExpertizeLevel");

                    b.HasData(
                        new { ExpertizeLevelId = 1, Name = "Beginner", NumericValue = 0 },
                        new { ExpertizeLevelId = 2, Name = "Intermediate", NumericValue = 1 },
                        new { ExpertizeLevelId = 3, Name = "Expert", NumericValue = 2 }
                    );
                });

            modelBuilder.Entity("OWTContactsAPI.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired();

                    b.HasKey("SkillId");

                    b.ToTable("Skills");

                    b.HasData(
                        new { SkillId = 1, Name = "C# Programming" },
                        new { SkillId = 2, Name = "SOLID Principles" },
                        new { SkillId = 3, Name = "Obect Oriented Programming" }
                    );
                });

            modelBuilder.Entity("OWTContactsAPI.Models.ContactSkill", b =>
                {
                    b.HasOne("OWTContactsAPI.Models.Contact", "Contact")
                        .WithMany("ContactSkills")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OWTContactsAPI.Models.ExpertizeLevel", "ExpertizeLevel")
                        .WithMany()
                        .HasForeignKey("ExpertizeLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OWTContactsAPI.Models.Skill", "Skill")
                        .WithMany("ContactSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
