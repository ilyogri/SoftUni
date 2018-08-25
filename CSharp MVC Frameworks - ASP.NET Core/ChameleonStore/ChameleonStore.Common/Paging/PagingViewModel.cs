namespace ChameleonStore.Common.Paging
{
    public class PagingViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PreviousPage => this.CurrentPage == 1
            ? 1
            : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages
            ? this.CurrentPage
            : this.CurrentPage + 1;
    }
}
