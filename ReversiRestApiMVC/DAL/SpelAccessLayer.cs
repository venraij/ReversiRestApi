using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApiMVC
{
    public class SpelAccessLayer : ISpelRepository
    {
        private const string ConnectionString = @"Server=localhost;Database=ReversiDbRestApi;User Id=SA;Password=Tijger08!;;";

        public void AddSpel(Spel spel)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = sqlCon.CreateCommand();
                sqlCmd.CommandText = "INSERT INTO Spel (GUID, Omschrijving, Speler1token) VALUES (@GUID, @Omschrijving, @Speler1token)";
                sqlCmd.Parameters.Add("@GUID", SqlDbType.VarChar).Value = spel.Token;
                sqlCmd.Parameters.Add("@Omschrijving", SqlDbType.VarChar).Value = spel.Omschrijving;
                sqlCmd.Parameters.Add("@Speler1token", SqlDbType.VarChar).Value = spel.Speler1Token;
                sqlCmd.ExecuteNonQuery();

                sqlCon.Close();
            }
        }

        public Spel GetSpel(string spelToken)
        {
            Spel spel = new Spel();

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = sqlCon.CreateCommand();
                sqlCmd.CommandText = "SELECT GUID, Omschrijving, Speler1token, Speler2token WHERE GUID=@spelToken";
                sqlCmd.Parameters.Add("@spelToken",SqlDbType.VarChar).Value = spelToken;
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                spel.Token = rdr["GUID"].ToString();
                spel.Omschrijving = rdr["Omschrijving"].ToString();
                spel.Speler1Token = rdr["Speler1token"].ToString();
                spel.Speler2Token = rdr["Speler2token"].ToString();

                sqlCon.Close();
            }
            return spel;
        }

        public List<Spel> GetSpellen()
        {
            List<Spel> spelList = new List<Spel>();
            string sqlQuery = "SELECT GUID, Omschrijving, Speler1token, Speler2token";

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    Spel spel = new Spel();
                    spel.Token = rdr["GUID"].ToString();
                    spel.Omschrijving = rdr["Omschrijving"].ToString();
                    spel.Speler1Token = rdr["Speler1token"].ToString();
                    spel.Speler2Token = rdr["Speler2token"].ToString();
                    spelList.Add(spel);
                }

                sqlCon.Close();
            }
            return spelList;
        }
    }
}
