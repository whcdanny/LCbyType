//179. Largest Number med
        //给定一组非负整数，重新排列它们的顺序使之组成一个最大的整数。
        //示例 1:
        //输入: [10,2]
        //输出: "210"
        //思路：转化为字符串之后，比较它们拼接之后的大小,如果a和b拼接后的字符串大于b和a拼接后的字符串，则a排在b的前面，否则b排在a的前面。
        public string LargestNumber(int[] nums)
        {
            //简化版
            string[] strNums = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                strNums[i] = nums[i].ToString();
            }
            Array.Sort(strNums, (a, b) => (b + a).CompareTo(a + b));
            if (strNums[0] == "0") return "0";
            return string.Join("", strNums);

            //if (nums == null || nums.Length == 0)
            //    return "";
            //string[] stringArray = new string[nums.Length];
            //for (int i = 0; i < stringArray.Length; i++)
            //{
            //    stringArray[i] = Convert.ToString(nums[i]);
            //}

            //Array.Sort(stringArray, delegate (string s1, string s2)
            //{ return (s2 + s1).CompareTo(s1 + s2); });

            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < stringArray.Length; i++)
            //{
            //    sb.Append(stringArray[i]);
            //}

            //string ans = sb.ToString();
            //if (ans[0] == '0')
            //    return "0";
            //else
            //    return ans;
        }