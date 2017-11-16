namespace _03.Many_to_ManyRelation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new MyManyToManyDBContext())
            {
                ClearDataBase(db);
            }
        }

        private static void ClearDataBase(MyManyToManyDBContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
