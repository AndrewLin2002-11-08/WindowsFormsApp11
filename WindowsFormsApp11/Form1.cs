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
        DataTable dtTypePemain = new DataTable();
        int PosisiSekarang = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            sqlQuery = sqlQuery = "select player.player_id, player.player_name, player.birthdate, nationality.nation, team.team_name, player.team_number from player, nationality, team where player.nationality_id = nationality.nationality_id and player.team_id = team.team_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTypePemain);
        }

        private void Btn_last_Click(object sender, EventArgs e)
        {
            IsiDataPemain(dtTypePemain.Rows.Count - 1);
        }
    }
}
