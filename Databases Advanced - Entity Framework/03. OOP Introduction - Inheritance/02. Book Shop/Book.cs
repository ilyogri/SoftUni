namespace _02.Book_Shop
{
    using System;
    using System.Text.RegularExpressions;

    public class Book
    {
        private const int TitleMinLength = 3;

        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get
            {
                return this.title;
                
            }
            set
            {
                if (value.Length < TitleMinLength)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
                
            }
            set
            {
                if (value.Split().Length == 2)
                {
                    if (Regex.IsMatch(value.Split()[1], "[0-9]"))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                    this.author = value;
                }
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
                
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}\nTitle: {this.Title}\nAuthor: {this.Author}\nPrice: {this.Price:f2}";
        }
    }
}