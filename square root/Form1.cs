using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//https://chat.openai.com/?model=text-davinci-002-render-sha
//https://plainenglish.io/blog/6-amazing-algorithms-to-get-the-square-root-and-any-root-of-any-number-in-python-3c976ad1ca04

namespace square_root
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    //working
    public static double Newton_Raphson(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double guess = (1 + number) * .5;
        double previousGuess;

        do
        {
            //
            previousGuess = guess;
            guess = (guess + number / guess) *.5;
        } while (Math.Abs(guess - previousGuess) > tolerance);

        return guess;
    }

    //working
    public static double Babylonian(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double guess = number * .5;
        double previousGuess;

        do
        {
            previousGuess = guess;
            guess = 0.5 * (guess + number / guess);
        } while (Math.Abs(guess - previousGuess) > tolerance);

        return guess;
    }

    //working
    public static double Halley(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double x = number; // Initial guess
        int iteration = 0;
        int maxIterations = 5;

        while (iteration < maxIterations)
        {
            double f = x * x - number; // Function f(x) = x^2 - number
            double fPrime = 2 * x; // Derivative of f(x) = 2 * x
            double fDoublePrime = 2; // Second derivative of f(x) = 2

            // Halley's method iteration formula
            double deltaX = -2 * f * fPrime / (2 * fPrime * fPrime - f * fDoublePrime);

            x += deltaX; // Update the guess

            // Check for convergence
            if (Math.Abs(deltaX) < tolerance)
                break;

            iteration++;
        }

        return x;
    }

    //working
    public static double Householder(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double y = number; // Initial guess
        int iteration = 0;
        int maxIterations = 100; // Increase the number of iterations
        double deltaY = 0;

        while (iteration < maxIterations)
        {
            double householderTransform = (y + number / y) * 0.5; // Householder transformation
            deltaY = householderTransform - y; // Change in y

            y = householderTransform; // Update the guess

            // Check for convergence
            if (Math.Abs(deltaY) < tolerance)
                break;

            iteration++;
        }

        return y;
    }

    //working
    public static double Heron(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        //double y = (1 + number) * 0.5; // Initial guess

        double x2 = number * 0.5;
        double y = Math.Abs(y  = number * ( 1.5 - ( x2 * number * number ) ));   // 1st iteration of newton

        int iteration = 0;
        int maxIterations = 100; // Increase the number of iterations

        while (iteration < maxIterations)
        {
            double nextApproximation = (y + number / y) * 0.5; // Heron's formula

            // Check for convergence
            if (Math.Abs(nextApproximation - y) < tolerance)
                break;

            y = nextApproximation; // Update the guess
            iteration++;
        }

        return y;
    }

    //working
    public static double Bakhshali(double number, double tolerance)
    {
        double y = number; // Initial guess
        int iteration = 0;
        int maxIterations = 100; // Increase the number of iterations

        while (iteration < maxIterations)
        {
            double nextApproximation = (y + number / y) * 0.5; // Bakhshali formula

            // Check for convergence
            if (Math.Abs(nextApproximation - y) < tolerance)
                break;

            y = nextApproximation; // Update the guess
            iteration++;
        }

        return y;
    }

    //working
    static double LogSqrt(double x)
    {
        double lnX = Math.Log(x);
        double sqrtX = Math.Exp(0.5 * lnX);
        return sqrtX;
    }

    //working
    public static double Bisection(double number)
    {
        double a = 1.0;
        double b = number * .5;
        double mid = (a + b) * .5;
        double aprox = number - mid * mid;

        while (Math.Abs(b - a) > 0.0001)
        {
            mid = (a + b) * .5;
            double squareMid = mid * mid;
            if (squareMid == number)
            {
                return mid; // Exact square root found
            }
            else if (squareMid < number)
            {
                a = mid;
            }
            else
            {
                b = mid;
            }
        }

        return mid;
    }

    //working
    public static double TaylorSeriesSquareRoot(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double guess = 1.0 + (number - 1.0) * .5;
        double previousGuess;
        do
        {
            previousGuess = guess;
            guess = (guess + number / guess) * .5;

        } while (Math.Abs(guess - previousGuess) > tolerance);

        return guess;
    }

    //working
    public static double MeanSquareRoot(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double guess = number * 0.5; // Initial guess should be a reasonable approximation
        double nextApproximation;

        do
        {
            nextApproximation = 0.5 * (guess + number / guess); // Newton-Raphson formula

            // Check for convergence
            if (Math.Abs(nextApproximation - guess) < tolerance)
                break;

            guess = nextApproximation; // Update the guess

        } while (true);

        return guess;
    }

    //working
    static double SuccessiveApproximation(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double y = number; // Initial guess
        double nextApproximation;

        while (true)
        {
            // Expand (y + x/y)^2 using the binomial theorem
            double expandedExpression = y + number / y;

            // Keep the terms up to the desired precision (usually the first few terms)
            nextApproximation = 0.5 * expandedExpression;

            // Check for convergence
            if (Math.Abs(nextApproximation - y) < tolerance)
                break; // Converged to the desired precision

            y = nextApproximation;
        }
        return nextApproximation; // Converged to the desired precision
    }

    //working
    public static double Approx(double number, double tolerance)
    {
        double guess = 1.0;
        double diff = double.MaxValue;

        if (number < 0)
            number = 0;

        while (diff > tolerance)
        {
            double quotient = number / guess;
            double average = (guess + quotient) / 2;
            diff = Math.Abs(average - guess);
            guess = average;
        }

        return guess;
    }

    //working
    static double BinarySearch(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double low = 0;
        double high = Math.Max(1, number); // The square root will be between 0 and number itself.

        while (high - low > tolerance)
        {
            double mid = (low + high) / 2;
            double square = mid * mid;

            if (square > number)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }

        return (low + high) / 2;
    }

    //working
    static double GoldschmidtSquareRoot(double number, double tolerance)
    {
        if (number < 0)
            number = 0;

        double x = number * .5; // Initial guess
        double nextApproximation;

        while (true)
        {
            nextApproximation = 0.5 * (x + number / x); // Goldschmidt's iteration formula

            // Check for convergence
            if (Math.Abs(nextApproximation - x) < tolerance)
                break;

            x = nextApproximation;
        }
        return nextApproximation; // Converged to the desired precision
    }

    //working
    public static double LucasSequenceSquareRoot(double N, double tolerance)
    {
        double L_n = 2;     // L0
        double L_n_plus_1 = 1;   // L1

        while (Math.Abs(L_n_plus_1 - L_n) >= tolerance)
        {
            L_n = L_n_plus_1;
            L_n_plus_1 = (L_n + N / L_n) / 2;
        }

        return L_n_plus_1;
    }




// wonky
//-------------------------------------------------------
    static double Power(double baseNumber, double exponent)
    {
        if (exponent == 0)
            return 1;

        if (exponent < 0)
        {
            baseNumber = 1 / baseNumber;
            exponent = -exponent;
        }

        double result = 1;
        while (exponent > 0)
        {
            if (exponent % 2 == 1)
            {
                result *= baseNumber;
            }
            baseNumber *= baseNumber;
            exponent /= 2.0; // Fixed: Use 2.0 to ensure correct floating-point division
        }

        return result;
    }

    static double rsqrt(double input)
    {//https://developer.download.nvidia.com/cg/rsqrt.html
        //return Power(input, -0.5);
        double x = 1.0 / input * .5;
        for (int i = 0; i < 10; i++) // You can increase the number of iterations for higher accuracy
        {
            x = 0.5 * (x + input / x);
        }
        return x;
    }

    public static double Nvidia(double number)
    {
        //return 1.0 / rsqrt(number);
        return rsqrt(number);
    }

    public static double InvSqrt(double x)
    {
        long i;
        double x2, y;
        double threehalfsMinusYTimesY;

        x2 = x * 0.5;
        y = x;
        i = BitConverter.DoubleToInt64Bits(y);
        i = 0x5FE6EB50C7B537AAL - (i >> 1);
        y = BitConverter.Int64BitsToDouble(i);
        threehalfsMinusYTimesY = 1.5 - y * y;
        y = y * threehalfsMinusYTimesY; // One Newton-Raphson iteration
        y = y * threehalfsMinusYTimesY; // Another Newton-Raphson iteration

        return y * x;
    }

    //ReciprocalSquareRootApproximation
    public static double ReciprocalSquareRoot(double x)
    {
        double reciprocalSqrt = 1.0 / Math.Sqrt(x);

        // Step 2: Perform more iterations of Newton's method to refine the approximation
        // The more iterations you perform, the more accurate the result will be
        const int iterations = 10; // Increase this value for better accuracy
        for (int i = 0; i < iterations; i++)
        {
            reciprocalSqrt = 0.5 * reciprocalSqrt * (1.5 - x * reciprocalSqrt * reciprocalSqrt);
        }

        // Step 3: Return the reciprocal square root approximation
        return reciprocalSqrt;

    }


//---------------------------------------------//

        private void button1_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = Math.Sqrt((double)numericUpDown1.Value);
            }

            string str = j.ToString(s);
            answer_01.Text = str;

            watch.Stop();

            //answer1Time.Text = watch.ToString();
            answer1Time.Text = watch.ElapsedMilliseconds.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = Newton_Raphson((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_02.Text = str;

            watch.Stop();

            answer2Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = Babylonian((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_03.Text = str;

            watch.Stop();

            //answer1Time.Text = watch.ToString();
            answer3Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = Halley((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_04.Text = str;

            watch.Stop();

            //answer1Time.Text = watch.ToString();
            answer4Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = Householder((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_05.Text = str;

            watch.Stop();

            //answer1Time.Text = watch.ToString();
            answer5Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = Heron((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_06.Text = str;

            watch.Stop();

            //answer1Time.Text = watch.ToString();
            answer6Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = Bakhshali((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_07.Text = str;

            watch.Stop();

            //answer1Time.Text = watch.ToString();
            answer7Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = LogSqrt((double)numericUpDown1.Value);
            }

            string str = j.ToString(s);
            answer_08.Text = str;

            watch.Stop();

            answer8Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = Bisection((double)numericUpDown1.Value);
            }

            string str = j.ToString(s);
            answer_09.Text = str;

            watch.Stop();

            answer9Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = TaylorSeriesSquareRoot((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_10.Text = str;

            watch.Stop();

            answer10Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = MeanSquareRoot((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_11.Text = str;

            watch.Stop();

            answer11Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = SuccessiveApproximation((double)numericUpDown1.Value, 0.0001);
                
            }

            string str = j.ToString(s);
            answer_12.Text = str;

            watch.Stop();

            answer12Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                //j = CordicSquareRoot((double)numericUpDown1.Value, 0.0001);
                j = Approx((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_13.Text = str;

            watch.Stop();

            answer13Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = BinarySearch((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_14.Text = str;

            watch.Stop();

            answer14Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = GoldschmidtSquareRoot((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_15.Text = str;

            watch.Stop();

            answer15Time.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //SteffensenSquareRoot
            double j = 0;

            string s = "N8";// Declaring and initializing format
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                j = LucasSequenceSquareRoot((double)numericUpDown1.Value, 0.0001);
            }

            string str = j.ToString(s);
            answer_16.Text = str;

            watch.Stop();

            answer16Time.Text = watch.ElapsedMilliseconds.ToString();
        }


        


    }
}
