using System;
using System.IO;

namespace WaveProcessing
{
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public Complex(Complex c)
        {
            if (c != null)
            { Real = c.Real; Imaginary = c.Imaginary; }
            else c = new Complex();
        }
        public Complex() { Real = 0; Imaginary = 0; }
        public Complex(double x) { Real = x; Imaginary = 0; }
        public Complex(double x, double y) { Real = x; Imaginary = y; }
        public static Complex operator +(Complex с1, Complex с2)
        { return new Complex(с1.Real + с2.Real, с1.Imaginary + с2.Imaginary); }
        public static Complex operator -(Complex с1, Complex с2)
        { return new Complex(с1.Real - с2.Real, с1.Imaginary - с2.Imaginary); }
        public static Complex operator *(Complex с1, Complex с2)
        {
            return new Complex(с1.Real * с2.Real - с1.Imaginary * с2.Imaginary,
            с1.Imaginary * с2.Real + с1.Real * с2.Imaginary);
        }
        public static Complex operator /(Complex с1, Complex с2)
        {
            double tmp = с2.Real * с2.Real + с2.Imaginary * с2.Imaginary;
            return new Complex((с1.Real * с2.Real + с1.Imaginary * с2.Imaginary) / tmp,
            (с1.Imaginary * с2.Real - с1.Real * с2.Imaginary) / tmp);
        }
        public static Complex operator +(Complex с, double num)
        { return new Complex(с.Real + num, с.Imaginary + num); }
        public static Complex operator -(Complex с, double num)
        { return new Complex(с.Real - num, с.Imaginary - num); }
        public static Complex operator *(Complex с, double num)
        { return new Complex(с.Real * num, с.Imaginary * num); }
        public static Complex operator /(Complex с, double num)
        { return new Complex(с.Real / num, с.Imaginary / num); }        
        public override string ToString()
        { return (String.Format("{0} + {1}i", Real, Imaginary)); }
    }
}
