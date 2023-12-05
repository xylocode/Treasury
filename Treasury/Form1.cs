using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XyloCode.Tools.Treasury
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var dt = DateTime.Now.Date;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dt = dt.AddDays(-2);
                    break;
                case DayOfWeek.Monday:
                    dt = dt.AddDays(-3);
                    break;
                default:
                    dt = dt.AddDays(-1);
                    break;
            }
            dateTimePicker1.Value = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;

            if (!Directory.Exists(textBox1.Text))
                toolStripStatusLabel1.Text = "Не задана директория выгурзки XML-файлов.";
            else
                toolStripStatusLabel1.Text = "Директория выгурзки XML-файлов задана.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
            {
                toolStripStatusLabel1.Text = "Не задана директория выгурзки XML-файлов.";
                return;
            }

            var exe = new TreasuryProcessing(textBox1.Text, dateTimePicker1.Value);
            exe.Run();
            if (exe.Data.Count > 0)
            {
                exe.Create1C();
                var sw = new StreamWriter(textBox1.Text + "\\1C-FederalTreasury.txt", false, Encoding.GetEncoding(1251));
                sw.Write(exe.ClientBankExchange);
                sw.Close();
                sw.Dispose();
                toolStripStatusLabel1.Text = "Осуществлена выгрузка данных в формате 1CClientBankExchange.";
            }
            else
            {
                toolStripStatusLabel1.Text = "Данные для формирования выгрузки отсутствуют.";
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Федеральное казначейство");
            sb.AppendLine("Конвертер данных XML – 1CClientBankExchange");
            sb.AppendLine("Copyright ©  2022 Коробейников Сергей Николаевич");
            sb.AppendLine("welcome@xylocode.com");
            sb.AppendLine("www.xylocode.ru");
            MessageBox.Show(sb.ToString(), caption: "О программе");
        }
    }
}
