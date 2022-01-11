using System.Collections.Generic;

namespace BibReader.Analysis
{
    public class Stopwords
    {
        public static List<string> userStopwords = new List<string>();

        public static List<string> pronouns_en = new List<string>
        {
            "you", "she", "they","him", "her", "them",
            "your", "his", "her", "its", "our", "their", "mine", "yours", "hers", "ours", "theirs",
            "this", "that", "these", "those", "such",
            "myself", "yourself", "himself", "herself", "itself", "ourselves", "yourselves", "themselves",
            "who", "what", "which", "whose", "whoever", "whatever", "whichever",
            "some", "something", "somebody", "someone", "any", "anything", "anybody", "anyone",
            "nothing", "nobody", "none", "neither", "other","another",
            "all", "each", "both", "either", "every", "everything", "everybody", "everyone",
            "with"
        };

        public static List<string> pronouns_ru = new List<string>
        {
            "она", "оно", "они", "себя",
            "мой", "твой", "свой", "ваш", "наш", "его",
            "кто", "что", "какой", "чей", "где", "который", "откуда", "сколько", "каковой", "каков", "зачем",
            "когда", "тот", "этот", "столько", "такой", "таков", "сей",
            "всякий", "каждый", "сам", "самый", "любой", "иной", "другой", "весь",
            "никто", "ничто", "никакой", "ничей", "некого", "нечего", "незачем",
            "некто", "весь", "нечто", "некоторый", "несколько", "кто-то", "что-нибудь", "какой-либо",
            "кое-кто", "кто-либо", "кто-нибудь", "кое-что", "что-то", "что-либо", "какой", "некий", "кое-какой",
            "какой-то", "какой-нибудь", "кое-чей", "чей-то", "чей-либо", "чей-нибудь", "который-либо",
            "который-нибудь", "сколько-то", "сколько-нибудь"
        };

        public static List<string> unions_en = new List<string>
        {
            "even", "only", "merely", "solely", "just", "alone", "simply", "right", "exactly", "precisely"
        };

        public static List<string> unions_ru = new List<string>
        {
            "абы","благо", "будто", "вроде", "дабы", "даже", "едва", "ежели",
            "если", "зато", "затем", "ибо", "или", "итак", "как", "кабы", "когда", "либо",
            "лишь", "нежели", "пока", "покуда", "поскольку", "притом", "причем", "пускай", "пусть",
            "раз", "ровно", "словно", "так", "также", "то", "тоже", "только", "точно", "хоть", "хотя",
            "чем", "чисто", "что", "чтоб", "чтобы", "чуть", "якобы"
        };

        public static List<string> particles_en = new List<string> {
            "and", "but", "because", "unless", "however", "whereas", "nor", "still",
            "nevertheless", "yet", "anyhow", "hence", "thus", "therefore", "for", "till",
            "until", "before", "after", "when", "since", "while", "seeing", "lest", "considering", "provided",
            "providing", "supposing", "once", "although", "though", "where", "how", "why"
        };

        public static List<string> particles_ru = new List<string> {
            "неужели", "разве", "вот", "вон", "это", "именно", "прямо", "точно", "точь-в-точь",
            "исключительно", "почти", "единственно", "ведь", "всё-таки",
        };

        public static List<string> otherStopwords_en = new List<string> {
            "not", "are", "the", "from", "been", "can", "can't", "did", "didn", "didn't",
            "cannot","does", "doesn", "doesn't", "don", "don't", "down", "had", "has", "hasn", "hasn't",
            "have", "haven't","isn", "isn't", "it's", "its", "itself", "about", "above", "according",
            "across", "actually", "afterwards","again", "against", "almost", "alone", "along", "already", "also",
            "although", "always", "among", "amongst", "anywhere", "aren", "aren't", "around", "became",
            "become", "becomes", "becoming", "beforehand", "begin", "beginning", "behind", "being", "below", "beside",
            "besides", "between", "beyond", "billion", "caption",  "during", "either", "else", "elsewhere", "end",
            "ending", "enough", "even", "except", "find", "first", "five", "former", "formerly", "forty", "found",
            "four", "further", "get",  "he'd", "he'll", "he's", "help", "hence", "here", "here's", "hereafter",
            "hereby", "herein", "hereupon", "hers", "herself", "hundred", "i'd", "i'll", "i'm", "i've", "indeed",
            "instead", "into", "join", "last", "later", "latter", "least", "less", "let", "let's", "li", "like",
            "likely", "made", "make", "makes", "many", "maybe", "meantime", "meanwhile", "might", "million", "miss",
            "more", "moreover", "most", "mostly", "much", "must", "namely", "neither", "net", "never", "nevertheless",
            "new", "next", "nine", "ninety", "nonetheless", "now", "nowhere", "null", "off", "often",
            "one", "one's", "onto", "otherwise", "out", "over", "overall", "own", "perhaps", "rather", "recent",
            "recently", "same",  "seem", "seemed", "seeming", "seems", "seven", "seventy", "several", "she'd",
            "she'll", "she's", "should", "shouldn", "shouldn't", "since", "six", "sixty", "somehow", "sometime",
            "taking", "text", "test", "than", "that'll", "that's", "then", "thence", "there'll", "there's", "thereafter",
            "thereby", "therefore", "therein", "thereupon", "they'd", "they'll", "they're", "they've", "thirty",
            "thousand", "three", "through", "throughout", "thru", "thus", "together", "too", "toward", "towards",
            "trillion", "twenty", "two", "unlike", "unlikely", "used", "was", "wasn", "wasn't", "we'd", "we'll",
            "we're", "we've", "well", "were", "weren", "weren't","what'll", "what's", "whatever",  "whence", "whenever",
            "where", "whereafter", "whereas", "whereby", "wherein", "whereupon", "wherever", "whether", "which", "while",
            "whither", "who'd", "who'll", "who's", "whoever", "whole", "whom", "whomever", "will", "within", "without",
            "won", "won't", "would", "wouldn", "wouldn't", "yes", "you'd", "you'll", "you're", "you've",
        };

        public static List<string> otherStopwords_ru = new List<string>
        {
            "для", "при", "без", "над", "под", "после",
            "скажем", "может", "допустим", "честно", "говоря", "например", "однако", "вообще", "вероятно",
            "очень", "минимально", "максимально", "абсолютно", "огромный", "предельно", "сильно", "слабо", "самый",
            "всего", "при­мерно", "около", "действительно", "проверено", "доказано", "гарантировано", "правда", "поверьте",
        };
    }
}
