using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Location
    {
        
        public int Section { get; private set; }
        public int Book { get; private set; }
        public int Chapter { get; private set; }
        public int Verse { get; private set; }
        public string Text { get; private set; }
        public Location(int section, int book, int chapter, int verse, string text)
        {
            Section = section;
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
        }


        // לא בשימוש בפרונט אנד
        public  enum  eBook
        {
            בראשית = 1,
            שמות = 2,
            ויקרא = 3,
            במדבר = 4,
            דברים = 5,
            יהושע = 6,
            שופטים = 7,
            שמואל_א = 8,
            שמואל_ב = 9,
            מלכים_א = 10,
            מלכים_ב = 11, 
            ישעיהו = 12,
            ירמיהו = 13,
            יחזקאל = 14,
            הושע = 15,
            יואל = 16,
            עמוס = 17,
            עובדיה = 18,
            יונה = 19,
            מיכה = 20,
            נחום = 21,
            חבקוק = 22,
            צפניה = 23,
            חגי = 24,
            זכריה = 25,
            מלאכי = 26,
            תהילים = 27,
            משלי= 28,
            איוב = 29,
            שיר_השירים = 30,
            רות = 31,
            איכה = 32,
            קהלת = 33,
            אסתר = 34,
            דניאל = 35,
            עזרא = 36,
            נחמיה = 37,
            דברי_הימים_א = 38,
            דברי_הימים_ב = 39,
            Unknown
        }

        public enum eSection
        {
            תורה = 1,
            נביאים = 2,
            כתובים = 3,
            Unknown 
        }

        public static Dictionary<int, char> basicConvert = new Dictionary<int, char>
            {
            { 1,'א' },
            { 2,'ב' },
            { 3, 'ג' },
            { 4, 'ד' },
            { 5, 'ה' },
            { 6, 'ו' },
            { 7,'ז' },
            { 8,'ח' },
            { 9,'ט' },
            { 10,'י' },
            { 20, 'כ' },
            { 30, 'ל' },
            { 40, 'מ' },
            { 50, 'נ' },
            { 60, 'ס' },
            { 70, 'ע' },
            { 80, 'פ' },
            { 90, 'צ' },
            { 100, 'ק' },
            { 200, 'ר' },
            { 300, 'ש' },
            { 400, 'ת' }
        };
        public static string convertNumberToLetters(int num)
        {   
            int smallnumbers = num % 100; // 17
            int bignumbers = num - smallnumbers; // 1000
            string res = "";

            res = smallnumbers % 10 != 0 ? ("" +basicConvert[smallnumbers % 10]) : ""; 
            smallnumbers = smallnumbers - smallnumbers % 10;
            res = (smallnumbers != 0 ? ("" + basicConvert[smallnumbers]) : "") + res;

            string bigs = "";
            while(bignumbers > 400)
            {
                bigs = basicConvert[400] + bigs;
                bignumbers -= 400;
            }
            if(bignumbers > 0)
                bigs = bigs + basicConvert[bignumbers];
            res = bigs + res; 
            if(res.Length>1)
            {
                if (res.Substring(res.Length - 2).Equals("יה"))
                    res = res.Substring(0, res.Length - 2) + "טו";
                if (res.Substring(res.Length - 2).Equals("יו"))
                    res = res.Substring(0, res.Length - 2) + "טז";
                res = res.Substring(0, res.Length - 1) + '"' + res[res.Length - 1];
            }
            else
            {
                res = res + "'";
            }
            return res;
        }


        public static int convertLettersToNumber(string verse)
        {
            int res = 0;
            foreach (char ch in verse)
            {
                try
                {
                    res += basicConvert[ch];
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            return res; 
        }
        
        public static eSection getSection(int book)
        {
            if (book > 0 && book <= 5)
                return eSection.תורה;
            if (book <= 26)
                return eSection.נביאים;
            if (book <= 39)
                return eSection.כתובים;
            return eSection.Unknown;
        }
    }
}