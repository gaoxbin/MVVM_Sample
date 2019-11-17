using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplicationDemo
{
    public class Program
    {
        //List<int> x;

        //class Student:INotifyPropertyChanged
        //{
        //    private int _MyProperty;
        //    public int MyProperty { get { return _MyProperty; } set { if (value != _MyProperty) { _MyProperty = value; OnPropertyChanged("MyProperty"); } } }

        //    public event PropertyChangedEventHandler PropertyChanged;

        //    private void OnPropertyChanged(string propertyName)
        //    {
        //        PropertyChangedEventHandler handler = this.PropertyChanged;
        //        if (handler != null)
        //        {
        //            handler(this, new PropertyChangedEventArgs(propertyName));
        //        }
        //    }
        //}

        //static ObservableCollection<Student> obStu;

        static void Main(string[] args)
        {
            // linq--objects linq--xml linq--dataset linq--sql
            // 1 以from子句开始
            // 2 以select、group子句结束
            // 3 中间可添加多行where、ordeby、join子句
            int[] scores = new int[] { 97, 92, 81, 60};

            IEnumerable<int> scoreQuery = from score in scores
                                          where score > 80
                                          select score;

            int count = (from score in scores
                          where score > 80
                          select score).Count();

            IEnumerable<string> strScoreQuery = from score in scores
                                                where score > 80
                                                select string.Format("The socre is {0}", score);

            foreach (var v in strScoreQuery)
            {
                Console.WriteLine(v);
            }



            Console.ReadKey();

            //obStu = new ObservableCollection<Student>();
            //obStu.Add(new Student(){MyProperty = 1});

            //Customer customer = new Customer();
            //Waiter waiter = new Waiter();
            //customer.Order += waiter.Action;

            //customer.Action();
            //customer.PayTheBill();
           // var fan = new DeskFan(new PowerSupply());

          //  Console.WriteLine(fan.Work());
        }

        public interface IPowerSupply 
        {
            int GetPower();
        }

        class PowerSupply : IPowerSupply
        {
            public int GetPower()
            {
                return 100;            
            }
        }
        public class DeskFan
        {
            private IPowerSupply _powerSupply;
            public DeskFan(IPowerSupply ps)
            { 
                _powerSupply = ps;
            }

            public string Work()
            {
                int p = _powerSupply.GetPower();
                if(p <= 0)
                {
                    return "Won't work.";
                }
                else if (p < 100)
                {
                    return "Slow.";
                }
                else if (p < 200)
                {
                    return "Work fine.";
                }
                else 
                {
                    return "warnning";
                }
            }
        }

    }
#if false
    class OrderEventArgs:EventArgs
    {
        public string DishName{get; set;}
        public string Size{get;set;}
    }

    delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    class Customer
    {
        //private OrderEventHandler orderEventHandler;

        //public event OrderEventHandler Order
        //{
        //    add { this.orderEventHandler += value; }
        //    remove { this.orderEventHandler -= value; }
        //}

        public event OrderEventHandler Order;

        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I'll pay {0}", this.Bill);
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant.");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit down.");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think.....");
                Thread.Sleep(1000);
            }

            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "KongPao Chiken";
                e.Size = "large";

                this.Order(this, e);
            }
        }

        public void Action()
        {
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    class Waiter
    {
        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I'll serve you the dish - {0}", e.DishName);

            double price = 10;
            switch(e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "larger":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }

    }
#endif
}
