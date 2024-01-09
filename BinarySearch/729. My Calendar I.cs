//Leetcode 729. My Calendar I med
//题意：设计一个日历类 MyCalendar，支持一个方法：
//book(int start, int end) : 在日历中预订一个区间[start, end) 的事件。返回一个布尔值，表示是否可以成功预订。
//要求：如果该事件在日历中没有与之重叠的其他事件，则返回 true。如果有某个事件与之重叠（包括部分重叠或完全重叠），则返回 false。
//思路：二分搜索：有序的列表（比如数组）events 来存储已经预订的事件，每个事件是一个区间 [start, end)。
//对于每次预订，使用 Binary Search 找到插入位置，即找到第一个 start 大于等于新事件的 start 的位置。
//判断插入位置前一个事件和插入位置后一个事件是否与新事件重叠，如果有重叠，则返回 false，表示预订失败。
//如果没有重叠，将新事件插入到 events 中，保持有序性。
//返回 true，表示预订成功。
//时间复杂度: O(log N)，其中 N 是数组的长度。
//空间复杂度：O(1)
        public class MyCalendar
        {

            private List<int[]> events;

            public MyCalendar()
            {
                events = new List<int[]>();
            }

            public bool Book(int start, int end)
            {
                int index = BinarySearch(start);

                // 判断是否与前一个事件重叠
                if (index > 0 && start < events[index - 1][1])
                {
                    return false;
                }

                // 判断是否与后一个事件重叠
                if (index < events.Count && end > events[index][0])
                {
                    return false;
                }

                // 插入新事件
                events.Insert(index, new int[] { start, end });
                return true;
            }

            // 二分查找插入位置
            private int BinarySearch(int target)
            {
                int left = 0, right = events.Count;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (events[mid][0] == target)
                    {
                        return mid;
                    }
                    else if (events[mid][0] < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                return left;
            }
        }
        /**
         * Your MyCalendar object will be instantiated and called as such:
         * MyCalendar obj = new MyCalendar();
         * bool param_1 = obj.Book(start,end);
         */