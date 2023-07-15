using System.Collections.Generic;

namespace VendingMachineProject
{
    public class VendingMachinProduct
    {
        private Dictionary<MachineProducts, int> Products { get; set; }
        public VendingMachinProduct()
        {
            Products = new Dictionary<MachineProducts, int>();
        }

        internal void AddProduct(MachineProducts product, int num)
        {
            if (Products.ContainsKey(product))
            {
                Products[product] += num;
            }
            else
            {
                Products.Add(product, num);
            }
        }

        internal void DispenseProduct(MachineProducts product)
        {
            int count = Count(product);
            if (count > 0)
            {
                Products[product] = count - 1;
            }
        }

        public int Count(MachineProducts product)
        {
            int count = 0;
            if (Products.ContainsKey(product))
            {
                count = Products[product];
            }
            return count;
        }
    }
}
