using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace UrlShortner.UI
{
    public class MainPageViewModel : BaseViewModel
    {
        private string _longUrl;
        public string LongURL
        {
            get => _longUrl;
            set
            {
                _longUrl = value;
                OnPropertyChanged(nameof(LongURL));
            }
        }

        private string _shortUrl;
        public string ShortURL
        {
            get => _shortUrl;
            set
            {
                _shortUrl = value;
                OnPropertyChanged(nameof(ShortURL));
            }
        }

        public ICommand ExecuteShortenURLCommand { get; }
        public ICommand ExecuteUserSearchHistoryCommand { get; }

        public MainPageViewModel()
        {
            ExecuteShortenURLCommand = new Command(() => GetShortenURL());
            ExecuteUserSearchHistoryCommand = new Command(() => GetUserHistory());
        }

        private void GetShortenURL()
        {
            bool isUri = Uri.IsWellFormedUriString(LongURL, UriKind.RelativeOrAbsolute);
            if(!isUri)
            {
                Application.Current.MainPage.DisplayAlert("Error","Please enyter a valid URL", "OK");
                return;
            }
            ShortURL = UrlHelper.GetShortenedUrl(LongURL);
            
        }

        private void GetUserHistory()
        {
            Application.Current.MainPage.Navigation.PushAsync(new HistoryPage());
        }


    }
}
