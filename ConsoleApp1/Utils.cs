using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public static class PersonUtil
    {
        static string connectionString = "Server=192.168.10.10;Database=simple;User Id=developer2;Password=Developer@2;";

        public static void ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static List<Person> GetAllPersons()
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllPersons", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person();
                    person.ID = Convert.ToInt32(reader["ID"]);
                    person.Name = Convert.ToString(reader["Name"]);
                    person.Age = Convert.ToInt32(reader["Age"]);

                    people.Add(person);
                }
            }

            return people;
        }

        public static void InsertPerson(Person person)
        {
            
            SqlParameter[] parameters = {
                new SqlParameter("@ID", person.ID),
                new SqlParameter("@Name", person.Name),
                new SqlParameter("@Age", person.Age)
            };

            ExecuteStoredProcedure("InsertPerson", parameters);
            Console.WriteLine("Person inserted successfully.");
        }

        public static Person GetPersonById(int id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ID", id)
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetPersonById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Person person = new Person();
                    person.ID = Convert.ToInt32(reader["ID"]);
                    person.Name = Convert.ToString(reader["Name"]);
                    person.Age = Convert.ToInt32(reader["Age"]);

                    return person;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void DeletePersonById(int id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@ID", id)
            };

            ExecuteStoredProcedure("DeletePersonById", parameters);
        }
    }
}
