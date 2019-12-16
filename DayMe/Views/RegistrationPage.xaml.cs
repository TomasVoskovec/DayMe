using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DayMe.Models;
using Newtonsoft.Json;

namespace DayMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        HttpClient client = new HttpClient();

        public RegistrationPage()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            Dictionary<string, int> genders = new Dictionary<string, int>
            {
                { "Male", 0 },
                { "Female", 1 },
                { "Bisexual", 2 }
            };

            foreach (string gender in genders.Keys)
            {
                Gender.Items.Add(gender);
            }

            Dictionary<string, int> sexualities = new Dictionary<string, int>
            {
                { "Heterosexual", 0 },
                { "Homosexual", 1 },
                { "Bisexual", 2 }
            };

            foreach (string sexuality in sexualities.Keys)
            {
                Sexualities.Items.Add(sexuality);
            }
        }

        void registerUser()
        {
            int phoneNumber = 0;

            if (Phone.Text != null)
            {
                phoneNumber = Convert.ToInt32(Phone.Text);
            }

            User user = new User(Name.Text, Email.Text, Convert.ToInt32(Age.Text), Gender.SelectedIndex, Sexualities.SelectedIndex, phoneNumber, Description.Text);

            FormUrlEncodedContent formContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "name", user.Name },
                { "email", user.Email },
                { "phone_number", user.PhoneNumber.ToString() },
                { "description", user.Description },
                { "age", user.Age.ToString() },
                { "gender", user.Gender.ToString() },
                { "sexuality", user.Sexuality.ToString() },
                { "password", Password.Text }
            });

            HttpResponseMessage response = client.PostAsync("https://voskoto16.sps-prosek.cz/DayMe/api/create_user.php", formContent).Result;

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Success", "User created!.", "Ok");
            }
            else
            {
                Task<string> api = response.Content.ReadAsStringAsync();
                string apiJson = api.Result;
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(apiJson);

                apiResponse.ResponseName = "Error";

                DisplayAlert(apiResponse.ResponseName, apiResponse.Message, "Ok");
            }
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            registerUser();
        }
    }
}