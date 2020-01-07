using GTA_SA_MP_Launcher.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTA_SA_MP_Launcher
{
    public partial class Form1 : Form
	{
        int fMove;
		int fMouse_X;
		int fMouse_Y;

		private Classes.Query sampquery = new Classes.Query(Globals.ServerIP, 7777);
		public Form1()
        {
            InitializeComponent();
			try
			{
				pictureBox1.Image = ResimCek("http://muteo.xyz/resimler/yukleniyor.gif");
			}
			catch
			{
				MessageBox.Show("Sunuculara şu anda ulaşılamıyor, resim yüklenemedi!", "Muteo - GTA SA-MP Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			ResimYukle.Start();
        }

		Bitmap ResimCek(string Url)
		{
			WebRequest rs = WebRequest.Create(Url);
			return (Bitmap)Bitmap.FromStream(rs.GetResponse().GetResponseStream());
		}

		private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
			int num = 1;
			this.sampquery.Send('p');
			int num2 = this.sampquery.Receive();
			if (num2 > 0)
			{
				string[] array = this.sampquery.Store(num2);
				int num3 = int.Parse(array[0]);
				this.sampquery.Send('i');
				num2 = this.sampquery.Receive();
				array = this.sampquery.Store(num2);
				if (num2 > 0)
				{
					label6.Text = "Aktif Oyuncu: " + array[1];
					label7.Text = "Ping: " + num3;
				}
			}
			else
			{
				label6.Text = "Aktif Oyuncu: N/A";
			    label7.Text = "Ping: N/A";
			}
			num++;
		}

		private void ResimYukle_Tick(object sender, EventArgs e)
		{
			backgroundWorker2.RunWorkerAsync();
			ResimYukle.Stop();
		}

		private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				pictureBox1.Image = ResimCek("http://muteo.xyz/resimler/clientresim.jpg");
			}
			catch
			{
				MessageBox.Show("Sunuculara şu anda ulaşılamıyor, resim yüklenemedi!", "Muteo - GTA SA-MP Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Functions.KonumGuncelle();
			label4.ForeColor = Color.Green;
			label4.Text = "Oyun çalıştırıldı.";
			Process.Start(Globals.OyunKonum + "\\samp.exe", Globals.ServerIP + " -n" + textBox1.Text);
		}

		private void SunucuBilgi_Tick(object sender, EventArgs e)
		{
			if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			fMove = 0;
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			fMove = 1;
			fMouse_X = e.X;
			fMouse_Y = e.Y;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (fMove == 1)
			{
				this.SetDesktopLocation(MousePosition.X - fMouse_X, MousePosition.Y - fMouse_Y);
			}
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			fMove = 0;
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (fMove == 1)
			{
				this.SetDesktopLocation(MousePosition.X - fMouse_X, MousePosition.Y - fMouse_Y);
			}
		}

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			fMove = 1;
			fMouse_X = e.X;
			fMouse_Y = e.Y;
		}
	}
}
