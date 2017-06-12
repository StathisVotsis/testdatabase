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

        public void Insert(int Id)
        {
            var customer = new Customer();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["det"].ToString()))
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "INSERT INTO Table2(Id) VALUES(@Id);";
                sqlCmd.Parameters.Add(new SqlParameter("@Id", Id));
                sqlCmd.Connection = connection;
                connection.Open();
                sqlCmd.ExecuteNonQuery();

            }


            //return customer;

        }

        public void Update(int Id)
        {
            var customer = new Customer();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["det"].ToString()))
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "UPDATE Table2 SET FirstName='ok' where Id='" + Id + "';";

                sqlCmd.Connection = connection;
                connection.Open();
                sqlCmd.Parameters.Add(new SqlParameter("@Id", Id));
                sqlCmd.Connection = connection;
                connection.Open();

                sqlCmd.ExecuteNonQuery();

            }


            //return customer;

        }

        public void Insert2(Customer customer)
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["det"].ToString()))
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "INSERT INTO Table2(Id,FirstName,LastName,Email) VALUES(@Id,@FirstName,@LastName,@Email);";
                sqlCmd.Parameters.Add(new SqlParameter("@Id", customer.Id));
                sqlCmd.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
                sqlCmd.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
                sqlCmd.Parameters.Add(new SqlParameter("@Email", customer.Email));
                sqlCmd.Connection = connection;
                connection.Open();
                sqlCmd.ExecuteNonQuery();

            }

        }
    }
}