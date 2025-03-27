﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MomCarePlus.Infrastructure.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MomCarePlus.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250327162923_DataSeeder")]
    partial class DataSeeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MomCarePlus.Domain.Entities.PregnancyAdvice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsRecommended")
                        .HasColumnType("boolean");

                    b.Property<int>("Stage")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Stage");

                    b.HasIndex("Type");

                    b.ToTable("PregnancyAdvices");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"),
                            Content = "Trong tam cá nguyệt đầu, mẹ bầu nên bổ sung đầy đủ axit folic, sắt và canxi...",
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6300),
                            IsRecommended = true,
                            Stage = 1,
                            Title = "Dinh dưỡng trong tam cá nguyệt đầu",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"),
                            Content = "Các bài tập như đi bộ, bơi lội, yoga là những lựa chọn an toàn cho mẹ bầu...",
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6300),
                            IsRecommended = true,
                            Stage = 2,
                            Title = "Bài tập an toàn cho mẹ bầu",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"),
                            Content = "Việc chuẩn bị tâm lý trước khi sinh rất quan trọng...",
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6310),
                            IsRecommended = true,
                            Stage = 3,
                            Title = "Chuẩn bị tâm lý trước khi sinh",
                            Type = 4
                        });
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.PregnancyAdviceCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("PregnancyAdviceCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9fce37c8-2a5f-446d-aa24-ac11f1ac746c"),
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6210),
                            Description = "Các lời khuyên về dinh dưỡng cho mẹ bầu",
                            Name = "Dinh dưỡng"
                        },
                        new
                        {
                            Id = new Guid("2aab5137-91b6-4399-b461-d82c834c2483"),
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6210),
                            Description = "Các bài tập an toàn cho mẹ bầu",
                            Name = "Tập thể dục"
                        },
                        new
                        {
                            Id = new Guid("e5b273d1-851e-44db-bf7c-e8f8a162e501"),
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6220),
                            Description = "Các lời khuyên về sức khỏe cho mẹ bầu",
                            Name = "Sức khỏe"
                        });
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.PregnancyAdviceTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("PregnancyAdviceTags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ca6b635-7c46-4376-bf35-38ce02b0c719"),
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6240),
                            Name = "Quan trọng"
                        },
                        new
                        {
                            Id = new Guid("c2fffc68-3cbb-40d5-bcc7-1c2d2bd64093"),
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6250),
                            Name = "Khẩn cấp"
                        },
                        new
                        {
                            Id = new Guid("db09bb37-b99b-4719-afcc-5485c04a4600"),
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6250),
                            Name = "Tham khảo"
                        });
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.PregnancyMilestone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PregnancyProfileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DueDate");

                    b.HasIndex("PregnancyProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("PregnancyMilestones");
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.PregnancyProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CurrentWeek")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ExpectedDeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("GenderPreference")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPlanningPregnancy")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastPeriodDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Stage")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PregnancyProfiles");
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("598c101b-de2e-4cb6-bf16-933711568238"),
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6110),
                            Email = "admin@momcareplus.com",
                            FullName = "Admin User",
                            PasswordHash = "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=",
                            UserType = 3
                        },
                        new
                        {
                            Id = new Guid("4be453ca-ccc5-4022-a55a-f71bad7e5e6c"),
                            CreatedAt = new DateTime(2025, 3, 27, 16, 29, 23, 194, DateTimeKind.Utc).AddTicks(6130),
                            Email = "expert@momcareplus.com",
                            FullName = "Expert User",
                            PasswordHash = "CerbEAri0Xh/RX2POYhbUZ0KSwuahTEIikkLwj6afj4=",
                            UserType = 3
                        });
                });

            modelBuilder.Entity("PregnancyAdvicePregnancyAdviceCategory", b =>
                {
                    b.Property<Guid>("AdvicesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uuid");

                    b.HasKey("AdvicesId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("PregnancyAdviceCategoryAdvices", (string)null);

                    b.HasData(
                        new
                        {
                            AdvicesId = new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"),
                            CategoriesId = new Guid("9fce37c8-2a5f-446d-aa24-ac11f1ac746c")
                        },
                        new
                        {
                            AdvicesId = new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"),
                            CategoriesId = new Guid("2aab5137-91b6-4399-b461-d82c834c2483")
                        },
                        new
                        {
                            AdvicesId = new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"),
                            CategoriesId = new Guid("e5b273d1-851e-44db-bf7c-e8f8a162e501")
                        });
                });

            modelBuilder.Entity("PregnancyAdvicePregnancyAdviceTag", b =>
                {
                    b.Property<Guid>("AdvicesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uuid");

                    b.HasKey("AdvicesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PregnancyAdviceTagAdvices", (string)null);

                    b.HasData(
                        new
                        {
                            AdvicesId = new Guid("f2d7438b-ba2d-45ac-b71e-72cc87b629de"),
                            TagsId = new Guid("9ca6b635-7c46-4376-bf35-38ce02b0c719")
                        },
                        new
                        {
                            AdvicesId = new Guid("27e27fa0-d3a4-4e34-a385-1a30c943abd1"),
                            TagsId = new Guid("c2fffc68-3cbb-40d5-bcc7-1c2d2bd64093")
                        },
                        new
                        {
                            AdvicesId = new Guid("0142abd4-2e98-455a-a88a-3a5a99042479"),
                            TagsId = new Guid("db09bb37-b99b-4719-afcc-5485c04a4600")
                        });
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.PregnancyMilestone", b =>
                {
                    b.HasOne("MomCarePlus.Domain.Entities.PregnancyProfile", "PregnancyProfile")
                        .WithMany("Milestones")
                        .HasForeignKey("PregnancyProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomCarePlus.Domain.Entities.User", "User")
                        .WithMany("Milestones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PregnancyProfile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.PregnancyProfile", b =>
                {
                    b.HasOne("MomCarePlus.Domain.Entities.User", "User")
                        .WithOne("PregnancyProfile")
                        .HasForeignKey("MomCarePlus.Domain.Entities.PregnancyProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PregnancyAdvicePregnancyAdviceCategory", b =>
                {
                    b.HasOne("MomCarePlus.Domain.Entities.PregnancyAdvice", null)
                        .WithMany()
                        .HasForeignKey("AdvicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomCarePlus.Domain.Entities.PregnancyAdviceCategory", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PregnancyAdvicePregnancyAdviceTag", b =>
                {
                    b.HasOne("MomCarePlus.Domain.Entities.PregnancyAdvice", null)
                        .WithMany()
                        .HasForeignKey("AdvicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MomCarePlus.Domain.Entities.PregnancyAdviceTag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.PregnancyProfile", b =>
                {
                    b.Navigation("Milestones");
                });

            modelBuilder.Entity("MomCarePlus.Domain.Entities.User", b =>
                {
                    b.Navigation("Milestones");

                    b.Navigation("PregnancyProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
