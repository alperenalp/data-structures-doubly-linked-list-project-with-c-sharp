using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev2_cift_yonlu_Link_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Dugum {
            public int numara;
            public string isim;
            public Dugum sonraki;
            public Dugum onceki;
        }
        Dugum ilk = null;
        Dugum son = null;
        private void listeyiYazdir_Click(object sender, EventArgs e)
        {
            if (ilk==null)
            {
                richTextBox1.Text = "null";
            }
            else
            {
                richTextBox1.Text = null;
                Dugum isaretci = ilk;
                richTextBox1.Text = "null <--- ";
                while (isaretci != null)
                {
                    richTextBox1.Text += Convert.ToString(isaretci.isim + " : " + isaretci.numara + " ---> ");
                    isaretci = isaretci.sonraki;
                }
                richTextBox1.Text += " null";
            }
        }

        private void BasaEkle_Click(object sender, EventArgs e)
        {
            Dugum yeni = new Dugum();
            yeni.numara = Convert.ToInt32(textBox1.Text);
            yeni.isim = textBox2.Text;
            if (ilk==null)  // liste boşsa
            {
                ilk = yeni;
                son = yeni;
            }
            else
            {
                ilk.onceki = yeni;
                yeni.sonraki = ilk;
                ilk = yeni;
                ilk.onceki = null;
            }
        }

        private void sonaEkle_Click(object sender, EventArgs e)
        {
            Dugum yeni = new Dugum();
            yeni.numara = Convert.ToInt32(textBox1.Text);
            yeni.isim = textBox2.Text;
            if (ilk==null)
            {
                ilk = yeni;
                son = yeni;
            }
            else
            {
                son.sonraki = yeni;
                yeni.onceki = son;
                son = yeni;
                son.sonraki = null;
            }
        }

        private void arayaEkle_Click(object sender, EventArgs e)
        {
            Dugum yeni = new Dugum();
            yeni.numara = Convert.ToInt32(textBox1.Text);
            yeni.isim = textBox2.Text;
            if (ilk==null)
            {
                ilk = yeni;
                son = yeni;
            }
            else if (ilk==son) // tek eleman varsa
            {
                Dugum isaretci = ilk;
                while (isaretci != null)
                {
                    if (yeni.numara > isaretci.numara) // tek eleman oldugu icin sona ekleme yapar
                    {
                        son.sonraki = yeni;
                        yeni.onceki = son;
                        son = yeni;
                        son.sonraki = null;
                        break;
                    }
                    if(yeni.numara==isaretci.numara)
                    {
                        richTextBox1.Text = "Eklemek istediğiniz numara mevcut";
                        break;
                    }
                    isaretci = isaretci.sonraki;
                }


            }
            else // ikiden fazla eleman varsa
            {
                Dugum isaretci1 = null;
                Dugum isaretci2 = ilk;
                while (isaretci2!=null)
                {
                    if (yeni.numara < isaretci2.numara)  // araya ve başa ekler
                    {
                        if (isaretci2==ilk)
                        {
                            ilk.onceki = yeni;
                            yeni.sonraki = ilk;
                            ilk = yeni;
                            ilk.onceki = null;
                        }
                        else
                        {
                            isaretci1.sonraki = yeni;
                            yeni.onceki = isaretci1;
                            isaretci2.onceki = yeni;
                            yeni.sonraki = isaretci2;
                        }
                        break;
                    }
                    if (yeni.numara > isaretci2.numara && isaretci2.sonraki==null)  // sona ekler
                    {
                        son.sonraki = yeni;
                        yeni.onceki = son;
                        son = yeni;
                        son.sonraki = null;
                        break;
                    }
                    if (yeni.numara == isaretci2.numara)
                    {
                        richTextBox1.Text = "Eklemek istediğiniz numara mevcut";
                        break;
                    }
                    isaretci1 = isaretci2;
                    isaretci2 = isaretci2.sonraki;
                }
            }
        }

        private void bastanSil_Click(object sender, EventArgs e)
        {
            if (ilk==son)  // tek eleman varsa
            {
                ilk = null;
                son = null;
            }
            else
            {
                ilk = ilk.sonraki;
                ilk.onceki = null;
            }
        }

        private void sondanSil_Click(object sender, EventArgs e)
        {
            if (ilk == son)
            {
                ilk = null;
                son = null;
            }
            else
            {
                son = son.onceki;
                son.sonraki = null;
            }
        }

        private void aradanSil_Click(object sender, EventArgs e)
        {
            
            int silincekNo = Convert.ToInt32(textBox1.Text);
            int Kontrol = 0;
            if (ilk.numara == silincekNo)
            {
                ilk = ilk.sonraki;
            }
            else
            {
                Dugum isaretci1 = null; // bir onceki dugumu bulmak icin gerekli
                Dugum isaretci2 = ilk;
                Dugum isaretci3 = ilk.sonraki;  // bir sonraki dugumu bulmak icin gerekli
                while (isaretci2!=null)
                {
                    if (isaretci2.numara==silincekNo && isaretci2.sonraki !=null)  //sondakini silemez
                    {
                        isaretci1.sonraki = isaretci2.sonraki;
                        isaretci2.sonraki.onceki = isaretci1;
                    }
                    if (isaretci2.numara==silincekNo && isaretci2.sonraki==null)  //sondakini siler
                    {
                        son = son.onceki;
                        son.sonraki = null;
                    }

                    isaretci1 = isaretci2;
                    isaretci2 = isaretci2.sonraki;
                }
            }
            
        }
    }
}

/*
 * 
 * while (isaretci2 != null)  // Silinecek Numaranın adedini kontrol eder
            {
                if (isaretci2.numara == silincekNo)
                {
                    Kontrol++;
                }
                isaretci2 = isaretci2.sonraki;
            }
            for (int i = 0; i < Kontrol; i++)  // for silinecek numara kadar donmesini saglar
            {
                isaretci1 = null;
                isaretci2 = ilk;
                isaretci3 = ilk.sonraki;
                while (isaretci2 != null)
                {
                    if (ilk == son)
                    {
                        ilk = null;
                        son = null;
                        break;
                    }
                    else
                    {
                        if (silincekNo == isaretci2.numara && isaretci2 == ilk)  // baştan siler
                        {
                            ilk = ilk.sonraki;
                            ilk.onceki = null;
                            break;
                        }
                        if (silincekNo == isaretci2.numara && isaretci2 == son)  // sondan siler
                        {
                            son = son.onceki;
                            son.sonraki = null;
                            break;
                        }
                        if (silincekNo == isaretci2.numara && isaretci2 != ilk && isaretci2 != son)  // aradan siler
                        {
                            isaretci1.sonraki = isaretci3;
                            isaretci3.onceki = isaretci1;
                            break;
                        }
                    }
                    isaretci1 = isaretci2;
                    isaretci2 = isaretci2.sonraki;
                    isaretci3 = isaretci3.sonraki;
                }
            }
*/