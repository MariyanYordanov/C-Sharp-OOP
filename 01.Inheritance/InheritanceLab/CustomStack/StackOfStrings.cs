using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        Stack<string> stack = new Stack<string>();
        public bool IsEmpty()
        {
            if (stack.Count == 0 )
            {
                return false;
            }

            return true;
        }

        public void AddRange(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                stack.Push(item);
            }
        }
    }
}
