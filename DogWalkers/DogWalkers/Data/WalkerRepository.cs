using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;
using DogWalkers.Models;

namespace DogWalkers.Data
{
    class WalkerRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DogWalking;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Walker> GetAllWalkers()
        {
   
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, NeighborhoodId FROM Walker";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Walker> walkers = new List<Walker>();

                while (reader.Read())
                {
                    // The "ordinal" is the numeric position of the column in the query results.
                    //  For our query, "Id" has an ordinal value of 0 and "DeptName" is 1.
                    int idColumnPosition = reader.GetOrdinal("Id");

                    // We user the reader's GetXXX methods to get the value for a particular ordinal.
                    int idValue = reader.GetInt32(idColumnPosition);

                    int nameColumnPosition = reader.GetOrdinal("Name");
                    string nameValue = reader.GetString(nameColumnPosition);

                    int neighborhoodColumnPosition = reader.GetOrdinal("NeighborhoodId");
                    int neighborhoodValue = reader.GetInt32(neighborhoodColumnPosition);

                    // Now let's create a new department object using the data from the database.
                    Walker walker = new Walker
                    {
                        Id = idValue,
                        Name = nameValue,
                        NeighborhoodId = neighborhoodValue
                    };

                    // ...and add that department object to our list.
                    walkers.Add(walker);
                }

                // We should Close() the reader. Unfortunately, a "using" block won't work here.
                reader.Close();

                // Return the list of departments who whomever called this method.
                return walkers;
            }
        }

        public List<Walker> GetAllWalkersByNeighborhoodId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT w.Id, w.Name, w.NeighborhoodId, n.Name as 'Neighborhood Name' FROM Walker w LEFT JOIN Neighborhood n on w.NeighborhoodId = n.Id WHERE n.Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Walker> allNeighborhoodWalkers = new List<Walker>();

                    Walker walker = null;

                    while (reader.Read())

                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int IdValue = reader.GetInt32(idColumnPosition);

                        int NameColumnPosition = reader.GetOrdinal("Name");
                        string NameValue = reader.GetString(NameColumnPosition);

                        int neighborhoodColumnPosition = reader.GetOrdinal("Neighborhood Name");
                        string neighborhoodValue = reader.GetString(neighborhoodColumnPosition);

                        int neighborhoodIdColumnPosition = reader.GetOrdinal("neighborhoodId");
                        int neighborhoodIdValue = reader.GetInt32(neighborhoodIdColumnPosition);

                        walker = new Walker
                        {
                            Id = IdValue,
                            Name = NameValue,
                            NeighborhoodId = neighborhoodIdValue,
                            Neighborhood = new Neighborhood
                            {
                                Name = neighborhoodValue,
                                Id = neighborhoodIdValue
                            }
                        };
                        allNeighborhoodWalkers.Add(walker);
                    }

                    reader.Close();
                    return allNeighborhoodWalkers;
                }
            }
        }


        public void AddWalker(Walker walker)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                  
                    cmd.CommandText = "INSERT INTO Walker (Name, NeighborhoodId) OUTPUT INSERTED.Id Values (@Name, @NeighborhoodId)";
                    cmd.Parameters.Add(new SqlParameter("@Name", walker.Name));
                    cmd.Parameters.Add(new SqlParameter("@NeighborhoodId", walker.NeighborhoodId));

                    int id = (int)cmd.ExecuteScalar();

                    walker.Id = id;
                }
            }
        }





    }
}
