using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanerOdev
{
    class Program
    {
       
        static void Main(string[] args)
        {
            DataBaseOperator db = new DataBaseOperator();
            Meal[] meals = db.GetMeals();
            Employee[] employees = db.GetEmployees();
            Order[] orders = db.GetOrders();
            Customer[] customers = db.GetCustomers();
            Prepare[] prepares = db.GetPrepares();

            /* Employee emp = db.GetEmployee("Caner Işık");
             Console.WriteLine(emp.Name);*/

            Handler hndlr = new Handler(meals, employees,customers,orders,prepares,db);

            hndlr.LogInScreen();



            Console.ReadLine();
        }
    }
}
