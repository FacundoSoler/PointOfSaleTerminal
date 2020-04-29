using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminalLibrary
{
    class Item
    {
        private int _quantity;
        Product _product;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public Product PProduct
        {
            get { return _product; }

        }

        public Item()
        {
            _product = new Product();
            Quantity = 0;
        }
        public Item(Product pProduct)
        {
            _product = pProduct;
        }

    }
}
