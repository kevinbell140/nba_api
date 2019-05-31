using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAApi.Migrations
{
    public partial class newdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LeagueID = table.Column<string>(nullable: true),
                    Conference = table.Column<string>(nullable: true),
                    Division = table.Column<string>(nullable: true),
                    PrimaryColor = table.Column<string>(nullable: true),
                    SecondaryColor = table.Column<string>(nullable: true),
                    TertiaryColor = table.Column<string>(nullable: true),
                    WikipediaLogoUrl = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    SeasonType = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    HomeTeamID = table.Column<int>(nullable: true),
                    AwayTeamID = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    AwayTeamScore = table.Column<int>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: true),
                    PointSpread = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    OverUnder = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    AwayTeamMoneyLine = table.Column<int>(nullable: true),
                    HomeTeamMoneyLine = table.Column<int>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Game_Team_AwayTeamID",
                        column: x => x.AwayTeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Team_HomeTeamID",
                        column: x => x.HomeTeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Jersey = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    UsaTodayHeadshotUrl = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ConferenceWins = table.Column<int>(nullable: false),
                    ConferenceLosses = table.Column<int>(nullable: false),
                    DivisionWins = table.Column<int>(nullable: false),
                    DivisionLosses = table.Column<int>(nullable: false),
                    HomeWins = table.Column<int>(nullable: false),
                    HomeLosses = table.Column<int>(nullable: false),
                    AwayWins = table.Column<int>(nullable: false),
                    AwayLosses = table.Column<int>(nullable: false),
                    LastTenWins = table.Column<int>(nullable: false),
                    LastTenLosses = table.Column<int>(nullable: false),
                    Streak = table.Column<int>(nullable: false),
                    GamesBack = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Standings_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsID);
                    table.ForeignKey(
                        name: "FK_News_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameStats",
                columns: table => new
                {
                    StatID = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Started = table.Column<int>(nullable: true),
                    Minutes = table.Column<int>(nullable: false),
                    FieldGoalsMade = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FieldGoalsAttempted = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FieldGoalsPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThreePointersMade = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThreePointersAttempted = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThreePointersPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FreeThrowsMade = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FreeThrowsAttempted = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FreeThrowsPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OffensiveRebounds = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DefensiveRebounds = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Rebounds = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Assists = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Steals = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BlockedShots = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Turnovers = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PersonalFouls = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Points = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PlusMinus = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameStats", x => x.StatID);
                    table.ForeignKey(
                        name: "FK_PlayerGameStats_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameStats_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSeasonStats",
                columns: table => new
                {
                    StatID = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    Games = table.Column<int>(nullable: false),
                    FieldGoalsPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FreeThrowsPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThreePointersMade = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Points = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Assists = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Rebounds = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Steals = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BlockedShots = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Turnovers = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSeasonStats", x => x.StatID);
                    table.ForeignKey(
                        name: "FK_PlayerSeasonStats_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_AwayTeamID",
                table: "Game",
                column: "AwayTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_HomeTeamID",
                table: "Game",
                column: "HomeTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_News_PlayerID",
                table: "News",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamID",
                table: "Player",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameStats_GameID",
                table: "PlayerGameStats",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameStats_PlayerID",
                table: "PlayerGameStats",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSeasonStats_PlayerID",
                table: "PlayerSeasonStats",
                column: "PlayerID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PlayerGameStats");

            migrationBuilder.DropTable(
                name: "PlayerSeasonStats");

            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
