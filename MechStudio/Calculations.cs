using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechStudio
{
    class Calculations
    {
        public int pas { get; set; }
        public double i { get; set; }
        public double Ki { get; set; }
        public double Ip { get; set; }
        public double Kl { get; set; }
        public double Kt { get; set; }
        public int Dp1 { get; set; }
        public int Dp2 { get; set; }
        public int Lp { get; set; }
        public double n1 { get; set; }
        public double KFi { get; set; }
        public int godz { get; set; }
        public int obc { get; set; }
        public int silnik { get; set; }
        public double N { get; set; }
        public double Nkm { get; set; }
        public double Zr { get; set; }

        public void Iskor() { Ip = Math.Round( (double)(Dp2)/ Dp1 , 2); }
        public double Amin() { return ((double)(Dp1 + Dp2)) / 2; }
        public double Amax() { return 2 * ((double)(Dp1 + Dp2)); }
        public double ACalc() { return Math.Round((Amin() + Amax()) / 2); }
        public double Lmin() { return Math.Round(2 * ACalc() + Math.PI / 2 * (Dp1 + Dp2) + 1 / (4 * ACalc()) * (Dp1 - Dp2) * (Dp1 - Dp2), 2); }
        public double AReal() { return Math.Round(ACalc() + (Lp - Lmin()) / 2, 2); }
        public double Fi() { return Math.Round(180 - (Dp2 - Dp1) / AReal() * 57.3, 1); }
        public double De() { return Math.Round(Ki * (double)Dp1, 2); }
        public double V() { return Math.Round(Math.PI * (double)Dp1 * n1 / 60000, 2); }
        public double Zt() { return Math.Round((Nkm * Kt) / (N1() * KFi * Kl), 2); } // teoretyczna liczba pasów

        public void SetKi() // współczynnik przełożenia
        {
            if ((Ip <= 0.55) || (Ip >= 1.80))
                Ki = 1.15;
            else if ((Ip >= 0.56 && Ip <= 0.83) || (Ip >= 1.21 && Ip <= 1.80))
                Ki = 1.10;
            else if ((Ip >= 0.84 && Ip <= 0.95) || (Ip >= 1.06 && Ip <= 1.20))
                Ki = 1.05;
            else if ((Ip >= 0.96) && (Ip <= 1.05))
                Ki = 1.00;
        }
        

        public double N1() //moc przenoszona przez jeden pas
        {
            if (pas == 1)
            {
                    return Math.Round((0.34 * Math.Pow(V(), -0.09) - 10.0 / De() * (-0.638) * 10e-4 * V() * V()) * V(), 2);
             
            }
            else if (pas == 2)
            {
                    return Math.Round((0.61 * Math.Pow(V(), -0.09) - 26.68 / De() * (-1.04) * 10e-4 * V() * V()) * V(), 2);
      
            }
            else if (pas == 3)
            {
                    return Math.Round((1.08 * Math.Pow(V(), -0.09) - 69.80 / De() * (-1.78) * 10e-4 * V() * V()) * V(), 2);
              
            }
            else if (pas == 4)
            {
                    return Math.Round((2.01 * Math.Pow(V(), -0.09) - 194.8 / De() * (-3.18) * 10e-4 * V() * V()) * V(), 2);
            }
            else if (pas == 5)
            {
                    return Math.Round((4.29 * Math.Pow(V(), -0.09) - 690 / De() * (-6.48) * 10e-4 * V() * V()) * V(), 2);
            }
            else if (pas == 6)
            {
            
                    return Math.Round((6.22 * Math.Pow(V(), -0.09) - 1294 / De() * (-9.59) * 10e-4 * V() * V()) * V(), 2);
            }
            else
                return 0;
        }

    
        public void DiameterDp1 (int[] tab)
        {

            int l = tab.Length;
            if (Dp1 > tab[l - 1])
            {
                Dp1 = tab[l - 1];
            }
            else
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    if (Dp1 <= tab[0])
                    {
                        Dp1 = tab[0];
                    }
                    else if (Dp1 == tab[i])
                    {
                        Dp1 = tab[i];
                    }
                    else if (Dp1 != tab[i] && Dp1 < tab[i] && Dp1 > tab[i - 1])
                    {
                        Dp1 = tab[i];
                    }
                }
            }

        }

        public void DiameterDp2(int[] tab)
        {

            int l = tab.Length;
            if (Dp2 > tab[l - 1])
            {
                Dp2 = tab[l - 1];
            }
            else
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    if (Dp2 <= tab[0])
                    {
                        Dp2 = tab[0];
                    }
                    else if (Dp2 == tab[i])
                    {
                        Dp2 = tab[i];
                    }
                    else if (Dp2 != tab[i] && Dp2 < tab[i] && Dp2 > tab[i - 1])
                    {
                        Dp2 = tab[i];
                    }
                }
            }

        }

        public void SetLp(int[] tab)
        {

            int l = tab.Length;
            if (Lmin() > tab[l - 1])
            {
                Lp = tab[l - 1];
            }
            else
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    if (Lmin() <= tab[0])
                    {
                        Lp = tab[0];
                    }
                    else if (Lmin() == tab[i])
                    {
                        Lp = tab[i];
                    }
                    else if (Lmin() != tab[i] && Lmin() < tab[i] && Lmin() > tab[i - 1])
                    {
                        Lp = tab[i];
                    }
                }
            }

        }
        
        public void SetKFi(double[] tab1, double[] tab2) // Wspolczynnik Kfi
        {

            int l = tab1.Length;
            if (Fi() < tab1[l - 1])
                KFi = tab2[l - 1];

            for (int i = 0; i < l; i++)
            {

                if (Fi() < tab1[i] && Fi() > tab1[i + 1])
                {
                    double dif1 = Math.Abs(Fi() - tab1[i]);
                    double dif2 = Math.Abs(Fi() - tab1[i + 1]);
                    if (dif1 < dif2)
                        KFi = tab2[i];
                    else
                        KFi = tab2[i + 1];
                }
            }
        }

        public void SetKl(int[] tab1, double[] tab2)
        {
            int size = tab1.Length;
            for (int i = 0; i < size; i++)
            {
                if (Lp == tab1[i])
                    Kl = tab2[i];
            }
        }
        


        public void SetKt()
        {
            if (silnik == 1)
            {
                if (obc == 1)
                {
                    if (godz == 1) Kt = 1.0;
                    else if (godz == 2) Kt = 1.1;
                    else if (godz == 3) Kt = 1.2;
                    else Kt = 0;
                }
                else if (obc == 2)
                {
                    if (godz == 1) Kt = 1.1;
                    else if (godz == 2) Kt = 1.2;
                    else if (godz == 3) Kt = 1.3;
                    else Kt = 0;
                }
                else if (obc == 3)
                {
                    if (godz == 1) Kt = 1.2;
                    else if (godz == 2) Kt = 1.3;
                    else if (godz == 3) Kt = 1.4;
                    else Kt = 0;
                }
                else if (obc == 4)
                {
                    if (godz == 1) Kt = 1.3;
                    else if (godz == 2) Kt = 1.4;
                    else if (godz == 3) Kt = 1.5;
                    else Kt = 0;
                }
                else Kt = 0;
            }
            else if (silnik == 2)
            {
                if (obc == 1)
                {
                    if (godz == 1) Kt = 1.1;
                    else if (godz == 2) Kt = 1.2;
                    else if (godz == 3) Kt = 1.3;
                    else Kt = 0;
                }
                else if (obc == 2)
                {
                    if (godz == 1) Kt = 1.2;
                    else if (godz == 2) Kt = 1.3;
                    else if (godz == 3) Kt = 1.4;
                    else Kt = 0;
                }
                else if (obc == 3)
                {
                    if (godz == 1) Kt = 1.3;
                    else if (godz == 2) Kt = 1.4;
                    else if (godz == 3) Kt = 1.5;
                    else Kt = 0;
                }
                else if (obc == 4)
                {
                    if (godz == 1) Kt = 1.4;
                    else if (godz == 2) Kt = 1.5;
                    else if (godz == 3) Kt = 1.6;
                    else Kt = 0;
                }
                else Kt = 0;
            }
            else if (silnik == 3)
            {
                if (obc == 1)
                {
                    if (godz == 1) Kt = 1.2;
                    else if (godz == 2) Kt = 1.3;
                    else if (godz == 3) Kt = 1.4;
                    else Kt = 0;
                }
                else if (obc == 2)
                {
                    if (godz == 1) Kt = 1.3;
                    else if (godz == 2) Kt = 1.4;
                    else if (godz == 3) Kt = 1.5;
                    else Kt = 0;
                }
                else if (obc == 3)
                {
                    if (godz == 1) Kt = 1.4;
                    else if (godz == 2) Kt = 1.5;
                    else if (godz == 3) Kt = 1.6;
                    else Kt = 0;
                }
                else if (obc == 4)
                {
                    if (godz == 1) Kt = 1.5;
                    else if (godz == 2) Kt = 1.6;
                    else if (godz == 3) Kt = 1.8;
                    else Kt = 0;
                }
                else Kt = 0;
            }

        }
        

        }
        
    }


