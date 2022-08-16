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
                cmd.CommandType = CommandType.Text;
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

        public string getMovieName(int movieId)
        {
            string movieName = null;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT movieName FROM movies WHERE movieId = @movieId";
                cmd.Parameters.AddWithValue("@movieId", movieId);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        movieName = dr.GetString(0);
                    }
                    
                }
            }

                return movieName;
        }

        public void addMovie(MovieViewModel movie)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO movies (movieName) VALUES (@movieName);";
                cmd.Parameters.AddWithValue("@movieName", movie.movieName);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void editMovie(MovieViewModel movie)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE movies SET movieName = '@movieName' WHERE movieId = @movieId;";
                cmd.Parameters.AddWithValue("@movieName", movie.movieName);
                cmd.Parameters.AddWithValue("@movieId", movie.movieName);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

    }
}