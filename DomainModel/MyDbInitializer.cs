using System.Data.Entity;

namespace DomainModel
{
    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
                        
            context.SaveChanges();
        }
    }
}
