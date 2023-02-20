using UrlShortner.UI;
using Xamarin.Forms;

namespace UrlShortner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Use IoC for getting single instance of Viewmodel and autowire to the view
            BindingContext = new MainPageViewModel();
        }





    }
}
