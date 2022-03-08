﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReversiRestApiMVC
{
    public class SpelAccessLayer : ISpelRepository
    {
        private const string ConnectionString = @"Server=localhost\sqlexpress;Database=ReversiDbRestApi;User Id=nick;Password=NickAlmelo69!;";

        public void AddSpel(Spel spel)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = sqlCon.CreateCommand();
                sqlCmd.CommandText = "INSERT INTO Spel (GUID, Omschrijving, Speler1token, StringBord) VALUES (@GUID, @Omschrijving, @Speler1token, @StringBord)";
                sqlCmd.Parameters.Add("@GUID", SqlDbType.VarChar).Value = spel.Token;
                sqlCmd.Parameters.Add("@Omschrijving", SqlDbType.VarChar).Value = spel.Omschrijving;
                sqlCmd.Parameters.Add("@Speler1token", SqlDbType.VarChar).Value = spel.Speler1Token;
                sqlCmd.Parameters.Add("@StringBord", SqlDbType.VarChar).Value = JsonConvert.SerializeObject(spel.Bord);
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
                sqlCmd.CommandText = "SELECT GUID, Omschrijving, Speler1token, Speler2token FROM Spel WHERE GUID=@spelToken";
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
        
        public Spel GetSpelBySpeler(string spelerToken)
        {
            Spel spel = new Spel();

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = sqlCon.CreateCommand();
                sqlCmd.CommandText = "SELECT GUID, Omschrijving, Speler1token, Speler2token FROM Spel WHERE Speler1token=@speler1Token OR Speler2token=@speler1Token";
                sqlCmd.Parameters.Add("@speler1Token",SqlDbType.VarChar).Value = spelerToken;
                sqlCmd.Parameters.Add("@speler2Token",SqlDbType.VarChar).Value = spelerToken;
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    spel.Token = rdr["GUID"].ToString();
                    spel.Omschrijving = rdr["Omschrijving"].ToString();
                    spel.Speler1Token = rdr["Speler1token"].ToString();
                    spel.Speler2Token = rdr["Speler2token"].ToString();
                }

                sqlCon.Close();
            }
            return spel;
        }

        public void SaveSpel(Spel spel)
        {
            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.Open();
                SqlCommand sqlCmd = sqlCon.CreateCommand();
                sqlCmd.CommandText = "UPDATE Spel SET StringBord=@stringBord WHERE GUID=@spelToken";
                string stringBord = JsonConvert.SerializeObject(spel.Bord);
                sqlCmd.Parameters.Add("@stringBord",SqlDbType.VarChar).Value = stringBord;
                sqlCmd.Parameters.Add("@spelToken",SqlDbType.VarChar).Value = spel.Token;
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                sqlCon.Close();
            }
        }

        public List<Spel> GetSpellen()
        {
            List<Spel> spelList = new List<Spel>();
            string sqlQuery = "SELECT GUID, Omschrijving, Speler1token, Speler2token FROM Spel";

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
