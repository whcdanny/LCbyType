1357. Apply Discount Every n Orders
//C#
		class Cashier
        {

            int counter;
            int n;

            int discount;
            int[] products;
            int[] prices;

            public Cashier(int n, int discount, int[] products, int[] prices)
            {
                counter = 0;
                this.n = n;
                this.discount = discount;
                this.products = new int[256];
                this.prices = new int[256];
                for (int i = 0; i < products.Length; i++)
                {
                    this.products[products[i]] = products[i];
                    this.prices[products[i]] = prices[i];
                }
            }

            public double getBill(int[] product, int[] amount)
            {
                counter++;
                double sum = 0.0d;
                for (int p = 0; p < product.Length; p++)
                {
                    int id = product[p];
                    sum += prices[id] * amount[p];
                }
                return counter % n == 0 ? (sum - (discount * sum) / 100) : sum;
            }
        }