using System;
using System.Globalization;

namespace Collection.Tests
{
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>, IFormattable
    {
        private string isbn;
        private string authorName;
        private string title;
        private string publisher;
        private int year;
        private int numberOfPages;
        private double price;

        public Book(string isbn, string authorName, string title, string publisher, int year, int numberOfPages, double price)
        {
            this.ISBN = isbn;
            this.AuthorName = authorName;
            this.Title = title;
            this.Publisher = publisher;
            this.Year = year;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
        }

        public string ISBN
        {
            get => this.isbn;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.isbn));
                }

                this.isbn = value;
            }
        }

        public string AuthorName
        {
            get => this.authorName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.authorName));
                }

                this.authorName = value;
            }
        }

        public string Title
        {
            get => this.title;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.title));
                }

                this.title = value;
            }
        }

        public string Publisher
        {
            get => this.publisher;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.publisher));
                }

                this.publisher = value;
            }
        }

        public int Year
        {
            get => this.year;

            private set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException(nameof(this.year));
                }

                this.year = value;
            }
        }

        public int NumberOfPages
        {
            get => this.numberOfPages;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(nameof(this.numberOfPages));
                }

                this.numberOfPages = value;
            }
        }

        public double Price
        {
            get => this.price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(this.price));
                }

                this.price = value;
            }
        }

        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (string.Compare(this.AuthorName, other.AuthorName, true) == 0 && string.Compare(this.Title, other.Title, true) == 0)
            {
                return 0;
            }

            if (string.Compare(this.AuthorName, other.AuthorName, true) > 0)
            {
                return 1;
            }

            if (string.Compare(this.Title, other.Title, true) > 0)
            {
                return 1;
            }

            return -1;
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            if (ReferenceEquals(obj, null))
            {
                return -1;
            }

            if (this.GetType() == obj.GetType())
            {
                return this.CompareTo((Book)obj);
            }

            throw new ArgumentException(nameof(obj));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj.GetType() == this.GetType())
            {
                return this.Equals((Book)obj);
            }

            return false;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (this.ISBN == other.ISBN && this.AuthorName == other.AuthorName && this.Title == other.Title && this.Publisher == other.Publisher && this.NumberOfPages == other.NumberOfPages && this.Year == other.Year)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return $"ISBN 13: {ISBN}, {AuthorName}, {Title}, \"{Publisher}\", {Year}, P. {NumberOfPages}., {Price}$";
                case "AT":
                    return $"{AuthorName}, {Title}";
                case "ATPY":
                    return $"{AuthorName}, {Title}, \"{Publisher}\", {Year}";
                case "IATPYN":
                    return $"ISBN 13: {ISBN}, {AuthorName}, {Title}, \"{Publisher}\", {Year}, P. {NumberOfPages}.";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode() * this.Price.GetHashCode() ^ this.AuthorName.GetHashCode();
        }
    }
}