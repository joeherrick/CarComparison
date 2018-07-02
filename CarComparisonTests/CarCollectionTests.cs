using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarComparisonApp;
using System.Linq;
using System.Collections.Generic;
namespace CarComparisonTests
{
    [TestClass]
    public class CarCollectionTests
    {
        [TestMethod]
        public void SortCarsByYear()
        {
            var carsUnsorted = new List<CarDetails>() { new CarDetails { Year = 2001 }, new CarDetails { Year = 2000 } };
            var coll = new CarCollection(carsUnsorted);
            var carsSorted = coll.AllCarsByYear;
            Assert.AreEqual(2001, carsUnsorted.FirstOrDefault().Year);
            Assert.AreEqual(2000, carsSorted.FirstOrDefault().Year);
        }
        [TestMethod]
        public void SortCarsByMakeAndModel()
        {
            var carsUnsorted = new List<CarDetails>()
            {
                new CarDetails { Make = "Honda", Model="B" },
                new CarDetails { Make = "Honda", Model = "A"},
                new CarDetails { Make = "Acura", Model = "1"}
            };
            var coll = new CarCollection(carsUnsorted);
            var carsSorted = coll.AllCarsByMakeAndModel;
            Assert.AreEqual("Honda", carsUnsorted.FirstOrDefault().Make);
            Assert.AreEqual("B", carsUnsorted.Where(c => c.Make.Equals("Honda")).FirstOrDefault().Model);
            Assert.AreEqual("Acura", carsSorted.FirstOrDefault().Make);
            Assert.AreEqual("A", carsSorted.Where(c => c.Make.Equals("Honda")).FirstOrDefault().Model);
        }
        [TestMethod]
        public void SortCarsByPrice()
        {
            var carsUnsorted = new List<CarDetails>() { new CarDetails { Price = 100 }, new CarDetails { Price = 90 } };
            var coll = new CarCollection(carsUnsorted);
            var carsSorted = coll.AllCarsByPrice;
            Assert.AreEqual(100, carsUnsorted.FirstOrDefault().Price);
            Assert.AreEqual(90, carsSorted.FirstOrDefault().Price);
        }
        [TestMethod]
        public void SortCarsByValue()
        {
            var carsUnsorted = new List<CarDetails>() { new CarDetails { Price = 100, TCCRating= 5 }, new CarDetails { Price = 100, TCCRating = 10} };
            var coll = new CarCollection(carsUnsorted);
            var carsSorted = coll.AllCarsByValue;
            Assert.AreEqual(5, carsUnsorted.FirstOrDefault().TCCRating);
            Assert.AreEqual(10, carsSorted.FirstOrDefault().TCCRating);
        }
        [TestMethod]
        public void AverageMPGByYear()
        {
            var carsUnsorted = new List<CarDetails>()
            {
                new CarDetails { Year = 2000, HwyMPG = 30},
                new CarDetails { Year = 2000, HwyMPG = 40},
                new CarDetails { Year = 2001, HwyMPG = 30},
                new CarDetails { Year = 2002, HwyMPG = 30},
            };
            var coll = new CarCollection(carsUnsorted);
            var mpgDetails = coll.AverageMPGByYear;
            Assert.AreEqual(35, mpgDetails.Where(g => g.Key == 2000).FirstOrDefault().Value);
            Assert.AreEqual(30, mpgDetails.Where(g => g.Key== 2001).FirstOrDefault().Value);
        }
    }
}
