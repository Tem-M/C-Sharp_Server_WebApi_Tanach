using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Entities.Location;

namespace BLL
{
    public class Books
    {
        public static Dictionary<int, Dictionary<int, string>> returnBook(int ebook)
        {
            return DAL.DataManegment.returnBook(ebook);
        }


        // לא בשימוש בפרונט אנד
        public static List<string> chapters(int ebook)
        {
            List<string> res = new List<string>();
            res.Add("הכל");
            Dictionary<int, Dictionary<int, string>> book = returnBook(ebook);
            foreach (KeyValuePair<int, Dictionary<int, string>> chapter in book)
            {
                res.Add(Location.convertNumberToLetters(chapter.Key));
            }
            return res;
        }

        public static string bookToString(int book)
        {
            string res = "";
            Dictionary<int, Dictionary<int, string>> bookDict = returnBook(book);
            if (bookDict != null)
            {
                foreach (KeyValuePair<int, Dictionary<int, string>> chapter in bookDict)
                {
                    res += "\n\nפרק " + Location.convertNumberToLetters(chapter.Key) + "\n";
                    foreach (KeyValuePair<int, string> verse in chapter.Value)
                    {
                        res += Location.convertNumberToLetters(verse.Key) + ": " + verse.Value + "\n";
                    }
                }
                return res;
            }
            return "Invalid input";   
           
           
        }

        public static string bookChapterToString(int book, int chapter)
        {
            if(chapter == 0) return bookToString(book);
            string res = Location.convertNumberToLetters(chapter) + "\n\n";
            Dictionary<int, Dictionary<int, string>> bookDict = returnBook(book);
            Dictionary<int, string> chapterDict = bookDict[chapter];
            foreach(KeyValuePair<int,string> verse in chapterDict)
            {
                res += Location.convertNumberToLetters(verse.Key) + ": " + verse.Value + "\n";
            }
            return res;
        }

        public static List<string> verses(int book, int chapter)
        {
            List<string> res = new List<string>();
            res.Add("הכל");
            Dictionary<int, Dictionary<int, string>> bookDict = returnBook(book);
            Dictionary<int, string> chapterDict = bookDict[chapter];
            foreach (KeyValuePair<int, string> verse in chapterDict)
            {
                res.Add(Location.convertNumberToLetters(verse.Key));
            }
            return res;
        }

        public static string bookChapterVerseToString(int book, int chapter, int verse)
        {
            if (verse == 0) return bookChapterToString(book, chapter);

            Dictionary<int, Dictionary<int, string>> bookDict = returnBook(book);
            Dictionary<int, string> chapterDict = bookDict[chapter];
            string versestr = chapterDict[verse];
            versestr = Location.convertNumberToLetters(chapter) + "\n\n" + 
                        Location.convertNumberToLetters(verse) + ": " + versestr;
            return versestr;
        }
    }
}
