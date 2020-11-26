using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace LearnTensesApp
{
    public partial class FormUtama : Form
    {
        /// <summary>
        /// Pendeklarasian attribute yang diperlukan
        /// </summary>
        TextBox[] textBoxes ;
        Label[] labels ;
        List<string> listKunciJawaban = new List<string>();
        KunciJawaban kunciJawaban = new KunciJawaban();
        
        public FormUtama()
        {
            InitializeComponent();
            listKunciJawaban = kunciJawaban.GetKunciJawaban();
            pnlKamus.Visible = false;
            pnlLatihanSoal.Visible = false;
            pnlMateri.Visible = false;
            btnMenuMateri.BackColor = Color.LimeGreen;
            lblDashboard.Text = "Materi";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMenuMateri_Click(object sender, EventArgs e)
        {
            pnlKamus.Visible = false;
            pnlLatihanSoal.Visible = false;
            pnlMateri.Visible = false;
            btnMenuMateri.BackColor = Color.LimeGreen;
            btnMenuKamus.BackColor = Color.DarkBlue;
            btnMenuLatSoal.BackColor = Color.DarkBlue;
            lblDashboard.Text = "Materi";
        }

        private void btnMenuLatSoal_Click(object sender, EventArgs e)
        {
            pnlKamus.Visible = false;
            pnlLatihanSoal.Visible = true;
            pnlMateri.Visible = false;
            btnMenuMateri.BackColor = Color.DarkBlue;
            btnMenuKamus.BackColor = Color.DarkBlue;
            btnMenuLatSoal.BackColor = Color.LimeGreen;
            if (label2.Text == "Kunci Jawaban")
                pnlHasil.Visible = true;
            else
                pnlHasil.Visible = false;
            lblDashboard.Text = "Latihan Soal";
            CreateAnswerSheet();
        }

        private void btnMenuKamus_Click(object sender, EventArgs e)
        {
            pnlKamus.Visible = true;
            pnlLatihanSoal.Visible = false;
            pnlMateri.Visible = false;
            btnMenuMateri.BackColor = Color.DarkBlue;
            btnMenuKamus.BackColor = Color.LimeGreen;
            btnMenuLatSoal.BackColor = Color.DarkBlue;
            lblDashboard.Text = "Kamus";
        }

        private void btnMateriPresentTense_Click(object sender, EventArgs e)
        {
            pnlKamus.Visible = false;
            pnlLatihanSoal.Visible = false;
            pnlMateri.Visible = true;
            btnMenuMateri.BackColor = Color.LimeGreen;
            btnMenuKamus.BackColor = Color.DarkBlue;
            btnMenuLatSoal.BackColor = Color.DarkBlue;
            lblDashboard.Text = "Present Tense";
            LoadVideoMateri();
        }

        private void btnMateriFutureTense_Click(object sender, EventArgs e)
        {
            pnlKamus.Visible = false;
            pnlLatihanSoal.Visible = false;
            pnlMateri.Visible = true;
            btnMenuMateri.BackColor = Color.LimeGreen;
            btnMenuKamus.BackColor = Color.DarkBlue;
            btnMenuLatSoal.BackColor = Color.DarkBlue;
            lblDashboard.Text = "Future Tense";
            LoadVideoMateri();
        }

        private void btnMateriPerfectTense_Click(object sender, EventArgs e)
        {
            pnlKamus.Visible = false;
            pnlLatihanSoal.Visible = false;
            pnlMateri.Visible = true;
            btnMenuMateri.BackColor = Color.LimeGreen;
            btnMenuKamus.BackColor = Color.DarkBlue;
            btnMenuLatSoal.BackColor = Color.DarkBlue;
            lblDashboard.Text = "Perfect Tense";
            LoadVideoMateri();
        }

        private void btnMateriPastTense_Click(object sender, EventArgs e)
        {
            pnlKamus.Visible = false;
            pnlLatihanSoal.Visible = false;
            pnlMateri.Visible = true;
            btnMenuMateri.BackColor = Color.Orange;
            btnMenuKamus.BackColor = Color.Maroon;
            btnMenuLatSoal.BackColor = Color.Maroon;
            lblDashboard.Text = "Past Tense";
            LoadVideoMateri();
        }

        private void btnMateriPresenContinous_Click(object sender, EventArgs e)
        {
            pnlKamus.Visible = false;
            pnlLatihanSoal.Visible = false;
            pnlMateri.Visible = true;
            btnMenuMateri.BackColor = Color.LimeGreen;
            btnMenuKamus.BackColor = Color.DarkBlue;
            btnMenuLatSoal.BackColor = Color.DarkBlue;
            lblDashboard.Text = "Present Continuous Tense";
            LoadVideoMateri();
        }

        private void btnPenerjemah_Click(object sender, EventArgs e)
        {
            Word word = new Word();
            if (lblBahasaTerjemahan.Text == "Indonesia")
            {
                if (word.SpellCheckerWord(rtbKataAsal.Text) == true)
                    rtbHasilKata.Text = word.TranslateWord(rtbKataAsal.Text, "id");
                else
                    MessageBox.Show("Mungkin maksud anda adalah " + word.SuggestionWord(rtbKataAsal.Text));
            }
            else
                rtbHasilKata.Text = word.TranslateWord(rtbKataAsal.Text, "en");
        }

        private void btnTukar_Click(object sender, EventArgs e)
        {
            if(lblBahasaAsal.Text == "Indonesia")
            {
                lblBahasaAsal.Text = "Inggris";
                lblBahasaTerjemahan.Text = "Indonesia";
            }
            else
            {
                lblBahasaAsal.Text = "Indonesia";
                lblBahasaTerjemahan.Text = "Inggris";
            }
        }

        private void btnCekJawaban_Click(object sender, EventArgs e)
        {

            List<string> kunci = new List<string>();
            kunci = kunciJawaban.GetKunciJawaban();
            int nilai = 0;
            for (int i = 0; i < 20; i++)
            {
                if (textBoxes[i].Text == listKunciJawaban[i])
                    nilai = nilai + 10;
                else
                    textBoxes[i].ForeColor = Color.Red;
                textBoxes[i].Text = listKunciJawaban[i];
            }
            int hasil;
            hasil = (nilai * 10) / 20;
            lblHasil.Text = hasil.ToString()+"/100";
            label2.Text = "Kunci Jawaban";
            label3.Hide();
            if (hasil < 70)
                lblGreeting.Text = "Sayang Sekali";
            else
                lblGreeting.Text = "Selamat";
            pnlHasil.Visible = true;
        }

        /// <summary>
        /// Method untuk membuat score sheet 
        /// </summary>
        private void CreateAnswerSheet()
        {
            textBoxes = new TextBox[20];
            labels = new Label[20];
            int k = 0;
            int l = 783;
            int m = 755;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    textBoxes[k] = new TextBox();
                    textBoxes[k].Size = new Size(40, 30);
                    textBoxes[k].Location = new Point(l, 65 + j * 30);
                    pnlLatihanSoal.Controls.Add(textBoxes[k]);
                    labels[k] = new Label();
                    labels[k].Size = new Size(40, 30);
                    labels[k].Text = (k + 1).ToString();
                    labels[k].Location = new Point(m, 65 + j * 30);
                    pnlLatihanSoal.Controls.Add(labels[k]);
                    k++;
                }
                l = l + 200;
                m = m + 200;
            }
        }

        /// <summary>
        /// Method untk mengambil video dari youtube, lalu dimasukkan di form
        /// </summary>
        private void LoadVideoMateri()
        {
            if (lblDashboard.Text == "Present Tense")
            {
                var embed1 = "<html><head>" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
            "</head><body>" +
            "<iframe width=\"890\" iframe height=\"566\" src=\"{0}\"" +
            "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" + "</body></html>";
                var url1 = "https://www.youtube.com/embed/rmmVuMfyKPQ";
                this.wbMateri.DocumentText = string.Format(embed1, url1);
            }
            else if (lblDashboard.Text == "Present Countinuous Tense")
            {
                var embed2 = "<html><head>" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
            "</head><body>" +
            "<iframe width=\"890\" iframe height=\"566\" src=\"{0}\"" +
            "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" + "</body></html>";
                var url2 = "https://www.youtube.com/embed/4q9zRigTXVM";
                this.wbMateri.DocumentText = string.Format(embed2, url2);
            }
            else if (lblDashboard.Text == "Perfect Tense")
            {
                var embed3 = "<html><head>" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
            "</head><body>" +
            "<iframe width=\"890\" iframe height=\"566\" src=\"{0}\"" +
            "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" + "</body></html>";
                var url3 = "https://www.youtube.com/embed/-sEfzeZ1p6Q";
                this.wbMateri.DocumentText = string.Format(embed3, url3);
            }
            else if (lblDashboard.Text == "Past Tense")
            {
                var embed4 = "<html><head>" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
            "</head><body>" +
            "<iframe width=\"890\" iframe height=\"566\" src=\"{0}\"" +
            "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" + "</body></html>";
                var url4 = "https://www.youtube.com/embed/hsquD9Rw7nM";
                this.wbMateri.DocumentText = string.Format(embed4, url4);
            }
            else
            {
                var embed5 = "<html><head>" +
               "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
               "</head><body>" +
               "<iframe width=\"890\" iframe height=\"566\" src=\"{0}\"" +
               "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" + "</body></html>";
                var url5 = "https://www.youtube.com/embed/hB_7Ph4oB6o";
                this.wbMateri.DocumentText = string.Format(embed5, url5);
            }
        }

    }
}

