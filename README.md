# EmployeeApplication


1> Create New Project 

2> Create new Database of 'EmpDB' --> Created 'Employee' Table 

3> WebConfig --> Add connectionstring with Database

4> Created 'Employee.aspx' --> used to create UI for Employee Application and for validation rules

5> Work on 'Employee.aspx.cs' --> While Clicking on button field 'button event' occured so for that logic implemented here

6> Created New Model Class --> Employee.cs

7> Created New Folder For BusinessLayer 'Business' -> Created BLEmployee.cs -> BusinessLayer related logic implemented 
                
8> Created New Folder For DataAccessLayer 'DataAccess' -> created DLEmploee.cs -> DataLayer related Logic implemented


So,  Generalized flow of project is like 'Employee.aspx -> Employee.aspx.cs ->BLEmployee.cs -> DLEmployee.cs' and once we get data from 
Datalayer it will return with same flow but vice versa like --> 'DLEmployee.cs ->BLEMployee.cs ->Employee.aspx.cs ->Employee.aspx'

so in last user can able to data on screen.


I follow this architecture design because it's easy to maintain and easy to understand, Independent of Database and Frameworks, Anytime 
we can change the UI without changing the rest of the system and business logic, Highly testable, Scalable.
