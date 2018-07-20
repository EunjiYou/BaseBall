using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBall
{
    class Answer
    {
        private int[] _numbers;

        public void Generate()
        {
            Random random = new Random();

            _numbers = new int[3];

            int index = 0;
            while (index < 3)
            {
                _numbers[index] = random.Next(0, 10);

                bool hasDuplicate = false;
                for (int j = 0; j < index; j++)
                {
                    if (_numbers[index] == _numbers[j])
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
        }

        public int Get(int index)
        {
            return _numbers[index];
        }
    }
}
