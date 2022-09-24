using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Spaceman
{
    internal class Game
    {
        // 屬性&欄位        
        public int MaxGuesses { get; } = 5;
        public int FailedGuesses { get; private set; } = 0;
        public static string[] AnswerBank { get; } = {
            "SPACE", "SALAD", "STEAM", "BACON", "MAGIC",
            "RIVER", "LUNCH", "SHARE", "WORLD", "TOAST" };
        public string CodeWord { get; } =
            AnswerBank[random.Next(1, AnswerBank.Length)];
        public string CurrentWord { get; private set; } = "_____";
        private string input;
        public string Input {
            get => input;
            private set {
                input =
                    value.All(char.IsLetter) ? value : "";
            }
        }

        public enum Status
            { INITIALED, CORRECT, RECUR, WRONG, INVALID, FULLCORRECT }
        public Status status;

        // 實例化
        private static Random random = new Random();
        public List<string> guessedLetter = new List<string>();

        // 方法
        public void DisplayInfo()
        {
            WriteLine(Ufo.Stringify());
            WriteLine($"\n     嘗試機會：{MaxGuesses - FailedGuesses}");
            Write("     已猜過：");
            foreach (string letter in guessedLetter)
            {
                Write($"{letter} ");
            }
            Write("\n     ");
            Write("\n     目前猜字：");
            foreach (char letter in CurrentWord)
            {
                Write(letter + " ");
            }
            WriteLine($"\n     -.-.-.-.-.-.-.-.-.-.-.-.-");
        }

        public void Ask()
        {
            // 取得使用者輸入
            Write("\n     猜一個字母：");
            Input = Console.ReadLine().ToUpper();

            // 輸入長度正確
            if (Input.Length == 1)
            {
                // 重複輸入
                if (guessedLetter.Contains(Input))
                {
                    status = Status.RECUR;
                }
                // 字母正確
                else if (CodeWord.Contains(Input))
                {
                    status = Status.CORRECT;
                    CurrentWord = UpdateCurrentWord();
                    guessedLetter.Add(Input);
                }
                // 字母錯誤
                else
                {
                    status = Status.WRONG;
                    FailedGuesses++;
                    Ufo.AddPart();
                    guessedLetter.Add(Input);
                }
            }
            // 輸入長度錯誤
            else
            {
                status = (CodeWord.Equals(Input)) ? Status.FULLCORRECT : Status.INVALID;
            }
        }

        private string UpdateCurrentWord()
        {
            // 將CodeWord、CurrentWord 轉成字元陣列
            char hit = Convert.ToChar(Input);
            char[] charCodeWord = CodeWord.ToCharArray();
            char[] charCurrentWord = CurrentWord.ToCharArray();

            // 若 charCodeWord 含有字母，則將該位置的 charCodeWord 字母刪除
            // 並將該位置的 charCurrentWord 改成該字母
            while (charCodeWord.Contains(hit))
            {
                int i = Array.IndexOf(charCodeWord, hit);
                charCurrentWord[i] = hit;
                charCodeWord[i] = '_';
            }
            return new string(charCurrentWord);
        }

        public bool DidWin() =>
            (CodeWord.Equals(CurrentWord) || status == Status.FULLCORRECT);

        public bool DidLose() =>
            FailedGuesses > MaxGuesses;

        /// <summary>
        /// 執行遊戲並判定輸贏。
        /// </summary>
        /// <param name="cheatMode">是否以作弊模式執行</param>
        public void Run(bool cheatMode = false)
        {
            while (true)
            {
                if (cheatMode)
                    WriteLine(CodeWord);

                DisplayInfo();
                switch (status)
                {
                    case Status.CORRECT:
                        WriteLine("\n     太好了，猜中了！"); break;
                    case Status.WRONG:
                        WriteLine("\n     糟糕，猜錯了！"); break;
                    case Status.INVALID:
                        WriteLine("\n     僅限輸入一個英文字母。"); break;
                    case Status.RECUR:
                        WriteLine("\n     您猜過這個字母了。"); break;
                    case Status.INITIALED: break;
                }
                
                Ask();
                if (DidLose())
                {
                    WriteLine($"\n     正確答案是：{CodeWord}");
                    WriteLine("\n     可惡，他被綁架了...");
                    ReadKey(true);
                    break;
                }

                if (DidWin())
                {
                    if (status == Status.FULLCORRECT)
                    {
                        WriteLine("\n     完全正確！您真厲害！");
                    }
                    WriteLine($"\n     正確答案是：{CodeWord}");
                    WriteLine("\n     太棒了，星際救援行動成功！");
                    ReadKey(true);
                    break;
                }
                
                Clear();
            }
        }

        public static void About()
        {
            Menu.Greet();
            WriteLine("     << 本遊戲由 SEACUCU 製作 >>");
            ReadKey(true);
        }
    }
}