﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PWA_Buffet_Williane.Data;

namespace PWA_Buffet_Williane.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210517224119_pwa_buffet")]
    partial class pwa_buffet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Acesso.HistoricoLoginEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataHoraLogin")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistoricoLogin");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Acesso.Papel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Acesso.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Cliente.ClienteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CNPJ")
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18) CHARACTER SET utf8mb4");

                    b.Property<string>("CPF")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("RegistroDataInsert")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("RegistroDataUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("TipoClienteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TipoClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Cliente.TipoClienteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("TipoCliente");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Convidado.ConvidadoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("EventoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("RegistroDataInsert")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("RegistroDataUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("SituacaoConvidadoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("SituacaoConvidadoId");

                    b.ToTable("Convidado");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Convidado.SituacaoConvidadoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("SituacaoConvidado");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Evento.EventoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataHoraFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("LocalId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("RegistroDataInsert")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("RegistroDataUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("SituacaoEventoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TipoEventoId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LocalId");

                    b.HasIndex("SituacaoEventoId");

                    b.HasIndex("TipoEventoId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Evento.SituacaoEventoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("SituacaoEvento");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Evento.TipoEventoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("TipoEvento");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Local.LocalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Local");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Acesso.Papel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Acesso.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Acesso.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Acesso.Papel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PWA_Buffet_Williane.Models.Acesso.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Acesso.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Acesso.HistoricoLoginEntity", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Acesso.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Cliente.ClienteEntity", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Buffet.Cliente.TipoClienteEntity", "TipoCliente")
                        .WithMany()
                        .HasForeignKey("TipoClienteId");

                    b.Navigation("TipoCliente");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Convidado.ConvidadoEntity", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Buffet.Evento.EventoEntity", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId");

                    b.HasOne("PWA_Buffet_Williane.Models.Buffet.Convidado.SituacaoConvidadoEntity", "SituacaoConvidado")
                        .WithMany()
                        .HasForeignKey("SituacaoConvidadoId");

                    b.Navigation("Evento");

                    b.Navigation("SituacaoConvidado");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Evento.EventoEntity", b =>
                {
                    b.HasOne("PWA_Buffet_Williane.Models.Buffet.Cliente.ClienteEntity", "Cliente")
                        .WithMany("Eventos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("PWA_Buffet_Williane.Models.Buffet.Local.LocalEntity", "Local")
                        .WithMany("Eventos")
                        .HasForeignKey("LocalId");

                    b.HasOne("PWA_Buffet_Williane.Models.Buffet.Evento.SituacaoEventoEntity", "SituacaoEvento")
                        .WithMany()
                        .HasForeignKey("SituacaoEventoId");

                    b.HasOne("PWA_Buffet_Williane.Models.Buffet.Evento.TipoEventoEntity", "TipoEvento")
                        .WithMany()
                        .HasForeignKey("TipoEventoId");

                    b.Navigation("Cliente");

                    b.Navigation("Local");

                    b.Navigation("SituacaoEvento");

                    b.Navigation("TipoEvento");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Cliente.ClienteEntity", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("PWA_Buffet_Williane.Models.Buffet.Local.LocalEntity", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
