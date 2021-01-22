using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SNI.Controllers
{
    class CustomerController
    {
        public static bool AddCustomer()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
