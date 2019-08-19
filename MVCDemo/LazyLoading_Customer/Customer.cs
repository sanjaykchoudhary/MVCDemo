using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading_Customer
{
    public class Customer
    {
        private List<Orders> _Orders = null;
        
        public List<Orders> Orders
        {
            get
            {
                if(_Orders == null)
                {
                    _Orders = LoadOrders();
                }
                return _Orders;
            }           
        }
        private string _CustomerName;
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        public Customer()
        {
            //in the customer constructor, we are loading the customer data as well as the order data.
            //means as well as the customer object is created, the customer data and order data will be loaded.
            //Makes a database trip;
            _CustomerName = "Sanjay";
            //Orders object creation discard here.
            //so, we have to remove the order loading in the constructor to achieve Lazy Laoding.
            //_Orders = LoadOrders();
        }

        private List<Orders> LoadOrders()
        {
            List<Orders> temp = new List<Orders>();
            Orders o = new LazyLoading_Customer.Orders();
            o.OrderNumber = "order1001";
            temp.Add(o);
            o = new LazyLoading_Customer.Orders();
            o.OrderNumber = "order1002";
            temp.Add(o);
            return temp;
        }
    }

    public class Orders
    {
       public string OrderNumber { get; set; }
    }

}
