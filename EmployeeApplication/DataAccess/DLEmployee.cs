using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace EmployeeApplication.DataAccess
{
    public class DLEmployee
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        public DLEmployee()
        {}

        public Employee GetEmployeeByEmailId(string emailId)
        {
            connection.Open();
            Employee employee = new Employee();
            string selectQuery = $"SELECT NAME, EMAILID, ADDRESS, CONTACTNO FROM EMPLOYEE WHERE EMAILID = '{emailId}'";
            employee = connection.Query<Employee>(selectQuery).FirstOrDefault();
            connection.Close();
            return employee;
        }

        public void UpdateEmployeeByEmailId(string name, string emailId, string address, string contactNo)
        {
            string updateQuery = $"UPDATE EMPLOYEE SET NAME = '{name}', ADDRESS = '{address}', CONTACTNO = '{contactNo}' WHERE EMAILID = '{emailId}'";
            connection.Open();
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public Employee GetEmployeeByContactId(string contactNo)
        {
            connection.Open();
            string selectQuery = $"SELECT NAME, EMAILID, ADDRESS, CONTACTNO FROM EMPLOYEE WHERE CONTACTNO = '{contactNo}'";
            Employee employeeContact = connection.Query<Employee>(selectQuery).FirstOrDefault();
            connection.Close();
            return employeeContact;
        }

        public void InsertEmployee(string name, string emailId, string address, string contactNo)
        {
            connection.Open();
            string insertQuery = $"INSERT INTO EMPLOYEE (NAME, EMAILID, ADDRESS, CONTACTNO) VALUES ('{name}','{emailId}','{address}','{contactNo}')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public int DeleteEmployeeByEmailId(string emailId)
        {
            connection.Open();
            string deleteQuery = $"DELETE EMPLOYEE WHERE EMAILID = '{emailId}'";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            int deletedRows = deleteCommand.ExecuteNonQuery();
            connection.Close();
            return deletedRows;
        }

        public DataTable ViewEmployeeByEmailId(string emailId)
        {
            connection.Open();
            string viewQuery = $"SELECT NAME, EMAILID, ADDRESS, CONTACTNO FROM EMPLOYEE WHERE EMAILID = '{emailId}'";
            SqlCommand viewCommand = new SqlCommand(viewQuery, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(viewCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public DataTable ViewEmployeeDetails()
        {
            connection.Open();
            string viewAllQuery = $"SELECT NAME, EMAILID, ADDRESS, CONTACTNO FROM EMPLOYEE";
            SqlCommand command = new SqlCommand(viewAllQuery, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public SqlDataReader BindEmployeeDetails(string emailId)
        {
            connection.Open();
            string bindQuery = $"SELECT NAME, EMAILID, ADDRESS, CONTACTNO FROM EMPLOYEE WHERE EMAILID = '{emailId}'";
            SqlCommand command = new SqlCommand(bindQuery, connection);
            SqlDataReader r = command.ExecuteReader();
            return r;
        }
    }
}