using System;

namespace PayItForward.ConsoleClient
{
    public interface IConsoleWrapper
    {
        void Print(string text);

        void ChangeColor(ConsoleColor color);

        ConsoleColor GetCurrentConsoleColor();
    }
}
