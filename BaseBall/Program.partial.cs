using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBall
{
    partial class Program
    {
        /// <summary>
        /// 환영메시지 출력 (splash screen)
        /// </summary>
        static void ShowWelcomeMessage()
        {
            Console.WriteLine("+-----------------------------------------------------+");
            Console.WriteLine("|                궁극의 숫자 야구 게임                |");
            Console.WriteLine("+-----------------------------------------------------+");
            Console.WriteLine("| 컴퓨터가 수비수가 되어 세 자리 수를 하나 골랐습니다.|");
            Console.WriteLine("| 각 숫자는 0~9 중에 하나며 중복되는 숫자는 없습니다. |");
            Console.WriteLine("| 모든 숫자와 위치를 맞추면 승리합니다.               |");
            Console.WriteLine("| 숫자와 순서가 둘 다 맞으면 스트라이크입니다.        |");
            Console.WriteLine("| 숫자만 맞고 순서가 틀리면 볼입니다.                 |");
            Console.WriteLine("| 숫자가 틀리면 아웃입니다.                           |");
            Console.WriteLine("+-----------------------------------------------------+");
        }

        private static int[] GenerateAnswers()
        {
            Random random = new Random();

            int[] answers = new int[3];
            int index = 0;
            while (index < 3)
            {
                answers[index] = random.Next(0, 10);

                bool hasDuplicate = false;
                for (int j = 0; j < index; j++)
                {
                    if (answers[index] == answers[j])
                    {
                        hasDuplicate = true;
                        break;
                    }
                }

                if (!hasDuplicate)
                {
                    index++;
                }
            }

            return answers;
        }

        private static void InputGuesses(int[] guesses, string[] inputMessages)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(inputMessages[i]);
                guesses[i] = int.Parse(Console.ReadLine());
            }
        }

        private static void ShowGuesses(int[] guesses)
        {
            Console.WriteLine("> 공격수가 고른 숫자");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(guesses[i]);
            }
        }

        private static bool IsInvalidGuesses(int[] guesses)
        {
            return guesses[0] == guesses[1] || guesses[0] == guesses[2] || guesses[1] == guesses[2];
        }

        private static Result CalculateResult(int[] answers, int[] guesses)
        {
            Result result = new Result();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (guesses[i] == answers[j])
                    {
                        if (i == j)
                        {
                            result.Strike++;
                        }
                        else
                        {
                            result.Ball++;
                        }
                    }
                }
            }

            result.Out = 3 - result.Strike - result.Ball;

            return result;
        }

        private static void ShowResult(Result result)
        {
            Console.Write("스트라이크 ");
            Console.WriteLine(result.Strike);
            Console.Write("볼 ");
            Console.WriteLine(result.Ball);
            Console.Write("아웃 ");
            Console.WriteLine(result.Out);
        }
    }
}
