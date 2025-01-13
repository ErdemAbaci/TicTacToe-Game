using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Tictac : Form
    {
        public enum Oyuncu
        {
            X , O             // Sabit değerler tanımlanıyor.
        }
        Oyuncu simdikiOyuncu;
        Random random = new Random();
        int oyuncuwin = 0;
        int pcwin = 0;                //Skor durumu için değerler giriliyor.
        List<Button> buttons;         // Butonları tutan liste.
        int oyunHamleSayisi = 0;      // Beraberlik durumu için kullanılan değer.
        
        public Tictac()
        {
            InitializeComponent();
            YenidenBaslat();      // Açıldığında sıfırlanması için metot çalışıyor.
        }

        private void PCOyun(object sender, EventArgs e)
        {
            if (buttons.Count>0)  // Button kaldıysa çalışır
            {
                int index = random.Next(buttons.Count); // Rastgele sayı seçiyor.
                buttons[index].Enabled = false;   // Butonu devre dışı bırakıyor.
                simdikiOyuncu = Oyuncu.O;         // O değerini atıyor
                buttons[index].Text = simdikiOyuncu.ToString(); // Metni O olarak değiştirme.
                buttons[index].BackColor = Color.DarkRed;  // Renk değiştirme.
                buttons.RemoveAt(index);    // Butonu listeden çıkarıyoruz.
                oyunHamleSayisi++;          
                CheckGame();                // Oyun durum kontrolü
                PCTimer.Stop();             // Hamle bitimi sonrası zamanlayıcı durdurur.

            }
        }

       
        private void OyuncuTıklama(object sender, EventArgs e)
        {
            var button = (Button)sender;
            simdikiOyuncu = Oyuncu.X;
            button.Text = simdikiOyuncu.ToString();   // Metin değiştirme
            button.Enabled = false;                   // Butonu devre dışı bırakma.
            button.BackColor = Color.Aqua;            // Renk değiştirme
            buttons.Remove(button);                   // Listeden çıkarma
            oyunHamleSayisi++;       
            CheckGame();                              // Oyun durum kontrolü
            PCTimer.Start();                          // Hamleden sonra zamanlayıcıyı başlat.
        }

        private void YenidenBaslat(object sender, EventArgs e)
        {
            YenidenBaslat();  //Butona tıklandığında yeniden başlatılması için.
        }
        // Oyun durum kontrolü için CheckGame
        private void CheckGame()
        {
            // Oyuncunun kazanması için olması gerekenler if bloğuna tanımlandı.
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                PCTimer.Stop();
                MessageBox.Show("Oyuncu Kazandı");
                oyuncuwin++;
                label1.Text = "Oyuncu Kazanma: " + oyuncuwin;
                YenidenBaslat();
            }
            // PC kazanması için gereken şartlar else if bloğuna tanımlandı.
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                PCTimer.Stop();
                MessageBox.Show("PC Kazandı");
                pcwin++;
                label2.Text = "PC Kazanma: " + pcwin;
                YenidenBaslat();
            }
            // Beraberlik durumu kontrolü
            else if (oyunHamleSayisi == 9)
            {
                PCTimer.Stop();
                MessageBox.Show("Beraberlik!");
                YenidenBaslat();
            }


        }

        private void YenidenBaslat()
        {
            //Tüm butonları geri eski haline çevirme işlemi
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            oyunHamleSayisi = 0; // Oyun yeniden başlatıldığında hamle sayısı sıfırlama.
            foreach (var x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
            
        }

       
    }
}
