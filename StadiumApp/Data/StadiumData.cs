using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient
using StadiumApp.Models;

namespace StadiumApp.Data
{
    class StadiumData
    {
        public void Add(Stadions stadion)
        {
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"insert into Stadiums (Name,HourPrice,Capacity) VALUES ('{stadion.Name}',{stadion.HourlyPrice},{stadion.Capacity})";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Stadions> GetStadiums()
        {
            List<Stadions> stadiums1 = new List<Stadions>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "select * from Stadiums";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Stadions stadiums = new Stadions()
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourlyPrice = dr.GetInt32(2),
                            Capacity = dr.GetInt32(3)

                        };
                        stadiums1.Add(stadiums);

                    }
                }
            }
            return stadiums1;
        }


        public Stadions GetStadiumsId(int id)
        {
            Stadions stadiums1 = null;
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "select * from Stadiums Where Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        stadiums1 = new Stadions()
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourlyPrice = dr.GetInt32(2),
                            Capacity = dr.GetInt32(3)

                        };


                    }
                }
            }
            return stadiums1;
        }



        public void DeleteById(int id)
        {

            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"delete from Stadiums Where Id=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
