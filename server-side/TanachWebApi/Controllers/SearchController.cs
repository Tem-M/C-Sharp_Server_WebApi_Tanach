using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TanachWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        // GET: api/<SearchController>
        [HttpPost()]
        [Route("Word/{word}")]
        public  List<Location> Search(string word, int[] books)
        {
            List<Location.eBook> booksEnumValues = new List<Location.eBook>();
            foreach(int i in books)
            {
                booksEnumValues.Add((Location.eBook)i);
            }
            //return "Books: " + books + " search function in server running";
            return BLL.searchFuncs.findWord(word, booksEnumValues);
        }

        [HttpPost]
        [Route("Save/{word}")]
        public void save(string word, List<Location> results)
        {
            BLL.searchFuncs.saveSearch(word, results);
        }

        

       
      

    
    }
}
