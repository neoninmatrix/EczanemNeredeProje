using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers
{
    public class DataModel
    {

        SqlConnection con;
        SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Giriş İşlemleri 

        public Kullanici KullaniciKontrol(string kullaniciAdi, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Kullanici WHERE KullaniciAdi=@kadi AND Sifre=@sfr";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sfr", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT * FROM Kullanici WHERE KullaniciAdi=@kadi AND Sifre=@sfr";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sfr", sifre);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Kullanici k = new Kullanici();
                    while (reader.Read())
                    {
                        k.ID = reader.GetInt32(0);
                        k.YetkiliTur_ID = reader.GetInt32(1);
                        k.Isim = reader.GetString(2);
                        k.Soyisim = reader.GetString(3);
                        k.KullaniciAdi = reader.GetString(4);
                        k.Sifre = reader.GetString(5);
                        k.Mail = reader.GetString(6);
                        k.OlusturmaTarihi = reader.GetDateTime(7);
                        k.Aktif = reader.GetBoolean(8);
                        k.Silinmis = reader.GetBoolean(9);
                    }
                    return k;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim, Aciklama) VALUES (@i,@a)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", model.Isim);
                cmd.Parameters.AddWithValue("@a", model.Aciklama);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListeleme()
        {

            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Aciklama FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Aciklama = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Aciklama FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategori k = new Kategori();
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Aciklama = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @i, Aciklama = @a WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@i", kat.Isim);
                cmd.Parameters.AddWithValue("@a", kat.Aciklama);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(KategoriID, YazarID, Baslik, Ozet, Icerik, KapakResmi, EklemeTarihi, BegeniSayi, GoruntulemeSayi, Aktif, silinmis) VALUES (@kategoriID, @yazarID, @baslik, @ozet, @icerik, @kapakResmi, @eklemeTarihi, @begeniSayi, @goruntulemeSayi, @aktif, @silinmis) ";
                // cmd.CommandText = "INSERT INTO Makaleler(KateogriID, YazarID, Baslik, Ozet, Icerik, KapakResmi, EklemeTarihi, BegeniSayi, GoruntulemeSayi, Aktif, Silinmis) Values (@kategoriID, @yazarID, @baslik, @ozet, @icerik, @kapakResmi, @eklemeTarihi, @begeniSayi, @goruntulemeSayi, @aktif, @silinmis) ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@yazarID", mak.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResmi", mak.KapakResmi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarihi);
                //cmd.Parameters.AddWithValue("@guncellemeTarihi", mak.GuncellemeTarih);
                cmd.Parameters.AddWithValue("@begeniSayi", mak.BegeniSayi);
                cmd.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                cmd.Parameters.AddWithValue("@aktif", mak.Aktif);
                cmd.Parameters.AddWithValue("@silinmis", mak.Silinmis);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makale> MakaleListeleme()
        {
            List<Makale> makaleler = new List<Makale>();

            try
            {
                cmd.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, KADI.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.EklemeTarihi, M.GuncellenmeTarihi, M.BegeniSayi, M.GoruntulemeSayi, M.Aktif, M.Silinmis From Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Kullanici AS KADI ON M.YazarID = KADI.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yazar_ID = reader.GetInt32(3);
                    mak.Yazar = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResmi = reader.GetString(8);
                    mak.EklemeTarihi = reader.GetDateTime(9);
                    if (!reader.IsDBNull(10))
                    {
                        mak.GuncellemeTarih = reader.GetDateTime(10);
                    }
                    mak.BegeniSayi = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                    mak.GoruntulemeSayi = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
                    mak.Aktif = reader.GetBoolean(13);
                    mak.Silinmis = reader.GetBoolean(14);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Makaleler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void UyeSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Uye WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Uye UyeDuzenlemeBilgileriniGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Soyisim, UyeAdi, EczaneTakmaAdı, Mail, Aktif FROM Uye WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Uye u = new Uye();
                while (reader.Read())
                {
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.Soyisim = reader.GetString(2);
                    u.UyeAdi = reader.GetString(3);
                    u.EczaneTakmaAdi = reader.GetString(4);
                    u.Mail = reader.GetString(5);
                    u.Aktif = reader.GetBoolean(6);
                }
                return u;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeAktifligiGuncelle(Uye uye)
        {
            try
            {
                cmd.CommandText = "UPDATE Uye SET Aktif = @aktif WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", uye.ID);
                cmd.Parameters.AddWithValue("aktif", uye.Aktif);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {

                cmd.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, KADI.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.EklemeTarihi, M.GuncellenmeTarihi, M.BegeniSayi, M.GoruntulemeSayi, M.Aktif, M.Silinmis FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Kullanici AS KADI ON M.YazarID = KADI.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makale mak = new Makale();
                while (reader.Read())
                {
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yazar_ID = reader.GetInt32(3);
                    mak.Yazar = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResmi = reader.GetString(8);
                    mak.EklemeTarihi = reader.GetDateTime(9);
                    if (!reader.IsDBNull(10))
                    {
                        mak.GuncellemeTarih = reader.GetDateTime(10);
                    }
                    mak.BegeniSayi = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                    mak.GoruntulemeSayi = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
                    mak.Aktif = reader.GetBoolean(13);
                    mak.Silinmis = reader.GetBoolean(14);
                }
                return mak;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleGuncelle(Makale mak)
        {
            try
            {
                cmd.CommandText = "Update Makaleler SET KategoriID = @kategoriID, Baslik = @baslik, Ozet = @ozet, Icerik = @icerik, KapakResmi = @kapakresmi, GuncellenmeTarihi=@guncellenmetarihi, Aktif = @aktif WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", mak.ID);
                cmd.Parameters.AddWithValue("@kategoriID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakresmi", mak.KapakResmi);
                cmd.Parameters.AddWithValue("@guncellenmetarihi", mak.GuncellemeTarih);
                cmd.Parameters.AddWithValue("@aktif", mak.Aktif);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Uye Metotları

        public bool UyeOl(Uye model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uye(Isim, Soyisim, UyeAdi, Sifre, EczaneTakmaAdı, EczaneSifre, Mail, OlusturulmaTarihi, Aktif, Silinmis) VALUES (@isim, @soyisim, @uyeAdi, @sifre, @eczaneTakmaAdi, @eczaneSifre, @mail, @olusturulmaTarihi, @aktif, @silinmis)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", model.Isim);
                cmd.Parameters.AddWithValue("@soyisim", model.Soyisim);
                cmd.Parameters.AddWithValue("@uyeAdi", model.UyeAdi);
                cmd.Parameters.AddWithValue("@sifre", model.Sifre);
                cmd.Parameters.AddWithValue("@eczaneTakmaAdi", model.EczaneTakmaAdi);
                cmd.Parameters.AddWithValue("@eczaneSifre", model.EczaneSifre);
                cmd.Parameters.AddWithValue("@mail", model.Mail);
                cmd.Parameters.AddWithValue("@olusturulmaTarihi", model.OlusturulmaTarihi);
                cmd.Parameters.AddWithValue("@aktif", model.Aktif);
                cmd.Parameters.AddWithValue("@silinmis", model.Silinmis);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Uye UyeGiris(string uyeAdi, string sifre, string eczaneTakmaAdi, string eczaneSifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uye WHERE UyeAdi = @uyeAdi AND Sifre = @sifre AND EczaneTakmaAdı = @eczaneTakmaAdi AND EczaneSifre = @eczaneSifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeAdi", uyeAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                cmd.Parameters.AddWithValue("@eczaneTakmaAdi", eczaneTakmaAdi);
                cmd.Parameters.AddWithValue("@eczaneSifre", eczaneSifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT * FROM Uye WHERE UyeAdi = @uyeAdi AND Sifre = @sifre AND EczaneTakmaAdı = @eczaneTakmaAdi AND EczaneSifre = @eczaneSifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@uyeAdi", uyeAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    cmd.Parameters.AddWithValue("@eczaneTakmaAdi", eczaneTakmaAdi);
                    cmd.Parameters.AddWithValue("@eczaneSifre", eczaneSifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        //u.YetkiliTur_ID = reader.GetInt32(1);
                        u.Isim = reader.GetString(2);
                        u.Soyisim = reader.GetString(3);
                        u.UyeAdi = reader.GetString(4);
                        u.Sifre = reader.GetString(5);
                        u.EczaneTakmaAdi = reader.GetString(6);
                        u.EczaneSifre = reader.GetString(7);
                        u.Mail = reader.GetString(8);
                        u.OlusturulmaTarihi = reader.GetDateTime(9);
                        u.Aktif = reader.GetBoolean(10);
                        u.Silinmis = reader.GetBoolean(11);
                    }
                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Uye> UyeListele()
        {
            try
            {
                List<Uye> uyeler = new List<Uye>();
                cmd.CommandText = "SELECT ID, Isim, Soyisim, UyeAdi, Mail, OlusturulmaTarihi, Aktif, Silinmis FROM Uye";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uye u = new Uye();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.Soyisim = reader.GetString(2);
                    u.UyeAdi = reader.GetString(3);
                    u.Mail = reader.GetString(4);
                    u.OlusturulmaTarihi = reader.GetDateTime(5);
                    u.Aktif = reader.GetBoolean(6);
                    u.Silinmis = reader.GetBoolean(7);
                    uyeler.Add(u);
                }
                return uyeler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        // İlk önce hepsi için farklı getir metodu yap. Olmazsa hepsini bir arada yapmayı dene.
        // UyeID çekemiyorum!!!
        #region Üstteki Bilgi (UyeBilgileriGetir, EczaneBilgileriGetir, IlacBilgileriGetir)

        public Uye UgeBilgileriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Soyisim, UyeAdi, Sifre, EczaneTakmaAdı, EczaneSifre, Mail, OlusturulmaTarihi FROM Uye WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Uye uye = new Uye();
                while (reader.Read())
                {
                    uye.ID = reader.GetInt32(0);
                    uye.Isim = reader.GetString(1);
                    uye.Soyisim = reader.GetString(2);
                    uye.UyeAdi = reader.GetString(3);
                    uye.Sifre = reader.GetString(4);
                    uye.EczaneTakmaAdi = reader.GetString(5);
                    uye.EczaneSifre = reader.GetString(6);
                    uye.Mail = reader.GetString(7);
                    uye.OlusturulmaTarihi = reader.GetDateTime(8);
                }
                return uye;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        //public bool UyeBilgileriniGuncelle(Uye uye)
        //{
        //    try
        //    {
        //        cmd.CommandText = "UPDATE Uye SET Isim = @isim, Soyisim = @soyisim, UyeAdi = @uyeadi, Sifre = @sifre, Mail = @mail WHERE ID = @id";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@id", uye.ID);
        //        cmd.Parameters.AddWithValue("@isim", uye.Isim);
        //        cmd.Parameters.AddWithValue("@soyisim", uye.Soyisim);
        //        cmd.Parameters.AddWithValue("@uyeadi",uye.UyeAdi);
        //        cmd.Parameters.AddWithValue("@sifre", uye.Sifre);
        //        cmd.Parameters.AddWithValue("@mail", uye.Mail);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        public Eczaneler EczaneBilgileriGetir(int uyeID)
        {
            try
            {
                cmd.CommandText = "SELECT ID, UyeID, Isim, Konum, Resim, IlacSayisi FROM Eczaneler WHERE UyeID = @uyeid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeid", uyeID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Eczaneler eczane = new Eczaneler();
                while (reader.Read())
                {
                    eczane.ID = reader.GetInt32(0);
                    eczane.UyeID = reader.GetInt32(1);
                    eczane.Isim = reader.GetString(2);
                    eczane.Konum = reader.GetString(3);
                    eczane.Resim = reader.GetString(4);
                    eczane.IlacSayisi = reader.GetInt64(5);
                    //eczane.IlacSayisi = Convert.ToInt64(reader.GetInt32(5));

                }
                return eczane;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        //public bool EczaneBilgileriniGuncelle(Eczaneler eczane)
        //{
        //    try
        //    {
        //        cmd.CommandText = "UPDATE Eczaneler SET Isim = @isim, Konum = @konum, Resim = @resim, IlacSayisi = @ilacSayisi WHERE UyeID = @uyeid";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@uyeid", eczane.UyeID);
        //        cmd.Parameters.AddWithValue("@isim", eczane.Isim);
        //        cmd.Parameters.AddWithValue("@konum", eczane.Konum);
        //        cmd.Parameters.AddWithValue("@resim", eczane.Resim);
        //        cmd.Parameters.AddWithValue("@ilacSayisi", eczane.IlacSayisi);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //public Eczaneler EczaneBilgiGuncelle(int UyeID, string isim, string konum, string resim, Int64 ilacsayisi)
        //{
        //    try
        //    {
        //        cmd.CommandText = "UPDATE Eczaneler SET Isim = @isim, Konum = @konum, Resim = @resim, IlacSayisi = @ilacSayisi WHERE UyeID = @uyeid";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@uyeid", UyeID);
        //        cmd.Parameters.AddWithValue("@isim", isim);
        //        cmd.Parameters.AddWithValue("@konum", konum);
        //        cmd.Parameters.AddWithValue("@resim", resim);
        //        cmd.Parameters.AddWithValue("@ilacSayisi", ilacsayisi);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        Eczaneler eczaneler = new Eczaneler();  
        //        return eczaneler;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        public Ilaclar IlacBilgileriGetir(int eczaneID)
        {
            try
            {
                cmd.CommandText = "SELECT ID, EczaneID, Isim, Marka, Aciklama, Fiyat, Kategori FROM Ilaclar WHERE EczaneID = @eczaneID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eczaneID", eczaneID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Ilaclar ilaclar = new Ilaclar();
                while (reader.Read())
                {
                    ilaclar.ID = reader.GetInt32(0);
                    ilaclar.EczaneID = reader.GetInt32(1);
                    ilaclar.Isim = reader.GetString(2);
                    ilaclar.Marka = reader.GetString(3);
                    ilaclar.Aciklama = reader.GetString(4);
                    ilaclar.Fiyat = reader.GetInt32(5);
                    ilaclar.Kategori = reader.GetString(6);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        //public Ilaclar IlacEkleme(int eczaneID)
        //{
        //    try
        //    {
        //        cmd.CommandText = ""
        //    }
        //    catch 
        //    {
        //        return null;
        //    }
        //    finally 
        //    {
        //        con.Close();
        //    }
        //}

        //public Eczaneler IlaclarEczaneIDcekmeDeneme(int EczaneID)
        //{
        //    try
        //    {



        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close() ;
        //    }
        //}

        public Ilaclar IlacEczaneIDGetir(int uID)
        {
            try
            {
                cmd.CommandText = "SELECT U.ID, U.Isim, E.ID, E.UyeID, E.Isim, I.ID, I.Isim, I.Marka, I.EczaneID FROM Uye AS U JOIN Eczaneler AS E ON U.ID = E.UyeID JOIN Ilaclar AS I ON E.ID = I.EczaneID WHERE U.ID = @uyeID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeID", uID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Ilaclar ilaclar = new Ilaclar();
                while (reader.Read())
                {
                    ilaclar.ID = reader.GetInt32(0);
                    ilaclar.Isim = reader.GetString(1);
                    ilaclar.Marka = reader.GetString(2);
                    ilaclar.EczaneID = reader.GetInt32(3);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }



        public List<Ilaclar> BunyeIlacListele(int eczaneID)// Burada geri dönen ID Uyenin ID'si o da 6
        {
            List<Ilaclar> ilaclar = new List<Ilaclar>();
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Marka, Aciklama, Kategori FROM Ilaclar WHERE EczaneID = @eczaneid ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eczaneid", eczaneID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ilaclar ilac = new Ilaclar();
                    ilac.ID = reader.GetInt32(0);
                    ilac.Isim = reader.GetString(1);
                    ilac.Marka = reader.GetString(2);
                    ilac.Aciklama = reader.GetString(3);
                    ilac.Kategori = reader.GetString(4);
                    ilaclar.Add(ilac);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        //public Ilaclar IlaclarinListesi(int eczaneID)
        //{
        //    try
        //    {
        //        cmd.CommandText = "SELECT ID, Isim, Marka, Aciklama, Kategori FROM Ilaclar Where EczaneID = @eczaneID";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@eczaneID", eczaneID);
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        Ilaclar ilaclar = new Ilaclar();
        //        while (reader.Read())
        //        {
        //            Ilaclar ilac = new Ilaclar();
        //            ilac.ID = reader.GetInt32(0);
        //            ilac.Isim = reader.GetString (1);
        //            ilac.Marka = reader.GetString(2);
        //            ilac.Aciklama= reader.GetString(3);
        //            ilac.Kategori = reader.GetString(4);
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}


        // BUNLARA DİKKAT ET. BU KISIM OLMAYABİLİR.


        #endregion

        #region Ilac Metotları

        public List<Ilaclar> IlacArama(string IlacIsim)
        {
            List<Ilaclar> ilaclar = new List<Ilaclar>();
            try
            {
                cmd.CommandText = "SELECT ID, EczaneID, Isim, Marka, Aciklama, Fiyat, Kategori FROM Ilaclar WHERE Isim LIKE '" + IlacIsim + "%'";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ilaclar ilac = new Ilaclar();
                    ilac.ID = reader.GetInt32(0);
                    ilac.EczaneID = reader.GetInt32(1);
                    ilac.Isim = reader.GetString(2);
                    ilac.Marka = reader.GetString(3);
                    ilac.Aciklama = reader.GetString(4);
                    ilac.Fiyat = reader.GetDecimal(5);
                    ilac.Kategori = reader.GetString(6);
                    ilaclar.Add(ilac);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Ilaclar> IlacListeleme(string IlacIsim)
        {
            List<Ilaclar> ilaclar = new List<Ilaclar>();
            try
            {
                cmd.CommandText = "SELECT ID, EczaneID, Isim, Marka, Aciklama, Fiyat, Kategori FROM Ilaclar WHERE Isim LIKE '" + IlacIsim + "%'";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ilaclar ilac = new Ilaclar();
                    ilac.ID = reader.GetInt32(0);
                    ilac.EczaneID = reader.GetInt32(1);
                    ilac.Isim = reader.GetString(2);
                    ilac.Marka = reader.GetString(3);
                    ilac.Aciklama = reader.GetString(4);
                    ilac.Fiyat = reader.GetDecimal(5);
                    ilac.Kategori = reader.GetString(6);
                    ilaclar.Add(ilac);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Ilaclar Ilac(string ilacisim)
        {
            try
            {

                cmd.CommandText = "SELECT ID, EczaneID, Isim, Marka, Aciklama, Fiyat, Kategori FROM Ilaclar WHERE Isim LIKE '" + ilacisim + "%'";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Ilaclar ilaclar = new Ilaclar();
                while (reader.Read())
                {
                    ilaclar.ID = reader.GetInt32(0);
                    ilaclar.EczaneID = reader.GetInt32(1);
                    ilaclar.Isim = reader.GetString(2);
                    ilaclar.Marka = reader.GetString(3);
                    ilaclar.Aciklama = reader.GetString(4);
                    ilaclar.Fiyat = reader.GetDecimal(5);
                    ilaclar.Kategori = reader.GetString(6);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Ilaclar IlaclarıGetir(string ilacisim)
        {
            try
            {

                cmd.CommandText = "SELECT I.ID, I.EczaneID, I.Isim, I.Marka, I.Aciklama,I.Fiyat, I.Kategori, E.UyeID, E.Isim, E.Konum, E.Resim, E.IlacSayisi, U.Isim, U.Soyisim, U.UyeAdi, U.Sifre, U.EczaneTakmaAdı, U.EczaneSifre, U.Mail, U.OlusturulmaTarihi FROM Ilaclar AS I JOIN Eczaneler AS E ON I.EczaneID = E.ID JOIN Uye AS U ON E.UyeID = U.ID WHERE I.Isim LIKE '" + ilacisim + "%' ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Ilaclar ilaclar = new Ilaclar();
                while (reader.Read())
                {
                    ilaclar.ID = reader.GetInt32(0);
                    ilaclar.EczaneID = reader.GetInt32(1);
                    ilaclar.Isim = reader.GetString(2);
                    ilaclar.Marka = reader.GetString(3);
                    ilaclar.Aciklama = reader.GetString(4);
                    ilaclar.Fiyat = reader.GetDecimal(5);
                    ilaclar.Kategori = reader.GetString(6);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Ilaclar IlacBilgiDetay(int id)
        {
            try
            {
                cmd.CommandText = "SELECT I.ID, I.EczaneID, I.Isim, I.Marka, I.Kategori, I.Aciklama, E.ID, E.Isim, E.Konum FROM Ilaclar AS I JOIN Eczaneler AS E ON I.EczaneID = E.ID WHERE I.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Ilaclar ilac = new Ilaclar();
                while (reader.Read())
                {
                    ilac.ID = reader.GetInt32(0);
                    ilac.EczaneID = reader.GetInt32(1);
                    ilac.Isim = reader.GetString(2);
                    ilac.Marka = reader.GetString(3);
                    ilac.Kategori = reader.GetString(4);
                    ilac.Aciklama = reader.GetString(5);
                }
                return ilac;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Eczaneler EczaneIDCekmeDeneme(int id)
        {
            try
            {
                cmd.CommandText = "SELECT E.ID, E.Isim, E.Konum, I.EczaneID, I.ID FROM Eczaneler AS E JOIN Ilaclar AS I ON E.ID = I.EczaneID WHERE I.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Eczaneler eczaneler = new Eczaneler();
                while (reader.Read())
                {
                    eczaneler.ID = reader.GetInt32(0);
                    eczaneler.Isim = reader.GetString(1);
                    eczaneler.Konum = reader.GetString(2);
                }
                return eczaneler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region ID getirme işlemleri

        public Eczaneler EczaneColumnUyeIDCekmeDeneme(int UyeColumnID)
        {
            try
            {
                cmd.CommandText = "SELECT U.ID, U.Isim, U.Soyisim, E.ID, E.UyeID, E.Isim FROM Uye AS U JOIN Eczaneler AS E ON U.ID = E.UyeID WHERE U.ID = @UyeColumnID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UyeColumnID", UyeColumnID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Eczaneler eczaneler = new Eczaneler();
                while (reader.Read())
                {
                    eczaneler.ID = reader.GetInt32(3);
                    eczaneler.UyeID = reader.GetInt32(4);
                    eczaneler.Isim = reader.GetString(5);
                }
                return eczaneler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Ilaclar IlaclarColumnEczaneIDCekmeDeneme(int EczaneColumnID)
        {
            try
            {
                cmd.CommandText = "SELECT E.ID, E.UyeID, E.Isim, I.ID, I.EczaneID, I.Isim FROM Eczaneler AS E JOIN Ilaclar AS I ON E.ID = I.EczaneID WHERE E.ID = @EczaneColumnID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EczaneColumnID", EczaneColumnID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Ilaclar ilaclar = new Ilaclar();
                while (reader.Read())
                {
                    ilaclar.ID = reader.GetInt32(3);
                    ilaclar.EczaneID = reader.GetInt32(4);
                    ilaclar.Isim = reader.GetString(5);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool IlacEkle(Ilaclar ilaclar)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Ilaclar(EczaneID, Isim, Marka, Aciklama, Kategori, Fiyat) VALUES (@eczaneID, @isim, @marka, @aciklama, @kategori,@fiyat)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eczaneID", ilaclar.EczaneID);
                cmd.Parameters.AddWithValue("@isim", ilaclar.Isim);
                cmd.Parameters.AddWithValue("@marka", ilaclar.Marka);
                cmd.Parameters.AddWithValue("@aciklama", ilaclar.Aciklama);
                cmd.Parameters.AddWithValue("@kategori", ilaclar.Kategori);
                cmd.Parameters.AddWithValue("@fiyat", ilaclar.Fiyat);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        public Ilaclar IlacBilgileriniGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Marka, Kategori, Aciklama FROM Ilaclar WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Ilaclar ilaclar = new Ilaclar();
                while (reader.Read())
                {
                    ilaclar.ID = reader.GetInt32(0);
                    ilaclar.Isim = reader.GetString(1);
                    ilaclar.Marka = reader.GetString(2);
                    ilaclar.Kategori = reader.GetString(3);
                    ilaclar.Aciklama = reader.GetString(4);
                }
                return ilaclar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool IlacBilgileriniGuncelle(Ilaclar ilaclar)
        {
            try
            {
                cmd.CommandText = "UPDATE Ilaclar SET Isim = @Isim, Marka = @Marka, Aciklama = @Aciklama, Fiyat = @Fiyat, Kategori = @Kategori WHERE ID = @id";
                cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@id", ilaclar.ID);
                //cmd.Parameters.AddWithValue("@Isim", ilaclar.Isim);
                //cmd.Parameters.AddWithValue("@Marka", ilaclar.Marka);
                //cmd.Parameters.AddWithValue("@Aciklama", ilaclar.Aciklama);
                //cmd.Parameters.AddWithValue("@Fiyat", ilaclar.Fiyat);
                //cmd.Parameters.AddWithValue("@Kategori", ilaclar.Kategori);
                cmd.Parameters.AddWithValue("@Isim", ilaclar.Isim);
                cmd.Parameters.AddWithValue("@Marka", ilaclar.Marka);
                cmd.Parameters.AddWithValue("@Aciklama", ilaclar.Aciklama);
                cmd.Parameters.AddWithValue("@Fiyat", ilaclar.Fiyat);
                cmd.Parameters.AddWithValue("@Kategori", ilaclar.Kategori);
                cmd.Parameters.AddWithValue("@id", ilaclar.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        //public void KategoriSil(int id)
        //{
        //    try
        //    {
        //        cmd.CommandText = "DELETE FROM Kategoriler WHERE ID = @id";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@id", id);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        public void IlacSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Ilaclar WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

    }

}
