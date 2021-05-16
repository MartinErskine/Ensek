using Ensek.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Data.Seed
{
    internal static class AccountsSeeder
    {
        internal static void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasData(
                    new Account {AccountId = 1234, Firstname = "Freya", Lastname = "Test"},
                    new Account {AccountId = 1239, Firstname = "Noddy", Lastname = "Test"},
                    new Account {AccountId = 1240, Firstname = "Archie", Lastname = "Test"},
                    new Account {AccountId = 1241, Firstname = "Lara", Lastname = "Test"},
                    new Account {AccountId = 1242, Firstname = "Tim", Lastname = "Test"},
                    new Account {AccountId = 1243, Firstname = "Graham", Lastname = "Test"},
                    new Account {AccountId = 1244, Firstname = "Tony", Lastname = "Test"},
                    new Account {AccountId = 1245, Firstname = "Neville", Lastname = "Test"},
                    new Account {AccountId = 1246, Firstname = "Jo", Lastname = "Test"},
                    new Account {AccountId = 1247, Firstname = "Jim", Lastname = "Test"},
                    new Account {AccountId = 1248, Firstname = "Pam", Lastname = "Test"},
                                 
                    new Account {AccountId = 2233, Firstname = "Barry", Lastname = "Test"},
                    new Account {AccountId = 2344, Firstname = "Tommy", Lastname = "Test"},
                    new Account {AccountId = 2345, Firstname = "Jerry", Lastname = "Test"},
                    new Account {AccountId = 2346, Firstname = "Ollie", Lastname = "Test"},
                    new Account {AccountId = 2347, Firstname = "Tara", Lastname = "Test"},
                    new Account {AccountId = 2348, Firstname = "Tammy", Lastname = "Test"},
                    new Account {AccountId = 2349, Firstname = "Simon", Lastname = "Test"},
                    new Account {AccountId = 2350, Firstname = "Colin", Lastname = "Test"},
                    new Account {AccountId = 2351, Firstname = "Gladys", Lastname = "Test"},
                    new Account {AccountId = 2352, Firstname = "Greg", Lastname = "Test"},
                    new Account {AccountId = 2353, Firstname = "Tony", Lastname = "Test"},
                    new Account {AccountId = 2355, Firstname = "Arthur", Lastname = "Test"},
                    new Account {AccountId = 2356, Firstname = "Craig", Lastname = "Test"},
                    new Account {AccountId = 4534, Firstname = "JOSH", Lastname = "TEST"},
                    new Account {AccountId = 6776, Firstname = "Laura", Lastname = "Test"},
                    new Account {AccountId = 8766, Firstname = "Sally", Lastname = "Test"}

                );
            });
        }


        // If we were to import Accounts then we may want to correct the case for all name strings ('JOSH TEST')
        private static string ProperCase(string text)
        {
            return System.Threading.Thread.CurrentThread
                .CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

    }
}
