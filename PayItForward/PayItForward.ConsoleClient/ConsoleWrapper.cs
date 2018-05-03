using System;
using System.Collections.Generic;
using System.Text;

namespace PayItForward.ConsoleClient
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public void ChangeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public ConsoleColor GetCurrentConsoleColor()
        {
            return Console.ForegroundColor;
        }
    }
}
