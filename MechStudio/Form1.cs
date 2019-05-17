using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechStudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
            
        Calculations CalcObject = new Calculations();
        Opissilnika os = new Opissilnika();
        NormArrays NormValues = new NormArrays();
        
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            int id = comboBox1.SelectedIndex;
            switch (id)
            {
                case 0: CalcObject.pas = 1; break;
                case 1: CalcObject.pas = 2; break;
                case 2: CalcObject.pas = 3; break;
                case 3: CalcObject.pas = 4; break;
                case 4: CalcObject.pas = 5; break;
                case 5: CalcObject.pas = 6; break;
                default: break;
            }

        }

       
     
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id2 = comboBox4.SelectedIndex;
          
            switch (id2)
            {
                case 0: CalcObject.obc = 1; break;
                case 1: CalcObject.obc = 2; break;
                case 2: CalcObject.obc = 3; break;
                case 3: CalcObject.obc = 4; break;
                default: break;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id2 = comboBox5.SelectedIndex;

            switch (id2)
            {
                case 0: CalcObject.godz = 1; break;
                case 1: CalcObject.godz = 2; break;
                case 2: CalcObject.godz = 3; break;
                default: break;
            }

        }
        
        
        private void textBox20_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                CalcObject.i = Convert.ToDouble(textBox20.Text);
            }
            catch
            {
                textBox22.Text = "Wpisz poprawną wartość przełożenia !";
            }

            if(CalcObject.i<0)
                textBox22.Text = "Wpisz poprawną wartość przełożenia, większą od 0 !";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcObject.Dp1 = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                textBox22.Text = "Wpisz poprawną wartość !";
            }

            if (CalcObject.Dp1 < 0)
            {
                textBox22.Text = "Wpisz poprawną wartość,większą od zera !";
            }

            switch (CalcObject.pas)
            {
                case 1:
                    if (CalcObject.Dp1 < NormValues.DpZ[0])
                        textBox22.Text = "Minimalna średnica skuteczna dla paska Z wynosi 63 mm !";
                    if (CalcObject.Dp1 > NormValues.DpZ[NormValues.DpZ.Length - 1])
                    {
                        textBox22.Text = "Maksymalna średnica skuteczna dla paska Z wynosi 250 mm !";
                    }
                    CalcObject.DiameterDp1(NormValues.DpZ);
                    break;
                case 2:
                    if (CalcObject.Dp1 < NormValues.DpA[0])
                        textBox22.Text = "Minimalna średnica skuteczna dla paska A wynosi 90 mm !";
                    if (CalcObject.Dp1 > NormValues.DpA[NormValues.DpZ.Length - 1])
                    {
                        textBox22.Text = "Maksymalna średnica skuteczna dla paska A wynosi 800 mm !";
                    }
                    CalcObject.DiameterDp1(NormValues.DpA);
                    break;
                case 3:
                    if (CalcObject.Dp1 < NormValues.DpB[0])
                        textBox22.Text = "Minimalna średnica skuteczna dla paska B wynosi 125 mm !";
                    if (CalcObject.Dp1 > NormValues.DpB[NormValues.DpB.Length - 1])
                    {
                        textBox22.Text = "Maksymalna średnica skuteczna dla paska B wynosi 1120 mm !";
                    }
                    CalcObject.DiameterDp1(NormValues.DpB);
                    break;
                case 4:
                    if (CalcObject.Dp1 < NormValues.DpC[0])
                        textBox22.Text = "Minimalna średnica skuteczna dla paska C wynosi 200 mm !";
                    if (CalcObject.Dp1 > NormValues.DpC[NormValues.DpC.Length - 1])
                    {
                        textBox22.Text = "Maksymalna średnica skuteczna dla paska C wynosi 1600 mm !";
                    }
                    CalcObject.DiameterDp1(NormValues.DpC);
                    break;
                case 5:
                    if (CalcObject.Dp1 < NormValues.DpD[0])
                        textBox22.Text = "Minimalna średnica skuteczna dla paska D wynosi 315 mm !";
                    if (CalcObject.Dp1 > NormValues.DpD[NormValues.DpD.Length - 1])
                    {
                        textBox22.Text = "Maksymalna średnica skuteczna dla paska D wynosi 2000 mm !";
                    }
                    CalcObject.DiameterDp1(NormValues.DpD);
                    break;
                case 6:
                    if (CalcObject.Dp1 < NormValues.DpE[0])
                        textBox22.Text = "Minimalna średnica skuteczna dla paska E wynosi 500 mm !";
                    if (CalcObject.Dp1 > NormValues.DpE[NormValues.DpE.Length - 1])
                    {
                        textBox22.Text = "Maksymalna średnica skuteczna dla paska E wynosi 2500 mm !";
                    }
                    CalcObject.DiameterDp1(NormValues.DpE);
                    break;
                default:
                    break;
            }
            
            textBox19.Text = Convert.ToString(CalcObject.Dp1); 
            textBox19.Enabled = false;

            if (CalcObject.i != 0)
            {
                CalcObject.Dp2 = Convert.ToInt32(CalcObject.i * CalcObject.Dp1);
            }
            switch (CalcObject.pas)
            {
                case 1:
                    CalcObject.DiameterDp2(NormValues.DpZ);
                    break;
                case 2:
                    CalcObject.DiameterDp2(NormValues.DpA);
                    break;
                case 3:
                    CalcObject.DiameterDp2(NormValues.DpB);
                    break;
                case 4:
                    CalcObject.DiameterDp2(NormValues.DpC);
                    break;
                case 5:
                    CalcObject.DiameterDp2(NormValues.DpD);
                    break;
                case 6:
                    CalcObject.DiameterDp2(NormValues.DpE);
                    break;
                default:
                    break;

            }
            textBox18.Text = Convert.ToString(CalcObject.Dp2);
            textBox18.Enabled = false;

            if (CalcObject.Dp1 > 0 &&  CalcObject.Dp2 > 0)
            {
                CalcObject.Iskor();
                textBox21.Text = Convert.ToString(CalcObject.Ip);
                textBox21.Enabled = false;
            }
            
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcObject.n1 = Convert.ToDouble(textBox23.Text);
            }
            catch
            {
                textBox22.Text = "Wpisz poprawną wartość prędkości obrotowej !";
            }
            if (CalcObject.n1 < 0) {
                textBox22.Text = "Wpisz poprawną wartość prędkości obrotowej, większą od 0 !";
                CalcObject.n1 = 0;
                    }

        }
        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcObject.N = Convert.ToDouble(textBox24.Text);
            }
            catch
            {
                textBox22.Text = "Wpisz poprawną wartość mocy !";
            }
            if (CalcObject.N <0)
            {
                textBox22.Text = "Wpisz poprawną wartość mocy, większą od 0!";
                CalcObject.N = 0;
            }
            

            CalcObject.Nkm = Math.Round(CalcObject.N / 735.499, 2);
            string f2 = Convert.ToString(CalcObject.Nkm);
            textBox25.Text = (" " + f2 + " KM");
            textBox25.Enabled = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (os.select > 0)
            {
                switch (os.select)
                {
                    case 1: CalcObject.silnik = 1; break;
                    case 2: CalcObject.silnik = 2; break;
                    case 3: CalcObject.silnik = 3; break;
                    case 4: CalcObject.silnik = 3; break;
                    default: break;
                }
            }

            if (CalcObject.pas > 0 && CalcObject.silnik > 0 && CalcObject.obc > 0 && CalcObject.godz > 0 && CalcObject.i > 0 && CalcObject.Dp1 > 0 && CalcObject.Dp2 > 0 && CalcObject.n1 > 0 && CalcObject.N > 0)
            {
                textBox2.Text = Convert.ToString(CalcObject.Amin());
                textBox2.Enabled = false;

                textBox3.Text = Convert.ToString(CalcObject.Amax());
                textBox3.Enabled = false;

                textBox4.Text = Convert.ToString(CalcObject.ACalc());
                textBox4.Enabled = false;

                textBox5.Text = Convert.ToString(CalcObject.Lmin());
                textBox5.Enabled = false;

               
                switch (CalcObject.pas)
                {
                    case 1:
                        CalcObject.SetLp(NormValues.LpZ);
                        break;
                    case 2:
                        CalcObject.SetLp(NormValues.LpA);
                        break;
                    case 3:
                        CalcObject.SetLp(NormValues.LpB);
                        break;
                    case 4:
                        CalcObject.SetLp(NormValues.LpC);
                        break;
                    case 5:
                        CalcObject.SetLp(NormValues.LpD);
                        break;
                    case 6:
                        CalcObject.SetLp(NormValues.LpE);
                        break;
                    default:
                        break;
                }

                textBox6.Text = Convert.ToString(CalcObject.Lp);
                textBox6.Enabled = false;

                textBox7.Text = Convert.ToString(CalcObject.AReal());
                textBox7.Enabled = false;

                textBox10.Text = Convert.ToString(CalcObject.Fi());
                textBox10.Enabled = false;
                
                CalcObject.SetKi();
                textBox12.Text = Convert.ToString(CalcObject.Ki);
                textBox12.Enabled = false;

                textBox13.Text = Convert.ToString(CalcObject.De());
                textBox13.Enabled = false;

                textBox14.Text = Convert.ToString(CalcObject.V());
                textBox14.Enabled = false;
                
                CalcObject.SetKFi(NormValues.fi,NormValues.Kfi);
                textBox11.Text = Convert.ToString(CalcObject.KFi);
                textBox11.Enabled = false;
                
                textBox15.Text = Convert.ToString(CalcObject.N1());
                textBox15.Enabled = false;
                
                textBox26.Text = Convert.ToString(Math.Round(CalcObject.N1() * 735.499, 2));
                textBox26.Enabled = false;
                
                switch (CalcObject.pas)
                {
                    case 1:
                        CalcObject.SetKl(NormValues.LpZ, NormValues.KlZ); break;
                    case 2:
                        CalcObject.SetKl(NormValues.LpA, NormValues.KlA); break;
                    case 3:
                        CalcObject.SetKl(NormValues.LpB, NormValues.KlB); break;
                    case 4:
                        CalcObject.SetKl(NormValues.LpC, NormValues.KlC); break;
                    case 5:
                        CalcObject.SetKl(NormValues.LpD, NormValues.KlD); break;
                    case 6:
                        CalcObject.SetKl(NormValues.LpE, NormValues.KlE); break;
                    default:
                        break;
                }
                
                textBox8.Text = Convert.ToString(CalcObject.Kl);
                textBox8.Enabled = false;

                CalcObject.SetKt();
                textBox9.Text = Convert.ToString(CalcObject.Kt);
                textBox9.Enabled = false;
            
                textBox16.Text = Convert.ToString(CalcObject.Zt());
                textBox16.Enabled = false;

                textBox17.Text = Convert.ToString(Math.Ceiling(CalcObject.Zt()));
                textBox17.Enabled = false;
                
            }
            else
                textBox22.Text = "Zdefniuj wszystkie parametry zadane !";
                

            }

       
        private void button2_Click(object sender, EventArgs e)
        {
            os.ShowDialog();

        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            os.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Wymiary_pasow image1 = new Wymiary_pasow();
            image1.ShowDialog();
        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {
            Schemat_przekladni image2 = new Schemat_przekladni();
            image2.ShowDialog();
        }

        private void informacjeOAplikacjiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Informacje inf = new Informacje();
            inf.ShowDialog();
        }

        private void zamknjiAplikacjęToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}



    