using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBall
{
    class Result
    {
        public int Strike;
        public int Ball;
        public int Out;

        public bool IsFinished()
        {
            return Strike == 3;
        }

        public void Calculate(Answer answer, Guess guess)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (guess.Get(i) == answer.Get(j))
                    {
                        if (i == j)
                        {
                            Strike++;
                        }
                        else
                        {
                            Ball++;
                        }
                    }
                }
            }

            Out = 3 - Strike - Ball;
        }

        public void Show()
        {
            Console.Write("스트라이크 ");
            Console.WriteLine(Strike);
            Console.Write("볼 ");
            Console.WriteLine(Ball);
            Console.Write("아웃 ");
            Console.WriteLine(Out);
        }
    }
}
