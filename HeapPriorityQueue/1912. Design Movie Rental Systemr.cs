//Leetcode 1912. Design Movie Rental Systemr Hard
//题意：你有一个包含 n 家店铺的电影租赁公司。你希望实现一个租赁系统，支持搜索、预订和归还电影。系统还应该支持生成当前已租用电影的报告。
//每部电影由一个二维整数数组 entries 表示，其中 entries[i] = [shopi, moviei, pricei] 表示在店铺 shopi 中有一份电影 moviei 的副本，租金为 pricei。每家店铺最多只能有一份电影 moviei 的副本。
//该系统应支持以下功能：
//Search：查找具有给定电影的未租用副本的最便宜的 5 家店铺。这些店铺应按照价格升序排序，如果价格相同，则应该按照 shopi 的大小升序排列。如果匹配的店铺少于 5 家，则应该返回所有匹配的店铺。如果没有店铺有未租用的副本，则应返回空列表。
//Rent：从给定的店铺租用给定电影的未租用副本。
//Drop：将以前租用的给定电影的副本归还给给定的店铺。
//Report：返回当前最便宜的 5 部已租用电影（可能是相同的电影 ID）作为二维列表 res，其中 res[j] = [shopj, moviej] 描述了第 j 便宜的已租用电影 moviej 是从店铺 shopj 租用的。
//res 中的电影应按价格升序排列，如果价格相同，则应按 shopj 的大小升序排列，并且如果仍然有相同的情况，则应按 moviej 的大小升序排列。如果已租用的电影少于 5 部，则应该返回所有已租用的电影。如果当前没有电影正在租用，则应返回空列表。
//实现 MovieRentingSystem 类：
//MovieRentingSystem(int n, int[][] entries)：使用 n 家店铺和 entries 中的电影初始化 MovieRentingSystem 对象。
//List<Integer> search(int movie)：返回具有给定电影的未租用副本的店铺列表，如上所述。
//void rent(int shop, int movie)：从给定的店铺租用给定的电影。
//void drop(int shop, int movie)：将以前租用的给定电影的副本归还给给定的店铺。
//List<List<Integer>> report()：返回最便宜的已租用电影列表，如上所述。
//思路：PriorityQueue 看code
//时间复杂度: O(nlogn)
//空间复杂度：O(1)        
        public class MovieRentingSystem
        {
            Dictionary<int, SortedSet<Entry>> unrented = new Dictionary<int, SortedSet<Entry>>();
            SortedSet<Entry> rented = new SortedSet<Entry>(new CustomCompare());
            Dictionary<Tuple<int, int>, int> prices = new Dictionary<Tuple<int, int>, int>();

            public MovieRentingSystem(int n, int[][] entries)
            {
                foreach (int[] entry in entries)
                {
                    int shop = entry[0];
                    int movie = entry[1];
                    int price = entry[2];

                    if (!unrented.ContainsKey(movie))
                        unrented.Add(movie, new SortedSet<Entry>(new CustomCompare()));
                    unrented[movie].Add(new Entry(price, shop, movie));
                    prices.Add(Tuple.Create(shop, movie), price);
                }
            }

            public IList<int> Search(int movie)
            {
                if (!unrented.ContainsKey(movie))
                    return new List<int>();
                IList<int> result = new List<int>();
                int i = 0;
                foreach (Entry e in unrented[movie])
                {
                    result.Add(e.shop);
                    ++i;
                    if (i == 5) break;
                }
                return result;
            }

            public void Rent(int shop, int movie)
            {
                int price = prices[Tuple.Create(shop, movie)];
                unrented[movie].Remove(new Entry(price, shop, movie));
                rented.Add(new Entry(price, shop, movie));
            }

            public void Drop(int shop, int movie)
            {
                int price = prices[Tuple.Create(shop, movie)];
                unrented[movie].Add(new Entry(price, shop, movie));
                rented.Remove(new Entry(price, shop, movie));
            }

            public IList<IList<int>> Report()
            {
                IList<IList<int>> result = new List<IList<int>>();
                int i = 0;
                foreach (Entry e in rented)
                {
                    result.Add(new List<int> { e.shop, e.movie });
                    ++i;
                    if (i == 5) break;
                }
                return result;
            }
        }

        public class Entry
        {
            public int price, shop, movie;
            public Entry(int price, int shop, int movie)
            {
                this.price = price;
                this.shop = shop;
                this.movie = movie;
            }
        }

        public class CustomCompare : IComparer<Entry>
        {
            public int Compare(Entry a, Entry b)
            {
                if (a.price != b.price)
                    return a.price - b.price;
                if (a.shop != b.shop)
                    return a.shop - b.shop;
                return a.movie - b.movie;
            }
        }
        /**
         * Your MovieRentingSystem object will be instantiated and called as such:
         * MovieRentingSystem obj = new MovieRentingSystem(n, entries);
         * IList<int> param_1 = obj.Search(movie);
         * obj.Rent(shop,movie);
         * obj.Drop(shop,movie);
         * IList<IList<int>> param_4 = obj.Report();
         */