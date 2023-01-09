using EmployeeApplication.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeApplication.Business
{
    public class BLEmployee
    {
        public BLEmployee() { }
        DLEmployee dataAccess = new DLEmployee();

        public int AddOrUpdateEmployee(string name, string emailId, string address, string contactNo)
        {
            int result = 0;
            Employee employee = dataAccess.GetEmployeeByEmailId(emailId);

            if (employee != null)
            {
                dataAccess.UpdateEmployeeByEmailId(name, emailId, address, contactNo);
                result = 1;
            }            
            else
            {
                Employee employeeContact = dataAccess.GetEmployeeByContactId(contactNo);
                if (employeeContact != null && employeeContact.ContactNo == contactNo)
                {
                    result = 2;
                }
                else
                {
                    dataAccess.InsertEmployee(name, emailId, address, contactNo);
                    result = 3;
                }             
            }
            return result;
        }

        public int DeleteEmployeeByEmailId(string emailId)
        {
            int deletedRows = dataAccess.DeleteEmployeeByEmailId(emailId);
            return deletedRows;
        }

        public DataTable ViewEmployeeByEmailId(string emailId)
        {
            DataTable dt = dataAccess.ViewEmployeeByEmailId(emailId);
            return dt;
        }

        public DataTable ViewEmployeeDetails()
        {
            DataTable dt = dataAccess.ViewEmployeeDetails();
            return dt;
        }

        public SqlDataReader BindEmployees(string emailId)
        {
            return dataAccess.BindEmployeeDetails(emailId); 
        }
    }        
}