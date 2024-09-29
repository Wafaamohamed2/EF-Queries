using Microsoft.EntityFrameworkCore;
using NewEF;

internal class Program
{
    private static void Main(string[] args)
    {
        var _context = new ApplicationDbContext();


        // make joins using LNIQ
        Console.WriteLine("--------------join---------------\n");
        var books = (from b in _context.Books
                     join a in _context.Authors
                     on b.Id equals a.AuthorId
                     join n in _context.Nationalities
                     on a.NationalityId equals n.NationalityId into authorNationality  //left join
                     from an in authorNationality.DefaultIfEmpty()

                     select new
                     {
                         BookId = b.Id,
                         BookName = b.Name,
                         AuthorNmae = a.Name
                     }).Count();

        Console.WriteLine(books);


        //stored procedure

        Console.WriteLine("--------------stored procedure-------------\n");
        var books2 = _context.Books.FromSqlRaw("prc_GetAllBooks").ToList();
        foreach (var book in books2)
        {
            Console.WriteLine(book.Name);
        }

        Console.WriteLine("\n--------stored procedure with input par------\n");
        var bookid = 1;
        var books3 = _context.Books.FromSqlRaw($"prc_GetBookById {bookid}").ToList();
        
        foreach (var book in books3)
        {
            Console.WriteLine(book.Name);
        }

        Console.WriteLine("\n------stored procedure with joins using DTO-------\n");
        var books4 = _context.BooksDTOs.FromSqlRaw("prc_GetBooksWithAuthors").ToList();
        foreach (var book in books4)
        {
            Console.WriteLine(book.Name);
        }

        Console.WriteLine("\n---------Filterd Authors-----------\n");
        var authors = _context.Authors.ToList();
        foreach(var author in authors)
        {
            Console.WriteLine(author.Name);
        }


        Console.WriteLine("\n---------Ignor Filterd -----------\n");
        var authors2 = _context.Authors.IgnoreQueryFilters().ToList();
        foreach (var author in authors2)
        {
            Console.WriteLine(author.Name);
        }
    }
}