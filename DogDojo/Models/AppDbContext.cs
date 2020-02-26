using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class AppDbContext : IdentityDbContext<IdentityUser>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<DoggieBagItem> DoggieBagItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // seed breeds
      modelBuilder.Entity<Breed>().HasData(new Breed { BreedId = 1, BreedName = "Labrador Retriever", Description = "A friendly, medium-sized companion. They can be yellow, brown, and black." });
      modelBuilder.Entity<Breed>().HasData(new Breed { BreedId = 2, BreedName = "Doberman", Description = "A German breed, medium-sized dog initially bred as guard dogs. They can be brown or black." });
      modelBuilder.Entity<Breed>().HasData(new Breed { BreedId = 3, BreedName = "Mastiff", Description = "An ancient breed initially bred for war over 5000 years go. This rather large breed comes in a plethora of colors." });

      // seed dogs
      modelBuilder.Entity<Dog>().HasData(new Dog
      {
        DogId = 1,
        Name = "Henry",
        Age = 3,
        Sex = "Male",
        Size = "Large",
        Price = 340.95M,
        Description = "Henry is a little bit shy around strangers but very gentle and calm. He gets along well with other dogs and sweet to people. Henry is very submissive and quiet and great on a leash. The ideal home is someone with gentle and social dogs (he prefers dogs smaller than him and also female). Henry is very happy and confident if he is with other dogs. He is currently in Toronto.",
        BreedId = 3,
        ImageUrl = "/images/dogs/henry.jpg",
        IsAvailable = true,
        IsDogOfTheWeek = true,
      });
      modelBuilder.Entity<Dog>().HasData(new Dog
      {
        DogId = 2,
        Name = "Terra",
        Age = 6,
        Sex = "Female",
        Size = "Medium",
        Price = 456.95M,
        Description = "If her soft, velvety ears, and kind, brown eyes don't you win you over, her personality sure will. This girl's a gem. Sweet, loving and loyal, Terra is as adventurous as she is affectionate. Every day a new adventure. She lives for car rides (front seat or back!), trail runs (she is the fastest!), and dog parks (squirrels?). After a long day of exploring the world and chasing the odd squirrel, she loves sitting down with her people for a cuddle/pet session.",
        BreedId = 1,
        ImageUrl = "/images/dogs/terra.jpg",
        IsAvailable = true,
        IsDogOfTheWeek = false,
      });
      modelBuilder.Entity<Dog>().HasData(new Dog
      {
        DogId = 3,
        Name = "Daytona",
        Age = 4,
        Sex = "Female",
        Size = "Medium",
        Price = 319.99M,
        Description = "While sweet, shy and tiny, Lovely is the backbone, the support system of the friendship. While Daytona is out shouting at leaves and dancing up a storm for others to see, Lovely is keeping things cool, patiently waiting for Daytona to come back down to earth. She is a sweet and sensitive girl who, at the same time, can handle Daytona's high energy and sometimes headstrong attitude.",
        BreedId = 1,
        ImageUrl = "/images/dogs/daytona.jpg",
        IsAvailable = true,
        IsDogOfTheWeek = false,
      });
      modelBuilder.Entity<Dog>().HasData(new Dog
      {
        DogId = 4,
        Name = "Scottie",
        Age = 5,
        Sex = "Male",
        Size = "Medium",
        Price = 512.95M,
        Description = "This boy's fixin' to move on out of the city to a place where ya'll can see the stars and here the wind blowin' through the trees. The cramped condos, the constant noise, the hustle and bustle of the city ain't him. Pardon his boldness, but city life don't amount to a hill o' beans for Scottie! It stinks to high heaven and everyone just seems to darn rushed all the time. He needs that rural calm so he can settle down, relax, and focus on his behaviour with his new family.",
        BreedId = 2,
        ImageUrl = "/images/dogs/scottie.jpg",
        IsAvailable = true,
        IsDogOfTheWeek = true,
      });
      modelBuilder.Entity<Dog>().HasData(new Dog
      {
        DogId = 5,
        Name = "Oslo",
        Age = 1,
        Sex = "Male",
        Size = "Small",
        Price = 257.56M,
        Description = "Walking advertisement for Herbal Essences and three-time male model of the year, Olso is beginning to realize there is more to life than being ridiculously good looking. Yes he likes flipping his lion's mane from side to side, yes he likes strutting his stuff for all to see. But he'd really wish someone would come and be his bestest friend forever. Why not? This boy just wants to chill. Being ridiculously good looking is a lot harder than it looks you know. People are always expecting him to smile and be ready for the camera. Gah! Some days he just wants to cruise around listening to Wham! while sipping on puppuccinos with a tight group of humans. Oslo can be a little cliquey. He's a wine and dine kinda guy who makes you work for his friendship. Models usually are. But deep down he's got a lot of love to give. He just needs to learn to trust. Once you show Oslo you're on his team, he is the epitome of loyal companion and will be a friend for life.",
        BreedId = 2,
        ImageUrl = "/images/dogs/oslo.jpg",
        IsAvailable = true,
        IsDogOfTheWeek = false,
      });
      modelBuilder.Entity<Dog>().HasData(new Dog
      {
        DogId = 6,
        Name = "George",
        Age = 12,
        Sex = "Male",
        Size = "Medium",
        Price = 699.95M,
        Description = "A good boy who loves attention. You couldn't ask for a better dog! He's a sweet lad who would never hurt a fly. He loves to explore and is aptly named after Curious George for his wonderous personality. He's always sniffing and exploring and still has a lot of energy for his age so he needs frequent walks! He can be nervous when it comes to bathing and medicating, but he's always excited to be finsihed. He'll always greet you when you come home with a wagging tale and a goofy smile.",
        BreedId = 1,
        ImageUrl = "/images/dogs/george.jpg",
        IsAvailable = true,
        IsDogOfTheWeek = true,
      });
    }
  }
}
