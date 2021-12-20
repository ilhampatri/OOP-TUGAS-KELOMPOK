using System;

namespace UserOop
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuChoice();
        }
        static void MenuChoice()
        {
            Activity a = new Activity();
            bool repeat = false;
            int menu;
            do
            {
                try
                {
                    Console.WriteLine("1.Create User");
                    Console.WriteLine("2.Show User");
                    Console.WriteLine("3.Search User");
                    Console.WriteLine("4.Login User");
                    Console.WriteLine("5.Delete User Data");
                    Console.WriteLine("6.Edit User Data");
                    Console.WriteLine("7.Exit");
                    Console.Write("Enter the selection menu: ");
                    menu = int.Parse(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            for (int i = 0; i < 1; i++)
                            {
                                Console.WriteLine("=====Create User========");
                                try
                                {
                                    User u = new User(a);
                                    a.CreateUser(u);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input not invalid...");
                                    i--;
                                    AnyKey();
                                }
                            }
                            repeat = true;
                            AnyKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("=====Show User========");
                            a.ShowUser();
                            repeat = true;
                            AnyKey();
                            break;
                        case 3:
                            Console.Clear();
                            bool loop = false;
                            do
                            {
                                    if (a.user.Count > 0)
                                    {
                                        Console.WriteLine("=====Search User========");
                                        Console.Write("Enter search ");
                                        string nama = Console.ReadLine();
                                        a.SearchUser(nama);
                                        loop = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Empty");
                                        loop = false;
                                    }
                                
                            } while (loop == true);
                            repeat = true;
                            AnyKey();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("=====Login User========");
                            a.Login();
                            repeat = true;
                            AnyKey();
                            break;
                        case 5:
                            Console.Clear();
                            if (a.user.Count > 0)
                            {
                                Console.WriteLine("=====Delete User========");
                                a.DeleteUser();
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                loop = false;
                            }
                            repeat = true;
                            AnyKey();
                            break;
                        case 6:
                            Console.Clear();
                            string userEdit;
                            if (a.user.Count > 0)
                            {
                                Console.WriteLine("=====Edit User========");
                            Console.Write("Enter the username you want to change ");
                            userEdit = Console.ReadLine();
                            a.EditUser(userEdit);
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                loop = false;
                            }
                            repeat = true;
                            AnyKey();
                            break;
                        case 7:
                            repeat = false;
                            break;
                        default:
                            Console.WriteLine("=Menu not found!");
                            repeat = true;
                            AnyKey();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Menu must be numbers");
                    AnyKey();
                    repeat = true;
                }
                
            } while (repeat==true);

            
            static void AnyKey()
            {
                Console.WriteLine("Press Any Key....");
                Console.ReadKey();
                Console.Clear();
            }
            
        }
    }

    
}
