using System;
using System.Collections.Generic;
namespace MyClasses
{
    public class User
    {
        Book[] MyFormuliar = new Book[10];
        public List<Book> SearchList = new List<Book>();
        public int CountBooks = 0;
        public string nickname;
        private string password;
        public bool reg;
       
        public User() 
        { this.reg = false; }



        public User(string nick, string pass)
        {
            this.nickname = nick;
            this.password = pass;
            this.reg = true;
        }

        public void ReturnBook(int n)
        {
            for (int i = n; i < CountBooks; i++)
            {
                MyFormuliar[i].available = true;
                MyFormuliar[i] = MyFormuliar[i+1];
            }
            CountBooks--;
        }
        public void SearchBook(Book[] Serbook, int key, string str)
        {
           
            switch (key)
            {    
                case 1:
                   
                    for (int i = 0; i < Serbook.Length; i++)
                    {
                        if (Serbook[i].name.Contains(str))
                        {
                            SearchList.Add(Serbook[i]);
                           
                        }
                    }
                    break;
                case 2:
                   
                    for (int i = 0; i < Serbook.Length; i++)
                    {
                        if (Serbook[i].author.Contains(str))
                        {
                            SearchList.Add(Serbook[i]);
                          
                        }
                    }
                    break;
                case 3:
                   
                    for (int i = 0; i < Serbook.Length; i++)
                    {
                        if (Serbook[i].theme.Contains(str))
                        {
                            SearchList.Add(Serbook[i]);
                            
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < Serbook.Length; i++)
                    {                      
                            SearchList.Add(Serbook[i]);
                    }
                    break;
            }
            

            if (SearchList.Count == 0)
            { Console.WriteLine("Нiчого не знайдено"); }
            else
            { for (int i = 0; i < SearchList.Count ; i++)
                   Console.WriteLine(Convert.ToString(i+1)+SearchList[i].OutputBook());
            }
            
        }
        public string AddBookToForm(Book newBook)
        {
            try
            {
                MyFormuliar[CountBooks] = newBook;
                CountBooks++;
                return " Книгу додано";
            }
            catch(System.IndexOutOfRangeException)
            {
                //CountBooks--;
                return " Не бiльше 10 книг";
            }
        }
        public void OutputForm()
        {
            for (int i = 0; i < CountBooks; i++)
            {
               Console.WriteLine((i+1)+"  "+MyFormuliar[i].OutputBook());
            }
        }


    }
}
