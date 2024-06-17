namespace AtrinCode.Core.Domain.PagingModel
{
    public class pagestartend
    {
        public int start { get; set; }
        public int end { get; set; }
    }
    public class PagingData
    {

        public pagestartend pagestartend
        {
            get
            {
                return CalculateDisplayPage();

            }
        }


        public int DisplayPageCount { get; set; } = 5;
        public int CurrentPage { get; set; } = 1;
        public int TotalPage
        {
            get { return PageCount(); }
        }
        public int PageSize { get; set; } = 10;
        public int TotalItem { get; set; }

        public int PageCount()
        {
            return TotalItem == 0 ? 0 : (int)Math.Ceiling(TotalItem / (double)PageSize);
        }


        public int Skip
        {
            get
            {
                return ((CurrentPage - 1) * PageSize);
            }


        }
        public pagestartend CalculateDisplayPage()
        {
            pagestartend displayStartEnd = new pagestartend();
            if (CurrentPage <= (DisplayPageCount / 2) + 1)
            {
                displayStartEnd.start = 1;

            }

            else
            {
                displayStartEnd.start = CurrentPage - (DisplayPageCount / 2);
            }

            displayStartEnd.end = displayStartEnd.start + DisplayPageCount - 1;
            if (TotalItem != 0)
            {
                if (displayStartEnd.end > TotalPage)
                {
                    displayStartEnd.end = TotalPage;
                    int startendthreshold = displayStartEnd.end - DisplayPageCount + 1;
                    displayStartEnd.start = startendthreshold < 1 ? 1 : startendthreshold;
                }
            }
            return displayStartEnd;


        }

    }
}
