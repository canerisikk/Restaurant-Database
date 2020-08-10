using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanerOdev
{
    class Employee
    {
        float _id;
        string _name;
        string _position;
        string _state;
        string _city;
        string _salary;
        string _startDate;
        float _departmentId;
        float _zipCode;

        public float Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }

        public string Salary
        {
            get
            {
                return _salary;
            }

            set
            {
                _salary = value;
            }
        }

        public string StartDate
        {
            get
            {
                return _startDate;
            }

            set
            {
                _startDate = value;
            }
        }

        public float DepartmentId
        {
            get
            {
                return _departmentId;
            }

            set
            {
                _departmentId = value;
            }
        } 

        public float ZipCode
        {
            get
            {
                return _zipCode;
            }

            set
            {
                _zipCode = value;
            }
        }

        public Employee(float id,string name,string position,string state,string city, string salary, string startDate, float departmentId, float zipCode)
        {
            _id = id;
            _name = name;
            _position = position;
            _state = state;
            _city = city;
            _salary = salary;
            _startDate = startDate;
            _departmentId = departmentId;
            _zipCode = zipCode;
        }
        
        public Employee()
        {

        }

     



    }
}
