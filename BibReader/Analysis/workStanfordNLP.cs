using System;
using System.IO;
using java.util;
using edu.stanford.nlp.pipeline;
using Console = System.Console;
using edu.stanford.nlp.ling;

namespace BibReader.Statistic
{
    class workStanfordNLP
    {
        public static void work()
        {

            var jarRoot = @"stanford-corenlp-full-2020-04-20\stanford-corenlp-4.0.0-models\";

            const string text = "I went or a run. Then I went to work. I had a good lunch meeting with a friend name John Jr. The commute home was pretty good.";

            // Annotation pipeline configuration
            java.util.Properties props = new java.util.Properties();
            props.setProperty("annotators", "tokenize, ssplit, pos, lemma, ner, parse, dcoref");
            props.setProperty("sutime.binders", "0");

            // We should change current directory, so StanfordCoreNLP could find all the model files automatically 
            var curDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);
            var pipeline = new StanfordCoreNLP(props);
            Directory.SetCurrentDirectory(curDir);

            // Annotation
            var annotation = new Annotation(text);
            pipeline.annotate(annotation);

            // these are all the sentences in this document
            // a CoreMap is essentially a Map that uses class objects as keys and has values with custom types
            var sentences = annotation.get(typeof(CoreAnnotations.SentencesAnnotation));
            if (sentences == null)
            {
                return;
            }

            StreamWriter outfile = new StreamWriter("outfile.txt", false, System.Text.Encoding.Default);
            foreach (Annotation sentence in sentences as ArrayList)
            {
                outfile.Write(sentence + "{\n");
            }
            outfile.Close();
        }

    }
}
