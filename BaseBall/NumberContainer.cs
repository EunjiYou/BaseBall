using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBall
{
    abstract class NumberContainer
    {
        protected int[] _numbers;

        public int Get(int index)
        {
            return _numbers[index];
        }

        protected abstract string GetShowText();
                
        public void Show()
        {
            Console.WriteLine(GetShowText());
            
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(_numbers[i]);
            }
        }
    }
}
