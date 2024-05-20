using Entities;
using System.Numerics;
using System.Threading.Tasks.Dataflow;
using Newtonsoft.Json;

namespace BLL
{
    public static class searchFuncs
    {
        public static List<Location> findWord(String s, List<Entities.Location.eBook> books)
        {

            Dictionary<int, Dictionary<int, Dictionary<int, string>>> data = new Dictionary<int, Dictionary<int, Dictionary<int, string>>> ();
            foreach (Entities.Location.eBook eBook in books)
            {
                data.Add(key: (int)eBook, value: DAL.DataManegment.returnBook((int)eBook)); 
            }

            List<Location> res = new List<Location>();

            foreach(KeyValuePair<int, Dictionary<int, Dictionary<int, string>>> book in data)
            {
               if(book.Value != null)
                {
                    foreach (KeyValuePair<int, Dictionary<int, string>> chapter in book.Value)
                    {
                        foreach (KeyValuePair<int, string> verse in chapter.Value)
                        {
                            if (verse.Value.IndexOf(s) != -1)
                            {
                                res.Add(new Location((int)Entities.Location.getSection(book.Key), book.Key, chapter.Key, verse.Key, verse.Value));
                            }
                        }
                    }
                }
            }
            return res;
        }

        public static int saveSearch(string word, List<Location> results)
        {
            Search s = new Search(word, results);
            List<Search> prevSearch = JsonConvert.DeserializeObject<List<Search>>(DAL.DataManegment.returnHistory());
            if (prevSearch == null)
            {
                prevSearch = new List<Search>();
            }
            prevSearch.Add(s);
            try
            {
                DAL.DataManegment.writeToHistory(JsonConvert.SerializeObject(prevSearch));
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public static List<Search> history()
        {
            return JsonConvert.DeserializeObject<List<Search>>(DAL.DataManegment.returnHistory());
        }

        public static void deleteHistory()
        {
            DAL.DataManegment.writeToHistory("");
        }

    }
}