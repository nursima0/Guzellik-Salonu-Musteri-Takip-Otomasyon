using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        vtislemler vtislem = new vtislemler();
        private void btnKayitGoruntule_Click(object sender, EventArgs e)
        {
            lblMenu.Location = new Point(lblMenu.Location.X, btnKayitGoruntule.Location.Y);
            pnlKayitlar.Visible = true;
            pnlKayitEkle.Visible = false;
            pnlSil.Visible = false;
            pnlHakkinda.Visible = false;
            pnlGuncelle.Visible = false;
            listKayitlar.Items.Clear();
            vtislem.listele(listKayitlar);
        }

        private void btnKayitEkle_Click(object sender, EventArgs e)
        {
            lblMenu.Location = new Point(lblMenu.Location.X, btnKayitEkle.Location.Y);
            pnlKayitlar.Visible = false;
            pnlKayitEkle.Visible = true;
            pnlSil.Visible = false;
            pnlHakkinda.Visible = false;
            pnlGuncelle.Visible = false;
        }

        private void btnKayitGuncelle_Click(object sender, EventArgs e)
        {
            lblMenu.Location = new Point(lblMenu.Location.X, btnKayitGuncelle.Location.Y);
            pnlKayitlar.Visible = false;
            pnlKayitEkle.Visible = false;
            pnlHakkinda.Visible = false;
            pnlSil.Visible = false;
            pnlGuncelle.Visible = true;
            listGuncelle.Items.Clear();
            vtislem.listele(listGuncelle);
        }

        private void btnKayitSil_Click(object sender, EventArgs e)
        {
            lblMenu.Location = new Point(lblMenu.Location.X, btnKayitSil.Location.Y);
            pnlKayitlar.Visible = false;
            pnlKayitEkle.Visible = false;
            pnlSil.Visible = true;
            pnlHakkinda.Visible = false;
            pnlGuncelle.Visible = false;
            listSil.Items.Clear();
            vtislem.listele(listSil);
        }

        private void btnHakkinda_Click(object sender, EventArgs e)
        {
            lblMenu.Location = new Point(lblMenu.Location.X, btnHakkinda.Location.Y);
            pnlKayitlar.Visible = false;
            pnlKayitEkle.Visible = false;
            pnlSil.Visible = false;
            pnlHakkinda.Visible = true;
            pnlGuncelle.Visible = false;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            DialogResult soru = MessageBox.Show("Yazılımdan çıkmak istediğinizden emin misiniz?", "ÇIKIŞ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (soru == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        bool surukle;
        Point nokta;

        private void pnlUstBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukle == true)
            {
                Point csp = PointToScreen(e.Location);
                Location = new Point(csp.X - nokta.X, csp.Y - nokta.Y);
            }
        }

        private void pnlUstBar_MouseDown(object sender, MouseEventArgs e)
        {
            surukle = true;
            nokta = e.Location;
        }

        private void pnlUstBar_MouseUp(object sender, MouseEventArgs e)
        {
            surukle = false;
        }
        bool aydinliktema = false;
        private void btnTheme_Click(object sender, EventArgs e)
        {
            if (aydinliktema == true)
            {
                btnTheme.BackgroundImage = Image.FromFile(Application.StartupPath + "\\images\\ay.png");
                toolTip1.SetToolTip(btnTheme, "KARANLIK TEMAYA GEÇ");
                aydinliktema = false;
                this.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                listKayitlar.BackColor = Color.White;
                listKayitlar.ForeColor = Color.Black;
                listSil.BackColor = Color.White;
                listSil.ForeColor = Color.Black;
                label14.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                groupBox1.ForeColor = Color.Black;
                txtHakkinda.ForeColor = Color.Black;
                txtHakkinda.BackColor = Color.White;
                txtGuncelleAd.ForeColor = Color.Black;
                txtGuncelleAd.BackColor = Color.White;
                txtGuncelleSoyad.ForeColor = Color.Black;
                txtGuncelleSoyad.BackColor = Color.White;
                txtGuncelleTel.ForeColor = Color.Black;
                txtGuncelleTel.BackColor = Color.White;
                txtGuncelleYapilacaklar.ForeColor = Color.Black;
                txtGuncelleYapilacaklar.BackColor = Color.White;
                dtpGuncelleTarih.CalendarForeColor = Color.Black;
                dtpGuncelleTarih.CalendarTitleBackColor = Color.White;
                label2.ForeColor = Color.Black;
                txtAra.BackColor = Color.White;
                label8.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                label11.ForeColor = Color.Black;
                label12.ForeColor = Color.Black;
                label13.ForeColor = Color.Black;
                txtAra.ForeColor = Color.Black;
                txtSilTel.BackColor = Color.White;
                txtSilTel.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                listGuncelle.BackColor = Color.White;
                listGuncelle.ForeColor = Color.Black;
                txtEkleAd.ForeColor = Color.Black;
                txtEkleAd.BackColor = Color.White;
                txtEkleSoyad.ForeColor = Color.Black;
                txtEkleSoyad.BackColor = Color.White;
                txtEkleTelNo.ForeColor = Color.Black;
                txtEkleTelNo.BackColor = Color.White;
                txtEkleYapilacaklar.ForeColor = Color.Black;
                txtEkleYapilacaklar.BackColor = Color.White;
                dtpEkleTarih.ForeColor = Color.Black;
                dtpEkleTarih.BackColor = Color.White;
            }
            else
            {
                btnTheme.BackgroundImage = Image.FromFile(Application.StartupPath + "\\images\\gunes.png");
                toolTip1.SetToolTip(btnTheme, "AYDINLIK TEMAYA GEÇ");
                aydinliktema = true;
                this.BackColor = Color.FromArgb(34, 38, 43);
                txtAra.BackColor = Color.FromArgb(34, 38, 43);
                txtAra.ForeColor = Color.White;
                txtSilTel.BackColor = Color.FromArgb(34, 38, 43);
                txtSilTel.ForeColor = Color.White;
                txtGuncelleAd.ForeColor = Color.White;
                txtGuncelleAd.BackColor = Color.FromArgb(34, 38, 43);
                txtGuncelleSoyad.ForeColor = Color.White;
                txtGuncelleSoyad.BackColor = Color.FromArgb(34, 38, 43);
                txtGuncelleTel.ForeColor = Color.White;
                txtGuncelleTel.BackColor = Color.FromArgb(34, 38, 43);
                txtGuncelleYapilacaklar.ForeColor = Color.White;
                txtGuncelleYapilacaklar.BackColor = Color.FromArgb(34, 38, 43);
                dtpGuncelleTarih.ForeColor = Color.White;
                dtpGuncelleTarih.BackColor = Color.FromArgb(34, 38, 43);
                listGuncelle.BackColor = Color.FromArgb(34, 38, 43);
                listGuncelle.ForeColor = Color.White;
                txtEkleAd.ForeColor = Color.White;
                txtEkleAd.BackColor = Color.FromArgb(34, 38, 43);
                txtEkleSoyad.ForeColor = Color.White;
                txtEkleSoyad.BackColor = Color.FromArgb(34, 38, 43);
                txtEkleTelNo.ForeColor = Color.White;
                txtEkleTelNo.BackColor = Color.FromArgb(34, 38, 43);
                txtEkleYapilacaklar.ForeColor = Color.White;
                txtEkleYapilacaklar.BackColor = Color.FromArgb(34, 38, 43);
                dtpEkleTarih.ForeColor = Color.White;
                dtpEkleTarih.BackColor = Color.FromArgb(34, 38, 43);
                label1.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label8.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                label11.ForeColor = Color.White;
                label12.ForeColor = Color.White;
                label13.ForeColor = Color.White;
                label14.ForeColor = Color.White;
                groupBox1.ForeColor = Color.White;
                txtHakkinda.ForeColor = Color.White;
                txtHakkinda.BackColor = Color.FromArgb(34, 38, 43);
                label10.ForeColor = Color.White;
                listKayitlar.BackColor = Color.FromArgb(34, 38, 43);
                listKayitlar.ForeColor = Color.White;
                listSil.BackColor = Color.FromArgb(34, 38, 43);
                listSil.ForeColor = Color.White;
                label2.ForeColor = Color.White;
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text == "" || txtAra.Text == null)
            {
                MessageBox.Show("Lütfen aramak istediğiniz kaydın telefon numarasını giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAra.Clear();
            }
            else
            {
                listKayitlar.Items.Clear();
                vtislem.arama(listKayitlar, txtAra.Text);
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkleAd.Text == "" || txtEkleAd.Text == null || txtEkleSoyad.Text == "" || txtEkleSoyad.Text == null || txtEkleTelNo.Text == "" || txtEkleTelNo.Text == null || txtEkleYapilacaklar.Text == "" || txtEkleYapilacaklar.Text == null)
            {
                MessageBox.Show("Lütfen boş değer girmeyiniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                vtislem.ekle(txtEkleAd.Text, txtEkleSoyad.Text, txtEkleTelNo.Text, txtEkleYapilacaklar.Text, dtpEkleTarih.Value);
            }
        }

        private void ListKayitlar_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listKayitlar.SelectedItems[0];
            MessageBox.Show("AD: " + item.Text + "\nSOYAD: " + item.SubItems[0].Text + "\nTEL NO: " + item.SubItems[1].Text + "\nYAPILACAKLAR: " + item.SubItems[2].Text + "\nRANDEVU TARİHİ: " + item.SubItems[3].Text, "KAYIT BİLGİLERİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (txtSilTel.Text == "" || txtSilTel.Text == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kayda ait telefon numarasını giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult soru = MessageBox.Show("Seçilen kayıtı silmek istediğinizden emin misiniz?", "KAYIT SİL?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (soru == DialogResult.Yes)
                {
                    vtislem.sil(txtSilTel.Text);
                    listSil.Items.Clear();
                    vtislem.listele(listSil);
                }
            }
        }

        private void ListSil_Click(object sender, EventArgs e)
        {
            ListViewItem item = listSil.SelectedItems[0];
            txtSilTel.Text = item.SubItems[2].Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTheme.BackgroundImage = Image.FromFile(Application.StartupPath + "\\images\\ay.png");
            pnlKayitlar.Visible = true;
            pnlKayitEkle.Visible = false;
            pnlHakkinda.Visible = false;
            pnlSil.Visible = false;
            pnlGuncelle.Visible = false;
            listKayitlar.Items.Clear();
            vtislem.listele(listKayitlar);
            CheckForIllegalCrossThreadCalls = false;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtGuncelleAd.Text == "" || txtGuncelleAd.Text == null || txtGuncelleSoyad.Text == "" || txtGuncelleSoyad.Text == null || txtGuncelleTel.Text == "" || txtGuncelleTel.Text == null || txtGuncelleYapilacaklar.Text == "" || txtGuncelleYapilacaklar.Text == null || dtpGuncelleTarih.Text == "" || dtpGuncelleTarih.Text == null)
            {
                MessageBox.Show("Lütfen boş değer bırakmayınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                vtislem.guncelle(txtGuncelleAd.Text, txtGuncelleSoyad.Text, txtGuncelleTel.Text, txtGuncelleYapilacaklar.Text, dtpGuncelleTarih.Value);
                listGuncelle.Items.Clear();
                vtislem.listele(listGuncelle);
            }
        }

        private void ListGuncelle_Click(object sender, EventArgs e)
        {
            ListViewItem ekle = listGuncelle.SelectedItems[0];
            txtGuncelleAd.Text = ekle.Text;
            txtGuncelleSoyad.Text = ekle.SubItems[1].Text;
            txtGuncelleTel.Text = ekle.SubItems[2].Text;
            txtGuncelleYapilacaklar.Text = ekle.SubItems[3].Text;
            dtpEkleTarih.Value = DateTime.Parse(ekle.SubItems[4].Text);
        }

        private void BtnHakkindaGonder_Click(object sender, EventArgs e)
        {
            Thread mailthread = new Thread(mailgonder);
            mailthread.Start();
        }

        void mailgonder()
        {
            try
            {
                btnHakkindaGonder.Enabled = false;
                btnHakkindaGonder.Text = "İLETİLİYOR..";
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("nursima.02ozmercan@gmail.com", "daffysmokes.002");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("nursima.02ozmercan@gmail.com", "HAKKINDA");
                mail.To.Add("nursima.02ozmercan@gmail.com");
                mail.Subject = "HAKKINDA";
                mail.Body = txtHakkinda.Text;
                sc.Send(mail);
                txtHakkinda.Text += "\r\n\r\nİLETİLDİ";
                btnHakkindaGonder.Enabled = true;
                btnHakkindaGonder.Text = "İLETİNİZİ GÖNDERİN";
            }
            catch (Exception ex)
            {
                btnHakkindaGonder.Enabled = true;
                btnHakkindaGonder.Text = "İLETİNİZİ GÖNDERİN";
                MessageBox.Show("HATA KODU: 005\n\n" + ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            frmRapor rapor = new frmRapor();
            rapor.ShowDialog();
        }
    }
}