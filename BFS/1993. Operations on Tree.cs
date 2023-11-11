//Leetcode 1993. Operations on Tree med
//题意：给定一棵有n个节点的树，节点编号从0到n-1，用父数组parent表示每个节点的父节点。树的根是节点0，因此parent[0] = -1。设计一个数据结构，支持以下功能：
//Lock： 为给定用户锁定节点，阻止其他用户锁定相同的节点。只有在节点未锁定时才能使用此功能来锁定节点。
//Unlock： 为给定用户解锁节点。只有在节点当前由同一用户锁定时，才能使用此功能解锁节点。
//Upgrade： 为给定用户锁定节点，并解锁其所有后代，无论是谁锁定的。只有在以下三个条件都成立时，才能升级节点：
	//节点未锁定，
	//它至少有一个已被任何用户锁定的后代，
	//它没有已锁定的祖先。
//思路：使用BFS（广度优先搜索）首先，使用一个父数组parent表示每个节点的父节点，用一个字典graph表示树的连接关系，其中键是节点，值是其子节点的列表。使用一个数组locked表示每个节点的锁定状态，初始值为0，表示未锁定。实现Lock、Unlock和Upgrade方法，根据题目要求进行相应的操作。   //时间复杂度: BFS的时间复杂度为O(V + E)，其中V是节点数，E是边数。每个操作都需要访问每个节点，因此总体时间复杂度为O(N + M)，其中N是节点数，M是操作数。
//空间复杂度：O(N)
        public class LockingTree
        {
            int[] parent;
            int[] locked;
            List<int>[] child;
            public LockingTree(int[] parent)
            {
                this.parent = parent;
                this.locked = new int[parent.Length];
                this.child = new List<int>[parent.Length];

                for (int i = 0; i < child.Length; i++)
                {
                    child[i] = new List<int>();
                }

                for (int i = 1; i < parent.Length; i++)
                {
                    child[parent[i]].Add(i);
                }
            }

            public bool Lock(int num, int user)
            {
                if (locked[num] != 0) return false;
                locked[num] = user;
                return true;
            }

            public bool Unlock(int num, int user)
            {
                if (locked[num] != user) return false;
                locked[num] = 0;
                return true;
            }

            public bool Upgrade(int num, int user)
            {
                if (locked[num] != 0) return false;

                int ancestor = parent[num];
                while (ancestor != -1)
                {
                    if (locked[ancestor] != 0)
                    {
                        return false;
                    }
                    ancestor = parent[ancestor];
                }
                if (!hasLockedDescendant(num))
                {
                    return false;
                }
                else
                {
                    unlockAll(num);
                    locked[num] = user;
                    return true;
                }
            }

            public bool hasLockedDescendant(int num)
            {
                foreach (var child in child[num])
                {
                    if (locked[child] != 0 || hasLockedDescendant(child)) return true;
                }
                return false;
            }
           
            private void unlockAll(int num)
            {
                locked[num] = 0;
                foreach (int x in child[num])
                {
                    unlockAll(x);
                }
            }

        }
        /**
         * Your LockingTree object will be instantiated and called as such:
         * LockingTree obj = new LockingTree(parent);
         * bool param_1 = obj.Lock(num,user);
         * bool param_2 = obj.Unlock(num,user);
         * bool param_3 = obj.Upgrade(num,user);
         */