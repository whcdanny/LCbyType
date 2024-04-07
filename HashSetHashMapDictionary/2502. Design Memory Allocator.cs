//Leetcode 2502. Design Memory Allocator med
//题意：你有一个内存分配器，具有以下功能：
//分配一个大小为 size 的连续内存块，并分配给 id 为 mID。
//释放所有具有给定 mID 的内存单元。
//注意：
//可以将多个块分配给相同的 mID。
//应该释放所有具有 mID 的内存单元，即使它们是在不同的块中分配的。
//实现 Allocator 类：
//Allocator(int n)：初始化一个大小为 n 的内存数组。
//int allocate(int size, int mID)：查找最左边的大小为 size 的连续空闲内存单元块，并将其分配给 id 为 mID。返回块的第一个索引。如果不存在这样的块，则返回 -1。
//int free(int mID)：释放所有具有 mID 的内存单元。返回你已释放的内存单元数。
//思路：hashtable, 我们可以memory借助数组进行建模，然后应用贪婪方法（尽早分配）
//时间复杂度：O(n)
//空间复杂度：O(n)
        public class Allocator
        {
            public int[] memory;

            public Allocator(int n)
            {
                memory = new int[n];
            }

            public int Allocate(int size, int mID)
            {				
                for (int i = 0, current = 0; i < memory.Length; ++i)
					//Free
                    if (memory[i] == 0)
                    {
						//连续空闲内存单元块
                        if (++current == size)
                        {
                            for (int j = 0; j < size; ++j)
                                memory[i - size + j + 1] = mID;

                            return i - size + 1;
                        }
                    }
                    else
                        current = 0;

                return -1;
            }

            public int Free(int mID)
            {
                int result = 0;

                for (int i = memory.Length - 1; i >= 0; --i)
                    if (memory[i] == mID)
                    {
                        memory[i] = 0;

                        ++result;
                    }

                return result;
            }
        }

        /**
         * Your Allocator object will be instantiated and called as such:
         * Allocator obj = new Allocator(n);
         * int param_1 = obj.Allocate(size,mID);
         * int param_2 = obj.Free(mID);
         */