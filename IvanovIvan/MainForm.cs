using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IvanovIvan.UsersClasses;

namespace IvanovIvan
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxEmail.Text = "ivan.ivanov2036@mail.ru";
            textBoxName.Text = "Иванов Иван";        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(textBoxName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
                    string.IsNullOrWhiteSpace(textBoxBody.Text))
                    {
                MessageBox.Show("Заполните все поля");
                return;
            }
            String smtp = "smtp.mail.ru";
            StringPair fromInfo = new StringPair("почта", "ФИО Студента");
            string password = "Xyykpxi4khrTDw8s139y";
            StringPair toInfo =new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now}\n" +
            $"{ Dns.GetHostName()}\n"+
            $"{ Dns.GetHostAddresses(Dns.GetHostName()).First()} \n"+
            $"{ textBoxBody.Text}";
            var info = new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();
            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
