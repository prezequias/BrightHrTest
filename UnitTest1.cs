using System.Collections.Generic;
using BrightHrLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable All

namespace BrightHrTest
{
    [TestClass]
    public class UnitTest1
    {
        public static SortedDictionary<string, int> itemsList = new SortedDictionary<string, int>();
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void ScanTest()
        {
            var added = false;
            //I used here method dependency injection, calling the abstract class Problem solution via the interface
            Icheckout getTotalPrices = new ProblemSolution();

            (string SKU, int quantity)[] list = {
                (SKU : "A", quantity : 10),
                (SKU : "B", quantity : 1),
                (SKU : "C", quantity : 3),
                (SKU : "D", quantity : 4),

            };

            if (!itemsList.ContainsKey(list[0].SKU))
            {
                itemsList.Add(list[0].SKU, list[0].quantity);
                added = true;
            }


            Assert.AreEqual(true, added);
        }

        [TestMethod]
        public void GetTotalPriceTest()
        {
            double? total = 0.0;
            //Create list of 
            (string SKU, int quantity)[] list = {
                (SKU : "A", quantity : 10),
                (SKU : "B", quantity : 1),
                (SKU : "C", quantity : 3),
                (SKU : "D", quantity : 4),

            };
            foreach (var item in list)
            {
                var current = item.SKU;
                if (itemOffer.Offer.ContainsKey(current))
                {
                    var currentOffer = itemOffer.Offer[current];
                    if (currentOffer.quantity < item.quantity)
                    {
                        total += (item.quantity % currentOffer.quantity) * ItemPrice.UnitPrice[item.SKU] +
                                 (item.quantity / currentOffer.quantity) * currentOffer.SpecialPrice;
                    }
                    else if (currentOffer.quantity == item.quantity)
                    {
                        //Just add the price to the total amount
                        total += currentOffer.SpecialPrice;
                    }
                    else
                    {
                        //If none of the above matches the criteria, then multiple the item quantity by the item price and add amount to total
                        total += (item.quantity) * ItemPrice.UnitPrice[item.SKU];
                    }
                }
            }
            Assert.AreEqual(630, total);
        }
    }
}
