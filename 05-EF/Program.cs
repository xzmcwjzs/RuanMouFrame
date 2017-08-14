using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05_EF.DBFirst;

namespace _05_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (DBFirstContext dbcontext=new DBFirstContext())
            //{
            //    var user = dbcontext.User.Find(1);
            //}

                            //{
                //    Console.WriteLine("****************************************");
                //    var list = from u in dbContext.User
                //               where new int[] { 1, 2, 3, 4, 6, 7, 10 }.Contains(u.Id)
                //               select u;

                //    var list1 = dbContext.User.Where(u => new int[] { 1, 2, 3, 4, 6, 7, 10 }.Contains(u.Id));
                //    foreach (var user in list)
                //    {
                //        Console.WriteLine("{0} {1}", user.Id, user.Name);
                //    }
                //}

                //{
                //    Console.WriteLine("****************************************");
                //    var list = from u in dbContext.User
                //               where (from c in dbContext.Company where c.Id == 1 select c.Id).Contains(u.CompanyId ?? 0)
                //               select u;
                //    foreach (var user in list)
                //    {
                //        Console.WriteLine("{0} {1}", user.Id, user.Name);
                //    }
                //}

                //{
                //    Console.WriteLine("****************************************");
                //    var list = from u in dbContext.User
                //               join c in dbContext.Company on u.CompanyId equals c.Id
                //               where new int[] { 1, 2, 3, 4, 6, 7, 10 }.Contains(u.Id)
                //               select u;
                //    foreach (var user in list)
                //    {
                //        Console.WriteLine("{0} {1}", user.Id, user.Name);
                //    }
                //}

                //{
                //    Console.WriteLine("****************************************");
                //    var list = from u in dbContext.User
                //               join c in dbContext.Company on u.CompanyId equals c.Id
                //               into ucList
                //               from uc in ucList.DefaultIfEmpty()
                //               where new int[] { 1, 2, 3, 4, 6, 7, 10 }.Contains(u.Id)
                //               select u;
                //    foreach (var user in list)
                //    {
                //        Console.WriteLine("{0} {1}", user.Id, user.Name);
                //    }
                //}

                //{
                //    var list = dbContext.Database.SqlQuery<EF6Show.CodeFirstFromDB.User>("SELECT * FROM [USER] WHERE Id=@id;", new SqlParameter("@id", 2));
                //    foreach (var user in list)
                //    {
                //        Console.WriteLine("{0} {1}", user.Id, user.Name);
                //    }
                //}

                //{
                //    DbContextTransaction trans = null;
                //    try
                //    {
                //        trans = dbContext.Database.BeginTransaction();
                //        dbContext.Database.ExecuteSqlCommand("UPDATE [USER] SET STATE=0 WHERE ID=@id", new SqlParameter("@id", 2));
                //        trans.Commit();
                //    }
                //    catch (Exception ex)
                //    {
                //        if (trans != null)
                //            trans.Rollback();
                //        throw ex;
                //    }
                //}

            Console.ReadKey();
        }
    }
}
