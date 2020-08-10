using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CanerOdev
{
    class DataBaseOperator
    {
        SqlConnection Connect()
        {
            string connetionString = null;
            SqlConnection cnn;

            //Connection Info For Database. Needs To Be Assigned Acording To Users DB Info.
            connetionString = "Data Source=MSI\\CANERSQL61;Initial Catalog=Restaurant;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();

               
            }
            catch (Exception ex)
            {
              
            }

            return cnn;
        }
        
        //Inserts new row to "Order" Table. Gets Order objects as parameter and uses it's data for insert operation.

        public void InsertOrder(Order order)
        {

            
            SqlConnection connection = Connect();

            int status = 0;

            if (order.OrderStatus == true)
            {
                status = 1;
            }
       
           
            string command = "Insert INTO Orders(id,Status,Quantity,Time,[Customer Id]) VALUES (" +order.OrderId +"," + status + "," +order.Quantity + ", '" + order.Time + "'," + order.CustomerId+")";
            SqlCommand cmd = new SqlCommand(command,connection);
            cmd.ExecuteNonQuery();
            connection.Close();

        }
     
        public void UpdateInsertOrder(Order order)
        {
            SqlConnection connection = Connect();

            int orderStatus = 0;

            if (order.OrderStatus == true)
            {
                orderStatus = 1;
            }

            string command = "Update dbo.Orders set Status = '" + orderStatus + "'" + "Where id = '"+ order.OrderId + "'";

            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            connection.Close();

        }


        public Employee[] GetEmployees()
        {
            Employee[] employees = null;


            string command = "Select * from Employee";

            
            SqlConnection conn = Connect();

            SqlCommand oCmd = new SqlCommand(command,conn);

            var employeeList = new List<Employee>();

            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                   

                    employeeList.Add(new Employee { Id = Convert.ToSingle(oReader["id"]), 
                    Name = oReader["name"].ToString(), 
                    Position = oReader["position"].ToString(), 
                    State = oReader["state"].ToString(), 
                    City = oReader["city"].ToString(),
                    Salary = oReader["salary"].ToString(),
                    StartDate = oReader["start date"].ToString(),
                    DepartmentId = Convert.ToSingle(oReader["department id"]),
                    ZipCode = Convert.ToSingle(oReader["zip code"])

                    });

                }

                conn.Close();

                employees = employeeList.ToArray();

                return employees;
            }
        }

        public Meal[] GetMeals()
        {

            Meal[] allMeals = null;

            string command = "Select * from Meal";

            SqlConnection conn = Connect();

            SqlCommand cmd = new SqlCommand(command, conn);

            var mealList = new List<Meal>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    mealList.Add(new Meal { MealId = Convert.ToSingle(reader["Id"]), Name = reader["Name"].ToString(), Quantity = Convert.ToSingle(reader["Quantity"]), Price = reader["Price"].ToString() });
                }
            }


            allMeals = mealList.ToArray();

            return allMeals;

        }

        public Order[] GetOrders()
        {
            Order[] allOrders = null;

            string command = "Select * from dbo.Orders";

            SqlConnection conn = Connect();

            SqlCommand cmd = new SqlCommand(command, conn);

            var orderList = new List<Order>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orderList.Add(new Order { 
                        OrderId = Convert.ToSingle(reader["id"]),
                        OrderStatus = Convert.ToBoolean(reader["Status"]),
                        Quantity = Convert.ToSingle(reader["Quantity"]),
                        Time = reader["Time"].ToString(),
                        CustomerId = Convert.ToSingle(reader["Customer Id"])
                    });
                }
            }

            allOrders = orderList.ToArray();
            return allOrders;
        }

        public Customer[] GetCustomers()
        {
            Customer[] allCustomers = null;

            string command = "Select * from Customer";


            SqlConnection conn = Connect();

            SqlCommand cmd = new SqlCommand(command, conn);

            var customerList = new List<Customer>();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    customerList.Add(new Customer
                    {
                        CustomerId = Convert.ToSingle(reader["id"]),
                        Name = reader["name"].ToString(),
                        PhoneNumber = reader["phone number"].ToString(),
                        EmployeeId = Convert.ToSingle(reader["Employee Id"])
                    });
                }
            }

            allCustomers = customerList.ToArray();

            return allCustomers;


        }

        public Prepare[] GetPrepares()
        {
            Prepare[] allPrepares = null;

            string command = "Select *  from Prepare";

            SqlConnection conn = Connect();

            SqlCommand cmd = new SqlCommand(command, conn);

            var prepareList = new List<Prepare>();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    prepareList.Add(new Prepare { EmployeeId = Convert.ToSingle(reader["[Employee Id"]), MealId = Convert.ToSingle(reader["Meal Id"]) });
                }
            }

            allPrepares = prepareList.ToArray();

            return allPrepares;


        }

        public void InsertNewCustomer(Customer customer)
        {
            SqlConnection connection = Connect();



            string command = "Insert INTO dbo.Customer(id,name,[phone number],[Employee Id]) VALUES (" +customer.CustomerId + ",'" + customer.Name + "', '" + customer.PhoneNumber + "'," + customer.EmployeeId+")";
            SqlCommand cmd = new SqlCommand(command,connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void InsertNewPrepare(Prepare prepare)
        {
           SqlConnection connection = Connect();



            string command = "Insert INTO dbo.Prepare([[Employee Id],[Meal Id]) VALUES (" +prepare.EmployeeId+"," + prepare.MealId+")";
            SqlCommand cmd = new SqlCommand(command,connection);
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void DeletePrepare(float employeeId)
        {

            SqlConnection connection = Connect();



            string command = "Delete From Prepare Where [[Employee Id] = '"+ employeeId + "'";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void InsertNewEmployee(Employee employee)
        {
            SqlConnection connection = Connect();



            string command = "insert into dbo.Employee(id,name,state,city,position,[start date],salary,[zip code],[department id]) VALUES("+employee.Id+", '"+employee.Name +"','"+employee.State+"','"+employee.City+"' ,'"+employee.Position+"' ,'"+employee.StartDate+"' ,'" + employee.Salary+"' ," +employee.ZipCode+ ","+ employee.DepartmentId + ")";
            Console.WriteLine(command);
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateCustomerInfo(Customer customer)
        {
            SqlConnection connection = Connect();



            string command = "Update  dbo.Customer set name = '" + customer.Name + "', [phone number] = '"+ customer.PhoneNumber + "',[Employee Id] = '"+customer.EmployeeId +"' where id = '"+customer.CustomerId+"'";
            Console.WriteLine(command);
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

        }






    }







}
