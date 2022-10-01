1352. Product of the Last K Numbers
//C#
		//慢
		public class ProductOfNumbers
        {
            private List<int> products;
            public ProductOfNumbers()
            {
                products = new List<int>();

            }

            public void Add(int num)
            {
                products.Add(num);
            }

            public int GetProduct(int k)
            {
                int sum = 1;
                //return products.ElementAt(products.Count - 1) / products.ElementAt(products.Count - 1 - k);
                for (int i = products.Count - 1; i >= 0; i--)
                {
                    if (k != 0)
                    {
                        sum *= products[i];
                        k--;
                    }

                }
                return sum;
            }
        }
		//快
		public class ProductOfNumbers
        {
            private List<int> products;
            public ProductOfNumbers()
            {
                products = new List<int>();
                products.Add(1);
            }

            public void Add(int num)
            {
                if (num == 0)
                {
                    products = new List<int>();
                    products.Add(1);
                }
                else
                {
                    products.Add(products.ElementAt(products.Count - 1) * num);
                }
            }

            public int GetProduct(int k)
            {
                if (products.Count <= k)
                {
                    return 0;
                }
                return products.ElementAt(products.Count - 1) / products.ElementAt(products.Count - 1 - k);
            }
        }