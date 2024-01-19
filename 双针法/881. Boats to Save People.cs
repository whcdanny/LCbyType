//Leetcode 881. Boats to Save People med
//题意：给定一个数组 people，其中 people[i] 表示第 i 个人的重量。还有无数个船，每艘船的最大载重量为 limit。每艘船最多可以搭载两个人，前提是这两个人的重量之和不超过 limit。
//要求返回搭载所有人所需的最小船数。
//思路：双指针，对人的重量数组 people 进行排序，以方便使用双指针法。
//使用两个指针 left 和 right 分别指向数组的开头和结尾。
//在循环中，判断 people[left] 和 people[right] 的重量之和是否小于等于 limit。
//如果是，说明可以将这两个人放在同一艘船上，移动 left 指针；否则，只能将 people[right] 这个人放在一艘船上，移动 right 指针。
//在每一轮循环中，无论如何都需要移动 right 指针，因为 people[right] 这个人必须要搭载一艘船。
//时间复杂度：遍历一遍数组的时间复杂度为 O(n)，总体时间复杂度为 O(nlogn)。
//空间复杂度：O(1)
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int left = 0, right = people.Length - 1;
            int boats = 0;

            while (left <= right)
            {
                if (people[left] + people[right] <= limit)
                {
                    left++;
                }
                right--;
                boats++;
            }

            return boats;
        }