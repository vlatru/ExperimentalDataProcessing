using System;
using System.Numerics;
using System.Threading.Tasks;
using System.Linq;

namespace WaveProcessing
{
    public static class FreqFiltering
    {
        /// <summary>
        /// LPF - low-pass filter
        /// Возвращает вейвлет-фильтр для удаления высоких частот
        /// по заданной частоте среза
        /// </summary>
        /// <param name="cutFreq">Частота среза</param>
        /// <param name="mask">Размер вейвлета.
        /// Регулировка плавности среза</param>
        /// <param name="dt">Шаг дискретизации сигнала</param>
        /// <returns>Массив со значениями LPF-фильтра</returns>
        public static double[] LPF(int cutFreq, int mask, double dt)
        {
            // w - result wavelet
            double[] w = new double[2 * mask + 1], d =
             {
                 0.35577019,
                 0.2436983,
                 0.07211497,
                 0.00630165
             }; // magic numbers ;p

            double[] w_tmp = new double[mask + 1];
            double fact = 2 * cutFreq * dt;

            w_tmp[0] = fact;
            fact *= Math.PI;
            for (int i = 1; i <= mask; i++)
                w_tmp[i] = Math.Sin(fact * i) / (Math.PI * i);
            w_tmp[mask] /= 2;

            double sum, sumG = w_tmp[0];
            for (int i = 1; i <= mask; i++)
            {
                sum = d[0];
                fact = Math.PI * i / mask;
                for (int k = 1; k <= 3; k++)
                    sum += 2 * d[k] * Math.Cos(fact * k);
                w_tmp[i] *= sum;
                sumG += 2 * w_tmp[i];
            }

            w[mask] = w_tmp[0];
            for (int i = 1; i < mask; i++)
            { w[mask + i] = w_tmp[i]; w[mask - i] = w_tmp[i]; }
            return w;
        }
        /// <summary>
        /// HPF - high-pass filter
        /// Возвращает вейвлет-фильтр для удаления низких частот
        /// по заданной частоте среза
        /// </summary>
        /// <param name="cutFreq">Частота среза</param>
        /// <param name="mask">Размер вейвлета.
        /// Регулировка плавности среза</param>
        /// <param name="dt">Шаг дискретизации сигнала</param>
        /// <returns>Массив со значениями HPF-фильтра</returns>
        public static double[] HPF(int cutFreq, int mask, double dt)
        {
            double[] w = new double[2 * mask + 1],
                w_tmp = new double[2 * mask + 1];

            w_tmp = LPF(cutFreq, mask, dt);
            for (int i = 0; i < 2 * mask + 1; i++)
                if (i == mask) w[i] = 1 - w_tmp[i];
                else w[i] = -w_tmp[i];
            return w;
        }
        /// <summary>
        /// BPF - band-pass filter
        /// Возвращает вейвлет-фильтр для удаления частот,
        /// НЕ входящих в заданный диапазон частот
        /// от <paramref name="cutFreq1"/> до <paramref name="cutFreq2"/>
        /// </summary>
        /// <param name="cutFreq1">Частота среза слева</param>
        /// <param name="cutFreq2">Частота среза справа</param>
        /// <param name="mask">Размер вейвлета.
        /// Регулировка плавности срезов</param>
        /// <param name="dt">Шаг дискретизации сигнала</param>
        /// <returns>Массив со значениями BPF-фильтра</returns>
        public static double[] BPF(int cutFreq1, int cutFreq2, int mask, double dt)
        {
            double[] w = new double[2 * mask + 1],
                w_tmp1 = new double[2 * mask + 1],
                w_tmp2 = new double[2 * mask + 1];
            w_tmp1 = LPF(cutFreq1, mask, dt);
            w_tmp2 = LPF(cutFreq2, mask, dt);
            for (int i = 0; i < 2 * mask + 1; i++)
                w[i] = w_tmp2[i] - w_tmp1[i];
            return w;

        }
        /// <summary>
        /// BRF - band-reject filter
        /// Возвращает вейвлет-фильтр для удаления частот,
        /// ВХОДЯЩИХ в заданный диапазон частот
        /// от <paramref name="cutFreq1"/> до <paramref name="cutFreq2"/>
        /// </summary>
        /// <param name="cutFreq1">Частота среза слева</param>
        /// <param name="cutFreq2">Частота среза справа</param>
        /// <param name="mask">Размер вейвлета.
        /// Регулировка плавности срезов</param>
        /// <param name="dt">Шаг дискретизации сигнала</param>
        /// <returns>Массив со значениями BRF-фильтра</returns>
        public static double[] BRF(int cutFreq1, int cutFreq2, int mask, double dt)
        {
            double[] w = new double[2 * mask + 1],
                w_tmp1 = new double[2 * mask + 1],
                w_tmp2 = new double[2 * mask + 1];
            w_tmp1 = LPF(cutFreq1, mask, dt);
            w_tmp2 = LPF(cutFreq2, mask, dt);
            for (int i = 0; i < 2 * mask + 1; i++)
                if (i == mask) w[i] = 1 + w_tmp1[i] - w_tmp2[i];
                else w[i] = w_tmp1[i] - w_tmp2[i];
            return w;
        }

        /// <summary>
        /// Возвращает спектр сигнала в области действительных чисел
        /// </summary>
        /// <param name="y">Массив значений сигнала</param>
        /// <param name="freq">Предельная частота сигнала</param>
        /// <param name="forInverse">Необязательный: Фурье-спектр сигнала</param>
        /// <returns>Массив со значениями спектра сигнала</returns>
        public static double[] DirectFourierDouble(double[] y, int freq, Complex[] forInverse = null)
        {
            double[] res = new double[freq / 2];
            if (forInverse == null)
                forInverse = DirectFourier(y, freq);

            Parallel.For(0, freq / 2, k => //  + 1
            //for (int k = 0; k < f / 2; k++)
            {
                res[k] = Math.Pow(Math.Pow(forInverse[k].Real, 2) + Math.Pow(forInverse[k].Imaginary, 2), 0.5);
            }
            );
            return res;
        }
        /// <summary>
        /// Возвращает комплексный Фурье-спектр сигнала
        /// </summary>
        /// <param name="y">Массив значений сигнала</param>
        /// <param name="freq">Предельная частота сигнала</param>
        /// <returns>Массив со значениями Фурье-спектра</returns>
        public static Complex[] DirectFourier(double[] y, int freq)
        {
            Complex[] res = new Complex[freq / 2];

            Parallel.For(0, freq / 2, k => //  + 1
            //for (int k = 0; k < f / 2; k++)
            {
                for (int i = 0; i < y.Length; i++)
                {
                    res[k] += new Complex(y[i] * Math.Cos(2 * Math.PI * k * i / freq),
                        y[i] * Math.Sin(2 * Math.PI * k * i / freq));
                }
                res[k] /= freq;
            }
            );
            return res;
        }
        /// <summary>
        /// Воостановление значений сигнала из комплексного Фурье-спектра
        /// </summary>
        /// <param name="Y">Массив значений комплексного Фурье-спектра</param>
        /// <param name="len">Длина массива значений сигнала</param>
        /// <returns>Массив со значениями воостановленного сигнала</returns>
        public static double[] InverseFourier(Complex[] Y, int len)
        {
            double[] x = new double[Y.Length];
            Complex[] c = new Complex[len];

            Parallel.For(0, len, i =>
            //for (int i = 0; i < len; i++)
            {
                for (int k = 0; k < len / 2 + 1; k++)
                {
                    double tmp;
                    if (k == 0)
                        tmp = c[0].Real / len;
                    else if (k == (len / 2))
                        tmp = c[len / 2].Real / len;
                    else
                        tmp = (Y[k].Real / (len / 2)) * Math.Cos(2 * Math.PI * i * k / len);
                    c[i] += new Complex(tmp, (Y[k].Imaginary / (len / 2)) * Math.Sin(2 * Math.PI * i * k / len));
                }
                x[i] = (c[i].Real + c[i].Imaginary) * len;
            }
            );
            return x;
        }
        //// stack overflow :(
        //// TODO: Реализовать не рекурсивный алгоритм БПФ | увеличить размер стека
        //double[] FastDirectFourier(double[] y)
        //{
        //    Complex[] fft_res = FFT.fft(GetComplexFromDouble(y));
        //    return GetDoubleFromComplex(fft_res);
        //}
        //Complex[] GetComplexFromDouble(double[] y)
        //{
        //    Complex[] x = new Complex[y.Length];
        //    for (int i = 0; i < x.Length; i++)
        //        x[i] = new Complex(y[i], 0);
        //    return x;
        //}
        //double[] GetDoubleFromComplex(Complex[] c)
        //{
        //    double[] x = new double[c.Length];
        //    for (int i = 0; i < c.Length; i++)
        //        x[i] = (c[i].Real + c[i].Imaginary) * c.Length;
        //    return x;
        //}

        /// <summary>
        /// Свертка фильтра с сигналом. В общем случае, свертка двух любых функций f(x) и g(x)
        /// </summary>
        /// <param name="y">Массив значений сигнала</param>
        /// <param name="filter">Массив значений вейвлет-фильтра</param>
        /// <returns>Преобразованный массив значений сигнала</returns>
        public static double[] Convolution(double[] y, double[] filter)
        {
            int filterLen = filter.Length,
                yLen = y.Length,
                resLen = yLen + filterLen - 1;
            if (filterLen > yLen) Helper.Swap(filterLen, yLen);
            double[] res = new double[resLen];
            //double[] tmp = new double[resLen];

            //Parallel.For(0, yLen, i =>
            for (int i = 0; i < yLen; i++)
            {
                for (int p = 0; p < filterLen; p++)
                    //lock ("w")
                    res[i + p] += filter[p] * y[i];
            }
            //);

            //res = tmp.Skip(filterLen / 2).Take(yLen).ToArray();
            //for (int i = 0; i < filterLen / 2; i++)
            //{
            //    res[i] -= tmp[filterLen / 2 - 1 - i];
            //    res[yLen - 1 - i] -= tmp[resLen - (filterLen / 2) + i];
            //}
            return res.Skip(filterLen / 2).Take(yLen).ToArray();
        }
        
    }

}
