using DogWalkers.Data;
using DogWalkers.Models;
using System;
using System.Collections.Generic;

namespace DogWalkers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("");

                Console.WriteLine("1. Show all dog  walkers");
                Console.WriteLine("2. Show all dog walkers for a specific neighborhood");
                Console.WriteLine("3. Add a new dog walker");
                Console.WriteLine("4. Show all owners");
                Console.WriteLine("5. Add a new owner");
                Console.WriteLine("6. Update owner's neighborhood");
                Console.WriteLine("");

                var choice = Console.ReadLine();
                WalkerRepository walkerRepo = new WalkerRepository();
                OwnerRepository ownerRepo = new OwnerRepository();
                NeighborhoodRepository neighborhoodRepo = new NeighborhoodRepository();

                switch (Int32.Parse(choice))
                {
                    case 1:
                        Console.WriteLine("All dog walkers:");
                        Console.WriteLine("");
                        List<Walker> allWalkers = walkerRepo.GetAllWalkers();
                        foreach(Walker walker in allWalkers)
                        {
                            Console.WriteLine($"{walker.Name}");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the neighborhood Id");
                        var neighborhoodChoice = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Getting walkers with a neighborhood Id of {neighborhoodChoice}");
                        List<Walker> neighborhoodWalkerList = walkerRepo.GetAllWalkersByNeighborhoodId(neighborhoodChoice);

                        foreach(var walker in neighborhoodWalkerList)
                        {
                            Console.WriteLine($"{walker.Name} - {walker.Neighborhood.Name} ");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the name of the new dog walker");
                        var walkerName = Console.ReadLine();
                        Console.WriteLine("Enter the new dog walker's neighborhood Id");
                        var walkerNeighborhoodId = Int32.Parse(Console.ReadLine());
                        Walker newWalker = new Walker
                        {
                            Name = walkerName,
                            NeighborhoodId = walkerNeighborhoodId

                        };
                        walkerRepo.AddWalker(newWalker);
                        Console.WriteLine($"Added {newWalker.Name} as a new dog walker!");
                        break;

                    case 4:
                        List<Owner> allOwners = ownerRepo.GetAllOwners();
                        Console.WriteLine("All owners:");

                        foreach (Owner owner in allOwners)
                        {
                            Console.WriteLine($"{owner.Name} - {owner.Neighborhood.Name}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter new owner's name");
                        var newOwnerName = Console.ReadLine();
                        Console.WriteLine("Enter the number of the neighborhood the owner belongs to");
                        List<Neighborhood> allNeighborhoods = neighborhoodRepo.GetAllNeighborhoods();

                        foreach (Neighborhood n in allNeighborhoods)
                        {
                            Console.WriteLine($"{n.Id}. {n.Name}");
                        }

                        var newOwnerNId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new owner's phone number");
                        var newOwnerPhone = Console.ReadLine();

                        Console.WriteLine("Enter the new owner's address");
                        var newOwnerAddress = Console.ReadLine();

                        Owner newOwner = new Owner
                        {
                            Name = newOwnerName,
                            NeighborhoodId = newOwnerNId,
                            Phone = newOwnerPhone,
                            Address = newOwnerAddress
                        };

                        ownerRepo.AddOwner(newOwner);
                        Console.WriteLine($"Added {newOwnerName} as a new owner!");
                        break;

                    case 6:
                        Console.WriteLine("Which owner would you like to update?");
                        List<Owner> allOwnersToUpdate = ownerRepo.GetAllOwners();
                        foreach(Owner owner in allOwnersToUpdate)
                        {
                            Console.WriteLine($"{owner.Id}. {owner.Name} - {owner.Neighborhood.Name}");
                        }

                        var chosenOwnerToUpdate = Int32.Parse(Console.ReadLine());
                        var selectedOwner = ownerRepo.GetOwnerById(chosenOwnerToUpdate);

                        Console.WriteLine("Enter the number of the neighborhood you change the owner to");
                        List<Neighborhood> allPossibleNeighborhoods = neighborhoodRepo.GetAllNeighborhoods();

                        foreach (Neighborhood n in allPossibleNeighborhoods)
                        {
                            Console.WriteLine($"{n.Name}");
                        }

                        var updateOwnerNId = int.Parse(Console.ReadLine());
                        selectedOwner.NeighborhoodId = updateOwnerNId;

                        ownerRepo.UpdateOwner(selectedOwner.Id, selectedOwner);
                        Console.WriteLine($"{selectedOwner.Name}'s neighborhood has been updated to {selectedOwner.Neighborhood.Name}");
                        break;

                }
            }
        }
    }
}
