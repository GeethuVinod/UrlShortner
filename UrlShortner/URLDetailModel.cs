using System;
namespace UrlShortner
{
    public class URLDetailModel : PropertyChangeNotifier
    {
        public string LongURL { get; set; }
        public string ShortURL { get; set; }
        public DateTime DateTime { get; set; }
    }
}
