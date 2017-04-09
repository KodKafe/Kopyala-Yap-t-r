using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kopyala_Yapıştır
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AddClipboardFormatListener(IntPtr hwnd);
        private const int WM_CLIPBOARDUPDATE = 0x031D;
        string[] kopyalar = new string[200];

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg==WM_CLIPBOARDUPDATE)
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string text = (string)iData.GetData(DataFormats.Text);
                    //textBox1.Text = text;
                    diziyiGuncelle();
                    kopyalar[0] = text;
                    textboxlariGuncelle();
                }
            }
        }

        private void textboxlariGuncelle()
        {
            textBox1.Text = kopyalar[0];
            textBox2.Text = kopyalar[1];
            textBox3.Text = kopyalar[2];
            textBox4.Text = kopyalar[3];
            textBox5.Text = kopyalar[4];
            textBox6.Text = kopyalar[5];
            textBox7.Text = kopyalar[6];
            textBox8.Text = kopyalar[7];
            textBox9.Text = kopyalar[8];
            textBox10.Text = kopyalar[9];
            textBox11.Text = kopyalar[10];
            textBox12.Text = kopyalar[11];
            textBox13.Text = kopyalar[12];
            textBox14.Text = kopyalar[13];
            textBox15.Text = kopyalar[14];
            textBox16.Text = kopyalar[15];
            textBox17.Text = kopyalar[16];
            textBox18.Text = kopyalar[17];
            textBox19.Text = kopyalar[18];
            textBox20.Text = kopyalar[19];
        }

        private void diziyiGuncelle()
        {
            for (int i =kopyalar.Length-1; i >0; i--)
            {
                kopyalar[i] = kopyalar[i - 1];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddClipboardFormatListener(this.Handle);
        }

    }
}
