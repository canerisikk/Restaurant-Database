using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanerOdev
{
    class Prepare
    {
        float _employeeId;
        float _mealId;

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


        public Prepare(float employeeId, float mealId)
        {
            _mealId = mealId;
            _employeeId = employeeId;
        }
        public Prepare()
        {

        }
    }
}
