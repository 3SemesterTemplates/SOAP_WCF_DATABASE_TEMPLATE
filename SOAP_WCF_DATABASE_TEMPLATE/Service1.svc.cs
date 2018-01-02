using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace SOAP_WCF_DATABASE_TEMPLATE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private const string ConnectionString =
           "Server=tcp:natascha.database.windows.net,1433;Initial Catalog=School;Persist Security Info=False;User ID=nataschajakobsen;Password=Roskilde4000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public int AddMovie(string titel, byte rating)
        {
            const string sql = "insert into Movies (Titel, Rating) values (@Titel, @Rating)";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand insertCommand = new SqlCommand(sql, conn))
                {
                    insertCommand.Parameters.AddWithValue("@Titel", titel);
                    insertCommand.Parameters.AddWithValue("@Rating", rating);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public void DeleteMovie(Movie deleteFilm)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMovie()
        {
            const string sql = "select * from movies order by id";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand selectCommand = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Movie> studentList = new List<Movie>();
                        while (reader.Read())
                        {
                            Movie student = ReadStudent(reader);
                            studentList.Add(student);
                        }
                        return studentList;
                    }
                }
            }
        }

        public void UpdateMovie(int id, Movie film)
        {
            throw new NotImplementedException();
        }


        private static Movie ReadStudent(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string titel = reader.GetString(1);
            int rating = reader.GetInt32(2);
            Movie film = new Movie
            {
                Id = id,
                Titel = titel,
                Rating = rating
                
            };
            return film;
        }
    }
}
