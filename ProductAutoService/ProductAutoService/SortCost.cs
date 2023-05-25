using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAutoService
{
    class SortCost
    {
         public SortCost() { }
         ~SortCost() { }

        public List<Product> SortCostUp(List<Product> _products)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                for (int j = 0; j < _products.Count - 1; j++)
                {
                    if (_products[i].Cost > _products[j].Cost)
                    {
                        Product temp = _products[i];
                        _products[i] = _products[j];
                        _products[j] = temp;
                    }
                }
            }
            return _products;
        }

        public List<Product> SortCostDown(List<Product> _products)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                for (int j = 0; j < _products.Count - 1; j++)
                {
                    if (_products[i].Cost < _products[j].Cost)
                    {
                        Product temp = _products[i];
                        _products[i] = _products[j];
                        _products[j] = temp;
                    }
                }
            }
            return _products;
        }

    }
}
