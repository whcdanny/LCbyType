//344. Reverse String ez
//反转一个string的数组
//左右针 然后相互交换
public void ReverseString(char[] s)
            {
                // 一左一右两个指针相向而行
                int left = 0, right = s.Length - 1;
                while (left < right)
                {
                    // 交换 s[left] 和 s[right]
                    char temp = s[left];
                    s[left] = s[right];
                    s[right] = temp;
                    left++;
                    right--;
                }
            }