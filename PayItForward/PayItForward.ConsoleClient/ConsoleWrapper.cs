namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Print(string text)
        {
            Console.Write(text);
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
