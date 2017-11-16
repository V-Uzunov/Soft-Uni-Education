namespace _02.One_to_ManyRelation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new MyDBContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                
            }
        }
    }
}
