using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Datastructure
{
    public class Document
    {
        public int number;
        public string title;
        public string author;
        public string content;
        public double SC;

        public Document() {}

        public Document(int number_, string title_, string author_, string content_, double SC)
        {
            number = number_;
            title = title_;
            author = author_;
            content = content_;
            this.SC = SC;
        }
    }
}
