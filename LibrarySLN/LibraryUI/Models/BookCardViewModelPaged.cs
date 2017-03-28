namespace LibraryUI.Models
{
    public class BookCardViewModelPaged
    {
        public PagedList.IPagedList<BookCardViewModel> BookCards { get; set; }
        public string FilterType { get; set; }
        public string SortType { get; set; }
        public bool registerResult { get; set; }
        public bool isBookToCart { get; set; }
    }
}