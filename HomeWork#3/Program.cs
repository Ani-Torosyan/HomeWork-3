namespace HomeWork_3
{
    // Book Class
    public class Book
    {
        // Properties
        private string title;
        private Author author;
        private Category category;
        private int year;
        private double price;

        // Constructors
        public Book(string title, Author author, Category category, int year, double price)
        {
            this.title = title;
            this.author = author;
            this.category = category;
            this.year = year;
            this.price = price;
        }

        // Getters and Setters
        public string GetTitle()
        {
            return title;
        }

        public Author GetAuthor()
        {
            return author;
        }

        public Category GetCategory()
        {
            return category;
        }

        public int GetYear()
        {
            return year;
        }

        public double GetPrice()
        {
            return price;
        }
    }

    // Author Class
    public class Author
    {
        // Properties
        private string name;
        private string biography;

        // Constructors
        public Author(string name, string biography)
        {
            this.name = name;
            this.biography = biography;
        }

        // Getters and Setters
        public string GetName()
        {
            return name;
        }

        public string GetBiography()
        {
            return biography;
        }
    }

    // Sealed Category Class
    public sealed class Category
    {
        // Properties
        private string categoryName;
        private string description;

        // Constructors
        public Category(string categoryName, string description)
        {
            this.categoryName = categoryName;
            this.description = description;
        }

        // Getters and Setters
        public string GetCategoryName()
        {
            return categoryName;
        }

        public string GetDescription()
        {
            return description;
        }
    }

    // Static LibraryManager Class
    public static class LibraryManager
    {
        // List to store books
        private static List<Book> books = new List<Book>();

        // Add Book Method
        public static void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Book added successfully!");
        }

        // Remove Book Method
        public static void RemoveBook(string title)
        {
            Book? bookToRemove = books.Find(book => book.GetTitle() == title);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine("Book removed successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        // List All Books Method
        public static void ListAllBooks()
        {
            bool empty = true;

            Console.WriteLine("Listing all books:");
            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.GetTitle()}, Author: {book.GetAuthor().GetName()}, Category: {book.GetCategory().GetCategoryName()}, Year: {book.GetYear()}, Price: {book.GetPrice()}");
                empty = false;
            }

            if(empty == true) Console.WriteLine("No books were found to list.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. List All Books");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = validInt();

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        RemoveBook();
                        break;
                    case 3:
                        LibraryManager.ListAllBooks();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.WriteLine("Enter book details:");
            Console.Write("Title: ");
            string? title = Console.ReadLine();
            Console.Write("Author Name: ");
            string? authorName = Console.ReadLine();
            Console.Write("Author Biography: ");
            string? authorBiography = Console.ReadLine();
            Console.Write("Category Name: ");
            string? categoryName = Console.ReadLine();
            Console.Write("Category Description: ");
            string? categoryDescription = Console.ReadLine();
            Console.Write("Year: ");
            int year = validInt();
            Console.Write("Price: ");
            double price = validInt();

            if (authorName != null && authorBiography != null && categoryDescription != null && categoryName != null && title != null)
            {
                Author author = new Author(authorName, authorBiography);
                Category category = new Category(categoryName, categoryDescription);
                Book book = new Book(title, author, category, year, price);
                
                LibraryManager.AddBook(book);
            }
            else
            {
                Console.WriteLine("Error! Operation couldn't be performed.");
            }

        }

        static void RemoveBook()
        {
            Console.Write("Enter the title of the book to remove: ");
            string? title = Console.ReadLine();
            if (title != null)
            {
                LibraryManager.RemoveBook(title);
            }
            else
            {
                Console.WriteLine("Error! Operation couldn't be performed.");
            }
        }

        static int validInt()
        {
            int num = 0;

            while (num == 0)
            {
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("Invalid input. Please enter a valid integer: ");
                }
            }
            return num;
        }
    }
}
