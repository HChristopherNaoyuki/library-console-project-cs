namespace library_console_project_cs
{
    /// <summary>
    /// Model class representing a Book with its properties
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the name of the book
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of chapters in the book
        /// </summary>
        public int ChapterCount { get; set; }

        /// <summary>
        /// Gets or sets the current page count of the book
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the original page count (for revert functionality)
        /// </summary>
        public int OriginalPageCount { get; set; }

        /// <summary>
        /// Gets or sets the collection of chapter descriptions
        /// </summary>
        public string[] ChapterDescriptions { get; set; }
    }
}