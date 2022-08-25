using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Interaction logic for CustomerHome.xaml
    /// </summary>
    public partial class CustomerHome : Page
    {
        static List<Service> Services = new List<Service>();
        static List<Car> cars = new List<Car>();
        static List<Garages> garage = new List<Garages>();
        static List<Showrooms> showroom = new List<Showrooms>();

        public CustomerHome()
        {
            InitializeComponent();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            adminbox.Items.Add("Cars");
            adminbox.Items.Add("Services");
            adminbox.Items.Add("Garages");
            adminbox.Items.Add("Showrooms");

        }

        private void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        //Load Data---------------------------------------------------------------------------------------------------------------------------

        private async void load_showrooms(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/MESR/getShowrooms.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                showroom = await response.Content.ReadAsAsync<List<Showrooms>>();
                foreach (Showrooms u in showroom)
                {




                    lst_showrooms.Items.Add(new Showrooms() {  name = u.name, location = u.location, phonenumber = u.phonenumber });



                }

            }
        }

        private async void load_cars(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/MESR/getCars.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                cars = await response.Content.ReadAsAsync<List<Car>>();
                foreach (Car u in cars)
                {



                    lst_cars.Items.Add(new Car() { make = u.make, id = u.id, rentingPrice = u.rentingPrice, sellingPrice = u.sellingPrice, model = u.model, year = u.year });



                }

            }
        }

        private async void load_garages(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/MESR/getGarage.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                garage = await response.Content.ReadAsAsync<List<Garages>>();
                foreach (Garages u in garage)
                {




                    lst_garages.Items.Add(new Garages() { name = u.name, location = u.location, phonenumber = u.phonenumber });



                }

            }
        }



        private async void load_services(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/MESR/getServices.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                Services = await response.Content.ReadAsAsync<List<Service>>();
                foreach (Service u in Services)
                {



                    lst_services.Items.Add(new Service() { name = u.name, id = u.id, price = u.price });



                }

            }
        }
        //---------------------------------------------------------------------------------------------------------------------------

        private void adminbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int z = adminbox.SelectedIndex;

            if (z == 0)
            {
                lst_showrooms.Visibility = System.Windows.Visibility.Hidden;
                lst_garages.Visibility = System.Windows.Visibility.Hidden;
                lst_cars.Visibility = System.Windows.Visibility.Visible;
                lst_services.Visibility = System.Windows.Visibility.Hidden;



                lst_cars.Items.Clear();
                load_cars(sender, e);


            }
            else if (z == 1)
            {
                lst_showrooms.Visibility = System.Windows.Visibility.Hidden;
                lst_garages.Visibility = System.Windows.Visibility.Hidden;
                lst_cars.Visibility = System.Windows.Visibility.Hidden;
                lst_services.Visibility = System.Windows.Visibility.Visible;


                lst_services.Items.Clear();
                load_services(sender, e);


            }
            else if (z == 2)
            {
                lst_showrooms.Visibility = System.Windows.Visibility.Hidden;
                lst_garages.Visibility = System.Windows.Visibility.Visible;
                lst_cars.Visibility = System.Windows.Visibility.Hidden;
                lst_services.Visibility = System.Windows.Visibility.Hidden;


                lst_garages.Items.Clear();
                load_garages(sender, e);


            }
            else if (z == 3)
            {
                lst_showrooms.Visibility = System.Windows.Visibility.Visible;
                lst_garages.Visibility = System.Windows.Visibility.Hidden;
                lst_cars.Visibility = System.Windows.Visibility.Hidden;
                lst_services.Visibility = System.Windows.Visibility.Hidden;


                lst_showrooms.Items.Clear();
                load_showrooms(sender, e);

            }
        }
    }
}

