using System;
using static System.Console;
using static Spaceman.Game;

namespace Spaceman
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SetWindowSize(60, 40);            
            int choice = 0;
            while (choice != 2)
            {
                // 畫出主選單
                choice = Menu.Run();
                Clear();

                // 根據使用者輸入做動作
                if (choice == 0)
                {
                    Game game = new Game();
                    game.Run(true);
                }
                else if (choice == 1)
                {
                    Game.About();
                }
            }
        }
    }
}