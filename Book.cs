using System;

namespace MyClasses
{
    public class Book
    {
        public string name;
        public string author;
        public string theme;
        public bool available;
        public Book(){}

        public Book(string nm, string aut, string them)
        {
            this.name = nm;
            this.author = aut;
            this.theme = them;
            this.available = true;
        }
      
        public string OutputBook()
        {
            return ("  "+name+"  "+author+"  "+theme);
        }
       
    }
}
