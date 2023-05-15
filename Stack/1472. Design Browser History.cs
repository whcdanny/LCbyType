//1472. Design Browser History med
//设计浏览器历史记录的问题
//思路：用两个stack一个存之前输入的网站，一个存之后的网站（这个发生在当我们返回上一个网页的时候）；
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