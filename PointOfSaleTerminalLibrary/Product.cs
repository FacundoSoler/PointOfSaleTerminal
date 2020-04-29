using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminalLibrary
{
    public class Product
    {
        private string _name;
        private double _unitPrice; // Price per product unit.
        private bool _HasVolumePrice; // If the product has a special volume price.
        private double _volumePrice; // Special price applied to pre-determined quantity of product units ordered.
        private int _volumeQuantity; // Number of product units to enable and apply volume price.
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public bool HasVolumePrice
        {
            get { return _HasVolumePrice; }
            set { _HasVolumePrice = value; }
        }

        public double VolumePrice
        {
            get { return _volumePrice; }
            set { _volumePrice = value; }
        }

        public int VolumeQuantity
        {
            get { return _volumeQuantity; }
            set { _volumeQuantity = value; }
        }

        public Product()
        {
            Name = "";
            UnitPrice = 0;
            VolumePrice = 0;
            VolumeQuantity = 0;
        }
        public Product(string pName, double pUnitPrice, bool pHasVolumePrice, int pVolumeQuantity, double pVolumePrice)
        {
            Name = pName;
            UnitPrice = pUnitPrice;
            HasVolumePrice = pHasVolumePrice;
            VolumePrice = pVolumePrice;
            VolumeQuantity = pVolumeQuantity;
        }
    }
}
