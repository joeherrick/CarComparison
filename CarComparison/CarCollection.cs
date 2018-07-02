using System;
using System.Collections.Generic;
using System.Linq;

namespace CarComparisonApp
{
    internal class CarCollection
    {
        public CarCollection(IEnumerable<CarDetails> carDetails)
        {
            AllCars = carDetails;
        }

        public IEnumerable<CarDetails> AllCars { get; }

        public IEnumerable<CarDetails> AllCarsByYear => AllCars.OrderBy(c => c.Year);
        public IEnumerable<CarDetails> AllCarsByMakeAndModel => AllCars.OrderBy(c => c.Make).ThenBy( c => c.Model);
        public IEnumerable<CarDetails> AllCarsByPrice => AllCars.OrderBy(c => c.Price);
        public IEnumerable<CarDetails> AllCarsByValue => AllCars.OrderBy(c => c.Price / c.TCCRating );
        public IEnumerable<KeyValuePair<int, decimal>> AverageMPGByYear => AllCars.GroupBy(c => c.Year).Select( g => new KeyValuePair<int, decimal>( g.Key, g.Average( c => c.HwyMPG )));
        public CarDetails RandomCar => AllCars.Skip(new Random().Next(0, AllCars.Count())).FirstOrDefault();
    }
}
