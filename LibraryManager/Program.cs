using LibraryManager.Model;
using LibraryManager.Service;

BookManager bookManager = new();

while(true) {
    Console.WriteLine("1. 책 추가");
    Console.WriteLine("2. 책 삭제");
    Console.WriteLine("3. 책 검색");
    Console.WriteLine("4. 모든 책 보기");
    Console.WriteLine("5. 종료");

    Console.Write("옵션을 선택하세요: ");

    int option = Convert.ToInt32(Console.ReadLine());

    switch(option) {
        case 1:
            AddBook();
            break;
        case 2:
            RemoveBook();
            break;
        case 3:
            FindBook();
            break;
        case 4:
            DisplayAllBooks();
            break;
        case 5:
            return;
        default:
            Console.WriteLine("잘못된 선택입니다.");
            break;
    }
}

void AddBook() {
    Console.Write("책 제목: ");
    string title = Console.ReadLine();

    Console.Write("저자: ");
    string author = Console.ReadLine();

    Book book = new Book { Title = title, Author = author };
    bookManager.AddBook(book);

    Console.WriteLine("책이 추가되었습니다.");
}

void RemoveBook() {
    Console.Write("삭제할 책의 ID를 입력하세요: ");
    int id = Convert.ToInt32(Console.ReadLine());

    bookManager.RemoveBook(id);

    Console.WriteLine("책이 삭제되었습니다.");
}

void FindBook() {
    Console.Write("무엇으로 검색하시겠습니까?\n1. ID\n2. 제목\n3. 저자\n");

    int bookOption = Convert.ToInt32(Console.ReadLine());

    switch(bookOption) {
        case 1:
            Console.WriteLine("검색할 책의 ID를 입력하세요.");
            int id = Convert.ToInt32(Console.ReadLine());

            Book findId = bookManager.FindBookById(id);

            Console.WriteLine($"ID: {findId.Id}, 제목: {findId.Title}, 저자: {findId.Author}");
            break;
        case 2:
            Console.WriteLine("검색할 책의 제목을 입력하세요.");
            string title = Console.ReadLine();

            Book findTitle = bookManager.FindBookByTitle(title);

            Console.WriteLine($"ID: {findTitle.Id}, 제목: {findTitle.Title}, 저자: {findTitle.Author}");
            break;
        case 3:
            Console.WriteLine("검색할 책의 저자를 입력하세요.");
            string author = Console.ReadLine();

            Book findAuthor = bookManager.FindBookByAuthor(author);

            Console.WriteLine($"ID: {findAuthor.Id}, 제목: {findAuthor.Title}, 저자: {findAuthor.Author}");
            break;
        default:
            Console.WriteLine("잘못된 선택입니다.");
            break;
    }
}

//void FindBook() {
//    Console.Write("검색할 책의 ID를 입력하세요: ");
//    int id = Convert.ToInt32(Console.ReadLine());

//    Book book = bookManager.FindBookById(id);

//    Console.WriteLine($"ID: {book.Id}, 제목: {book.Title}, 저자: {book.Author}");
//}

void DisplayAllBooks() {
    var books = bookManager.GetAllBooks();

    foreach(var book in books) {
        Console.WriteLine($"ID: {book.Id}, 제목: {book.Title}, 저자: {book.Author}");
    }
}