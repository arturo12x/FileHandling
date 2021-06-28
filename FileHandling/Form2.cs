using System;
using System.Windows;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FileHandling
{
    public partial class Form2 : Form
    {
        string path, filename, fullpath;
        bool close = false;
        public static bool fontbold = false;
        public static bool fontitalic = false;
        public static bool fontunderline = false;
        public static float fontsize;
        public static string fontname;
        private void Form2_Load(object sender, EventArgs e)
        {
            ContextMenuStrip ctx = new ContextMenuStrip();
            ctx.Items.Add(new ToolStripMenuItem("Cut", null, cutClick));
            ctx.Items.Add(new ToolStripMenuItem("Copy", null, copyClick));
            ctx.Items.Add(new ToolStripMenuItem("Paste", null, pasteClick));
            richTextBox1.ContextMenuStrip = ctx;


            if (Form1.oper == "OPEN")
            {


                OpenFileDialog ofd1 = new OpenFileDialog();

                ofd1.Filter = "Text Files (.rtf)|*.rtf|All Files (*.*)|*.*";
                if (ofd1.ShowDialog() == DialogResult.OK)
                {



                    fullpath = ofd1.FileName;
                    richTextBox1.LoadFile(fullpath, RichTextBoxStreamType.RichText);
                    /* StreamReader sr1 = new StreamReader(fullpath);
                     while (!sr1.EndOfStream)
                     {
                         richTextBox1.Text += sr1.ReadLine();
                         richTextBox1.Text += Environment.NewLine;
                     }
                     //StreamReader sr1 = new StreamReader(fullpath);
                     /* List<string> lines = File.ReadAllLines(fullpath).ToList();
                      foreach(string element in lines)
                      {
                          richTextBox1.Text += element;
                          richTextBox1.Text += Environment.NewLine;
                      }

                     sr1.Close();/*/
                }
                else
                {
                    close = true;
                }
            }
        }




        void cutClick(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
                richTextBox1.Cut();
        }
        void copyClick(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
                richTextBox1.Copy();
        }
        void pasteClick(object sender, EventArgs e)
        {
            DataFormats.Format textFormat = DataFormats.GetFormat(DataFormats.Text);
            if (richTextBox1.CanPaste(textFormat))
                richTextBox1.Paste();
        }
        internal void saveAs()
        {

            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Title = "SAVE AS...";
            sfd1.FileName = this.Text;
            sfd1.CheckFileExists = false;
            //sfd1.InitialDirectory =@"c:\Users\";
            sfd1.InitialDirectory = Environment.CurrentDirectory;
            sfd1.Filter = "Text Files (.rtf)|*.rtf|All Files (*.*)|*.*";

            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                path = Path.GetDirectoryName(sfd1.FileName);

                filename = richTextBox1.Text;
                filename = Path.GetFileName(sfd1.FileName);
                //label1.Text = path;
                //label2.Text = filename;
                fullpath = path + @"\" + filename;
                var file = File.CreateText(fullpath);
                file.Close();
                //PARA GUARDAR DOCUMENTOS DE TB EN FORMATO TXT

                //StreamWriter sw1 = new StreamWriter(fullpath);
                //sw1.WriteLine(richTextBox1.Text);
                //sw1.Close();

                //PARA GUARDAR DOCUMENTOS DE richTextBox1 EN FORMATO RT
                richTextBox1.SaveFile(fullpath, RichTextBoxStreamType.RichText);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }


        internal void changefont(ComboBox combo)
        {

            fontname = combo.Text;

            try
            {
                richTextBox1.SelectionFont = new Font(fontname, fontsize, richTextBox1.SelectionFont.Style);

                combo.Font = new Font(fontname, combo.Font.Size, richTextBox1.SelectionFont.Style); ;

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
                var filexist = File.Exists(rutaarchivo);
         
                  
                    sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();
             
            }

        }

        internal void alinear(string tipo)
        {
            try
            {
                if (tipo == "centro")
                {
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                }



                if (tipo == "izquierda")
                {
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                }


                if (tipo == "derecha")
                {
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
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
                var filexist = File.Exists(rutaarchivo);


                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        internal void changefontsize(string masomenos, ComboBox combo)
        {

            if (masomenos == "+")
            {
                if (fontsize >= 300)
                {
                    return;
                }
                fontsize += 2;


            }


            if (masomenos == "-")
            {
                if (fontsize <= 2)
                {
                    return;
                }

                fontsize -= 2;
            }


            if (masomenos == "combo")
            {

                if (fontsize >= 300)
                {
                    return;
                }

                if (fontsize <= 2)
                {
                    return;
                }






                fontsize = float.Parse(combo.Text);



            }

            try
            {
                richTextBox1.SelectionFont = new Font(fontname, fontsize, richTextBox1.SelectionFont.Style);
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
        

        internal void color(Button btn, Label lbl)
        {
            ColorDialog color = new ColorDialog();
            color.AllowFullOpen = false;

            color.ShowDialog();

            try
            {

                lbl.Text = color.Color.Name;
                lbl.ForeColor = color.Color;
                richTextBox1.SelectionColor = color.Color;
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
                var filexist = File.Exists(rutaarchivo);


                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }
        internal void llenarcombo(ComboBox combo, ComboBox combo2)
        {

            try
            {
                foreach (FontFamily font in FontFamily.Families)
                {
                    combo.Items.Add(font.Name.ToString());
                }


                combo.Text = richTextBox1.Font.Name.ToString();

                combo2.Items.Add("8");
                combo2.Items.Add("9");
                combo2.Items.Add("10");
                combo2.Items.Add("11");
                combo2.Items.Add("12");
                combo2.Items.Add("14");
                combo2.Items.Add("16");
                combo2.Items.Add("18");
                combo2.Items.Add("20");
                combo2.Items.Add("22");
                combo2.Items.Add("24");
                combo2.Items.Add("26");
                combo2.Items.Add("36");
                combo2.Items.Add("48");
                combo2.Items.Add("72");

                fontsize = richTextBox1.Font.Size;

                combo2.Text = fontsize.ToString();
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
                var filexist = File.Exists(rutaarchivo);


                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");
                sw1.Close();

            }
        }

        internal void font(string type)
        {
            try
            {

                switch (type)
                {
                    case "bold":
                        if (!fontbold)
                        {


                            richTextBox1.SelectionFont = new Font(fontname, fontsize, richTextBox1.SelectionFont.Style | FontStyle.Bold);




                            fontbold = true;
                            richTextBox1.Focus();
                        }
                        else
                        {

                            if (fontitalic)
                            {
                                richTextBox1.SelectionFont = new Font(fontname, fontsize, FontStyle.Italic | FontStyle.Regular);


                                if (fontunderline)
                                {
                                    richTextBox1.SelectionFont = new Font(fontname, fontsize, richTextBox1.SelectionFont.Style | FontStyle.Underline | FontStyle.Regular);

                                }
                            }
                            else
                            {
                                richTextBox1.SelectionFont = new Font(fontname, fontsize, FontStyle.Regular);
                            }










                            fontbold = false;
                            richTextBox1.Focus();

                        }
                        break;


                    case "italic":
                        if (!fontitalic)
                        {

                            richTextBox1.SelectionFont = new Font(fontname, fontsize, richTextBox1.SelectionFont.Style | FontStyle.Italic);
                            fontitalic = true;
                            richTextBox1.Focus();
                        }
                        else
                        {
                            if (fontbold)
                            {
                                richTextBox1.SelectionFont = new Font(fontname, fontsize, FontStyle.Bold | FontStyle.Regular);


                                if (fontunderline)
                                {
                                    richTextBox1.SelectionFont = new Font(fontname, fontsize, richTextBox1.SelectionFont.Style | FontStyle.Underline | FontStyle.Regular);

                                }
                            }
                            else
                            {
                                richTextBox1.SelectionFont = new Font(fontname, fontsize, FontStyle.Regular);
                            }


                            fontitalic = false;
                            richTextBox1.Focus();
                        }
                        break;

                    case "underline":
                        if (!fontunderline)
                        {

                            richTextBox1.SelectionFont = new Font(fontname, fontsize, richTextBox1.SelectionFont.Style | FontStyle.Underline);
                            fontunderline = true;
                            richTextBox1.Focus();
                        }
                        else
                        {
                            if (fontbold)
                            {
                                richTextBox1.SelectionFont = new Font(fontname, fontsize, FontStyle.Bold | FontStyle.Regular);


                                if (fontitalic)
                                {
                                    richTextBox1.SelectionFont = new Font(fontname, fontsize, richTextBox1.SelectionFont.Style | FontStyle.Italic | FontStyle.Regular);

                                }
                            }
                            else
                            {
                                richTextBox1.SelectionFont = new Font(fontname, fontsize, FontStyle.Regular);
                            }

                            fontunderline = false;

                            richTextBox1.Focus();
                        }



                        break;


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
                var filexist = File.Exists(rutaarchivo);


                sw1.WriteLine("Date error: " + fecha + " " + mierror);
                sw1.WriteLine("****************************************************************************************************************************************");
                sw1.WriteLine(" ");

                sw1.Close();

            }



            //        richTextBox1.SelectionStart = s1 + s2;
            //          richTextBox1.Select(s1, s2);            
        }





        internal void save()
        {
            var file2 = File.Exists(fullpath);

            if (file2)
            {
                //     StreamWriter sw2 = new StreamWriter(fullpath);
                //   sw2.WriteLine(richTextBox1.Text);
                // sw2.Close();
                richTextBox1.SaveFile(fullpath, RichTextBoxStreamType.RichText);
                return;
            }

            saveAs();
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            if (close == true)
            {
                Form1 F1 = (Form1)Application.OpenForms["Form1"];
                F1.panel1.Hide();
                F1.panel12.Hide();
                this.Close();
            }
        }

        internal void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 F1 = (Form1)Application.OpenForms["Form1"];
            F1.panel1.Hide();
            F1.panel12.Hide();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            Form1 F1 = (Form1)Application.OpenForms["Form1"];
            F1.panel1.Show();
            F1.panel12.Show();
        }

        public Form2()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {


        }
    }
}
    

