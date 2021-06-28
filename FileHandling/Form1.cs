using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;

namespace FileHandling
{
    public partial class Form1 : Form
    {
        public static string oper;
        bool openclose = true;
        bool windowstate = false;
        bool openclosefiles=false;
        bool fontopenclose = true;
        Size tamaño;
        Point ubicacion;
        int numdoc;
        
        bool primeravez = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oper = "NEW";
            panel12.Show();
            panel1.Show();
            Form f2 = new Form2();

            f2.TopLevel = false;
           f2.TopMost = true;
         numdoc++;
            //f2.Width = panel11.Width;
            //f2.Height = panel11.Height;
          f2.Text = "New_Document_" + numdoc;
            this.panel11.Controls.Add(f2);
            f2.Size = panel11.Size;
            f2.Dock = DockStyle.Fill;
          
            f2.Show();
            timer2.Start();
            /* this.Hide();
            f2.ShowDialog();
            this.Show();/*/

            if (!primeravez)
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.llenarcombo(comboBox1,comboBox2);
                primeravez = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            oper = "OPEN";
            panel12.Show();
            panel1.Show();
            Form f2 = new Form2();

            f2.TopLevel = false;
            f2.TopMost = true;

           // panel2.Width = f2.Width;
            //panel2.Height = f2.Height;

            this.panel11.Controls.Add(f2);
            f2.Size = panel11.Size;
            f2.Dock = DockStyle.Fill;
            f2.Show();
            timer2.Start();
        
            if (!primeravez)
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.llenarcombo(comboBox1,comboBox2);
                primeravez = true;
            }
       /*     this.Hide();
            f2.ShowDialog();
            this.Show();/*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tamaño = this.Size;
            ubicacion = this.Location;


           
            //llama a la funcion internal del form 2 para llenar el combobox


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (openclose)
            {
                panel1.Height += 7;
                if (panel1.Size==panel1.MaximumSize) 
                {
                    timer1.Stop();
                    openclose = false; 
                    button3.Image = Properties.Resources.flcha_arriba;

                }
            }

            else            {
                panel1.Height -= 7;
                if (panel1.Size == panel1.MinimumSize)
                {
                    timer1.Stop();
                    openclose = true ; 
                    button3.Image = Properties.Resources.flecha_abajo;

                }
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (openclosefiles)
            {
                panel4.Height += 6;
                if (panel4.Size == panel4.MaximumSize)
                {
                    timer2.Stop();
                    openclosefiles = false; ;
                    button7.Image = Properties.Resources.flcha_arriba;


                }
            }

            else
            {
                panel4.Height -= 6;
                if (panel4.Size == panel4.MinimumSize)
                {
                    timer2.Stop();
                    openclosefiles = true;
                    button7.Image = Properties.Resources.flecha_abajo;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void flowLayoutPanel2_MouseMove(object sender, MouseEventArgs e)
        {

      
        }

        private void button8_Click(object sender, EventArgs e)
        {


            //PONER MENSAJE SI AUN NO A GUARDADO DE QUE SI DE VERDAD QUIERE SALIR.
            Application.Exit();

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!windowstate)
            {
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                windowstate = true;
            }
            else
            {
                

                this.Size = tamaño;
                this.CenterToScreen();
                windowstate = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            timer2.Start();
        }

       
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }





        private void selectfont(string typefont, Button btn)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.font(typefont); //Llama a la funcion font que determina el tipo de fuente enviandole el parametro typefond[bold, italic,underline]


                switch (typefont)
                {

                    case "bold":
                        if (!Form2.fontbold)
                        {
                            btn.BackColor = Color.FromArgb(61, 90, 241);
                        }
                        else
                        {
                            btn.BackColor = Color.FromArgb(40, 53, 147);

                        }
                        break;


                    case "italic":

                        if (!Form2.fontitalic)
                        {
                            btn.BackColor = Color.FromArgb(61, 90, 241);
                        }
                        else
                        {
                            btn.BackColor = Color.FromArgb(40, 53, 147);

                        }

                        break;
                    case "underline":

                        if (!Form2.fontunderline)
                        {
                            btn.BackColor = Color.FromArgb(61, 90, 241);
                        }
                        else
                        {
                            btn.BackColor = Color.FromArgb(40, 53, 147);

                        }

                        break;

                        F2.richTextBox1.Focus();

                }
            }


            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror );
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            selectfont("italic", button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            selectfont("underline", button6);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.changefont(comboBox1);
                F2.richTextBox1.Focus();
            }

            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo,true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.changefontsize("+", null);
                comboBox2.Text = Form2.fontsize.ToString();
                F2.richTextBox1.Focus();
            }

            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {


                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.changefontsize("-", null);
                comboBox2.Text = Form2.fontsize.ToString();
                F2.richTextBox1.Focus();
            }

            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //poner try&catch aqui
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.changefontsize("combo", comboBox2);
                F2.richTextBox1.Focus();
            }

            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        private void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
         
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.alinear("izquierda");
                F2.richTextBox1.Focus();
            }


            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);
  

                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }

        }


        public void InsertImage()
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];






                OpenFileDialog ofd1 = new OpenFileDialog();
                ofd1.ShowDialog();
                string fullpath = ofd1.FileName;
                Bitmap myBitmap = new Bitmap(fullpath);
                // Copy the bitmap to the clipboard.
                Clipboard.SetDataObject(myBitmap);
                // Get the format for the object type.
                DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                // After verifying that the data can be pasted, paste
                if (F2.richTextBox1.CanPaste(myFormat))
                {
                    F2.richTextBox1.Paste(myFormat);
                }
                else
                {
                    MessageBox.Show("The data format that you attempted site" +
                      " is not supportedby this control.");
                }
            }


            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);
//


                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.alinear("centro");
                F2.richTextBox1.Focus();
            }


            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);
//


                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.alinear("derecha");
                F2.richTextBox1.Focus();
            }


            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);
//


                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }

        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {

          
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {

                    Form2 F2 = (Form2)Application.OpenForms["Form2"];
                    F2.changefontsize("combo", comboBox2);

                }
            }

            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.color(button13, label2);
                F2.richTextBox1.Focus();
            }

            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (fontopenclose)
            {
                panel12.Height += 4;
                if (panel12.Size == panel12.MaximumSize)
                {
                    timer3.Stop();
                    fontopenclose = false; ;
                    button14.Image = Properties.Resources.flcha_arriba;


                }
            }

            else
            {
                panel12.Height -= 4;
                if (panel12.Size == panel12.MinimumSize)
                {
                    timer3.Stop();
                    fontopenclose = true;
                    button14.Image = Properties.Resources.flecha_abajo;
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.save();
            }

            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 F2 = (Form2)Application.OpenForms["Form2"];
                F2.saveAs();
            }

            catch (Exception mierror)
            {



                // MessageBox.Show("Error!,please try again");

                string rutaarchivo;
                string direc = Environment.CurrentDirectory;
                string fecha = System.DateTime.Now.ToString();
                string filename = "LOG.txt";
                rutaarchivo = direc + @"\" + filename;
                StreamWriter sw1 = new StreamWriter(rutaarchivo, true);



                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
         

        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectfont("bold", button4);
        }
    }
}
