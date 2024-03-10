//Leetcode 2296. Design a Text Editor hard
//题意：设计一个带有光标的文本编辑器，光标可以执行以下操作：
//在光标当前位置添加文本。
//删除光标当前位置的文本（模拟退格键）。
//将光标向左或向右移动。
//当删除文本时，只有光标左侧的字符将被删除。光标也必须保持在实际文本范围内，并且不能移动到文本范围之外。
//更正式地说，我们有0 <= cursor.position <= currentText.length。
//实现TextEditor类：
//TextEditor()：用空文本初始化对象。
//void addText(string text)：将文本追加到光标的位置。光标位于文本的右侧。
//int deleteText(int k)：删除光标左侧的k个字符。返回实际删除的字符数。
//string cursorLeft(int k)：将光标向左移动k次。返回光标左侧的最后min(10, len)个字符，其中len是光标左侧的字符数。
//string cursorRight(int k)：将光标向右移动k次。返回光标左侧的最后min(10, len)个字符，其中len是光标左侧的字符数。
//思路：Stack, 使用两个栈，一个用于存储光标左侧的字符，另一个用于存储光标右侧的字符。
//当执行addText操作时，将新文本追加到光标left侧的栈中。
//当执行deleteText操作时，从光标左侧的栈中弹出k个字符，并返回实际删除的字符数。
//当执行cursorLeft操作时，将光标左侧的栈中的字符依次弹出，并压入光标右侧的栈中，直到达到k次移动或栈为空。
//然后输出此时left还有，并且最多10个位置，记得要反转；
//当执行cursorRight操作时，将光标右侧的栈中的字符依次弹出，并压入光标左侧的栈中，直到达到k次移动或栈为空。
//然后输出此时left还有，并且最多10个位置，记得要反转；
//时间复杂度：每个操作的时间复杂度为O(k)，其中k是要删除的字符数或移动的次数
//空间复杂度：用了两个栈来存储文本，因此空间复杂度为O(n)，其中n是文本的长度。
        public class TextEditor
        {
            Stack<char> left;
            Stack<char> right;
            public TextEditor()
            {
                left = new Stack<char>();
                right = new Stack<char>();
            }

            public void AddText(string text)
            {
                for(int i = 0; i < text.Length; i++)
                {
                    left.Push(text[i]);
                }
            }

            public int DeleteText(int k)
            {
                int res = 0;
                while (left.Count > 0 && k-- > 0)
                {
                    left.Pop();
                    res++;
                }
                return res; ;
            }

            public string CursorLeft(int k)
            {
                while (left.Count > 0 && k-- > 0)
                {
                    right.Push(left.Pop());                
                }
                return getLeftString();
            }
            
            public string CursorRight(int k)
            {
                while (right.Count > 0 && k-- > 0)
                {
                    left.Push(right.Pop());
                }
                return getLeftString();
            }

            private string getLeftString()
            {
                int count = 10;
                StringBuilder sb = new StringBuilder();
                while (left.Count > 0 && count-- > 0)
                {
                    sb.Append(left.Pop());
                }
                StringBuilder res = new StringBuilder();
                for(int i = sb.Length-1; i >= 0; i--)
                {
                    left.Push(sb[i]);
                    res.Append(sb[i]);
                }
                return res.ToString();
            }

        }

        /**
         * Your TextEditor object will be instantiated and called as such:
         * TextEditor obj = new TextEditor();
         * obj.AddText(text);
         * int param_2 = obj.DeleteText(k);
         * string param_3 = obj.CursorLeft(k);
         * string param_4 = obj.CursorRight(k);
         */