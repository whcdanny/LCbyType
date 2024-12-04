//Leetcode 558. Logical OR of Two Binary Grids Represented as Quad-Trees med
//题意：我们有两个 四叉树 (Quad-Tree)，分别表示两个 
//n×n 的二进制矩阵。每个矩阵中的元素值为 0 或 1。
//需要对这两个矩阵执行按位 或运算(Logical OR)，并返回结果矩阵所表示的四叉树。
//四叉树的定义
//每个节点有以下属性：
//val：布尔值，表示当前节点是否为全 1（True）或全 0（False）。
//isLeaf：布尔值，表示当前节点是否为叶子节点。
//如果某个节点是叶子节点，则它没有子节点，且表示一个区域的值（全 1 或全 0）。
//如果某个节点不是叶子节点，它有 4 个子节点，分别表示：
//topLeft：左上角子区域。topRight：右上角子区域。bottomLeft：左下角子区域。bottomRight：右下角子区域。
//运算规则
//如果两个节点都是叶子节点：
//它们的 val 按位或运算(val1 || val2) 生成新节点的 val。
//新节点也是叶子节点。
//如果两个节点中至少有一个不是叶子节点：
//将两棵树的子节点递归进行按位或运算。
//最终节点是否为叶子节点，取决于递归结果的子节点是否全为叶子且值相同。
//思路：递归方法：
//递归遍历两棵树：
//如果当前节点是叶子节点，直接按位或计算 val。
//如果当前节点不是叶子节点，将四个子区域递归进行按位或运算。
//优化节点合并：
//如果某个节点的四个子节点均为叶子节点且值相同，则合并为一个叶子节点。
//时间复杂度：O(n)
//空间复杂度：O(logn)
        public Node Intersect(Node quadTree1, Node quadTree2)
        {
            if (quadTree1.isLeaf)
            {
                if (quadTree1.val)
                {
                    return new Node(true, true, null, null, null, null);
                }
                else
                {
                    return quadTree2;
                }
            }

            if (quadTree2.isLeaf)
            {
                if (quadTree2.val)
                {
                    return new Node(true, true, null, null, null, null);
                }
                else
                {
                    return quadTree1;
                }
            }

            Node topLeft = Intersect(quadTree1.topLeft, quadTree2.topLeft);
            Node topRight = Intersect(quadTree1.topRight, quadTree2.topRight);
            Node bottomLeft = Intersect(quadTree1.bottomLeft, quadTree2.bottomLeft);
            Node bottomRight = Intersect(quadTree1.bottomRight, quadTree2.bottomRight);

            if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf &&
                topLeft.val == topRight.val && topRight.val == bottomLeft.val && bottomLeft.val == bottomRight.val)
            {
                return new Node(topLeft.val, true, null, null, null, null);
            }

            return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
        }