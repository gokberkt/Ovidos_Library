
using Ovidos_Library.EntityLayer;
using Ovidos_Library.RepositoryLayer;
using Ovidos_Library.WebAPI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ovidos_Library.WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        [AuthorizeAPI]
        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            List<Book> books = BookRepository.GetCacheBooks();
            return Json(books.Select(x => new
            {
                x.Name,
                x.Author,
                x.ISBN,
                x.Language,
                x.PrintLength,
                x.PublicationDate,
                x.Publisher
            }).ToList());
        }

        [AuthorizeAPI]
        [HttpPost]
        public IHttpActionResult ReserveBook(int bookID, int userID)
        {
            try
            {
                BookStock bs = BookStockRepository.GetCacheBookStocks().FirstOrDefault(x => x.BookID == bookID && x.Status == BookStockStatus.Available);
                if (bs == null)
                {
                    //The stocks of the book you have researched for is insufficient
                    return Json("0");
                }
                int returnedCount = BookTransactionRepository.GetCacheBookTransactions().Where(x => x.UserID == userID && x.Status != BookTransactionStatus.Returned).Count();
                if (returnedCount == 3)
                {
                    return Json("-2");
                }

                BookTransaction bt = new BookTransaction();
                bt.BookID = bookID;
                bt.DateOfReserved = DateTime.Now;
                bt.ExpirationOfReserveDate = DateTime.Now.AddDays(7);
                bt.UserID = userID;
                bt.Status = BookTransactionStatus.Reserved;

                BookTransactionRepository btr = new BookTransactionRepository();
                btr.AddEntity(bt);

                bs.Status = BookStockStatus.Reserved;
                BookStockRepository bsr = new BookStockRepository();
                bsr.UpdateEntity(bs);

                LogRepository.NewLog(bookID, userID);
            }
            catch (Exception)
            {
                return Json("-1");
            }

            return Json("1");
        }

        [AuthorizeAPI]
        [HttpGet]
        public IHttpActionResult GetTransactions(int userID, BookTransactionStatus? status = null)
        {
            List<BookTransaction> bookTransactions = new List<BookTransaction>();
            if (status == null)
            {
                bookTransactions = BookTransactionRepository.GetCacheBookTransactions().Where(x => x.UserID == userID).ToList();
                return Json(bookTransactions.Select(x => new
                {
                    BookName = BookRepository.GetCacheBooks().FirstOrDefault(y=>y.ID== x.BookID).Name,
                    x.DateOfReserved,
                    x.DateOfReturned
                }));
            }
            else
            {
                bookTransactions = BookTransactionRepository.GetCacheBookTransactions().Where(x => x.UserID == userID && x.Status == status).ToList();
                return Json(bookTransactions.Select(x => new
                {
                    BookName = BookRepository.GetCacheBooks().FirstOrDefault(y => y.ID == x.BookID).Name,
                    x.DateOfReserved,
                    x.DateOfReturned
                }));
            }
        }
    }
}
