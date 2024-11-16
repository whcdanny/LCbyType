//Leetcode 2353. Design a Food Rating System med
//题意：设计一个食品评分系统，该系统可以执行以下操作：
//修改系统中列出的食品项目的评分。
//返回系统中某种类型的美食中评分最高的食品项目。
//实现 FoodRatings 类：
//FoodRatings(String[] foods, String[] cuisines, int[] ratings)：初始化系统。食品项目由 foods、cuisines 和 ratings 描述，它们的长度都为 n。
//foods[i] 是第 i 个食品的名称，
//cuisines[i] 是第 i 个食品的美食类型，以及
//ratings[i] 是第 i 个食品的初始评分。
//void changeRating(String food, int newRating)：更改名称为 food 的食品项目的评分。
//String highestRated(String cuisine)：返回给定类型的美食中评分最高的食品项目的名称。如果有多个食品项目的评分相同，则返回字典顺序最小的食品项目。
//思路：PriorityQueue 看code        
//时间复杂度: O(n * log( n))；O(log(n))；O(1)  
//空间复杂度：O(n)；O(n * log(n))；O(1)       
        public class FoodRatings
        {
            //存储食物名称及其对应的菜系。
            private Dictionary<string, string> map;
            //private Dictionary<string, string> foodCuisineMap = new Dictionary<string, string>();            
            //将美食映射到包含食品评级和名称的已排序元组集。 以按评分存储食品项目。
            private Dictionary<string, PriorityQueue<(int r, string f, int t), (int r, string f, int t)>> items;
            //private Dictionary<string, SortedSet<Tuple<int, string>>> cuisineFoodMap = new Dictionary<string, SortedSet<Tuple<int, string>>>();
            //存储食物名称及其评级
            private Dictionary<string, int> time;
            //private Dictionary<string, int> foodRatingMap = new Dictionary<string, int>();
            private int t;

            public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
            {
                this.map = new Dictionary<string, string>();
                this.items = new Dictionary<string, PriorityQueue<(int r, string f, int t), (int r, string f, int t)>>();
                this.time = new Dictionary<string, int>();
                
                int n = foods.Length;
                for (int i = 0; i < n; i++)
                {
                    this.map.Add(foods[i], cuisines[i]);
                    this.time.Add(foods[i], 0);
                    if (this.items.ContainsKey(cuisines[i]) == false)
                    {
                        this.items.Add(cuisines[i], new PriorityQueue<(int r, string f, int t), (int r, string f, int t)>());
                    }
                    this.items[cuisines[i]].Enqueue((-ratings[i], foods[i], 0), (-ratings[i], foods[i], 0));
                }

                this.t = -1;
                /* for (int i = 0; i < foods.Length; ++i)
                    {
                        foodRatingMap[foods[i]] = ratings[i];
                        foodCuisineMap[foods[i]] = cuisines[i];

                        if (!cuisineFoodMap.ContainsKey(cuisines[i]))
                        {
                            cuisineFoodMap[cuisines[i]] = new SortedSet<Tuple<int, string>>(new TupleComparer());
                        }

                        cuisineFoodMap[cuisines[i]].Add(Tuple.Create(-ratings[i], foods[i]));
                    }*/
            }

            public void ChangeRating(string food, int newRating)
            {

                var que = this.items[this.map[food]];
                que.Enqueue((-newRating, food, this.t), (-newRating, food, this.t));

                this.time[food] = this.t;
                this.t--;
                /*string cuisineName = foodCuisineMap[food];
                    SortedSet<Tuple<int, string>> cuisineSet = cuisineFoodMap[cuisineName];

                    cuisineSet.Remove(Tuple.Create(-foodRatingMap[food], food));
                    foodRatingMap[food] = newRating;
                    cuisineSet.Add(Tuple.Create(-newRating, food));*/
            }

            public string HighestRated(string cuisine)
            {
                var que = this.items[cuisine];

                while (que.Count > 0)
                {
                    (int _, string f, int t) = que.Peek();
                    if (this.time[f] != t)
                    {
                        que.Dequeue();
                    }
                    else
                    {
                        return f;
                    }
                }

                return string.Empty;
                /*Tuple<int, string> highestRated = cuisineFoodMap[cuisine].FirstOrDefault();
                    return highestRated != null ? highestRated.Item2 : null;*/
            }            
        }

        /**
         * Your FoodRatings object will be instantiated and called as such:
         * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
         * obj.ChangeRating(food,newRating);
         * string param_2 = obj.HighestRated(cuisine);
         */