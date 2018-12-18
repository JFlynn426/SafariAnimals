using System;
using System.Linq;

namespace SafariAnimals
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new AnimalSeenContext();
      //   db.SafariAnimalsSeen.Add(new SafariAnimalsSeen
      //   {
      //     Species = "Lion",
      //     CountOfTimesSeen = 3,
      //     LocationOfLastSeen = "Eating my leg"
      //   });
      //   db.SafariAnimalsSeen.Add(new SafariAnimalsSeen
      //   {
      //     Species = "Hyena",
      //     CountOfTimesSeen = 5,
      //     LocationOfLastSeen = "Waiting for the lion to finish eating my leg"
      //   });
      //   db.SafariAnimalsSeen.Add(new SafariAnimalsSeen
      //   {
      //     Species = "Elephant",
      //     CountOfTimesSeen = 3,
      //     LocationOfLastSeen = "On top of the car"
      //   });
      //   db.SafariAnimalsSeen.Add(new SafariAnimalsSeen
      //   {
      //     Species = "Hippo",
      //     CountOfTimesSeen = 1,
      //     LocationOfLastSeen = "Trampling me on the way to go swimming"
      //   });
      //   db.SafariAnimalsSeen.Add(new SafariAnimalsSeen
      //   {
      //     Species = "Giraffe",
      //     CountOfTimesSeen = 1,
      //     LocationOfLastSeen = "Peeking in the window while I'm sleeping"
      //   });
      //   db.SafariAnimalsSeen.Add(new SafariAnimalsSeen
      //   {
      //     Species = "Crocodile",
      //     CountOfTimesSeen = 1,
      //     LocationOfLastSeen = "Ate my wife while swimming"
      //   });
      //   db.SaveChanges();
      //  db.SafariAnimalsSeen.Add(new SafariAnimalsSeen
      //   {
      //     Species = "Tigers",
      //     CountOfTimesSeen = 1,
      //     LocationOfLastSeen = "Jungle"
      //   });
      //    db.SafariAnimalsSeen.Add(new SafariAnimalsSeen
      //   {
      //     Species = "Bears",
      //     CountOfTimesSeen = 2,
      //     LocationOfLastSeen = "Desert"
      //   });
      // do
      var allAnimals = db.SafariAnimalsSeen;
      foreach (var animal in allAnimals)
      {
        Console.WriteLine($"I saw a {animal.Species} {animal.CountOfTimesSeen} times and it was {animal.LocationOfLastSeen} and it's ID is {animal.ID}");
      }
      var Crocodile = db.SafariAnimalsSeen.FirstOrDefault(animal => animal.ID == 6);
      if (Crocodile != null)
      {
        Crocodile.CountOfTimesSeen = 2;
        Crocodile.LocationOfLastSeen = "Waiting for the hyenas to finish me up";
        db.SaveChanges();
      }
      var desertAnimals = db.SafariAnimalsSeen.Where(animal => animal.LocationOfLastSeen == "Desert");
      if (desertAnimals != null)
      {
        db.SafariAnimalsSeen.RemoveRange(desertAnimals);
        db.SaveChanges();
      }
      var CountOfSightings = db.SafariAnimalsSeen.Sum(animal => animal.CountOfTimesSeen);
      Console.WriteLine($"I have seen {CountOfSightings} animals");
      var LTB = db.SafariAnimalsSeen.Where(animal => animal.Species == "Lion" || animal.Species == "Tigers" || animal.Species == "Bears");
      foreach (var animal in LTB)
      {
        Console.WriteLine($"I have seen {animal.Species} {animal.CountOfTimesSeen} times");
      }
    }
  }
}
