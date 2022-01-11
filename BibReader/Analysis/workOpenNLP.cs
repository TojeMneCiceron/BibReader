using System;
using System.Collections.Generic;
using System.Linq;
using OpenNLP.Tools.SentenceDetect;
using OpenNLP.Tools.Tokenize;
using OpenNLP.Tools.Lang.English;
using OpenNLP.Tools.Parser;
using OpenNLP.Tools.NameFind;
using OpenNLP.Tools.Chunker;
using OpenNLP.Tools.PosTagger;
using java.io;

namespace BibReader.Analysis
{
    public class WorkOpenNLP
    {
        public string modelPath = "./Resources/Models/";

        // A part of speech tagger assigns a part of speech(noun, verb etc.) 
        // to each token in a sentence.
        public void Part_of_speech(string[] tokens)
        {
            EnglishMaximumEntropyPosTagger posTagger = new EnglishMaximumEntropyPosTagger(modelPath + "EnglishSD.nbin", modelPath);
            string[] pos = posTagger.Tag(tokens);
        }

        // Coference detects all expressions that refer to the same entities in a text.
        public void Coreference(string[] sentences)
        {
            TreebankLinker coreferenceFinder = new TreebankLinker(modelPath + "Coref");
            string coreference_finder = coreferenceFinder.GetCoreferenceParse(sentences);
        }

        // Name entity recognition identifies specific entities in sentences.
        // With the current models, you can detect persons, dates, locations,
        // money, percentages and time
        public static string GetNameEntity(string sentence)
        {
            string modelPath = "./Resources/Models/";

            EnglishNameFinder nameFinder = new EnglishNameFinder(modelPath + "NameFind/");
            string[] models = { "person" };
            string names = nameFinder.GetNames(models, sentence);

            return names;
        }

        public static string GetOrganizationEntity(string sentence)
        {
            string modelPath = "./Resources/Models/";

            EnglishNameFinder organizationFinder = new EnglishNameFinder(modelPath + "namefind/");
            string[] models = { "organization" };
            string organization = organizationFinder.GetNames(models, sentence);

            return organization;
        }

        //A parser gives the full syntactic structure of a sentence.
        public static Parse Parse_tree(string sentence)
        {
            string modelPath = "./Resources/Models/";

            EnglishTreebankParser parser = new EnglishTreebankParser(modelPath);
            return parser.DoParse(sentence);
        }

        // A tokenizer breaks a text into words, 
        // symbols or other meaningful elements. 
        // The historical tokenizers are based on the maxent algorithm.
        public static string[] Tokenisation(string text)
        {
            EnglishRuleBasedTokenizer tokenizer = new EnglishRuleBasedTokenizer(true);
            string[] tokens = tokenizer.Tokenize(text);

            return tokens;
        }

        public static string[] Lemmatization(string text)
        {
            string[] tokens= { };
            //LemmatizerModel model = null;
            //try (InputStream modelIn = new FileInputStream("en-lemmatizer.bin")) {
            //    model = new LemmatizerModel(modelIn);
            //}
            //LemmatizerME lemmatizer = new LemmatizerME(model);
            //string[] postags = new String[] { "NNP", "NNP", "NNP", "POS", "NNP", "NN",
            //    "VBD", "PRP", "VBD", "DT", "JJ", "NN", "VBG", "PRP$", "NN", "IN",
            //    "NNP", "NNP", "TO", "VB", "JJ", "NNS", "IN", "NNP", "POS", "CD", "NNS",
            //    "." };

            //string[] lemmas = lemmatizer.lemmatize(tokens, postags);
            return tokens;
        }
    }
}
