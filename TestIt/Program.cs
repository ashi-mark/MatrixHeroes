using MatrixHeroes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIt
{
    class Program
    {
        static void Main(string[] args)
        {

            MatrixHeroes.Model1 m = new Model1();
            Database.SetInitializer<Model1>
                (new DropCreateDatabaseIfModelChanges<Model1>());
            //m.Database.SetInitializer<Model1>(null);
            AddAbility(m, "Attacker");
            AddAbility(m, "Defender");
            AddColor(m, "Blue");
            AddColor(m, "Green");
            AddColor(m, "Black");
            foreach (var item in m.Heroes)
            {
                Console.WriteLine(item.Name);
            }
            m.Heroes.Add(new MatrixHeroes.Hero { Name = "12", StartedTrain = DateTime.Now });
            m.SaveChanges();
            Console.WriteLine(
            registr(new UserAccount
            {
                FirstName = "Ashi",
                LastName = "Mark",
                DOB = new DateTime(1986, 4, 18),
                Email = "a@a.com",
                UserName = "Ashi",
                Password = "123456",
                ConfirmPassword = "123456"
            }
            ));


            Console.WriteLine(   Login(new UserAccount { UserName = "Ashi", Password = "123456" }));
            Console.WriteLine(   Login(new UserAccount { UserName = "Ashi", Password = "123456666" }));
            Console.ReadLine();
        }

        public static string Login(UserAccount user)
        {
            using (Model1 db = new Model1())
            {
                var get_user = db.UserAccounts.Single(p => p.UserName == user.UserName);
                if (get_user!=null&&get_user.Password==AESCryptography.Encrypt(user.Password))
                {

              
                    return ("LoggedIn");
                }
                else
                {
                    return "UserName or Password does not match.";
                }

            }
        }
            

            private static string registr(UserAccount user)
        {
            using (Model1 db = new Model1())
            {
                var get_user = db.UserAccounts.FirstOrDefault(p => p.UserName == user.UserName);
                if (get_user == null)
                {
                    user.Password = AESCryptography.Encrypt(user.Password);
                    user.ConfirmPassword = AESCryptography.Encrypt(user.ConfirmPassword);
                    db.UserAccounts.Add(user);
                    db.SaveChanges();
                }
                else
                {
                    return "UserName already exists" + user.UserName;

                }
            }

            return "Successfully Registered Mr. " + user.FirstName + " " + user.LastName;

        }



        private static void AddAbility(Model1 m, string clr)
        {
            if (!m.Abilities.Any(x => x.Name == clr))
            {
                m.Abilities.Add(new MatrixHeroes.Ability() { Name = clr });
                m.SaveChanges();
            }
        }
        private static void AddColor(Model1 m, string clr)
        {
            if (!m.SuitColors.Any(x => x.Name == clr))
            {
                m.SuitColors.Add(new MatrixHeroes.SuitColor() { Name = clr });
                m.SaveChanges();
            }
        }
    }
}
