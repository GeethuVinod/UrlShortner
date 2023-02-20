using System;
using System.Collections.Generic;
using System.Linq;

namespace UrlShortner
{
    public static class UrlHelper
    {
        private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int base62 = 62;


        private static List<URLDetailModel> HistoryList = new List<URLDetailModel>();

        private static Dictionary<string, string> shortToLong = new Dictionary<string, string>();

        private static Random random = new Random();

        public static string GetShortenedUrl(string url)
        {
            string shortUrl;

            // Check if long url already exist in previous search

            if (shortToLong.ContainsValue(url))
            {
                var test = shortToLong.FirstOrDefault(item => item.Value == url).Key;
                return test;
            }

         

            // Regenerate Short URL if the generated short url key already exists
            do
            {
                shortUrl = $"www.urlShortner.com/{GenerateRandomString()}";
            }
            while (shortToLong.ContainsKey(shortUrl));

            shortToLong.Add(shortUrl, url);

            return shortUrl;
        }

       
        public static List<URLDetailModel> GetUserSearchHistory()
        {
            foreach (var item in shortToLong)
            {
                HistoryList.Add(new URLDetailModel() { ShortURL = item.Key, LongURL = item.Value });
            }
            return HistoryList;
        }

        private static string GenerateRandomString()
        {
            char[] shortUrl = new char[7];
            for (int i = 0; i < shortUrl.Length; i++)
            {
                shortUrl[i] = chars[random.Next(base62)];
            }
            return new string(shortUrl);
        }

      
    }
}
