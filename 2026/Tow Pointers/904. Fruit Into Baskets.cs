//Leetcode 904. Fruit Into Baskets med
//题意：给一个int[]的水果，然后int[i]数字表示一种水果，根据规则最多能摘多少个水果。
//规则如下
//1. 两个篮子，每个篮子只能放一种水果
//2. 选择一棵树就必须摘果子，然后练习向右摘
//3. 如果不能摘了就停止
//思路：双针法+滑窗，dictionary根据历遍的fruit来存出现个数，却居于Dictionary的个数
//如果<2,说明有空蓝子，如果>2说明现在不能放入篮子，
//有个小技巧，当不能放入的时候，由于求的是最多放入，其实就是最大窗口，所以当我们找到最大窗口的时候，
//就算后面的不满足条件，不缩小窗口，只平移，
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int TotalFruit(int[] fruits)
        {
            int left = 0;
            int res = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int right = 0; right < fruits.Length; right++)
            {                
                if (!map.ContainsKey(fruits[right]))
                    map[fruits[right]] = 0;
                map[fruits[right]]++;
                
                if (map.Count > 2)
                {
                    map[fruits[left]]--;
                    
                    if (map[fruits[left]] == 0)
                    {
                        map.Remove(fruits[left]);
                    }
                    left++; 
                }
                
                res = Math.Max(res, right - left + 1);
            }

            return res;
        }