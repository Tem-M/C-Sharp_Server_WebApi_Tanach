basicConvert = {
     1:'א', 
     2:'ב', 
     3: 'ג', 
     4: 'ד', 
     5: 'ה', 
     6: 'ו', 
     7:'ז', 
     8:'ח', 
     9:'ט',
     10:'י',
     20: 'כ', 
     30: 'ל', 
     40: 'מ', 
     50: 'נ', 
     60: 'ס',
     70: 'ע',
     80: 'פ', 
     90: 'צ', 
     100: 'ק', 
     200: 'ר',
     300: 'ש',
     400: 'ת'
}

books = [
    "בראשית",
    "שמות",
    "ויקרא",
    "במדבר",
    "דברים",
    "יהושע",
    "שופטים",
    "'שמואל א",
    "'שמואל ב",
    "'מלכים א",
    "'מלכים ב", 
    "ישעיהו",
    "ירמיהו",
    "יחזקאל",
    "הושע",
    "יואל",
    "עמוס",
    "עובדיה",
    "יונה",
    "מיכה",
    "נחום",
    "חבקוק",
    "צפניה",
    "חגי",
    "זכריה",
    "מלאכי",
    "תהילים",
    "משלי",
    "איוב",
    "שיר השירים",
    "רות",
    "איכה",
    "קהלת",
    "אסתר",
    "דניאל",
    "עזרא",
    "נחמיה",
    "'דברי הימים א" ,
    "'דברי הימים ב"
]

function convertNumberToLetters(num)
{   
    var smallnumbers = num % 100; // 17
    var bignumbers = num - smallnumbers; // 1000
    var res = "";

    res = smallnumbers % 10 !== 0 ? ("" + basicConvert[smallnumbers % 10]) : ""; 
    smallnumbers = smallnumbers - (smallnumbers % 10);
    res = (smallnumbers !== 0 ? ("" + basicConvert[smallnumbers]) : "") + res;

    var bigs = "";
    while (bignumbers > 400) {
        bigs = basicConvert[400] + bigs;
        bignumbers -= 400;
    }
    if (bignumbers > 0) {
        bigs = bigs + basicConvert[bignumbers];
    }
    res = bigs + res; 
    if (res.length > 1) {
        if (res.substring(res.length - 2) === "יה") {
            res = res.substring(0, res.length - 2) + "טו";
        }
        if (res.substring(res.length - 2) === "יו") {
            res = res.substring(0, res.length - 2) + "טז";
        }
        res = res.substring(0, res.length - 1) + '"' + res[res.length - 1];
    } else {
        res = res + "'";
    }
    return res;
}


function convertLettersToNumber(verse)
{
    var res = 0;
    for(var i=0; i<verse.Length; i++)
    {
        try
        {
            res += basicConvert[verse[i]];
       }
        catch (e)
        {
            continue;
       }
   }
    return res; 
}

function book(num) {
    return books[num-1]
}

function section(num) {
    switch(num) {
        case 1: {
            return "תורה"
            break;
        }
        case 2: {
            return "נביאים"
            break;
        } 
        case 3: {
            return "כתובים"
            break;
        } 
        default: {
            return ""
        }  
    }
}

