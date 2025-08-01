using System;
using System.Collections;

namespace library_console_project_cs
{
    /// <summary>
    /// Main controller class that manages all book operations
    /// </summary>
    public class LibraryManager
    {
        // Instance of the current book
        private Book currentBook;

        // Collection to store all book information
        private ArrayList bookShelve;

        /// <summary>
        /// Initializes a new instance of LibraryManager
        /// </summary>
        public LibraryManager()
        {
            currentBook = new Book();
            bookShelve = new ArrayList();
        }

        /// <summary>
        /// Initializes a new book by gathering information from user
        /// </summary>
        public void InitializeBook()
        {
            try
            {
                Console.WriteLine("Welcome to My Console Library\n\n" +
                                "Enter a Book Name:");
                currentBook.Name = Console.ReadLine();

                ValidateBookName(currentBook.Name);
                bookShelve.Add($"Book Name -> {currentBook.Name}");

                Console.WriteLine($"Enter how many chapters for {currentBook.Name}:");
                currentBook.ChapterCount = int.Parse(Console.ReadLine());

                ValidateChapterCount(currentBook.ChapterCount);
                bookShelve.Add($"Number of Chapters -> {currentBook.ChapterCount}");

                Console.WriteLine($"Enter how many pages for {currentBook.Name}:");
                currentBook.PageCount = int.Parse(Console.ReadLine());

                ValidatePageCount(currentBook.PageCount);
                currentBook.OriginalPageCount = currentBook.PageCount;
                bookShelve.Add($"Number of pages -> {currentBook.PageCount}");

                // Initialize array for chapter descriptions
                currentBook.ChapterDescriptions = new string[currentBook.ChapterCount];

                // Get chapter descriptions
                for (int i = 0; i < currentBook.ChapterCount; i++)
                {
                    Console.WriteLine($"Enter description for chapter {i + 1}:");
                    currentBook.ChapterDescriptions[i] = Console.ReadLine();
                    bookShelve.Add($"Chapter {i + 1} Description -> {currentBook.ChapterDescriptions[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Please restart the application.");
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Runs the main menu loop
        /// </summary>
        public void RunMainMenu()
        {
            while (true)
            {
                try
                {
                    DisplayMainMenu();
                    int userChoice = int.Parse(Console.ReadLine());
                    ProcessMenuChoice(userChoice);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Displays the main menu options
        /// </summary>
        private void DisplayMainMenu()
        {
            Console.WriteLine("\nWhat would you like to do?\n\n" +
                              "1. Read Book\n" +
                              "2. Scale Pages\n" +
                              "3. Revert Pages\n" +
                              "4. Delete Book\n" +
                              "5. Exit\n");
        }

        /// <summary>
        /// Processes the user's menu choice
        /// </summary>
        /// <param name="choice">The user's menu selection</param>
        private void ProcessMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayBook();
                    break;
                case 2:
                    ScalePages();
                    break;
                case 3:
                    RevertPages();
                    break;
                case 4:
                    DeleteBook();
                    break;
                case 5:
                    ExitApplication();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose 1-5.");
                    break;
            }
        }

        /// <summary>
        /// Displays all book information
        /// </summary>
        public void DisplayBook()
        {
            Console.WriteLine("\n=== Book Information ===");
            foreach (var item in bookShelve)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// Doubles the page count of the book
        /// </summary>
        public void ScalePages()
        {
            currentBook.PageCount *= 2;
            UpdatePageCountInShelve();
            Console.WriteLine($"Pages scaled to: {currentBook.PageCount}");
        }

        /// <summary>
        /// Reverts the page count to original value
        /// </summary>
        public void RevertPages()
        {
            currentBook.PageCount = currentBook.OriginalPageCount;
            UpdatePageCountInShelve();
            Console.WriteLine($"Pages reverted to original: {currentBook.PageCount}");
        }

        /// <summary>
        /// Clears all book information
        /// </summary>
        public void DeleteBook()
        {
            bookShelve.Clear();
            Console.WriteLine("Book has been deleted from the shelve.");
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        public void ExitApplication()
        {
            Console.WriteLine("Closing the library. Goodbye!");
            Environment.Exit(0);
        }

        /// <summary>
        /// Updates the page count in the book shelve
        /// </summary>
        private void UpdatePageCountInShelve()
        {
            for (int i = 0; i < bookShelve.Count; i++)
            {
                if (bookShelve[i].ToString().StartsWith("Number of pages -> "))
                {
                    bookShelve[i] = $"Number of pages -> {currentBook.PageCount}";
                    break;
                }
            }
        }

        /// <summary>
        /// Validates the book name
        /// </summary>
        /// <param name="name">Book name to validate</param>
        private void ValidateBookName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Book name cannot be empty.");
            }
        }

        /// <summary>
        /// Validates the chapter count
        /// </summary>
        /// <param name="count">Chapter count to validate</param>
        private void ValidateChapterCount(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Chapter count must be positive.");
            }
        }

        /// <summary>
        /// Validates the page count
        /// </summary>
        /// <param name="count">Page count to validate</param>
        private void ValidatePageCount(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Page count must be positive.");
            }
        }
    }
}