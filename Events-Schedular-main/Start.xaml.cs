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

namespace UIKitTutorials
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }


        private async void Signin_Click(object sender, RoutedEventArgs e)
        {
            // get cridentials of the user 
            var userName = username.Text;
            var passWord = password.Text;
            //
            // create new http client  and provide header and uri
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/MESR/LoginResponse.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var formcontent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("username",userName),
                new KeyValuePair<string, string>("password",passWord)


            });

            HttpResponseMessage response = client.PostAsync(client.BaseAddress, formcontent).Result;

            if (response.IsSuccessStatusCode)
            {
                string answer = await response.Content.ReadAsStringAsync();

                if (!answer.Contains("false"))
                {
                    User user = await response.Content.ReadAsAsync<User>();

                    Storyboard sb = (this.Resources["Storyboard1"] as Storyboard);
                    sb.Begin();

                    if (user.Type == "Admin")
                    {
                        MainWindow mw = new MainWindow();
                        await Task.Delay(2000);
                        mw.Show();
                        this.Close();
                    }
                    else
                    {
                        CustomerMain cm = new CustomerMain();
                        await Task.Delay(2000);
                        cm.Show();
                        this.Close();
                    }

                }
                else
                {

                    MessageBox.Show("invalid login please check the username and password");

                }


            }
        }

        private async void signup_Click(object sender, RoutedEventArgs e)
        {
            var userName = username1.Text;
            string password = password1.Text;
            string Confirm = password1_Copy.Text;

            if (password.Equals(Confirm))
            {
                // create new http client  and provide header and uri
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost/MESR/Signup.php");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("username",userName),
                    new KeyValuePair<string,string>("password",password),


                });

                HttpResponseMessage response = client.PostAsync(client.BaseAddress, formcontent).Result;

                if (response.IsSuccessStatusCode)
                {
                    string answer = await response.Content.ReadAsStringAsync();

                    if (answer.Contains("exist"))
                    {


                        MessageBox.Show("this email is already associated with an account ");



                    }
                    if (answer.Contains("succesfull"))
                    {
                        username1.Clear();
                        password1.Clear();
                        password1_Copy.Clear();

                        MessageBox.Show("welcome to the mesr motors please sign in ");



                    }



                }
            }
            else
            {
                password1.Clear();
                password1_Copy.Clear();
                MessageBox.Show("Password Don't match ");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
