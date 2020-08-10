using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanerOdev
{
    class Department
    {
        float _depId;
        string _depName;

        public float DepId
        {
            get
            {
                return _depId;
            }
            set
            {
                _depId = value;
            }
        }

        public string DepName
        {
            get
            {
                return _depName;
            }

            set
            {
                _depName = value;
            }
        }

        public Department(float depId, string depName)
        {
            _depId = depId;
            _depName = depName;

        }

    }
}
