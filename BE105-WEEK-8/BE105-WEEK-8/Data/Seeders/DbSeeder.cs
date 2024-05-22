using BE105_WEEK_8.Entities;
using BE105_WEEK_8.DTOs;
using Bogus;

namespace BE105_WEEK_8.Data.Seeders
{
    public class DbSeeder
    {
        
        

            public static void Faker(AppDbContext context)
            {
                
                Randomizer.Seed = new Random();
                Student testUsers = new Faker<Student>()
                .RuleFor(u => u.Firstname, f => f.Name.FirstName())
                .RuleFor(u => u.Lastname, (f, u) => f.Name.LastName())
                .RuleFor(u=>u.StudentNumber, (f,u) =>f.Random.Number(1,10000))
                .RuleFor(u=>u.BirthDate,(f,u) => f.Date.Past())
                .RuleFor(u => u.CreatedAt, (f, u) => f.Date.Recent())
                .RuleFor(u => u.LastUpdatedAt, (f, u) => f.Date.Recent());
                
                context.Students.Add(testUsers);
                context.SaveChanges();

            }
       

    }
}
