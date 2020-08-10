using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanerOdev
{
    class Handler
    {
        Meal[] _allMeals = null;
        Employee[] _allEmployees = null;
        Customer[] _allCustomers = null;
        Order[] _allOrders = null;
        Prepare[] _allPrepares = null;
        DataBaseOperator db = null;




        public Handler(Meal[] allMeals, Employee[] allEmployees, Customer[] allCustomers, Order[] allOrders, Prepare[] allPrepares, DataBaseOperator db)
        {
            _allEmployees = allEmployees;
            _allMeals = allMeals;
            _allCustomers = allCustomers;
            _allOrders = allOrders;
            _allPrepares = allPrepares;

            this.db = db;
        }

        public Meal[] AllMeals
        {
            get
            {
                return _allMeals;
            }

            set
            {
                _allMeals = value;
            }
        }

        public Employee[] AllEmployees
        {
            get
            {
                return _allEmployees;
            }

            set
            {
                _allEmployees = value;
            }
        }


        void ShowEmployeeList()
        {
            int currentEmployee = 1;
            Console.WriteLine("------ Employee List -------");
            foreach (Employee e in _allEmployees)
            {
                string employeeString = currentEmployee + "-) Employee ID : " + e.Id + " | Name : " + e.Name + " | Position : " + e.Position;
                Console.WriteLine(employeeString);
                currentEmployee++;
            }



        }

        void ShowMealList()
        {
            int currentMeal = 1;
            Console.WriteLine("------- Meal List -------");

            foreach (Meal m in _allMeals)
            {
                string mealString = currentMeal + "-) Meal ID : " + m.MealId + " | Name : " + m.Name + " | Price : " + m.Price + " | Quantity : " + m.Quantity;
                Console.WriteLine(mealString);
                currentMeal++;
            }


        }

        void ShowCustomerList()
        {
            int currentCustomer = 1;

            Console.WriteLine("--------Customer List --------");

            foreach (Customer c in _allCustomers)
            {
                string customerString = currentCustomer + "-) Customer ID :" + c.CustomerId + " | Name : " + c.Name + " | Phone : " + c.PhoneNumber;
                Console.WriteLine(customerString);
                currentCustomer++;
            }

        }

        bool CheckEmployeeOnPrepare(float employeeId)
        {
            for (int i = 0; i < _allPrepares.Length; i++)
            {
                if (_allPrepares[i].EmployeeId == employeeId)
                {
                    return true;
                }

            }

            return false;

        }

        void AddOrder(Customer customer, float employeeId)
        {



            Order newOrder = null;

            string orderTime;
            orderTime = GetOrderTime();

            float mealId = MealSelectionForOrder();

            float quantity = 0;


            Console.WriteLine("Enter Order Amount :");
            quantity = Convert.ToSingle(Console.ReadLine());

            float orderId = GetOrderId();

            newOrder = new Order(orderId, false, quantity, orderTime, customer.CustomerId);

            db.InsertOrder(newOrder);
            AddPrepare(mealId, employeeId);
            Console.WriteLine("Your Order Is Successfuly Created");






        }

        float GetOrderId()
        {
            bool isIdUnique = false;

            Random rand = new Random();

            float orderId;

            orderId = rand.Next() % 100000;

            while (!isIdUnique)
            {
                orderId = rand.Next() % 100000;
                if (IsOrderIdExist(orderId))
                {
                    isIdUnique = true;
                    break;
                }

            }

            return orderId;

        }

        string GetOrderTime()
        {
            string time;
            time = DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt");
            return time;
        }

        float MealSelectionForOrder()
        {
            float mealId = 0;
            ShowMealList();

            Console.WriteLine("Enter Meal ID For Order: ");
            mealId = Convert.ToSingle(Console.ReadLine());

            return mealId;

        }

        void CustomerSelection()
        {
            int selection = 0;

            Console.WriteLine("-------- Customer Selection --------");
            Console.WriteLine("1-)New Customer");
            Console.WriteLine("2-)Existing Customer");
            selection = Convert.ToInt32(Console.ReadLine());

            switch (selection)
            {
                default:
                    Console.WriteLine("Unknown Selection, Please enter correct selection according to menu ...");
                    break;
                case 1:
                    AskNewCustomerInfo();
                    StartMenu();

                    break;

                case 2:
                    AskExistingCustomer();
                    break;
            }


        }

        void AskExistingCustomer()
        {
            Customer customer = null;
            Employee employee = null;

            float customerId = 0;
            float employeeId = 0;

            Console.WriteLine("-------- Existing Customer --------");
            ShowCustomerList();

            Console.WriteLine("Enter Customer Id To Give Order");
            customerId = Convert.ToSingle(Console.ReadLine());

            customer = SelectCustomer(customerId);

            Console.WriteLine("Enter Employee Id To Assign Employee To The Order");
            employeeId = Convert.ToSingle(Console.ReadLine());

            employee = SelectEmployee(employeeId);


            if (!CheckEmployeeOnPrepare(employeeId))
            {
                AddOrder(customer, employeeId);


            }
            else
            {
                bool retry = false;
                Console.WriteLine("Personel Unavailable !");

                while (!retry)
                {
                    Console.WriteLine("Enter Employee Id To Assign Employee To The Order");
                    employeeId = Convert.ToSingle(Console.ReadLine());

                    if (!CheckEmployeeOnPrepare(employeeId))
                    {
                        AddOrder(customer, employeeId);
                        retry = true;
                        break;

                    }

                }
            }




        }

        void AskNewCustomerInfo()
        {
            string customerName, phoneNumber;
            float employeeId, customerId;
            Employee employee = null;
            Customer newCustomer = null;
            bool isCustomerIdUnique = false;

            Console.WriteLine("-------- NEW CUSTOMER --------");
            Console.WriteLine("Enter Customer Name : ");
            customerName = Console.ReadLine();

            Console.WriteLine("Enter Customer Phone Number :");
            phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Employee Name To Assign Employee For New Customer :");
            employeeId = Convert.ToSingle(Console.ReadLine());

            employee = SelectEmployee(employeeId);

            customerId = CreateCustomerId();


            while (isCustomerIdUnique)
            {
                customerId = CreateCustomerId();

                if (IsCustomerIdExist(customerId))
                {
                    break;
                }
            }

            newCustomer = new Customer(customerId, customerName, phoneNumber, employeeId);

            db.InsertNewCustomer(newCustomer);
            AddNewCustomer(newCustomer);
            if (!CheckEmployeeOnPrepare(employeeId))
            {
                AddOrder(newCustomer, employeeId);


            }
            else
            {
                bool retry = false;
                Console.WriteLine("Personel Unavailable !");

                while (!retry)
                {
                    Console.WriteLine("Enter Employee Id To Assign Employee To The Order");
                    employeeId = Convert.ToSingle(Console.ReadLine());

                    if (!CheckEmployeeOnPrepare(employeeId))
                    {
                        AddOrder(newCustomer, employeeId);
                        retry = true;
                        break;

                    }

                }
            }



        }

        bool IsCustomerIdExist(float customerId)
        {

            for (int i = 0; i < _allCustomers.Length; i++)
            {
                if (_allCustomers[i].CustomerId == customerId)
                {
                    return false;

                }

            }

            return true;
        }

        bool IsOrderIdExist(float orderId)
        {
            for (int i = 0; i < _allOrders.Length; i++)
            {
                if (_allOrders[i].OrderId == orderId)
                {
                    return false;

                }

            }

            return true;
        }

        bool IsEmployeeIdExist(float employeeId)
        {
            for (int i = 0; i < _allEmployees.Length; i++)
            {
                if (_allEmployees[i].Id == employeeId)
                {
                    return false;

                }

            }

            return true;
        }

        void AddPrepare(float mealId, float employeeId)
        {
            Prepare[] tempPrepares = new Prepare[_allPrepares.Length + 1];

            Prepare newPrepare = new Prepare(employeeId, mealId);

            for (int i = 1; i < _allPrepares.Length; i++)
            {

                if (i == _allCustomers.Length)
                {
                    tempPrepares[i] = newPrepare;
                }

                else
                {
                    tempPrepares[i] = _allPrepares[i];
                }
            }

            db.InsertNewPrepare(newPrepare);
        }

        float CreateCustomerId()
        {
            Random rand = new Random();

            float newCustomerId = 0;

            newCustomerId = rand.Next() % 100000;


            for (int i = 0; i < _allCustomers.Length; i++)
            {
                if (_allCustomers[i].CustomerId == newCustomerId)
                {
                    newCustomerId = rand.Next() % 100000;
                }
            }

            return newCustomerId;
        }

        void AddNewCustomer(Customer newCustomer)
        {
            Customer[] tempCustArr = new Customer[_allCustomers.Length + 1];


            for (int i = 1; i < _allCustomers.Length + 1; i++)
            {

                if (i == _allCustomers.Length)
                {
                    tempCustArr[i] = newCustomer;
                }

                else
                {
                    tempCustArr[i] = _allCustomers[i];
                }
            }

            _allCustomers = tempCustArr;
        }


        Meal SelectMeal(string mealName)
        {
            Meal meal = null;
            for (int i = 0; i < _allMeals.Length; i++)
            {
                if (_allMeals[i].Name == mealName)
                {
                    meal = _allMeals[i];
                }
            }

            return meal;
        }

        void DeletePrepare()
        {
            float employeeId;

            ShowEmployeeList();



            bool tryAgain = true;


            while (tryAgain)
            {
                Console.WriteLine("Enter Employee Id(PRESS '2' TO EXIT): ");
                employeeId = Convert.ToSingle(Console.ReadLine());

                if (CheckEmployeeOnPrepare(employeeId))
                {
                    db.DeletePrepare(employeeId);
                    tryAgain = true;
                    break;
                }

                else if (employeeId == 2)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Employee Job Not Found Please Enter Valid Employee ID !");
                }



            }



        }

        void AddEmployee()
        {
            string name, state, city, salary, position, startDate;
            float zipCode, id, departmentId;
            bool isIdUnique = false;

            Employee employee = null;

            Console.WriteLine("-------- New Employee --------");

            Console.WriteLine("Enter Employee Name : ");
            name = Console.ReadLine();

            Console.WriteLine("Enter Position : ");
            position = Console.ReadLine();

            Console.WriteLine("Enter State :");
            state = Console.ReadLine();

            Console.WriteLine("Enter City :");
            city = Console.ReadLine();

            Console.WriteLine("Enter Salary: ");
            salary = Console.ReadLine();

            Console.WriteLine("Enter Zipcode : ");
            zipCode = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter Department ID : ");
            departmentId = Convert.ToSingle(Console.ReadLine());



            startDate = GetOrderTime();

            id = GetOrderId();

            while (!isIdUnique)
            {
                id = GetOrderId();

                if (IsEmployeeIdExist(id))
                {
                    isIdUnique = true;
                    break;
                }

            }


            employee = new Employee(id, name, position, state, city, salary, startDate, departmentId, zipCode);

            db.InsertNewEmployee(employee);


        }

        void UpdateCustomerInfo()
        {
            Customer customer = null;
            float customerId;

            bool isFound = false;

            Console.WriteLine("-------- UPDATE CUSTOMER INFO --------");

            ShowCustomerList();

            while (!isFound)
            {

                Console.WriteLine("Enter Customer Id :");

                customerId = Convert.ToSingle(Console.ReadLine());

                customer = SelectCustomer(customerId);

                if (customer != null)
                {
                    isFound = true;
                    break;
                }

                else
                {
                    Console.WriteLine("Customer Not Found, Please Enter Valid Customer ID.");
                }
            }

            string name, phoneNumber;
            float employeeId;

            Console.WriteLine("Enter New Customer Name :");
            name = Console.ReadLine();

            customer.Name = name;

            Console.WriteLine("Enter New Customer Phone Number : ");
            phoneNumber = Console.ReadLine();

            customer.PhoneNumber = phoneNumber;

            Console.WriteLine("Enter Employee ID to Assign Customer To An Employee :");
            ShowEmployeeList();
            employeeId = Convert.ToSingle(Console.ReadLine());

            customer.EmployeeId = employeeId;

            db.UpdateCustomerInfo(customer);


        }

        Employee SelectEmployee(float employeeId)
        {
            Employee employee = null;
            for (int i = 0; i < _allEmployees.Length; i++)
            {
                if (_allEmployees[i].Id == employeeId)
                {
                    employee = _allEmployees[i];
                }
            }
            return employee;
        }

        Customer SelectCustomer(float customerId)
        {
            Customer customer = null;

            for (int i = 0; i < _allCustomers.Length; i++)
            {
                if (_allCustomers[i].CustomerId == customerId)
                {
                    customer = _allCustomers[i];
                }
            }

            return customer;
        }


        public void LogInScreen()
        {
            int selection;

            Console.WriteLine("-------- |LOGIN SCREEN| --------");
            Console.WriteLine("1-)Login As Employee :");
            Console.WriteLine("2-)Login As Manager :");
            selection = Convert.ToInt32(Console.ReadLine());


            switch (selection)
            {
                default:
                    Console.WriteLine("Unknown Selection, Please enter correct selection according to menu ...");
                    LogInScreen();
                    break;

                case 1:

                    bool isEmployeeVerified = false;

                    while (isEmployeeVerified == false)
                    {
                        if (userAuthentication())
                        {
                            isEmployeeVerified = true;
                            EmployeeStartMenu();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Password !");
                        }
                    }

                    break;
                case 2:

                    bool isManagerVerified = false;

                    while (isManagerVerified == false)
                    {
                        if (userAuthentication())
                        {
                            isManagerVerified = true;
                            StartMenu();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Password !");
                        }
                    }

                    break;


            }

        }

        bool userAuthentication()
        {
            string employeePassword = "12345";
            string managerPassword = "123456";
            string password;

            Console.WriteLine("Enter Password :");
            password = Console.ReadLine();

            if (password == employeePassword || password == managerPassword)
            {
                return true;
            }

            return false;

        }

        void EmployeeStartMenu()
        {
            int selection;

            Console.WriteLine("-------- Employee Menu --------");
            Console.WriteLine("1-)Add Order");
            Console.WriteLine("2-)Check In Finished Order");
            Console.WriteLine("3-)Update Customer Info");
            Console.WriteLine("4-)Exit ");

            selection = Convert.ToInt32(Console.ReadLine());



            switch (selection)
            {
                default:
                    Console.WriteLine("Unknown Selection, Please enter correct selection according to menu ...");
                    EmployeeStartMenu();
                    break;
                case 1:
                    CustomerSelection();
                    StartMenu();
                    break;
                case 2:
                    DeletePrepare();
                    StartMenu();
                    break;
                case 3:
                    UpdateCustomerInfo();
                    StartMenu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;

            }

        }

        void StartMenu()
        {



            int selection = 0;
            Console.WriteLine("-----Order System -------");
            Console.WriteLine("1-)Show Employee List");
            Console.WriteLine("2-)Show Meal List");
            Console.WriteLine("3-)Add Order");
            Console.WriteLine("4-)Check In Finished Order");
            Console.WriteLine("5-)Add Employee");
            Console.WriteLine("6-)Update Customer Info");
            Console.WriteLine("7-)Exit ");
            selection = Convert.ToInt32(Console.ReadLine());

            switch (selection)
            {
                default:
                    Console.WriteLine("Unknown Selection, Please enter correct selection according to menu ...");
                    break;
                case 1:
                    ShowEmployeeList();
                    StartMenu();
                    break;
                case 2:
                    ShowMealList();
                    StartMenu();
                    break;
                case 3:
                    CustomerSelection();
                    StartMenu();
                    break;
                case 4:
                    DeletePrepare();
                    StartMenu();
                    break;
                case 5:
                    AddEmployee();
                    StartMenu();
                    break;
                case 6:
                    UpdateCustomerInfo();
                    StartMenu();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;


            }



        }
    }
}
