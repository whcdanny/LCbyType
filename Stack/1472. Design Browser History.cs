//Leetcode 1472. Design Browser History mid
//题意：题意是设计一个浏览器历史记录功能，要求实现以下几个功能：
//BrowserHistory(string homepage) : 构造函数，输入起始页的 URL。
//void Visit(string url): 访问一个新的 URL，会将当前页面的所有历史记录清空，然后添加新的 URL。
//string Back(int steps): 回退到前面的页面，steps 表示回退的步数。如果步数大于当前历史记录的数量，那么就回退到起始页。
//string Forward(int steps): 前进到后面的页面，steps 表示前进的步数。如果步数大于当前可以前进的页面数量，那么就前进到最后一页。
//思路：两个栈来实现这个功能，一个栈用来记录访问的历史记录（backStack），另一个栈用来记录回退的历史记录（forwardStack）。Visit: 每当访问一个新的页面，就将当前页面入栈到 backStack 中，同时清空 forwardStack。Back: 每当需要回退时，就将 backStack 栈顶的页面弹出，并入栈到 forwardStack 中，返回回退后的页面。Forward: 每当需要前进时，就将 forwardStack 栈顶的页面弹出，并入栈到 backStack 中，返回前进后的页面。
//时间复杂度：Visit: O(1); Back: O(1); Forward: O(1)
//空间复杂度：backStack 和 forwardStack 的最大空间为浏览的页面数量，O(n)
        public class BrowserHistory
        {
            private Stack<string> backStack;
            private Stack<string> forwardStack;
            private string currentPage;

            public BrowserHistory(string homepage)
            {
                backStack = new Stack<string>();
                forwardStack = new Stack<string>();
                currentPage = homepage;
            }

            public void Visit(string url)
            {
                backStack.Push(currentPage);
                forwardStack.Clear();
                currentPage = url;
            }

            public string Back(int steps)
            {
                while (steps > 0 && backStack.Count > 0)
                {
                    forwardStack.Push(currentPage);
                    currentPage = backStack.Pop();
                    steps--;
                }
                return currentPage;
            }

            public string Forward(int steps)
            {
                while (steps > 0 && forwardStack.Count > 0)
                {
                    backStack.Push(currentPage);
                    currentPage = forwardStack.Pop();
                    steps--;
                }
                return currentPage;
            }
        }