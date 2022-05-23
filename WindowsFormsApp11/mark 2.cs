using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection sqlConnect = new MySqlConnection("server=localhost;uid=root;pwd=;database=premier_league");
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        String sqlQuery;
        DataTable dtPemain = new DataTable();
        int PosisiSekarang = 0;
        int yeye = 9;


        private void Form1_Load(object sender, EventArgs e)
        {
            sqlQuery = sqlQuery = "select player.player_id, player.player_name, player.birthdate, nationality.nation, team.team_name as 'nama tim', player.team_number from player, nationality, team where player.nationality_id = nationality.nationality_id and player.team_id = team.team_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPemain);
        }


        public void IsiDataPemain(int Posisi)
        {
            tBox_id.Text = dtPemain.Rows[Posisi][0].ToString();
            tBox_Player.Text = dtPemain.Rows[Posisi][1].ToString();
            Tbox_nationality.Text = dtPemain.Rows[Posisi][2].ToString();
            cBox_Team.DataSource = dtPemain;
            cBox_Team.DisplayMember = "nama tim";
            PosisiSekarang = Posisi;
        }

        private void Btn_last_Click(object sender, EventArgs e)
        {
            IsiDataPemain(dtPemain.Rows.Count - 1);
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            IsiDataPemain(0);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {

            if (PosisiSekarang < dtPemain.Rows.Count - 1)
            {
                PosisiSekarang++;
                IsiDataPemain(PosisiSekarang);
            }
            else
            {
                MessageBox.Show("Data yang diinput sudah terakhir dan tidak bisa diinput lagi!");
            }
        }

        private void cBox_Team_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //kosong
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
