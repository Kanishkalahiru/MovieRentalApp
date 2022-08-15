using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using MovieRentalApp.Models;
using System.Data;

namespace MovieRentalApp.DAL
{
    public class MoviesDAL
    {
        string connString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();

        //Get list of all movies
        public List<MovieViewModel> getAllMovies()
        {
            List<MovieViewModel> movieList = new List<MovieViewModel>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT movieId ,movieName FROM movies";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtMovies = new DataTable();

                conn.Open();
                sqlDA.Fill(dtMovies);
                conn.Close();

                foreach(DataRow dr in dtMovies.Rows)
                {
                    movieList.Add(new MovieViewModel
                    {
                        movieId = (int)dr["movieId"],
                        movieName = dr["movieName"].ToString()
                    }) ;
                }
            }

                return movieList;
        }

    }
}