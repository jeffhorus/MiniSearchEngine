﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniSearchEngine.Datastructure;
using System.Data.OleDb;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MiniSearchEngine.Engine
{
    class Parser
    {
        
        private Dictionary<string, int> termOccurenceInCollection;
        private Config config;
        private searchSet.DocumentsDataTable documentDataTable = new searchSet.DocumentsDataTable();
        private searchSet.Document_TermDataTable documentTermDataTable = new searchSet.Document_TermDataTable();
        private searchSet.TermsDataTable termsDataTable = new searchSet.TermsDataTable();
        private BackgroundWorker progressReporter;

        public Parser(Config config, BackgroundWorker reporter)
        {
            this.config = config;
            termOccurenceInCollection = new Dictionary<string, int>();

            documentDataTable = new searchSet.DocumentsDataTable();
            documentTermDataTable = new searchSet.Document_TermDataTable();
            termsDataTable = new searchSet.TermsDataTable();

            progressReporter = reporter;
        }


        public void openDocumentFile(string pathName)
        {
            searchSetTableAdapters.DocumentsTableAdapter documentTableAdapter = new searchSetTableAdapters.DocumentsTableAdapter();
            searchSetTableAdapters.Document_TermTableAdapter documentTermTableAdapter = new searchSetTableAdapters.Document_TermTableAdapter();
            searchSetTableAdapters.TermsTableAdapter termTableAdapter = new searchSetTableAdapters.TermsTableAdapter();

            documentTableAdapter.DeleteAll();
            documentTermTableAdapter.DeleteAll();
            termTableAdapter.DeleteAll();

            searchSet.DocumentsRow doc;
            System.IO.StreamReader file = new System.IO.StreamReader(pathName);
            string line;
            int max_term;
            char nowState = ' ';
            int number = 0;
            StringBuilder titleBuilder = new StringBuilder("");
            string title = "";
            string authors = "";
            string content = "";
            StringBuilder contentBuilder = new StringBuilder("");

            Dictionary<string, int> termOccurenceInDocument = new Dictionary<string, int>();

            int jumlah_dokumen = 0;

            while ((line = file.ReadLine()) != null)
            {
                if (line.Length > 1)
                {
                    if (line[0] == '.')
                    {
                        if (line[1] == 'I')
                        {
                            if (nowState == 'W')
                            {
                                title = titleBuilder.ToString();
                                content = contentBuilder.ToString().Trim();

                                StringBuilder allContentsInDocument = new StringBuilder("");
                                allContentsInDocument.Append(title);
                                allContentsInDocument.Append(" ");
                                allContentsInDocument.Append(content);
                                allContentsInDocument.Append(" ");
                                allContentsInDocument.Append(authors);

                                List<String> splittedTerms = new List<String>();
                                splittedTerms = Utility.separateData(allContentsInDocument.ToString().ToLower());
                                splittedTerms = splittedTerms.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                                doc = documentDataTable.NewDocumentsRow();
                                doc.ID = number;
                                doc.Title = title;
                                doc.Content = content;
                                doc.Authors = authors;

                                

                                documentDataTable.AddDocumentsRow(doc);

                                //documentTableAdapter.Insert(number, title, content, authors.ToString());

                                splittedTerms = Utility.removeStopWord(splittedTerms);
                                if (config.stemmingOption == 1)
                                {
                                    splittedTerms = Utility.stemming(splittedTerms);
                                }

                                max_term = 0;
                                termOccurenceInDocument = new Dictionary<string, int>();
                                foreach (string s in splittedTerms)
                                {
                                    if (!termOccurenceInDocument.ContainsKey(s))
                                    {
                                        termOccurenceInDocument[s] = 1;
                                        if (!termOccurenceInCollection.ContainsKey(s))
                                            termOccurenceInCollection[s] = 1;
                                        else termOccurenceInDocument[s]++;
                                    }
                                    else
                                        termOccurenceInDocument[s]++;

                                    if (max_term < termOccurenceInDocument[s]) max_term = termOccurenceInDocument[s];
                                }


                                //documentTermDataTable = new searchSet.Document_TermDataTable();
                                
                                foreach (KeyValuePair<string, int> entry in termOccurenceInDocument)
                                {
                                    searchSet.TermsRow term = termsDataTable.NewTermsRow();
                                    term.Term = entry.Key;
                                    term.IDF = 1;
                                    try
                                    {
                                        termsDataTable.AddTermsRow(term);
                                        //termTableAdapter.Insert(entry.Key, 0);
                                    }
                                    catch (Exception x)
                                    {

                                    }

                                    searchSet.Document_TermRow dterm = documentTermDataTable.NewDocument_TermRow();
                                    dterm.Term = entry.Key;
                                    dterm.Document_ID = number;
                                    dterm.Weight = calculateTF(entry.Value, max_term);

                                    documentTermDataTable.AddDocument_TermRow(dterm);
                                    //documentTermTableAdapter.Insert(entry.Key, number, entry.Value);
                                }

                                jumlah_dokumen++;
                                progressReporter.ReportProgress(jumlah_dokumen);

                                //termTableAdapter.Update(termsDataTable);
                                //documentTermTableAdapter.Update(documentTermDataTable);

                            }

                            nowState = 'I';
                            number = Int32.Parse(line.Split(' ')[1]);
                            
                            content = "";
                            authors = "";
                        }
                        else if (line[1] == 'T')
                        {
                            nowState = 'T';
                            titleBuilder = new StringBuilder("");
                        }
                        else if (line[1] == 'A')
                        {
                            if (nowState != 'A')
                            {
                                title = titleBuilder.ToString().Trim();
                            }
                            nowState = 'A';
                            authors = "";
                        }
                        else if (line[1] == 'W')
                        {
                            nowState = 'W';
                            contentBuilder = new StringBuilder("");
                        }
                    }
                    else
                    {
                        if (nowState == 'T')
                        {
                            titleBuilder.Append(line);
                            titleBuilder.Append(" ");
                        }
                        else if (nowState == 'A')
                        {
                            if (authors.Length > 0) authors += ", ";
                            authors += line.Trim();
                        }
                        else if (nowState == 'W')
                        {
                            contentBuilder.Append(line);
                            contentBuilder.Append(" ");
                        }
                    }
                }
            }
            file.Close();

            // last document
            content = contentBuilder.ToString().Trim();
            title = titleBuilder.ToString();

            StringBuilder allContentsInDoc = new StringBuilder("");
            allContentsInDoc.Append(title);
            allContentsInDoc.Append(" ");
            allContentsInDoc.Append(content);

            allContentsInDoc.Append(" ");
            allContentsInDoc.Append(authors);

            List<String> splitTerm = new List<String>();
            splitTerm = Utility.separateData(allContentsInDoc.ToString().ToLower());
            splitTerm = splitTerm.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();


            //////////// update doc
            //documentTableAdapter.Update(documentDataTable);
            doc = documentDataTable.NewDocumentsRow();
            doc.ID = number;
            doc.Title = title;
            doc.Content = content;
            doc.Authors = authors;

            documentDataTable.AddDocumentsRow(doc);

            jumlah_dokumen++;
            progressReporter.ReportProgress(jumlah_dokumen);

            //documentTableAdapter.Insert(number, title, content, authors.ToString());

            splitTerm = Utility.removeStopWord(splitTerm);
            if (config.stemmingOption == 1)
            {
                splitTerm = Utility.stemming(splitTerm);
            }

            max_term = 0;

            termOccurenceInDocument = new Dictionary<string, int>();
            foreach (string s in splitTerm)
            {
                if (!termOccurenceInDocument.ContainsKey(s))
                {
                    termOccurenceInDocument[s] = 1;
                    if (!termOccurenceInCollection.ContainsKey(s))
                        termOccurenceInCollection[s] = 1;
                    else termOccurenceInDocument[s]++;
                }
                else
                    termOccurenceInDocument[s]++;

                if (max_term < termOccurenceInDocument[s]) max_term = termOccurenceInDocument[s];
            }


            //documentTermDataTable = new searchSet.Document_TermDataTable();
            //termsDataTable = new searchSet.TermsDataTable();

            foreach (KeyValuePair<string, int> entry in termOccurenceInDocument)
            {
                searchSet.TermsRow term = termsDataTable.NewTermsRow();
                term.Term = entry.Key;
                term.IDF = 1;

                try
                {
                    termsDataTable.AddTermsRow(term);
                    //termTableAdapter.Insert(entry.Key, 0);
                }
                catch (Exception x)
                {

                }
                searchSet.Document_TermRow dterm = documentTermDataTable.NewDocument_TermRow();
                dterm.Term = entry.Key;
                dterm.Document_ID = number;
                dterm.Weight = calculateTF(entry.Value, max_term);

                documentTermDataTable.AddDocument_TermRow(dterm);
                //documentTermTableAdapter.Insert(entry.Key, number, entry.Value);
            }


            
            if (config.idfOption == 1)
            {
                foreach (KeyValuePair<string, int> entry in termOccurenceInCollection)
                {
                    termsDataTable.FindByTerm(entry.Key).IDF = (double)number / (double) entry.Value;
                }
            }


            calculateWeight();


            // save to database
            documentTableAdapter.Update(documentDataTable);
            termTableAdapter.Update(termsDataTable);
            documentTermTableAdapter.Update(documentTermDataTable);

            if (MainForm.doc_config.normalizationOption == 1)
            {
                foreach (searchSet.DocumentsRow doc_row in documentDataTable)
                {
                    double panjang = (double) documentTermTableAdapter.HitungPanjang(doc_row.ID);
                    documentTermTableAdapter.NormalisasiWeight(panjang, doc_row.ID);
                }
            }

            
        }

        public double calculateTF(int original, int max)
        {
            if (config.tfOption == 0)
            {
                return 1;
            }
            else if (config.tfOption == 1)
            {
                return original;
            }
            else if (config.tfOption == 2)
            {
                return 1 + Math.Log10(original);
            }
            else if (config.tfOption == 3)
            {
                if (original > 1) return 1;
                return 0;
            }
            else
            {
                return 0.5 + 0.5 * ((double)original / max);
            }


        }

        public void calculateWeight()
        {
            foreach (searchSet.Document_TermRow row in documentTermDataTable)
            {
                row.Weight = row.Weight * termsDataTable.FindByTerm(row.Term).IDF;
            }

        }

        public static List<RelevantJudgement> getRelevantJudgement(string pathName)
        {
            List<RelevantJudgement> relevantJudgementList = new List<RelevantJudgement>();

            System.IO.StreamReader file = new System.IO.StreamReader(pathName);

            string line;

            while ((line = file.ReadLine()) != null)
            {
                line = Regex.Replace(line, @"\s+", " ");

                char[] separator = { ' ' };
                string[] splittedNumber = line.Split(separator);

                RelevantJudgement relevantJudgement = new RelevantJudgement(Int32.Parse(splittedNumber[0]), Int32.Parse(splittedNumber[1]));
                relevantJudgementList.Add(relevantJudgement);
            }
            file.Close();

            return relevantJudgementList;
        }

        public static List<Query> openQueryFile(string pathName)
        {
            List<Query> queries = new List<Query>();
            System.IO.StreamReader file = new System.IO.StreamReader(pathName);

            string line;

            int number = 0;
            StringBuilder contentBuilder = new StringBuilder();
            string content = "";
            char nowState = ' ';

            while ((line = file.ReadLine()) != null)
            {
                if (line.Length > 1)
                {
                    if (line[0] == '.')
                    {
                        if (line[1] == 'I')
                        {
                            if (nowState == 'W')
                            {
                                content = contentBuilder.ToString().Trim();

                                List<String> splittedTerms = new List<String>();
                                splittedTerms = Utility.separateData(content.ToLower());
                                splittedTerms = splittedTerms.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                                Query query = new Query(number, content);
                                queries.Add(query);
                            }

                            nowState = 'I';
                            number = Int32.Parse(line.Split(' ')[1]);
                        }
                        else if (line[1] == 'W')
                        {
                            nowState = 'W';
                            contentBuilder = new StringBuilder("");
                        }
                    }
                    else
                    {
                        if (nowState == 'W')
                        {
                            contentBuilder.Append(line);
                            contentBuilder.Append(" ");
                        }
                    }
                }
            }
            file.Close();

            // last query
            content = contentBuilder.ToString().Trim();

            List<String> splitTerm = new List<String>();
            splitTerm = Utility.separateData(content.ToLower());
            splitTerm = splitTerm.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            Query query_ = new Query(number, content);
            queries.Add(query_);

            return queries;
        }

    }
}
