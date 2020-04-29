using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleTerminalLibrary
{
    public class PointOfSaleTerminalService
    {
        List<Item> ItemsList = new List<Item>();
        readonly List<Product>  ProductList = new List<Product>();
        
        public void SetPricing(string pProductName, double pUnitPrice, bool pHasVolumePrice, int pVolumeQuantity, double pVolumePrice)
        {
            Product product = new Product();
            try
            {
                product = ProductList.Where(i => i.Name == pProductName).FirstOrDefault();

                if (product == null)
                {
                    product = new Product(pProductName, pUnitPrice, pHasVolumePrice, pVolumeQuantity, pVolumePrice);
                    ProductList.Add(product);
                }
                else
                {
                    int index = ProductList.IndexOf(product);
                    product = new Product(pProductName, pUnitPrice, pHasVolumePrice, pVolumeQuantity, pVolumePrice);
                    ProductList[index] = product;
                }
            }
            catch { throw; }
            finally 
            {
                product = null;
            }
        }
        public string ScanProduct(string pProductName)
        {
            Product product = new Product();
            Item item = new Item();
            try
            {
                // Check if product already exists in the terminal
                product = ProductList.Where(i => i.Name == pProductName).FirstOrDefault();

                if (product == null)
                {
                    return "Product '"+ pProductName +"' doesn´t exist. Please use 'SetPricing' function to register the new product and try again.";
                }
                else { // Check if item (of Product type) already exists in the terminal
                    item = ItemsList.Where(i => i.PProduct.Name == pProductName).FirstOrDefault();
                    if (item == null)
                    {
                        item = new Item(product);
                        item.Quantity++;
                        ItemsList.Add(item);
                    }
                    else
                    {
                        item.Quantity++;
                    }
                }
                return "OK";
            }
            catch { throw; }
            finally
            {
                product = null;
                item = null;
            }
        }
        public decimal CalculateTotal()
        {
            decimal total = 0;
            decimal itemTotal;
            int multiBuyPromotions; // number of multi-buy promotions (group of product units)
            decimal multiBuySubTotal;
            int units; // number of units without multi-buy promotion
            decimal unitsSubTotal;

            try
            {
                foreach (Item item in ItemsList)
                {
                    if (item.PProduct.HasVolumePrice)
                    {
                        multiBuyPromotions = Convert.ToInt32(item.Quantity / item.PProduct.VolumeQuantity);
                        multiBuySubTotal = Convert.ToDecimal(multiBuyPromotions * item.PProduct.VolumePrice);
                        units = item.Quantity - (multiBuyPromotions * item.PProduct.VolumeQuantity);
                        unitsSubTotal = Convert.ToDecimal(units * item.PProduct.UnitPrice);
                        itemTotal = multiBuySubTotal + unitsSubTotal;
                    }
                    else
                    {
                        itemTotal = Convert.ToDecimal(item.Quantity * item.PProduct.UnitPrice);
                    }
                    total += itemTotal;
                }
            }
            catch { throw; }
            finally
            {
                ItemsList = null;
            }
            return total;
        }
    }
}
