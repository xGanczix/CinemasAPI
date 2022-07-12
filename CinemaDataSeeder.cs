using CinemasAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CinemaAPI
{
    public class CinemaDataSeeder
    {
        private readonly CinemaDbContext _dbContext;
        public CinemaDataSeeder(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Cinemas.Any())
                {
                    var cinemas = GetCinemas();
                    _dbContext.Cinemas.AddRange(cinemas);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Cinema> GetCinemas()
        {
            var cinemas = new List<Cinema>()
            {
                new Cinema()
                {
                    Name = "CinemaCity",
                    IsOpen = true,
                    ContactEmail = "cinemacity@contact.com",
                    ContactNumber = "123456789",
                    Films = new List<Film>()
                    {
                        new Film()
                        {
                            Name = "Minionki",
                            Description = "Minionki Kevin, Stuart, Bob oraz Otto muszą ratować młodego Gru, który popadł w konflikt z grupą super złoczyńców znaną jako Vicious 6.",
                            Minutes = 90,
                            Price = 18.99M,
                        },

                        new Film()
                        {
                            Name = "TopGun - Maveric",
                            Description = "Po ponad 20 latach służby w lotnictwie marynarki wojennej, Pete - Maverick Mitchell zostaje wezwany do legendarnej szkoły Top Gun. Ma wyszkolić nowe pokolenie pilotów do niezwykle trudnej misji.",
                            Minutes = 131,
                            Price = 19.99M,
                        },

                        new Film()
                        {
                            Name = "Elvis",
                            Description = "Historia wieloletniej relacji Elvisa Presleya z Parkerem. Kluczowym elementem opowieści jest jedna z najważniejszych  osób w życiu piosenkarza jego żona Priscilla Presley.",
                            Minutes = 169,
                            Price = 19.99M,
                        },
                    },
                    Address = new Address()
                    {
                        City =  "Krakow",
                        Street = "Niebieska 1",
                        PostalCode = "12-345",
                    },
                },

                new Cinema()
                {
                    Name = "Multikino",
                    IsOpen = true,
                    ContactEmail = "multikino@contact.com",
                    ContactNumber = "234567890",
                    Films = new List<Film>()
                    {
                        new Film()
                        {
                            Name = "Minionki",
                            Description = "Minionki Kevin, Stuart, Bob oraz Otto muszą ratować młodego Gru, który popadł w konflikt z grupą super złoczyńców znaną jako Vicious 6.",
                            Minutes = 90,
                            Price = 20.99M,
                        },

                        new Film()
                        {
                            Name = "TopGun - Maveric",
                            Description = "Po ponad 20 latach służby w lotnictwie marynarki wojennej, Pete - Maverick Mitchell zostaje wezwany do legendarnej szkoły Top Gun. Ma wyszkolić nowe pokolenie pilotów do niezwykle trudnej misji.",
                            Minutes = 131,
                            Price = 21.99M,
                        },

                        new Film()
                        {
                            Name = "Buzz Astral",
                            Description = "Młody pilot testowy zostaje bohaterem w kosmosie i dzięki temu dostaje swoją własną zabawkę - Buzza.",
                            Minutes = 100,
                            Price = 18.99M,
                        },
                    },
                    Address = new Address()
                    {
                        City =  "Krakow",
                        Street = "Zolta 3",
                        PostalCode = "23-456",
                    },
                },

                new Cinema()
                {
                    Name = "Helios",
                    IsOpen = true,
                    ContactEmail = "helios@contact.com",
                    ContactNumber = "345678901",
                    Films = new List<Film>()
                    {
                        new Film()
                        {
                            Name = "Thor: Milosc i grom",
                            Description = "Thor: Miłość i grom wytwórni Marvel ukazuje Boga Piorunów w obliczu wyzwania, z jakim dotąd się nie zetknął - konieczności znalezienia wewnętrznego spokoju.",
                            Minutes = 119,
                            Price = 19.99M,
                        },

                        new Film()
                        {
                            Name = "Jurassic World: Dominion",
                            Description = "Jurassic World Dominion rozgrywa się cztery lata po zniszczeniu Isla Nublar. Dinozaury żyją i polują teraz razem z ludźmi na całym świecie.",
                            Minutes = 131,
                            Price = 22.99M,
                        },

                        new Film()
                        {
                            Name = "Buzz Astral",
                            Description = "Młody pilot testowy zostaje bohaterem w kosmosie i dzięki temu dostaje swoją własną zabawkę - Buzza.",
                            Minutes = 100,
                            Price = 19.99M,
                        },
                    },
                    Address = new Address()
                    {
                        City =  "Krakow",
                        Street = "Niebieska 14",
                        PostalCode = "34-567",
                    },
                },
            };

            return cinemas;
        }
    }
}
