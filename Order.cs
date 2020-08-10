using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanerOdev
{
    class Order
    {
        float _orderId;
        
        bool _orderStatus;

        float _quantity;

        string _time;

        float _customerId;



        public float OrderId { 
            get
            {
                return _orderId; 
            } 
            set 
            {
              _orderId = value; 
            } 
        }

        public bool OrderStatus
        {
            get
            {
                return _orderStatus;
            }
            
            set
            {
                _orderStatus = value;
            }

        }

        public float Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
            }
        }

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

        public string Time 
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }

        }

        public Order(float orderId, bool orderStatus, float quantity, string time, float customerId)
        {
            _orderId = orderId;
            _orderStatus = orderStatus;
            _quantity = quantity;
            _time = time;
            _customerId = customerId;

        }

        public Order()
        {

        }

    }
}
