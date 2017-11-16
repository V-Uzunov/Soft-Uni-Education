using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Photographer.Data
{
    class DBSeed
    {
        class DbInitializerPhotographerContext : DropCreateDatabaseAlways<PhotographerContext>
        {


            protected override void Seed(PhotographerContext context)
            {
                Console.WriteLine($"Seeding...");
                Photographer photographer01 = new Photographer("Ivan", "ivanEp1ChO7Klass4!%@", "ivan@softuni.bg");
                Photographer photographer02 = new Photographer("Maria", "B1nag1C4gl4sn4$@#", "mimi69@gola.sam");
                Photographer photographer03 = new Photographer("Pesho", "Sn1m4mS1Br4t**", "pepi@abv.gg");
                Photographer photographer04 = new Photographer("FourStar", "asfuij8h7**", "four@five.bg");


                Album album1 = new Album("Summer 2017", "Blue", true);
                Album album2 = new Album("Winter 2017", "White", true);
                Album album3 = new Album("Dubai 2017", "Sandy", false);
                Album album4 = new Album("Private", "Black and red", false);


                Picture picture1 = new Picture("Pic001", "PrivatePic001", $"/root/Pictures/Pic001");
                Picture picture2 = new Picture("Pic002", "PrivatePic002", $"/root/Pictures/Pic002");
                Picture picture3 = new Picture("Pic003", "PrivatePic003", $"/root/Pictures/Pic003");
                Picture picture4 = new Picture("Pic004", "PrivatePic004", $"/root/Pictures/Pic004");
                Picture picture5 = new Picture("Pic005", "PrivatePic005", $"/root/Pictures/Pic005");
                Picture picture6 = new Picture("Pic006", "PrivatePic006", $"/root/Pictures/Pic006");
                Picture picture7 = new Picture("Pic007", "PrivatePic007", $"/root/Pictures/Pic007");

                Tag tag1 = new Tag("#CS");
                Tag tag2 = new Tag("#CSharp");
                Tag tag3 = new Tag("#.NET");
                Tag tag4 = new Tag("#EntityFramework");


                album1.Pictures.Add(picture1);
                album1.Pictures.Add(picture2);
                album1.Pictures.Add(picture3);
                album1.Pictures.Add(picture4);
                album1.Pictures.Add(picture5);
                album1.Pictures.Add(picture6);
                album1.Pictures.Add(picture7);
                album2.Pictures.Add(picture1);
                album2.Pictures.Add(picture2);
                album2.Pictures.Add(picture3);
                album2.Pictures.Add(picture4);
                album3.Pictures.Add(picture5);
                album3.Pictures.Add(picture6);
                album3.Pictures.Add(picture7);
                album4.Pictures.Add(picture7);

                album1.Tags.Add(tag1);
                album1.Tags.Add(tag2);
                album2.Tags.Add(tag1);
                album2.Tags.Add(tag2);
                album2.Tags.Add(tag3);
                album3.Tags.Add(tag1);
                album3.Tags.Add(tag2);
                album3.Tags.Add(tag3);
                album3.Tags.Add(tag4);
                album4.Tags.Add(tag1);
                photographer01.Albums.Add(album1);
                photographer01.Albums.Add(album2);
                photographer02.Albums.Add(album3);
                // The migration for uniq album owner is located here: ./Migrations/201703091822532_SingleAlbum.cs
                // It is commented out for easy further DB use
                //photographer03.Albums.Add(album3); 
                photographer04.Albums.Add(album4);

                Console.WriteLine($"Seeding Photographers..");
                context.Photographers.AddOrUpdate(x => x.Username, photographer01);
                context.Photographers.AddOrUpdate(x => x.Username, photographer02);
                context.Photographers.AddOrUpdate(x => x.Username, photographer03);
                context.Photographers.AddOrUpdate(x => x.Username, photographer04);
                context.SaveChanges();

                Console.WriteLine($"Seeding Albums..");
                context.Albums.AddOrUpdate(x => x.Name, album1);
                context.Albums.AddOrUpdate(x => x.Name, album2);
                context.Albums.AddOrUpdate(x => x.Name, album3);
                context.Albums.AddOrUpdate(x => x.Name, album4);
                context.SaveChanges();

                Console.WriteLine($"Seeding Pictures..");
                context.Pictures.AddOrUpdate(x => x.Title, picture1);
                context.Pictures.AddOrUpdate(x => x.Title, picture2);
                context.Pictures.AddOrUpdate(x => x.Title, picture3);
                context.Pictures.AddOrUpdate(x => x.Title, picture4);
                context.Pictures.AddOrUpdate(x => x.Title, picture5);
                context.Pictures.AddOrUpdate(x => x.Title, picture6);
                context.Pictures.AddOrUpdate(x => x.Title, picture7);
                context.SaveChanges();

                Console.WriteLine($"Seeding Tags..");
                context.Tags.AddOrUpdate(x => x.TagName, tag1);
                context.Tags.AddOrUpdate(x => x.TagName, tag2);
                context.Tags.AddOrUpdate(x => x.TagName, tag3);
                context.Tags.AddOrUpdate(x => x.TagName, tag4);

                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}
