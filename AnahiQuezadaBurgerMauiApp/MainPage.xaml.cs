using Newtonsoft.Json;
using AnahiQuezadaBurgerMauiApp.Models;
namespace AnahiQuezadaBurgerMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked_JDS(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7044/api/");
            var response = client.GetAsync("burger").Result;
            if (response.IsSuccessStatusCode)
            {
                var burgers = response.Content.ReadAsStringAsync().Result;
                var burgersList = JsonConvert.DeserializeObject<List<AQBurger>>(burgers);
                AQlistView.ItemsSource = burgersList;
            }
        }
    }

}
