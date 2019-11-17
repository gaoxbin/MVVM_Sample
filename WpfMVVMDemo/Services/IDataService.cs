using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMDemo.Client.Models;

namespace WpfMVVMDemo.Client.Services
{
    interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
