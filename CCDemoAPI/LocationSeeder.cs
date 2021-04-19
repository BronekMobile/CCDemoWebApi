using CCDemoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI
{
    public class LocationSeeder
    {
        private readonly CCDbContext _dbContext;

        public LocationSeeder(CCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();

                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Locations.Any())
                {
                    var locations = GetLocations();
                    _dbContext.AddRange(locations);
                    _dbContext.SaveChanges();
                }
            }
         }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };
            return roles;
        }

        private IEnumerable<Location> GetLocations()
        {
            var locations = new List<Location>()
            {
                new Location()
                {
                    Name = "Mieszkanie w Ustroniu",
                    Type = "House",
                    ContactEmail = "kbronowski@gmail.pl",

                    Parking = new Parking()
                    {
                        Name = "No Parking",
                        Description = "There is no parking available"
                    },
                    Address = new Address()
                    {
                        City = "Ustroń",
                        Country = "Poland",
                        PostalCode = "43-450",
                        Street = "Gołyska 3"
                    },
                    Rooms = new List<Room>()
                    {
                        new Room()
                        {
                            Area = 40,
                            DoorCount = 1,
                            Name = "Mój pokój",
                        },
                        new Room()
                        {
                            Area = 40,
                            DoorCount = 1,
                            Name = "Moja łazienka",
                        }
                    }
                }
            };

            return locations;
        }
    }
}
