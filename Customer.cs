using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanerOdev
{
    class Customer
    {
        float _customerId;
        string _name;
        string _phoneNumber;
        float _employeeId;

        public float CustomerId
        {
            get
            {
                return _customerId;
            }

            set
            {
                _customerId = value;
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

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
            }
        }

        public float EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
            }
        } 

        public Customer(float customerId,string name, string phoneNumber, float employeeId)
        {
            _customerId = customerId;
            _name = name;
            _phoneNumber = phoneNumber;
            _employeeId = employeeId;

        }

        public Customer()
        {

        }
    }
}
