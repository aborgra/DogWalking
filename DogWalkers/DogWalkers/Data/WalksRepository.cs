using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;

namespace DogWalkers.Data
{
   public class WalksRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DogWalking;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }



    }
}
