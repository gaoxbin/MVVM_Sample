using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMDemo.Services
{
    interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}
