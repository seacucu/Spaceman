using Microsoft.VisualBasic.FileIO;
using System;
using static System.Console;

namespace Spaceman
{
    internal static class Menu
    {
        // 屬性
        private const string PREFIX = ">";

        private static int SelectedIndex { get; set; } = 0;
        private static string[] Options { get; set; } =
            { "開始", "關於", "退出" };

        // 方法
        public static void Greet()
        {
            string title = @"
       _____                                           
      / ___/____  ____ _________  ____ ___  ____ _____ 
      \__ \/ __ \/ __ `/ ___/ _ \/ __ `__ \/ __ `/ __ \
     ___/ / /_/ / /_/ / /__/  __/ / / / / / /_/ / / / /
    /____/ .___/\__,_/\___/\___/_/ /_/ /_/\__,_/_/ /_/ 
        /_/                                            

    糟糕，外星人入侵地球了！
    那個人有危險了，只有您能救他！！

    遊戲玩法：
    在有限次數內，猜出本次遊戲的正確答案。
    謎底是五個字母的英文單字，您一次只能猜一個字母。

    別忘了，您隨時都可以直接輸入正確答案喔！";
            WriteLine(title);
            WriteLine(Ufo.Stringify());
        }

        private static void DisplayMainMenu()
        {            
            for (int i = 0; i < Options.Length; i++)
            {
                if (i == SelectedIndex)
                {
                    BackgroundColor = ConsoleColor.White;
                    ForegroundColor = ConsoleColor.Black;
                    WriteLine($"{PREFIX} << {Options[i]} >>");
                }
                else
                {
                    BackgroundColor = ConsoleColor.Black;
                    ForegroundColor = ConsoleColor.White;
                    WriteLine($"  << {Options[i]} >>");
                }
            }
            ResetColor();            
        }

        public static int Run()
        {
            ConsoleKey keypressed;
            do
            {
                Clear();
                Greet();
                DisplayMainMenu();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keypressed = keyInfo.Key;

                // 根據方向鍵更新 SelectedIndex
                if (keypressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keypressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex >= Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keypressed != ConsoleKey.Enter) ;
            return SelectedIndex;
        }
    }
}