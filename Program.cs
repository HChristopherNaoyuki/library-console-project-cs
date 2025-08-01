using System;
using library_console_project_cs;

namespace library_console_project_cs
{
    /// <summary>
    /// Main program class that handles the book library application flow
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        static void Main()
        {
            // Create an instance of LibraryManager to handle operations
            LibraryManager library = new LibraryManager();

            // Display initial prompts to gather book information
            library.InitializeBook();

            // Start the main application loop
            library.RunMainMenu();
        }
    }
}