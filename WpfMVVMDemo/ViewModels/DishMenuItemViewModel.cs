using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMDemo.Client.Models;



namespace WpfMVVMDemo.Client.ViewModels
{
    class DishMenuItemViewModel: BindableBase
    {
        public Dish Dish { get; set; }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set 
            {
                SetProperty(ref isSelected, value);
            }
        }
    }
}
