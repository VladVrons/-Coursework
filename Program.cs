
using System;
using MyClasses;
namespace MyBiblio
{

    class Program
    {
       
        static User ActiveUser = new User();
        static Book[] books = new Book[11];
        static void Main(string[] args)
        {
            
            UploadBooksData();
           
            int key=1;      
            while (key != 0)
            {
                
               try
                {
                    Menu(key);
                    key = Convert.ToInt32(Console.ReadLine());
                }
                
               catch(System.FormatException)   
                {
                    Console.WriteLine("Введiть корректне число {0}", Environment.NewLine);
                    
                    key = 1;            
                }
                
            }
            Console.WriteLine("Exit");

        }

        static void UploadBooksData()
        {                     
            books[0] = new Book("Вiйна I мир", "Лев Толстой", "Iсторiя");
            books[1] = new Book("Життя Пi", "Янн Мартель", "Роман");
            books[2] = new Book("Кобзар", "Тарас Шевченко", "Поезiя");
            books[3] = new Book("Мастер i Маргарита", "Михайло Булгаков", "Роман");
            books[4] = new Book("Шерлок Холмс", "Артур Конан Дойл", "Детектив");
            books[5] = new Book("Зло пiд сонцем", "Агатa Крiстi", "Детектив");
            books[6] = new Book("Володар перстнів", "Джон Толкiн", "Фентазi");
            books[7] = new Book("Хронiки Нарнiї", "Клайв Льюiс", "Фентазi");
            books[8] = new Book("Гаррi Поттер", "Джоан Роулiнг", "Фентазi");
            books[9] = new Book("Анна Каренiна", "Лев Толстой", "Роман");
            books[10] = new Book("Зелена миля", "Стiвен Кiнг", "Роман");
        }
        static void Menu(int keycode)
        {
            
            switch (keycode)
            {
                
                case 1: 
                    MenuInfo(); 
                    break;
                case 2:
                    Console.WriteLine(" Введiть iм'я та пароль");
                    string name = Console.ReadLine(); 
                    string pass = Console.ReadLine();
                    ActiveUser = new User(name,pass);
                    Console.WriteLine(" Ви успiшно зареєстрованi");
                    break;
                case 3:
                    if (ActiveUser.reg)
                        Console.WriteLine(ActiveUser.nickname);
                    else 
                        Console.WriteLine(" Ви не зареєстрованi"); 
                    break;
                case 4:
                    Console.WriteLine(" Пошук за назвою-1, за автором-2, за темою-3, увесь список-4");
                    int bookkey = Convert.ToInt32(Console.ReadLine());
                    string searchkey=" ";
                    if (bookkey != 4)
                    { searchkey = Console.ReadLine(); }
                    ActiveUser.SearchBook(books, bookkey, searchkey);

                    if (ActiveUser.reg)
                    {
                        Console.WriteLine(" Для продовження- 0, для додання до формуляру - номер книги");
                        int addkey = Convert.ToInt32(Console.ReadLine());
                        do
                        {
                            
                            if (ActiveUser.SearchList[addkey - 1].available)
                            {
                                Console.WriteLine(ActiveUser.AddBookToForm(ActiveUser.SearchList[addkey - 1]));
                                ActiveUser.SearchList[addkey - 1].available = false;                               
                            }
                            else Console.WriteLine(" Книга вiдсутня");
                            Console.WriteLine(" Для продовження- 0, для додання до формуляру - номер книги");
                            addkey = Convert.ToInt32(Console.ReadLine());

                        } while (addkey != 0);
                    }
                    else
                        Console.WriteLine(" Ви не зареєстрованi");
                    ActiveUser.SearchList.Clear();
                    
                    break;
                case 5:
                    ActiveUser.OutputForm();
                    break;
                case 6:
                    ActiveUser.OutputForm();
                    Console.WriteLine("Номер книги для видалення");
                    int delkey = Convert.ToInt32(Console.ReadLine());
                    ActiveUser.ReturnBook(delkey-1);
                    ActiveUser.OutputForm();
                    break;
            }
        }

        static void MenuInfo()
        {
            Console.WriteLine(" Вiтаю в меню бiблiотеки ");
            Console.WriteLine(" Для виходу з бiблiотеки натиснiть 0 ");
            Console.WriteLine(" Для вiдображення цього меню натиснiть 1");
            Console.WriteLine(" Для реєстрацiї натиснiть 2 ");
            Console.WriteLine(" Для вiдображення iменi натиснiть 3");
            Console.WriteLine(" Для пошуку книги натиснiть 4");
            Console.WriteLine(" Для виведення формуляру натиснiть 5");
            Console.WriteLine(" Для видалення книги натиснiть 6");
        }
    }
    


}
