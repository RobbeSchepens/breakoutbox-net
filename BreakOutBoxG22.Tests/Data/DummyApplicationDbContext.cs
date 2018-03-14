using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using BreakOutBox.Models.Domain;

namespace BreakOutBoxG22.Tests.Data
{
    public class DummyApplicationDbContext
    {
        //public IEnumerable<Oefening> Oefeningen { get; }
        //public Brewer Bavik { get; }
        //public Brewer Moortgat { get; }
        //public Brewer DeLeeuw { get; }
        //public Beer BavikPils { get; }
        //public Beer Wittekerke { get; }
        //public Location Bavikhove { get; }
        //public Customer CustomerJan { get; }
        //public Cart CartFilled { get; }

        //public DummyApplicationDbContext()
        //{
        //    int oefeningId = 1;
        //    int brewerId = 1;
        //    Bavikhove = new Location { Name = "Bavikhove", PostalCode = "8531" };
        //    Location puurs = new Location { Name = "Puurs", PostalCode = "2870" };
        //    Location leuven = new Location { Name = "Leuven", PostalCode = "3000" };

        //    Locations = new[] { Bavikhove, puurs, leuven };

        //    Bavik = new Brewer("Bavik", Bavikhove, "Rijksweg 33") { BrewerId = brewerId++ };
        //    Bavik.AddBeer("Bavik Pils", 5.2, 1.0M).BeerId = beerId++;
        //    Bavik.AddBeer("Wittekerke", 5.0, 2.0M).BeerId = beerId++;
        //    Bavik.Turnover = 20000000;
        //    BavikPils = Bavik.Beers.FirstOrDefault(b => b.Name == "Bavik Pils");
        //    Wittekerke = Bavik.Beers.FirstOrDefault(b => b.Name == "Wittekerke");

        //    Moortgat = new Brewer("Duvel Moortgat", puurs, "Breendonkdorp 28") { BrewerId = brewerId++ };
        //    Moortgat.AddBeer("Duvel", 8.5, 2.0M).BeerId = beerId;

        //    DeLeeuw = new Brewer("De Leeuw") { BrewerId = brewerId };
        //    DeLeeuw.Turnover = 50000;

        //    Brewers = new[] { DeLeeuw, Moortgat, Bavik };

        //    Beers = Brewers.SelectMany(b => b.Beers).OrderBy(be => be.Name);

        //    CartFilled = new Cart();
        //    CartFilled.AddLine(Wittekerke, 5);
        //    CustomerJan = new Customer
        //    {
        //        Email = "jan@hogent.be",
        //        FirstName = "Jan",
        //        Name = "De man",
        //        Location = Bavikhove,
        //        Street = "Bavikhovestraat"
        //    };
        }
    }
}
