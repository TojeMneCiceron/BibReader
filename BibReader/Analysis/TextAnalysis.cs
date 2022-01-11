using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using edu.stanford.nlp.tagger.maxent;
using java.io;
using LemmaSharp;
using OpenNLP.Tools.Parser;

namespace BibReader.Analysis
{
    public class TextAnalysis
    {
        private static ILemmatizer lmtz_en = new LemmatizerPrebuiltCompact(LanguagePrebuilt.English);
        private static ILemmatizer lmtz_ru = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Russian);

        private static Dictionary<string, string> TagsPos { get; } = new Dictionary<string, string>
        {
            {"CC", "Союз"},
            {"IN", "Предлог"},
            {"JJ", "Прилагательное"},
            {"JJR", "Прилагательное"},
            {"JJS", "Прилагательное"},
            {"EX", "Глагол"},
            {"NN", "Существительное"},
            {"NNS", "Существительное"},
            {"NNP", "Существительное"},
            {"NNPS", "Существительное"},
            {"RB", "Наречие"},
            {"RBR", "Наречие"},
            {"RBS", "Наречие"},
            {"VB", "Глагол"},
            {"VBD", "Глагол"},
            {"VBG", "Глагол"},
            {"VBN", "Глагол"},
            {"VBP", "Глагол"},
        };

        public static Dictionary<string, DataTag> Concepts { get; private set; } = new Dictionary<string, DataTag>();

        public static List<string> Persons { get; private set; } = new List<string>();

        public static List<string> Organizations { get; private set; } = new List<string>();

        public static Dictionary<string, string> POS = new Dictionary<string, string>();

        public static string Names;

        public static void getAnalysis()
        {
            Concepts = new Dictionary<string, DataTag>();
            Persons = new List<string>();
            Organizations = new List<string>();
            POS = new Dictionary<string, string>();
        }

        public static void getNames(string text)
        {
            Names = WorkOpenNLP.GetNameEntity(text);
        }

        public static int getMaxVvalueConcepts()
        {
            return Concepts.Values.Max((item) => item.count);
        }

        public static int getMinVvalueConcepts()
        {
            return Concepts.Values.Min((item) => item.count);
        }

        public static double getAverageValueConcepts()
        {
            return Concepts.Values.Average((item) => item.count);
        }

        private static bool IsRussian(string word)
        {
            return !Regex.IsMatch(word, @"\P{IsCyrillic}");
        }

        private static bool IsEnglish(string word)
        {
            return !Regex.IsMatch(word, @"\P{IsBasicLatin}");
        }

        public static void SetConceptsAnalysis(string text)
        {
            getAnalysis();
            string[] tokens = WorkOpenNLP.Tokenisation(text);

            //dynamic tagger = PartsOfSpeech.Initialize();

            foreach (string token in tokens)
            {
                string tok = token.ToLower();
                if (tok.Length >= 3 && char.IsLetter(tok, tok.Length - 1))
                {
                    if (IsRussian(tok))
                    {
                        if (
                             !Stopwords.particles_ru.Contains(tok) &&
                             !Stopwords.pronouns_ru.Contains(tok) &&
                             !Stopwords.unions_ru.Contains(tok) &&
                             !Stopwords.otherStopwords_ru.Contains(tok)
                             )
                        {
                            tok = lmtz_ru.Lemmatize(tok);
                        }
                        else continue;
                    }
                    else if (IsEnglish(tok))
                    {
                        if (
                           !Stopwords.particles_en.Contains(tok) &&
                           !Stopwords.pronouns_en.Contains(tok) &&
                           !Stopwords.unions_en.Contains(tok) &&
                           !Stopwords.otherStopwords_en.Contains(tok)
                           )
                            tok = lmtz_en.Lemmatize(tok);
                        else continue;
                    } else
                    {
                        continue;
                    }

                    var sentences = MaxentTagger.tokenizeText(
                        new StringReader(Regex.Replace(text, @"[^\w\d\s]", ""))
                        ).toArray();
                    //var taggedSentence = tagger.tagSentence(sentences).toArray();

                    if (Concepts.ContainsKey(tok))
                    {
                        Concepts[tok].count++;
                    }
                    else
                    {
                        //string tag = taggedSentence[0].tag();
                        // POS.Add(tok, TagsPos[tag]);
                        Concepts.Add(tok, new DataTag(1, new List<string>()));
                    }
                }
            }
        }

        public static void setConceptsAnalysisWithStopwords()
        {
            foreach (string word in Stopwords.userStopwords)
            {
                string _word = word.ToLower();
                if (word.Length >= 3 && char.IsLetter(word, word.Length - 1))
                {
                    if (Concepts.ContainsKey(word))
                    {
                        Concepts.Remove(word);
                    }
                }
            }
        }

        private static List<string> nodeType = new List<string>
        {
            "NP", "NNS", "NNP", "NN"
        };

        private static string pre_parent = "";

        private static void parseTree(Parse node)
        {

            if (node == null) return;

            Parse ch = null;

            if (node.ChildCount > 0)
            {
                ch = node.GetChildren()[0];
            }
            if (node.Parent == null || pre_parent != node.Parent.ToString())
            {
                if (node.ChildCount == 1 && node.IsPosTag && nodeType.Contains(node.Type) && ch != null && ch.IsLeaf)
                {
                    string[] nodes = node.Parent.Value.Split();
                    for(int i = 0; i < nodes.Length - 1; i++)
                    {
                        string key1 = nodes[i].ToLower();
                        string key2 = nodes[i + 1].ToLower();

                        key1 = IsRussian(key1) ? lmtz_ru.Lemmatize(key1) : lmtz_en.Lemmatize(key1);
                        key2 = IsRussian(key2) ? lmtz_ru.Lemmatize(key2) : lmtz_en.Lemmatize(key2);

                        if (Concepts.ContainsKey(key1) && Concepts.ContainsKey(key2))
                        {
                            if (!Concepts[key1].neighbors.Contains(key2))
                            {
                                Concepts[key1].neighbors.Add(key2);
                            }
                        }
                    }
                }
                else
                {
                    foreach (Parse child in node.GetChildren())
                    {
                        parseTree(child);
                    }
                }
            }
        } 
           
        public static void GetParseTree(string text)
        {
            Parse tree = WorkOpenNLP.Parse_tree(text);
            parseTree(tree);
        }

        public static void SetNamesAnalysis()
        {
            getAnalysis();
            Regex regex = new Regex(@"(?<=<person>)([\s\S]+?)(?=</person>)");

            MatchCollection names = regex.Matches(Names);

            foreach (Match name in names)
            {
                GroupCollection groups = name.Groups;
                string person = groups[0].Value;
                if (person.Length > 1 && !Persons.Contains(person))
                    Persons.Add(groups[0].Value);          
            }
        }

        public static void SetOrganizationAnalysis()
        {
            getAnalysis();
            Regex regex = new Regex(@"(?<=<organization>)([\s\S]+?)(?=</organization>)");

            MatchCollection organizations = regex.Matches(Names);

            foreach (Match organization in organizations)
            {
                GroupCollection groups = organization.Groups;
                string org = groups[0].Value;
                if (org.Length > 1 && !Organizations.Contains(org))
                    Organizations.Add(groups[0].Value);
            }
        }
    }
}
