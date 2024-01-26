using LibraryManager.Interfaces;
using LibraryManager.Model;
using System.Net;

namespace LibraryManager.Service {
    public class BookManager : IBookManager {
        private List<Book?> _books = new();
        private int _nextId = 1;

        public void AddBook(Book book) {
            if(book == null) throw new ArgumentNullException(nameof(book));

            book.Id = _nextId++;
            _books.Add(book);
        }

        public void RemoveBook(int bookId) {
            Book? book = _books.FirstOrDefault(b => b.Id == bookId);
            if(book != null) _books.Remove(book);
        }

        public Book FindBookById(int bookId) {
            return _books.FirstOrDefault(b => b.Id == bookId);
        }

        public Book FindBookByTitle(string bookTitle) {
            return _books.FirstOrDefault(b => b.Title == bookTitle);
        }

        public Book FindBookByAuthor(string bookAuthor) {
            return _books.FirstOrDefault(b => b.Author == bookAuthor);
        }

        public List<Book> GetAllBooks() {
            return _books;
        }
    }
}
