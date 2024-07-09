using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    class vtislemler
    {
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\vt.mdb");
        OleDbCommand kmt;
        OleDbDataReader oku;

        public void listele(ListView liste)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                kmt = new OleDbCommand("select * from kayıt", baglanti);
                oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["ad"].ToString();
                    ekle.SubItems.Add(oku["soyad"].ToString());
                    ekle.SubItems.Add(oku["telno"].ToString());
                    ekle.SubItems.Add(oku["yapılacaklar"].ToString());
                    ekle.SubItems.Add(oku["rtarih"].ToString());
                    liste.Items.Add(ekle);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA KODU: 000\n\n"+ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void arama(ListView liste,string telno)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                kmt = new OleDbCommand("select * from kayıt where telno=@telno", baglanti);
                kmt.Parameters.AddWithValue("@telno", telno);
                oku = kmt.ExecuteReader();
                if (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["ad"].ToString();
                    ekle.SubItems.Add(oku["soyad"].ToString());
                    ekle.SubItems.Add(oku["telno"].ToString());
                    ekle.SubItems.Add(oku["yapılacaklar"].ToString());
                    ekle.SubItems.Add(oku["rtarih"].ToString());
                    liste.Items.Add(ekle);
                }
                else
                {
                    MessageBox.Show("Bu kayıt bulunamadı!", "KAYIT BULUNAMADI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA KODU: 001\n\n"+ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ekle(string ad, string soyad, string telno, string yapilacaklar, DateTime rtarih)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                kmt = new OleDbCommand("select * from kayıt where telno=@telno", baglanti);
                kmt.Parameters.AddWithValue("@telno", telno);
                oku = kmt.ExecuteReader();

                if (oku.Read())
                {
                    MessageBox.Show("Böyle bir kayıt mevcuttur!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    kmt = new OleDbCommand("insert into kayıt (ad, soyad, telno, yapılacaklar, rtarih) values (@ad, @soyad, @telno, @yapılacaklar, @rtarih)", baglanti);
                    kmt.Parameters.AddWithValue("@ad", ad);
                    kmt.Parameters.AddWithValue("@soyad", soyad);
                    kmt.Parameters.AddWithValue("@telno", telno);
                    kmt.Parameters.AddWithValue("@yapılacaklar", yapilacaklar);
                    kmt.Parameters.AddWithValue("@rtarih", rtarih);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız başarıyla eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA KODU: 002\n\n" + ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void sil(string telno)
        {
            try
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                kmt = new OleDbCommand("select * from kayıt where telno=@telno", baglanti);
                kmt.Parameters.AddWithValue("@telno", telno);
                oku = kmt.ExecuteReader();

                if (oku.Read())
                {
                    kmt = new OleDbCommand("delete from kayıt where telno=@telno", baglanti);
                    kmt.Parameters.AddWithValue("@telno", telno);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show(telno + " numaralı kayıt silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Silmek istediğiniz kayıt bulunamamaktadır! Lütfen girdiğiniz telefon numarasını kontrol edin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA KODU: 003\n\n" + ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void guncelle(string ad, string soyad, string telno, string yapılacaklar, DateTime rtarih)
        {
            try
            {
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                kmt = new OleDbCommand("update kayıt set ad=@ad, soyad=@soyad, yapılacaklar=@yapılacaklar, rtarih=@rtarih where telno=@telno", baglanti);
                kmt.Parameters.AddWithValue("@ad", ad);
                kmt.Parameters.AddWithValue("@soyad", soyad);
                kmt.Parameters.AddWithValue("@yapılacaklar", yapılacaklar);
                kmt.Parameters.AddWithValue("@rtarih", rtarih);
                kmt.Parameters.AddWithValue("@telno", telno);
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(telno + " numaralı kaydınız güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA KODU: 004\n\n" + ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}