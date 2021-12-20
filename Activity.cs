using System;
using System.Collections.Generic;
using System.Text;

namespace UserOop
{
    class Activity
    {
        //List penampung
        //public List<string> name = new List<string>();
        //public List<string> nameLast = new List<string>();
        public List<User> user = new List<User>();
        public void ShowUser()
        {
            
            foreach (var element in user)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine($"Nama:{element.FirstName} {element.LastName}");
                Console.WriteLine($"Username:{ element.UserName }");
                Console.WriteLine($"Password:{element.HashedPassword}");
                Console.WriteLine("=========================================");
            }
        }

        public void Login()
        {
            Activity a = new Activity();
            Console.Write("Enter Username: ");
            var username = Console.ReadLine();
            Console.Write("Enter Password: ");
            var password = Console.ReadLine();
            var userN = user.Exists(x => x.UserName == username);
            var pass = user.Exists(x => BCrypt.Net.BCrypt.Verify(password, x.HashedPassword));

                if ( userN==true && pass==true)
                {
                
                Console.WriteLine("Login Successfully");
                }
                else
                {
                
                Console.WriteLine("Login failed");
                }
        }
        public void SearchUser(string nama)
        {
            ///variabel penampung awal (saat delete user akan bug)
            //var cari = false;
            //var index = user.Exists(user => user.FirstName == nama);
                var validate= user.Exists(user => user.FirstName.Contains(nama)|| user.LastName.Contains(nama));
                if (validate == true && user.Count>0)
                {
                    Console.WriteLine("data found");
                    var foundUser = user.FindAll(x => x.FirstName.Contains(nama)|| x.LastName.Contains(nama));
                    foreach (User u in foundUser)
                    {
                    Console.WriteLine("=========================================");
                    Console.WriteLine($"Nama:{u.FirstName} {u.LastName}");
                    Console.WriteLine($"Username:{u.UserName }");
                    Console.WriteLine($"Password:{u.HashedPassword}");
                    Console.WriteLine("=========================================");
                    Console.ReadKey();
                }
                }
                else
                {
                    Console.WriteLine("data not found");
                    Console.ReadKey();
                }
        }
        public void CreateUser(User user)
        {
                this.user.Add(user);
                Console.WriteLine("==============================");
                Console.WriteLine("Successfully adding");
                Console.WriteLine("==============================");
        }
            
        public void EditUser(string username)
        {
            var validate = user.Exists(user => user.UserName==username);
            if (validate == true && user.Count > 0)
            {
                Console.WriteLine("data found");
                var foundUser = user.FindAll(x => x.UserName==username);
                foreach (User u in foundUser)
                {
                    Console.WriteLine("=========================================");
                    Console.Write("Change First Name ");
                    u.FirstName = Console.ReadLine();
                    Console.Write("Change Last Name ");
                    u.LastName = Console.ReadLine();
                    Console.Write("Change Password ");
                    u.Password = Console.ReadLine();
                    u.HashedPassword = BCrypt.Net.BCrypt.HashPassword(u.Password);
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Profile successfully changed!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("data not found");
                Console.ReadKey();
            }
        }
        public void DeleteUser()
        {
            ///Hapus user dengan index
            /*try
            {
                int index;
                Console.WriteLine("Masukkan index data yang dihapus ");
                index = int.Parse(Console.ReadLine());
                user.RemoveAt(index - 1);
                Console.WriteLine("==============================");
                Console.WriteLine("Data Sukses Terhapus");
                Console.WriteLine("==============================");
            }
            catch (Exception)
            {
                Console.WriteLine("Data kosong!");
            }*/
            try
            {
                Console.Write("Please enter the data you want to delete :");
                //int hapus = Convert.ToInt32(Console.ReadLine());
                var dlt = Console.ReadLine();
                var validasi = user.Exists(x => x.FirstName == dlt);
                var validate = user.FindAll(user => user.FirstName == dlt);
                //var valNameFirst = name.FindAll(a => a == dlt);
                //var valNameF = name.Exists(b => b == dlt);
                //var valNameLast = nameLast.FindAll(a => a == dlt);
                //var valNameL = nameLast.Exists(b => b == dlt);
                if (validasi == true)
                {
                    foreach (User item in validate)
                    {
                        Console.WriteLine("Data successfully deleted");
                        user.Remove(item);
                    }
                    /*foreach (string ite in valNameFirst)
                    {
                        name.Remove(ite);
                    }*/
                }
                else
                {
                    Console.WriteLine("data was not successfully deleted");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
