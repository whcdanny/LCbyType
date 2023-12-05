//Leetcode 1600. Throne Inheritance med
//题意： 描述了一个王国，包括国王、他的子女、孙子等等。王国中定期会发生家庭成员的死亡或新生儿的诞生。    
//王国有一种明确定义的继承顺序，以国王作为第一个成员。题目中定义了递归函数 Successor(x, curOrder)，给定一个人 x 和迄今为止的继承顺序，返回在继承顺序中 x 后面应该是谁。
//ThroneInheritance(string kingName) : 初始化 ThroneInheritance 类的对象。国王的名字作为构造函数的一部分给出。
//void Birth(string parentName, string childName): 表示 parentName 生下了 childName。
//void Death(string name): 表示 name 的死亡。这个人的死亡不影响 Successor 函数或当前的继承顺序。可以将其视为将人标记为已故。
//string[] GetInheritanceOrder(): 返回一个表示当前继承顺序的列表，不包括已故的人。
//思路：使用一个字典 familyTree 来存储家族树，键是每个人的名字，值是他们的子女列表。使用一个集合 deadPeople 来存储已故的人。使用深度优先搜索（DFS）来遍历家族树，获取当前的继承顺序。在 GetInheritanceOrder 方法中调用 DFS，并返回继承顺序
//时间复杂度: O(N + M)，其中 N 是人的数量，M 是继承树中的边的数量
//空间复杂度：O(N + M)，用于存储家族树和已故人的集合
        public class ThroneInheritance
        {

            private Dictionary<string, List<string>> familyTree;
            private HashSet<string> deadPeople;
            private string king;

            public ThroneInheritance(string kingName)
            {
                king = kingName;
                familyTree = new Dictionary<string, List<string>>();
                deadPeople = new HashSet<string>();
            }

            public void Birth(string parentName, string childName)
            {
                if (!familyTree.ContainsKey(parentName))
                {
                    familyTree[parentName] = new List<string>();
                }
                familyTree[parentName].Add(childName);
            }

            public void Death(string name)
            {
                deadPeople.Add(name);
            }

            public IList<string> GetInheritanceOrder()
            {
                List<string> inheritanceOrder = new List<string>();
                DFS_ThroneInheritance(king, inheritanceOrder);
                return inheritanceOrder;
            }

            private void DFS_ThroneInheritance(string person, List<string> order)
            {
                if (!deadPeople.Contains(person))
                {
                    order.Add(person);
                }

                if (familyTree.ContainsKey(person))
                {
                    foreach (var child in familyTree[person])
                    {
                        DFS_ThroneInheritance(child, order);
                    }
                }
            }
        }