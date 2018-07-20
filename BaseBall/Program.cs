using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBall
{
    class Program
    {
        static void Main(string[] args)
        {
            // 환영메시지 출력 (splash screen)
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


            // 랜덤한 정답을 생성한다.
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


            // 추측을 입력하라는 메시지를 출력한다.
            int[] guesses = new int[3];
            string[] inputMessages = { "> 첫 번째 숫자를 입력하세요.", "> 두 번째 숫자를 입력하세요.", "> 세 번째 숫자를 입력하세요." };

            while (true)
            {
                // 추측을 입력받는다
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(inputMessages[i]);
                    guesses[i] = int.Parse(Console.ReadLine());
                }

                
                // 입력받은 추측을 출력한다.
                Console.WriteLine("> 공격수가 고른 숫자");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(guesses[i]);
                }


                // 추측의 유효성을 검사한다.
                if (guesses[0] == guesses[1] || guesses[0] == guesses[2] || guesses[1] == guesses[2])
                {
                    Console.WriteLine("같은 숫자를 입력하면 안 됩니다.");
                    continue;
                }


                // 결과를 계산한다.
                int strikeCount = 0;
                int ballCount = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (guesses[i] == answers[j])
                        {
                            if (i == j)
                            {
                                strikeCount++;
                            }
                            else
                            {
                                ballCount++;
                            }
                        }
                    }
                }


                // 결과를 출력한다.
                Console.Write("스트라이크 ");
                Console.WriteLine(strikeCount);
                Console.Write("볼 ");
                Console.WriteLine(ballCount);
                Console.Write("아웃 ");
                Console.WriteLine(3 - strikeCount - ballCount);


                // 정답이면 게임을 끝낸다
                if (strikeCount == 3)
                {
                    Console.WriteLine("정답입니다!");
                    break;
                }
            }
        }
    }
}
