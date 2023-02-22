using System.Collections.Generic;
using System.Linq;

namespace UrlShortner.Helpers
{
    public static class UrlHelperBase62
    {
        private static readonly string _base62Set = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static int _counter = 9999;
        private static readonly Dictionary<string, string> _urlMappings = new Dictionary<string, string>();
        private static List<URLDetailModel> HistoryList = new List<URLDetailModel>();

        public static string GetShortenedUrl(string url)
        {
            if (_urlMappings.ContainsValue(url))
            {
                // If the URL has already been shortened, return the existing short URL
                return _urlMappings.FirstOrDefault(x => x.Value == url).Key;
            }
            else
            {
                // Use a counter based base 62 conversion for minimal duplication of short urls generated
                string shortUrl = EncodeBase62(_counter);
                string result = $"www.urlshortner.com/{shortUrl.PadLeft(7, '0')}";
                _urlMappings.Add(result,url);
                _counter++;
                return result;
            }
        }

        public static List<URLDetailModel> GetUserSearchHistory()
        {
            foreach (var item in _urlMappings)
            {
                HistoryList.Add(new URLDetailModel() { ShortURL = item.Key, LongURL = item.Value });
            }

            return HistoryList;
        }


        private static string EncodeBase62(int number)
        {
            string result = string.Empty;

            do
            {
                int remainder = (int)(number % 62);
                result =  _base62Set[remainder] + result;
                number /= 62;
            } while (number > 0);

            return result;
        }
    }
}
