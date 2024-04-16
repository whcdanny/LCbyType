//Leetcode 2094. Finding 3-Digit Even Numbers ez
//题意：给定一个整数数组 digits，每个元素是一个数字。数组可能包含重复元素。
//需要找到满足以下条件的所有唯一整数：
//整数由 digits 中任意三个元素拼接而成，顺序任意。
//整数不以零开头。整数是偶数。
//例如，如果给定的 digits 是[1, 2, 3]，则整数 132 和 312 符合条件。
//要求：返回满足条件的唯一整数的排序数组。
//思路：hashtable 因为给了条件3 <= digits.length <= 100 0 <= digits[i] <= 9
//开头不为0，所以我们只需要从100找到999，然后有多少在digits里
//找出个十百每个位置的数，然后查看是否在digits里，那么就可以算找到一个答案，然后依此找到所有；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int[] FindEvenNumbers(int[] digits)
        {
            List<int> result = new List<int>();

            for (int num = 100; num < 999; num += 2)
            {
                //get 3 digits..
                int one = num % 10;
                int ten = (num / 10) % 10;
                int hun = num / 100;

                //to check if 3 digits found..
                bool oneBool = false;
                bool tenBool = false;
                bool hunBool = false;

                for (int i = 0; i < digits.Length; i++)
                {
                    if (!oneBool && one == digits[i])
                    {
                        oneBool = true;
                    }
                    else if (!tenBool && ten == digits[i])
                    {
                        tenBool = true;
                    }
                    else if (!hunBool && hun == digits[i])
                    {
                        hunBool = true;
                    }

                    //if all digits are found..
                    if (oneBool && tenBool && hunBool)
                    {
                        result.Add(num);
                        break;
                    }
                }
            }

            return result.ToArray();
        }