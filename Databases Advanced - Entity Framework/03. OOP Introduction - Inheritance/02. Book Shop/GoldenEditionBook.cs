namespace _02.Book_Shop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price) : base(title, author, price)
        {
           this.Price += (this.Price * 0.3m);
        }
    }
}