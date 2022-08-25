using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIKitTutorials
{
    class User
    {

        public string ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Type { get; set; }


    }

    class Service
    {
        public String id { get; set; }
        public String name { get; set; }
        public String price { get; set; }

    }

    class Showrooms
    {
        public String id { get; set; }
        public String name { get; set; }
        public String location { get; set; }
        public String phonenumber { get; set; }

    }

    class Car
    {
        public String id { get; set; }
        public String make { get; set; }
        public String model { get; set; }
        public String year { get; set; }
        public String sellingPrice { get; set; }
        public String rentingPrice { get; set; }
        public String showname { get; set; }


    }

    class Garages
    {
        public String id { get; set; }
        public String name { get; set; }
        public String location { get; set; }
        public String phonenumber { get; set; }

    }

    class BuyProcess
    {
        public String id { get; set; }
        public String Cid { get; set; }
        public String Date { get; set; }
        public String AmountOfMoney { get; set; }
        public String ChoosenCar { get; set; }


    }

    class RentProcess
    {
        public String id { get; set; }
        public String Cid { get; set; }
        public String Date { get; set; }
        public String AmountOfMoney { get; set; }
        public String ChoosenCar { get; set; }
    }

    class ServiceProcess
    {
        public String id { get; set; }
        public String Cid { get; set; }
        public String Date { get; set; }
        public String AmountOfMoney { get; set; }
        public String ChoosenService { get; set; }
    }
}
