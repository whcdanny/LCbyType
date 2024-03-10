//Leetcode 1996. The Number of Weak Characters in the Game med
//题意：给定一个二维整数数组 properties，表示游戏中多个角色的攻击和防御属性。数组中的每个元素 properties[i] = [attacki, defensei] 表示第 i 个角色的属性。
//一个角色被称为“弱角色”，如果存在另一个角色的攻击和防御属性都严格大于这个角色的攻击和防御属性。
//要求返回“弱角色”的数量。
//思路：Stack, 对 properties 按照攻击力进行降序排序，如果攻击力相同，则按照防御力进行升序排序，这样可以保证后面的角色一定不会是前面角色的“弱角色”。
//stack来存储可能是“弱角色”的角色。，当新添加的攻防都小于当前的，count++；       
//时间复杂度：排序的时间复杂度为 O(nlogn)，遍历数组的时间复杂度为 O(n)，总时间复杂度为 O(nlogn)。
//空间复杂度：O(n)
        public int NumberOfWeakCharacters(int[][] properties)
        {
            Array.Sort(properties, (a, b) => {
                if (a[0] == b[0]) return a[1] - b[1]; // 如果攻击力相同，按照防御力升序排列
                return b[0] - a[0]; // 否则按照攻击力降序排列
            });

            Stack<int[]> stack = new Stack<int[]>();
            stack.Push(properties[0]);
            int count = 0;
            for(int i = 1; i < properties.Length; i++)
            {
                if(properties[i][0]<stack.Peek()[0] && properties[i][1] < stack.Peek()[1])
                {
                    count++;
                }
                else
                {
                    stack.Push(properties[i]);
                }
            }

            return count;
        }