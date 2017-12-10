﻿// <auto-generated />
using Contractorss.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Contractorss.Migrations
{
    [DbContext(typeof(ContractorsContext))]
    [Migration("20171127185019_InitialSecond")]
    partial class InitialSecond
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contractorss.BuildingMaterial", b =>
                {
                    b.Property<int>("BuildingMaterialId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractorId");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("NameMaterial");

                    b.Property<int>("VolumePurchaseQuantity");

                    b.HasKey("BuildingMaterialId");

                    b.HasIndex("ContractorId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("BuildingMaterials");
                });

            modelBuilder.Entity("Contractorss.Contractor", b =>
                {
                    b.Property<int>("ContractorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameCompany");

                    b.HasKey("ContractorId");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("Contractorss.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("NameCeo");

                    b.Property<string>("SurnameCeo");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Contractorss.License", b =>
                {
                    b.Property<int>("LicenseId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateIssue");

                    b.Property<int>("Number");

                    b.Property<int>("ValidityYear");

                    b.HasKey("LicenseId");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Contractorss.ListWork", b =>
                {
                    b.Property<int>("ListWorkId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MainObjectId");

                    b.Property<int>("TypesJobId");

                    b.HasKey("ListWorkId");

                    b.HasIndex("MainObjectId");

                    b.HasIndex("TypesJobId");

                    b.ToTable("ListWork");
                });

            modelBuilder.Entity("Contractorss.MainObject", b =>
                {
                    b.Property<int>("MainObjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ConclusionContract");

                    b.Property<int>("ContractorId");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateInputObject");

                    b.Property<DateTime>("DeliveryObject");

                    b.Property<string>("NameObject");

                    b.HasKey("MainObjectId");

                    b.HasIndex("ContractorId");

                    b.HasIndex("CustomerId");

                    b.ToTable("MainObjects");
                });

            modelBuilder.Entity("Contractorss.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ManufacturerName");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Contractorss.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Contractorss.TechnicalEquipment", b =>
                {
                    b.Property<int>("TechnicalEquipmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Appointment");

                    b.Property<int>("ContractorId");

                    b.Property<DateTime>("DatePurchase");

                    b.Property<string>("Denotation");

                    b.Property<int>("LifetimeYear");

                    b.HasKey("TechnicalEquipmentId");

                    b.HasIndex("ContractorId");

                    b.ToTable("TechnicalEquipments");
                });

            modelBuilder.Entity("Contractorss.TypesJob", b =>
                {
                    b.Property<int>("TypesJobId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractorId");

                    b.Property<int>("LicenseId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("TypesJobId");

                    b.HasIndex("ContractorId");

                    b.HasIndex("LicenseId");

                    b.ToTable("TypesJobs");
                });

            modelBuilder.Entity("Contractorss.BuildingMaterial", b =>
                {
                    b.HasOne("Contractorss.Contractor", "ContractorIdNavigation")
                        .WithMany("BuildingMaterials")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Contractorss.Manufacturer", "ManufacturerIdNavigation")
                        .WithMany("BuildingMaterials")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contractorss.ListWork", b =>
                {
                    b.HasOne("Contractorss.MainObject", "MainObjectIdNavigation")
                        .WithMany("ListWork")
                        .HasForeignKey("MainObjectId");

                    b.HasOne("Contractorss.TypesJob", "TypesJobIdNavigation")
                        .WithMany("ListWork")
                        .HasForeignKey("TypesJobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contractorss.MainObject", b =>
                {
                    b.HasOne("Contractorss.Contractor", "ContractorIdNavigation")
                        .WithMany("MainObjects")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Contractorss.Customer", "CustomerIdNavigation")
                        .WithMany("MainObjects")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contractorss.TechnicalEquipment", b =>
                {
                    b.HasOne("Contractorss.Contractor", "ContractorIdNavigation")
                        .WithMany("TechnicalEquipments")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contractorss.TypesJob", b =>
                {
                    b.HasOne("Contractorss.Contractor", "ContractorIdNavigation")
                        .WithMany("TypesJobs")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Contractorss.License", "LicenseIdNavigation")
                        .WithMany("TypesJobs")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
