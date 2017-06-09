using Stathis.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Stathis.Repository
{
    public class CustomerRepository
    {
        public Customer GetById(int Id)
        {
            var customer = new Customer();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["det"].ToString()))
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * from Table2 where Id='" + Id + "';";
                sqlCmd.Connection = connection;
                connection.Open();
                //SqlDataReader reader = sqlCmd.ExecuteReader();
                 using (var reader = sqlCmd.ExecuteReader())
                 {

                 while (reader.Read())
                 {
                    customer.Id = Int32.Parse(reader["Id"].ToString());
                    customer.FirstName = reader["FirstName"].ToString();
                    customer.Email = reader["Email"].ToString();
                }
                 }

            }


            return customer;

        }

        public Customer GetByString(string Name)
        {
            var customer = new Customer();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["det"].ToString()))
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * from Table2 where FirstName='" + Name + "';";
                sqlCmd.Connection = connection;
                connection.Open();
                //SqlDataReader reader = sqlCmd.ExecuteReader();
                using (var reader = sqlCmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        //customer.Id = Int32.Parse(reader["Id"].ToString());
                        //customer.FirstName = reader["FirstName"].ToString();
                        customer.Email = reader["Email"].ToString();
                    }
                }

            }


            return customer;

        }
    }
}