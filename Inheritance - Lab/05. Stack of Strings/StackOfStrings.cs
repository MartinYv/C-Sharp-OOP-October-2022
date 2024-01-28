using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
   public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            bool isEmpty = this.IsEmpty();
            return isEmpty;
        }
        public Stack<string> AddRange(string str)
        {
            this.Push(str);
            return this;
        }
    }
}
