using System.Collections.Generic;
using UrlShortner.Helpers;

namespace UrlShortner.UI
{
    public class HistoryViewModel : BaseViewModel
    {
        private List<URLDetailModel> _uRLDetailList;
        public List<URLDetailModel> URLDetailList
        {
            get
            {
                return _uRLDetailList;
            }
            set
            {
                _uRLDetailList = value;
            }
        }

        public HistoryViewModel()
        {
            GetUserHistory();
        }

        public void GetUserHistory()
        {
            URLDetailList = UrlHelperBase62.GetUserSearchHistory();
        }
    }
}
