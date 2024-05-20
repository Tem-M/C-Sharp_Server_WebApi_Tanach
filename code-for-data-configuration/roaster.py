import re
import json 

locations = {
    "D:\\C#\\פרויקט התנך\\TanachProject\\איכה.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\איכה.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\אסתר.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\אסתר.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\במדבר.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\במדבר.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\בראשית.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\בראשית.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\דברי הימים א.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\דברי הימים א.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\דברי הימים ב.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\דברי הימים ב.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\דברים.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\דברים.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\דניאל.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\דניאל.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\הושע.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\הושע.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\ויקרא.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\ויקרא.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\זכריה.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\זכריה.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\חבקוק.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\חבקוק.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\חגי.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\חגי.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\יהושע.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\יהושע.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\יואל.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\יואל.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\יונה.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\יונה.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\יחזקאל.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\יחזקאל.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\ירמיהו.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\ירמיהו.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\ישעיהו.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\ישעיהו.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\מיכה.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\מיכה.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\מלאכי.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\מלאכי.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\מלכים א.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\מלכים א.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\מלכים ב.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\מלכים ב.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\משלי.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\משלי.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\נחום.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\נחום.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\נחמיה.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\נחמיה.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\עובדיה.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\עובדיה.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\עזרא.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\עזרא.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\עמוס.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\עמוס.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\צפניה.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\צפניה.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\קהלת.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\קהלת.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\רות.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\רות.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\שופטים.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\שופטים.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\שיר השירים.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\שיר השירים.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\שמואל א.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\שמואל א.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\שמואל ב.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\שמואל ב.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\שמות.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\שמות.json",
    "D:\\C#\\פרויקט התנך\\TanachProject\\תהילים.txt":"D:\\C#\\פרויקט התנך\\TanachProject\\תהילים.json",
}

for src, dest in locations.items():
    lines = open(src, "r", encoding="UTF-8").read()

    lines = re.split(r'\d+', lines)
    for i in range(len(lines)):
        lines[i] = lines[i].split("\n")

    del lines[0]

    dict = {index: value for index, value in enumerate(lines, start = 1)}

    for i in range(1, len(dict)+1):
        dict[i] = [item for item in dict[i] if item != ""]
        dict[i] = {index: value for index, value in enumerate(dict[i], start =1 )}


    with open(dest, "w", encoding="UTF-8") as dest:
        json.dump(dict, dest, ensure_ascii=False, indent=4)
