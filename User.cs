using System;
using System.Collections.Generic;
using System.Text;

namespace UserOop
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        //Activity a = new Activity();
        public string HashedPassword { get; set; }
        public User(Activity a)
        {
            
            bool loop = true;
            bool loopInner = true;
            Console.Write("Masukkan FirstName: ");
            this.FirstName = Console.ReadLine();
            Console.Write("Masukkan LastName: ");
            this.LastName = Console.ReadLine();
            Console.Write("Masukkan Password: ");
            this.Password = Console.ReadLine();
            this.HashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
            var userA = a.user.Exists(x => x.FirstName == FirstName);
            var userB = a.user.Exists(y => y.LastName == LastName);
            /*var userF = a.name.Exists(x=>x==FirstName);
            var userL = a.nameLast.Exists(x => x == LastName);
            a.name.Add(FirstName);
            a.nameLast.Add(LastName);*/
            while (loop == true)
            {
                if (userA == true||userB == true)
                {
                    Random random = new Random();
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    string letter = Convert.ToString(shift + 65);
                    UserName = $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}{letter}";
                    loop = false;
                }
                else
                {
                    UserName = $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}";
                    loop = false;
                }
                while(loopInner == true)
                {
                    var userName= a.user.Exists(y => y.UserName == UserName);
                    if (userName == true)
                    {
                        Random random = new Random();
                        double flt = random.NextDouble();
                        int shift = Convert.ToInt32(Math.Floor(25 * flt));
                        string letter = Convert.ToString(shift + 65);
                        UserName = $"{FirstName.Substring(0, 2)}{LastName.Substring(0, 2)}{letter}";
                        loopInner = false;
                    }
                    else
                    {
                        loopInner = false;
                    }
                }
            }
        }
    }
    

}
