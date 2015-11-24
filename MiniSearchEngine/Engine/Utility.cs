using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Engine
{
    class Utility
    {
        private static string STOPWORD_PATH = "./stopword.txt";
        private static List<string> stopWordList = new List<string>();

        public static void getStopWord()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(STOPWORD_PATH);

            string line;
            while ((line = file.ReadLine()) != null)
            {
                stopWordList.Add(line);
            }

        }

        public static List<string> removeStopWord(List<string> data)
        {
            List<string> processedData = new List<string>();
            processedData.AddRange(data);

            foreach (string s in stopWordList)
            {
                while (processedData.Contains(s.ToLower()))
                {
                    processedData.Remove(s.ToLower());
                }
            }
            return processedData;
        }

        public static List<String> separateData(string data)
        {
            char[] delimiter = { ' ', ',', '-', '!', '?', '.', '@', '#', '$', '%', '^', '&', '*', '(', ')', '{', '}', '/', ';', ':', '\'', '"' };
            return new List<string>(data.Split(delimiter));
        }

        public static List<string> stemming(List<string> data)
        {
            List<string> processedData = new List<string>();
            List<string> resultData = new List<string>();
            processedData.AddRange(data);

            Stemmer stemmer = new Stemmer();
            foreach (string s in processedData)
            {
                char[] processedChar = s.ToCharArray();
                stemmer.add(processedChar, processedChar.Length);
                stemmer.stem();
                String result = stemmer.ToString();

                resultData.Add(result);
            }

            return resultData;
        }

        public static int getDocumentID(String documentName)
        {
            string[] res = documentName.Split(' ');
            return Int32.Parse(res[1]);
        }

    }
}
