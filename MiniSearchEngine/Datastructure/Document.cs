using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Datastructure
{
    class Document
    {
        public int number;
        public string title;
        public string author;
        public string content;

        public Document() {}

        public Document(int number_, string title_, string author_, string content_)
        {
            number = number_;
            title = title_;
            author = author_;
            content = content_;
        }
    }
}
