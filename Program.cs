using System.Numerics;
using System.Runtime.CompilerServices;

namespace ConsoleApp11111
{
    public class Ratio
    {
        public int numerator;
        public int denominator;
        public Ratio(int numerator, int denominator = 1)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            if (this.denominator == 0)
            {
                throw new DivideByZeroException();
            }
            if (this.numerator < 0 & this.denominator < 0)
            {
                this.numerator = Math.Abs(this.numerator);
                this.denominator = Math.Abs(this.denominator);
            }
            else if (this.denominator < 0)
            {
                this.numerator *= -1;
                this.denominator = Math.Abs(this.denominator);
            }
        }
        public override string ToString()
        {
            if (denominator == 1)
            {
                return $"{numerator}";
            }
            else
            {
                return $"{numerator} / {denominator}";
            }
        }
        public double toDouble()
        {
            return  (double)numerator / denominator;
        }
        public class MyMath
        {
            public static int Evklid(int x, int y)
            {
                x = Math.Abs(x);
                y = Math.Abs(y);
                while (x * y != 0)
                {
                    if (x > y) { x = x % y; }
                    else { y = y % x; }
                }
                return x + y;

            }
        }
        public Ratio Simple_fraction()
        {
            int NOD;
            NOD = MyMath.Evklid(numerator, denominator);
            numerator /= NOD;
            denominator /= NOD;
            return new Ratio(numerator, denominator);
        }
        public static Ratio operator *(Ratio x, Ratio y)
        {
            int N, D;
            Ratio NewR;
            N = x.numerator * y.numerator;
            D = x.denominator * y.denominator;
            NewR = new Ratio(N, D);
            return NewR.Simple_fraction();
        }
        public static Ratio operator *(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x * N;
        }
        public static Ratio operator /(Ratio x, Ratio y)
        {
            int N, D;
            Ratio NewR;
            N = x.numerator * y.denominator;
            D = x.denominator * y.numerator;
            NewR = new Ratio(N, D);
            return NewR.Simple_fraction();
        }
        public static Ratio operator /(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x / N;
        }
        public static Ratio operator -(Ratio x, Ratio y)
        {
            int N, D;
            Ratio NewR;
            N = x.numerator * y.denominator - y.numerator * x.denominator;
            D = x.denominator * y.denominator;
            NewR = new Ratio(N, D);
            return NewR.Simple_fraction();
        }
        public static Ratio operator -(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x - N;
        }
        public static Ratio operator +(Ratio x, Ratio y)
        {
            int N, D;
            Ratio NewR;
            N = x.numerator * y.denominator + y.numerator * x.denominator;
            D = x.denominator * y.denominator;
            NewR = new Ratio(N, D);
            return NewR.Simple_fraction();
        }
        public static Ratio operator +(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x + N;
        }
        public static Ratio operator ++ (Ratio x)
        {
            x.numerator += x.denominator;
            return x.Simple_fraction();
        }
        public static Ratio operator --(Ratio x)
        {
            x.numerator -= x.denominator;
            return x.Simple_fraction();
        }      
        public static bool operator ==(Ratio x, Ratio y)
        {
            return x.numerator * y.denominator == y.numerator * x.denominator;
        }
        public static bool operator ==(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x.numerator * N.denominator == N.numerator * x.denominator;
        }
        public static bool operator !=(Ratio x, Ratio y)
        {
        return x.numerator * y.denominator != y.numerator * x.denominator;
        }
        public static bool operator !=(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x.numerator * N.denominator != N.numerator * x.denominator;
        }
        public static bool operator <(Ratio x, Ratio y)
        {
        return x.numerator * y.denominator < y.numerator * x.denominator;
        }
        public static bool operator <(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x.numerator * N.denominator < N.numerator * x.denominator;
        }
        public static bool operator >(Ratio x, Ratio y)
        {
        return x.numerator * y.denominator > y.numerator * x.denominator;
        }
        public static bool operator >(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x.numerator * N.denominator > N.numerator * x.denominator;
        }
        public static bool operator <=(Ratio x, Ratio y)
        {
        return x.numerator * y.denominator <= y.numerator * x.denominator;
        }
        public static bool operator <=(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x.numerator * N.denominator <= N.numerator * x.denominator;
        }
        public static bool operator >=(Ratio x, Ratio y)
        {
        return x.numerator * y.denominator >= y.numerator * x.denominator;
        }
        public static bool operator >=(Ratio x, int y)
        {
            Ratio N = new Ratio(y);
            return x.numerator * N.denominator >= N.numerator * x.denominator;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var r1 = new Ratio(1, 1);
            var r2 = new Ratio(1, 1);
            Console.WriteLine(r1 < r2);
        }
    }
}
