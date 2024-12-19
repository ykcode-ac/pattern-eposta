using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pattern_eposta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan e-posta adresi
            string email = txtEmail.Text;

            // Hata mesajlarını tutmak için string değişken
            string errorMessage = "";

            // Regex desenini güncelleme
            string userNamePattern = @"^[a-zA-Z0-9._-]{6,}";  // Kullanıcı adı en az 6 karakter olmalı
            string domainPattern = @"@[a-zA-Z0-9-]{2,}";      // Domain en az 2 karakter olmalı
            string extensionPattern = @"\.[a-zA-Z]{2,}$";      // Uzantı en az 2 karakter olmalı

            // Kullanıcı adı kontrolü
            if (!Regex.IsMatch(email, userNamePattern))
            {
                errorMessage += "- Kullanıcı adı en az 6 karakter olmalı.\n";
            }

            // Domain kontrolü
            if (!Regex.IsMatch(email, domainPattern))
            {
                errorMessage += "- Domain en az 2 karakter olmalı.\n";
            }

            // Uzantı kontrolü
            if (!Regex.IsMatch(email, extensionPattern))
            {
                errorMessage += "- Uzantı en az 2 karakter olmalı.\n";
            }

            // Eğer herhangi bir hata varsa, mesaj göster
            if (errorMessage != "")
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi girin:\n\n" + errorMessage,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("E-posta adresi geçerlidir.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
