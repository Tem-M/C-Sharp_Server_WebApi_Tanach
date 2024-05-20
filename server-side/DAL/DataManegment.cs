using Newtonsoft.Json;
using System.Data.Common;
using System.Security.Permissions;
using System.Text;

namespace DAL
{
    public static class DataManegment
    {
        public static Dictionary<int, string> books = new Dictionary<int, string>()
        {
            {1, "../DAL/בראשית.json" },
            {2,  "../DAL/שמות.json"},
            {3, "../DAL/ויקרא.json" },
            {4, "../DAL/במדבר.json" },
            {5, "../DAL/דברים.json" },
            {6, "../DAL/יהושע.json" },
            {7, "../DAL/שופטים.json" },
            {8, "../DAL/שמואל א.json" },
            {9, "../DAL/שמואל ב.json" },
            {10, "../DAL/מלכים א.json" },
            {11, "../DAL/מלכים ב.json" },
            {12, "../DAL/ישעיהו.json" },
            {13, "../DAL/ירמיהו.json" },
            {14, "../DAL/יחזקאל.json" },
            {15, "../DAL/הושע.json" },
            {16, "../DAL/יואל.json" },
            {17, "../DAL/עמוס.json" },
            {18, "../DAL/עובדיה.json" },
            {19, "../DAL/יונה.json" },
            {20, "../DAL/מיכה.json" },
            {21, "../DAL/נחום.json" },
            {22, "../DAL/חבקוק.json" },
            {23, "../DAL/צפניה.json" },
            {24, "../DAL/חגי.json" },
            {25, "../DAL/זכריה.json" },
            {26, "../DAL/מלאכי.json" },
            {27, "../DAL/תהילים.json" },
            {28, "../DAL/משלי.json" },
            {29, "../DAL/איוב.json" },
            {30, "../DAL/שיר השירים.json" },
            {31, "../DAL/רות.json" },
            {32, "../DAL/איכה.json" },
            {33, "../DAL/קהלת.json" },
            {34, "../DAL/אסתר.json" },
            {35, "../DAL/דניאל.json" },
            {36, "../DAL/עזרא.json" },
            {37, "../DAL/נחמיה.json" },
            {38, "../DAL/דברי הימים א.json" },
            {39, "../DAL/דברי הימים ב.json" }
        };

        public static string historyFile = "../DAL/history.json";
        public static Dictionary<int, Dictionary<int, string>> returnBook(int book)
        {
            if (book < books.Count)
            {
                Dictionary<int, Dictionary<int, string>> res = new Dictionary<int, Dictionary<int, string>>();
                var text = File.ReadAllText(books[book]);
                res = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<int, string>>>(text);
                return res;
            }
            return null;
            
        }

        public static string returnHistory()
        {
            return File.ReadAllText(historyFile);
        }
        
        public static void writeToHistory(string searches)
        {
            File.WriteAllText(historyFile, searches);
        }
    }
}