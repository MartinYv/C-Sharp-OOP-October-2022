using System;

namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings ();
            stack.Push("asd");
            stack.AddRange("qwe");
        }
    }
}
