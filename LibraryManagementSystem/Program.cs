namespace LibraryManagementSystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = true;
        }

    }
    public class Library
    {
        public List<Book> BookList = new List<Book>();
        public void AddBook(Book book)
        {
            BookList.Add(book);
            Console.WriteLine($"Book '{book.Title}' has been added to the library.");
        }

        public string BorrowBook(string bookName)
        {
            for (int i = 0; i < BookList.Count; i++)
            {
                if (BookList[i].Title.ToLower().Contains(bookName.ToLower()))
                {
                    if (BookList[i].Availability)
                    {
                        BookList[i].Availability = false;
                        return $"You have borrowed the book: '{BookList[i].Title}'";
                    }
                    else
                    {
                        return $"The book '{BookList[i].Title}' is currently borrowed";
                    }
                }
            }
            return $"The book '{bookName}' is not in the library";
        }

        public string ReturnBook(string bookName)
        {
            for (int i = 0; i < BookList.Count; i++)
            {

                if (BookList[i].Title.ToLower().Contains(bookName.ToLower()))
                {
                    if (BookList[i].Availability == false)
                    {

                        BookList[i].Availability = true;
                        return $"You have returned the book: '{BookList[i].Title}'";
                    }
                    else
                        return $"The book '{BookList[i].Title}' was not borrowed"; ;
                }


            }
            return $"The book '{bookName}' is not in the library";
        }
        public bool SearchBook(string booktitle)
        {
            for (int i = 0; i < BookList.Count; i++)
            {
                if (BookList[i].Title.ToLower().Contains(booktitle.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(library.BorrowBook("Gatsby"));
            Console.WriteLine(library.BorrowBook("1984"));
            Console.WriteLine(library.BorrowBook("Harry Potter")); // This book is not in the library

            Console.WriteLine("\nReturning books...");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine(library.ReturnBook("Gatsby"));
            Console.WriteLine(library.ReturnBook("Harry Potter")); // This book is not borrowed
            Console.WriteLine("\nSearching books...");
            Console.WriteLine(new string('=', 30));
            if (library.SearchBook("Gatsby") == true)
            {

                Console.WriteLine("Book in the library");
            }
            else
            {
                Console.WriteLine("cant find the book in the library");
            }

            Console.ReadLine();
        }
    }
}
