// <auto-generated />
using System;
using GameEngine.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameEngine.Migrations
{
    [DbContext(typeof(LudoGameDbContext))]
    [Migration("20210408123940_addedPlayersCountInGame")]
    partial class addedPlayersCountInGame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameEngine.Models.GameMove", b =>
                {
                    b.Property<int>("GameMoveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiceThrowResult")
                        .HasColumnType("int");

                    b.Property<int?>("LudoGameId")
                        .HasColumnType("int");

                    b.Property<int?>("OriginalPosition")
                        .HasColumnType("int");

                    b.Property<int?>("PieceGamePieceId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerGamePlayerID")
                        .HasColumnType("int");

                    b.HasKey("GameMoveID");

                    b.HasIndex("LudoGameId");

                    b.HasIndex("PieceGamePieceId");

                    b.HasIndex("PlayerGamePlayerID");

                    b.ToTable("GameMoves");
                });

            modelBuilder.Entity("GameEngine.Models.GamePiece", b =>
                {
                    b.Property<int>("GamePieceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Color")
                        .HasColumnType("int");

                    b.Property<int?>("LudoGameId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("TrackPosition")
                        .HasColumnType("int");

                    b.HasKey("GamePieceId");

                    b.HasIndex("LudoGameId");

                    b.ToTable("GamePieces");
                });

            modelBuilder.Entity("GameEngine.Models.GamePlayer", b =>
                {
                    b.Property<int>("GamePlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<int?>("GamePlayersId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GamePlayerID");

                    b.HasIndex("GamePlayersId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GameEngine.Models.GamePlayers", b =>
                {
                    b.Property<int>("GamePlayersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerCount")
                        .HasColumnType("int");

                    b.HasKey("GamePlayersId");

                    b.ToTable("PlayersInGame");
                });

            modelBuilder.Entity("GameEngine.Models.LudoGame", b =>
                {
                    b.Property<int>("LudoGameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NextPlayerGamePlayerID")
                        .HasColumnType("int");

                    b.Property<int?>("PlayersGamePlayersId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WinnerGamePlayerID")
                        .HasColumnType("int");

                    b.HasKey("LudoGameId");

                    b.HasIndex("NextPlayerGamePlayerID");

                    b.HasIndex("PlayersGamePlayersId");

                    b.HasIndex("WinnerGamePlayerID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameEngine.Models.GameMove", b =>
                {
                    b.HasOne("GameEngine.Models.LudoGame", null)
                        .WithMany("Moves")
                        .HasForeignKey("LudoGameId");

                    b.HasOne("GameEngine.Models.GamePiece", "Piece")
                        .WithMany()
                        .HasForeignKey("PieceGamePieceId");

                    b.HasOne("GameEngine.Models.GamePlayer", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerGamePlayerID");

                    b.Navigation("Piece");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("GameEngine.Models.GamePiece", b =>
                {
                    b.HasOne("GameEngine.Models.LudoGame", null)
                        .WithMany("PieceSetup")
                        .HasForeignKey("LudoGameId");
                });

            modelBuilder.Entity("GameEngine.Models.GamePlayer", b =>
                {
                    b.HasOne("GameEngine.Models.GamePlayers", null)
                        .WithMany("Players")
                        .HasForeignKey("GamePlayersId");
                });

            modelBuilder.Entity("GameEngine.Models.LudoGame", b =>
                {
                    b.HasOne("GameEngine.Models.GamePlayer", "NextPlayer")
                        .WithMany()
                        .HasForeignKey("NextPlayerGamePlayerID");

                    b.HasOne("GameEngine.Models.GamePlayers", "Players")
                        .WithMany()
                        .HasForeignKey("PlayersGamePlayersId");

                    b.HasOne("GameEngine.Models.GamePlayer", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerGamePlayerID");

                    b.Navigation("NextPlayer");

                    b.Navigation("Players");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("GameEngine.Models.GamePlayers", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("GameEngine.Models.LudoGame", b =>
                {
                    b.Navigation("Moves");

                    b.Navigation("PieceSetup");
                });
#pragma warning restore 612, 618
        }
    }
}
