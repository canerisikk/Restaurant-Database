using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanerOdev
{
    class Meal
    {
        float _mealId;
        string _name;
        float _quantity;
        string _price;

        public float MealId
        {
            get
            {
                return _mealId;
            }

            set
            {
                _mealId = value;
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

        public string Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }


        public Meal(float mealId,string name, float quantity,string price)
        {
            _mealId = mealId;
            _name = name;
            _quantity = quantity;
            _price = price;

        }
        public Meal()
        {

        }
    }
}
