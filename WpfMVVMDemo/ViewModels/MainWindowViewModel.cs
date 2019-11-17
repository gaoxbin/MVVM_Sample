using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVMDemo.Client.Models;
using WpfMVVMDemo.Client.Services;
using WpfMVVMDemo.Services;

namespace WpfMVVMDemo.Client.ViewModels
{
    class MainWindowViewModel:BindableBase
    {
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        private int count;
        public int Count 
        { 
            get { return count; }
            set{SetProperty(ref count, value);}
        }

        private Restaurant restaurant;
        public Restaurant Restaurant 
        { 
            get { return restaurant; }
            set { SetProperty(ref restaurant, value); } 
        }

        private List<DishMenuItemViewModel> dishMenu;
        public List<DishMenuItemViewModel> DishMenu 
        {
            get { return dishMenu; }
            set{ SetProperty(ref dishMenu, value); }
        }

        public MainWindowViewModel()
        {
            this.LoadRestaurant();
            this.LoadDishMenu();
            this.PlaceOrderCommand = new DelegateCommand(new Action(this.PlaceOrderCommandExecute));
            this.SelectMenuItemCommand = new DelegateCommand(new Action(this.SelectMenuItemExecute));
        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "Crazy大象";
            this.Restaurant.Address = "北京市海淀区万泉路紫金庄园1号楼1层113室（亲们，这地儿特难找！）";
            this.Restaurant.PhoneNumber = "15210365423 or 82650336";
        }

        private void LoadDishMenu()
        {
            XmlDataService ds = new XmlDataService();
            var dishes = ds.GetAllDishes();
            this.dishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel item = new DishMenuItemViewModel();
                item.Dish = dish;
                this.DishMenu.Add(item);
            }
        }

        private void PlaceOrderCommandExecute()
        {
            var selectedDishes = this.DishMenu.Where(i => i.IsSelected == true).Select(i => i.Dish.Name).ToList() ;
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功");
        }

        private void SelectMenuItemExecute()
        {
            this.Count = this.DishMenu.Count(i => i.IsSelected == true) ;
        }
    }
}
