using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmacaaa
{
    public partial class Form1 : Form
    {
        // Türkiye şehirlerinden oluşan kelime listesi
        #region Veriable
        List<string> words = new List<string> { "adana","adıyaman","afyonkarahisar","aksaray","amasya","ankara","antalya","ardahan","artvin","aydın","ağrı","balıkesir","bartın","batman","bayburt","bilecik","bingöl","bitlis","bolu","burdur","bursa","denizli","diyarbakır","düzce","edirne","elazığ","erzincan","erzurum","eskişehir","gaziantep","giresun","gümüşhane","hakkâri","hatay","ısparta","ığdır","kahramanmaraş","karabük","karaman","kars","kastamonu","kayseri","kilis","kocaeli","konya","kütahya","kırklareli","kırıkkale","kırşehir","malatya","manisa","mardin","mersin","muğla","muş","nevşehir","niğde","ordu","osmaniye","rize","sakarya","samsun","siirt","sinop","sivas","tekirdağ","tokat","trabzon","tunceli","uşak","van","yalova","yozgat","zonguldak",
        "çanakkale","çankırı","çorum","istanbul","izmir","şanlıurfa","şırnak" };
        int incorretGuess;
        Random random;
        String selectedWord;
        char[] displayWord;
        private int incorrectGuess;
        #endregion
        public Form1()
        {
            // Form bileşenlerini başlatır
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Yanlış tahmin sayısı için değişken
            incorretGuess = 0;
            // Rastgele kelime seçimi için kullanılan Random sınıfı
            random = new Random();
            // Seçilen kelime (tahmin edilmesi gereken kelime)
            selectedWord = words[random.Next(words.Count)];
            // Seçilen kelimenin uzunluğunda alt çizgi karakterlerinden oluşan bir dizi oluştur
            displayWord = new string('_', selectedWord.Length).ToCharArray();
            // Alt çizgileri boşluk ile ayırarak ekranda görüntüle
            string formattedDisplayWord = string.Join(" ", displayWord);
            lblWordDisplay.Text = formattedDisplayWord;

        }
        // "Tahmin Et" butonuna basıldığında çalışacak olay
        private void btnGuess_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği harfi al ve küçük harfe çevi
            char guess = tbGuess.Text.ToLower()[0];
            // Doğru tahmin yapılıp yapılmadığını izlemek için bayrak
            bool correctGuess = false;
            // Seçilen kelimedeki harfleri kontrol et
            for (int i = 0; i < selectedWord.Length; i++)
            {
                // Eğer tahmin edilen harf seçilen kelimedeki bir harfe eşitse

                if (selectedWord[i] == guess)
                {
                    // Doğru tahmin edilen harfi alt çizginin yerine yerleştir
                    displayWord[i] = guess;
                    correctGuess = true;
                }

            }
            // Güncellenmiş kelimeyi ekranda göster
            lblWordDisplay.Text = string.Join(" ", displayWord);
            if (!correctGuess)
            {

                // Adam asmaca görselini güncelle
                UpdateAdamAsmacaImage();
            }
            // Eğer kelimenin tamamı tahmin edildiyse (alt çizgi kalmadıysa)                         
            if (!lblWordDisplay.Text.Contains('_'))
            {
                MessageBox.Show("Tebrikler Kazandınız");
                Application.Restart();
            }

        }
        // Yanlış tahmin sayısına göre Adam Asmaca görselini güncelleyen metot
        private void UpdateAdamAsmacaImage()
        {
            // Yanlış tahmin sayısını artır
            incorrectGuess++;
            // Yanlış tahmin sayısına göre farklı Adam Asmaca resimlerini göster
            switch (incorrectGuess)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources._1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources._5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources._6;
                    break;
                case 7:
                    // 7. yanlış tahminde oyunun bittiğini belirt ve kaybedildiğini bildir
                    pictureBox1.Image = Properties.Resources._7;
                    MessageBox.Show("Kaybettiniz! Kelime Buydu " + selectedWord);
                    // Oyunu baştan başlat
                    Application.Restart();
                    break;
            }

        }
    }
}
