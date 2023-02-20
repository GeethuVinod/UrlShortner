using Xamarin.Forms;

namespace UrlShortner.UI
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            this.BindingContext = new HistoryViewModel();
        }
    }
}
