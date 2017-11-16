using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OOPIntro
{
    class MathUtil
    {
        public static int Sum(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        public static int Substract(int firstNum, int secondNum)
        {
            return firstNum - secondNum;
        }

        public static int Multiply(int firstNum, int secondNum)
        {
            return firstNum * secondNum;
        }
        public static int Divide(int firstNum, int secondNum)
        {
            return firstNum / secondNum;
        }

        public static int Percentage(int total, int percent)
        {
            return MathUtil.Divide(MathUtil.Multiply(total, percent), 100);
        }
    }
}
