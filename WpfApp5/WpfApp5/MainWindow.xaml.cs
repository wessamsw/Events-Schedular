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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void login(object sender, RoutedEventArgs e) {
         
            // get cridentials of the user 
            var userName = username.Text;
            var passWord = password.Password.ToString();
            //
            // create new http client  and provide header and uri
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/pharmasuite/login1.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var formcontent = new FormUrlEncodedContent(new[]
          {
                new KeyValuePair<string,string>("username",userName),
                new KeyValuePair<string, string>("password",passWord)


            });

            HttpResponseMessage response = client.PostAsync(client.BaseAddress, formcontent).Result;

            if (response.IsSuccessStatusCode) {
                string answer = await response.Content.ReadAsStringAsync();

                if (!answer.Contains("false"))
                {
                    User user = await response.Content.ReadAsAsync<User>();
                    MessageBox.Show("successfull login welcome " + user.username);



                }
                else {

                    MessageBox.Show("invalid login please check the username and password");

                }
            
            
            }






        }

        private async void signup(object sender, RoutedEventArgs e) {
            var userName = usernameCreate.Text;
            var password = passwordCreate.Password.ToString();
            var lastname = lastName.Text;
            var firstname = firstName.Text;

            // create new http client  and provide header and uri
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/pharmasuite/sign_up.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var formcontent = new FormUrlEncodedContent(new[]
          {
                new KeyValuePair<string,string>("username",userName),
                new KeyValuePair<string,string>("password",password),
                new KeyValuePair<string,string>("lastName",lastname),
                new KeyValuePair<string,string>("firstName",firstname)


            });

            HttpResponseMessage response = client.PostAsync(client.BaseAddress,formcontent).Result;

            if (response.IsSuccessStatusCode) {
                string answer = await response.Content.ReadAsStringAsync();

                if (answer.Contains("exist")) {


                    MessageBox.Show("this email is already associated with an account ");
                
                
                
                }
                if (answer.Contains("succesfull"))
                {
                    usernameCreate.Clear();
                    passwordCreate.Clear();
                    lastName.Clear();
                    firstName.Clear();

                    if (MessageBox.Show("you have successfully signed up , do you want to login",
                     "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Storyboard sb = (this.Resources["Storyboard2"] as Storyboard);
                        sb.Begin();
                    }
                    else
                    {


                    }
                    

                }

            
            
            }
        }

        
        class User {

            public string username { get; set; }
            public string password { get; set; }
        
        
        
        
        }

    }
}
