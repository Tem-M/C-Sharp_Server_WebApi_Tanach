using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TanachWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        [HttpGet("{book}")]
        public Dictionary<int, Dictionary<int, string>> Get(int book)
        {
            return BLL.Books.returnBook(book);
        }
        // לא בשימוש בפרונט אנד
        //[HttpGet("{book}/{chapter}")]
        //public string Get(int book, int chapter)
        //{
        //    return BLL.Books.bookChapterToString(book, chapter);
        //}

        //[HttpGet("{book}/{chapter}/{verse}")]
        //public string Get(int book, int chapter, int verse)
        //{
        //    return BLL.Books.bookChapterVerseToString(book, chapter, verse);
        //}
    }
}
