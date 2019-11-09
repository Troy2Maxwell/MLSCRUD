using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLS_CRUD.Models;
using MySql.Data.MySqlClient;

namespace MLS_CRUD
{
    public class TeamRepository
    {
        private static string connectionString = System.IO.File.ReadAllText("ConnectionString.txt");

        public List<Team> GetTeams()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM standings ORDER BY Points DESC;";
            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Team> allTeams = new List<Team>();

                while (reader.Read() == true)
                {
                    Team currentTeam = new Team();

                    currentTeam.TeamID = reader.GetInt32("tid");
                    if (reader.IsDBNull(reader.GetOrdinal("Conference")))
                    {
                        currentTeam.Conference = null;
                    }
                    else
                    {
                        currentTeam.Conference = reader.GetString("Conference");
                    }
                    
                    if (reader.IsDBNull(reader.GetOrdinal("Team_Name")))
                    {
                        currentTeam.TeamName = null;
                    }
                    else
                    {
                        currentTeam.TeamName = reader.GetString("Team_Name");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Games_Played")))
                    {
                        currentTeam.GamesPlayed = null;
                    }
                    else
                    {
                        currentTeam.GamesPlayed = reader.GetInt32("Games_Played");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Wins")))
                    {
                        currentTeam.Wins = null;
                    }
                    else
                    {
                        currentTeam.Wins = reader.GetInt32("Wins");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Losses")))
                    {
                        currentTeam.Losses = null;
                    }
                    else
                    {
                        currentTeam.Losses = reader.GetInt32("Losses");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Draws")))
                    {
                        currentTeam.Draws = null;
                    }
                    else
                    {
                        currentTeam.Draws = reader.GetInt32("Draws");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Goals_For")))
                    {
                        currentTeam.GoalsFor = null;
                    }
                    else
                    {
                        currentTeam.GoalsFor = reader.GetInt32("Goals_For");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Goals_Against")))
                    {
                        currentTeam.GoalsAgainst = null;
                    }
                    else
                    {
                        currentTeam.GoalsAgainst = reader.GetInt32("Goals_Against");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Goal_Difference")))
                    {
                        currentTeam.GoalDifference = null;
                    }
                    else
                    {
                        currentTeam.GoalDifference = reader.GetInt32("Goal_Difference");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Points")))
                    {
                        currentTeam.Points = null;
                    }
                    else
                    {
                        currentTeam.Points = reader.GetInt32("Points");
                    }

                    allTeams.Add(currentTeam);
                }

                return allTeams;
            }
        }
        public Team GetTeam(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM standings WHERE tid = @id;";
            cmd.Parameters.AddWithValue("id", id);

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                var team = new Team();

                while (reader.Read() == true)
                {
                    if (reader.IsDBNull(reader.GetOrdinal("Conference")))
                    {
                        team.Conference = null;
                    }
                    else
                    {
                        team.Conference = reader.GetString("Conference");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Team_Name")))
                    {
                        team.TeamName = null;
                    }
                    else
                    {
                        team.TeamName = reader.GetString("Team_Name");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Games_Played")))
                    {
                        team.GamesPlayed = null;
                    }
                    else
                    {
                        team.GamesPlayed = reader.GetInt32("Games_Played");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Wins")))
                    {
                        team.Wins = null;
                    }
                    else
                    {
                        team.Wins = reader.GetInt32("Wins");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Losses")))
                    {
                        team.Losses = null;
                    }
                    else
                    {
                        team.Losses = reader.GetInt32("Losses");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Draws")))
                    {
                        team.Draws = null;
                    }
                    else
                    {
                        team.Draws = reader.GetInt32("Draws");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Goals_For")))
                    {
                        team.GoalsFor = null;
                    }
                    else
                    {
                        team.GoalsFor = reader.GetInt32("Goals_For");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Goals_Against")))
                    {
                        team.GoalsAgainst = null;
                    }
                    else
                    {
                        team.GoalsAgainst = reader.GetInt32("Goals_Against");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Goal_Difference")))
                    {
                        team.GoalDifference = null;
                    }
                    else
                    {
                        team.GoalDifference = reader.GetInt32("Goal_Difference");
                    }

                    if (reader.IsDBNull(reader.GetOrdinal("Points")))
                    {
                        team.Points = null;
                    }
                    else
                    {
                        team.Points = reader.GetInt32("Points");
                    }

                }

                return team;
            }
        }
        public List<Team> GetEastTeams()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM standings WHERE Conference = 'Eastern' ORDER BY Points DESC;";
            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Team> allEastTeams = new List<Team>();

                while (reader.Read() == true)
                {
                    Team currentTeam = new Team();

                    currentTeam.TeamID = reader.GetInt32("tid");
                    currentTeam.Conference = reader.GetString("Conference");
                    currentTeam.TeamName = reader.GetString("Team_Name");
                    currentTeam.GamesPlayed = reader.GetInt32("Games_Played");
                    currentTeam.Wins = reader.GetInt32("Wins");
                    currentTeam.Losses = reader.GetInt32("Losses");
                    currentTeam.Draws = reader.GetInt32("Draws");
                    currentTeam.GoalsFor = reader.GetInt32("Goals_For");
                    currentTeam.GoalsAgainst = reader.GetInt32("Goals_Against");
                    currentTeam.GoalDifference = reader.GetInt32("Goal_Difference");
                    currentTeam.Points = reader.GetInt32("Points");

                    allEastTeams.Add(currentTeam);
                }

                return allEastTeams;
            }
        }

        public List<Team> GetWestTeams()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM standings WHERE Conference = 'Western' ORDER BY Points DESC;";
            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Team> allWestTeams = new List<Team>();

                while (reader.Read() == true)
                {
                    Team currentTeam = new Team();

                    currentTeam.TeamID = reader.GetInt32("tid");
                    currentTeam.Conference = reader.GetString("Conference");
                    currentTeam.TeamName = reader.GetString("Team_Name");
                    currentTeam.GamesPlayed = reader.GetInt32("Games_Played");
                    currentTeam.Wins = reader.GetInt32("Wins");
                    currentTeam.Losses = reader.GetInt32("Losses");
                    currentTeam.Draws = reader.GetInt32("Draws");
                    currentTeam.GoalsFor = reader.GetInt32("Goals_For");
                    currentTeam.GoalsAgainst = reader.GetInt32("Goals_Against");
                    currentTeam.GoalDifference = reader.GetInt32("Goal_Difference");
                    currentTeam.Points = reader.GetInt32("Points");

                    allWestTeams.Add(currentTeam);
                }

                return allWestTeams;
            }
        }

        public void InsertTeam(Team teamToInsert)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO standings (Team_Name, Conference) VALUES(@name, @conference);";
            
            cmd.Parameters.AddWithValue("name", teamToInsert.TeamName);
            cmd.Parameters.AddWithValue("conference", teamToInsert.Conference);

            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeam(string teamName)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM standings WHERE Team_Name = @teamName";
            cmd.Parameters.AddWithValue("teamName", teamName);

            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTeam(Team teamToUpdate)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE standings SET Games_Played = @gamesplayed, Wins=@wins, Losses=@losses," +
                " Goals_For=@goalsfor, " +
                "Goals_Against=@goalsagainst, Goal_Difference=@goaldifference, Points=@points WHERE tid = @tid;";
            
            cmd.Parameters.AddWithValue("gamesplayed", teamToUpdate.GamesPlayed);
            cmd.Parameters.AddWithValue("wins", teamToUpdate.Wins);
            cmd.Parameters.AddWithValue("losses", teamToUpdate.Losses);
            cmd.Parameters.AddWithValue("draws", teamToUpdate.Draws);
            cmd.Parameters.AddWithValue("goalsfor", teamToUpdate.GoalsFor);
            cmd.Parameters.AddWithValue("goalsagainst", teamToUpdate.GoalsAgainst);
            cmd.Parameters.AddWithValue("goaldifference", teamToUpdate.GoalDifference);
            cmd.Parameters.AddWithValue("points", teamToUpdate.Points);
            cmd.Parameters.AddWithValue("tid", teamToUpdate.TeamID);
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
