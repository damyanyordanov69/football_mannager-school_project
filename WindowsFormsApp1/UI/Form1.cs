using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootballProject
{
    public partial class Form1 : Form
    {
        private TeamsRepository _teamsRepo = new TeamsRepository();
        private PlayersRepository _playersRepo = new PlayersRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTeamsData();
            LoadPlayersDropdowns();
            LoadPlayersData();
        }

        // ======================= ТАБ 1: ОТБОРИ =======================
        private void LoadTeamsData()
        {
            try
            {
                dgvTeams.DataSource = _teamsRepo.GetAll();
                dgvTeams.ClearSelection();
                txtTeamId.Clear(); txtTeamName.Clear(); txtTeamCity.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Грешка отбори: " + ex.Message); }
        }

        private void dgvTeams_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeams.SelectedRows.Count > 0)
            {
                var team = (Team)dgvTeams.SelectedRows[0].DataBoundItem;
                txtTeamId.Text = team.TeamId.ToString();
                txtTeamName.Text = team.Name;
                txtTeamCity.Text = team.City;
            }
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeamName.Text)) return;
            _teamsRepo.Add(new Team { Name = txtTeamName.Text, City = txtTeamCity.Text });
            MessageBox.Show("Отборът е добавен!");
            LoadTeamsData();
            LoadPlayersDropdowns(); // Обновява падащото меню при играчите!
        }

        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeamId.Text)) return;
            _teamsRepo.Update(new Team { TeamId = int.Parse(txtTeamId.Text), Name = txtTeamName.Text, City = txtTeamCity.Text });
            MessageBox.Show("Отборът е редактиран!");
            LoadTeamsData();
            LoadPlayersDropdowns();
        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeamId.Text)) return;
            if (MessageBox.Show("Сигурни ли сте?", "Потвърждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try { _teamsRepo.Delete(int.Parse(txtTeamId.Text)); LoadTeamsData(); LoadPlayersDropdowns(); }
                catch (Exception ex) { MessageBox.Show("Не може да се изтрие отбор с играчи! "); }
            }
        }

        // ======================= ТАБ 2: ИГРАЧИ =======================
        private void LoadPlayersDropdowns()
        {
            var teams = _teamsRepo.GetAll();

            // Филтър Отбори
            var filterTeams = new List<Team> { new Team { TeamId = 0, Name = "Всички" } };
            filterTeams.AddRange(teams);
            cboFilterTeam.DataSource = filterTeams;
            cboFilterTeam.DisplayMember = "Name";
            cboFilterTeam.ValueMember = "TeamId";

            // Отбори за добавяне
            cboTeam.DataSource = new List<Team>(teams);
            cboTeam.DisplayMember = "Name";
            cboTeam.ValueMember = "TeamId";

            // Позиции
            if (cboPosition.Items.Count == 0)
            {
                string[] pos = { "GK", "DF", "MF", "FW" };
                cboPosition.Items.AddRange(pos);
                cboFilterPosition.Items.Add("Всички");
                cboFilterPosition.Items.AddRange(pos);
                cboFilterPosition.SelectedIndex = 0;
            }
        }

        private void LoadPlayersData()
        {
            try
            {
                int? teamId = cboFilterTeam.SelectedValue as int?;
                string position = cboFilterPosition.SelectedItem?.ToString();
                string search = txtSearchName.Text;

                dgvPlayers.DataSource = _playersRepo.GetPlayers(teamId, position, search);
                if (dgvPlayers.Columns.Contains("TeamId")) dgvPlayers.Columns["TeamId"].Visible = false;
                dgvPlayers.ClearSelection();
            }
            catch { }
        }

        private void dgvPlayers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlayers.SelectedRows.Count > 0)
            {
                var p = (Player)dgvPlayers.SelectedRows[0].DataBoundItem;
                txtPlayerId.Text = p.PlayerId.ToString();
                txtFirstName.Text = p.FirstName;
                txtLastName.Text = p.LastName;
                dtpBirthDate.Value = p.BirthDate;
                cboPosition.SelectedItem = p.Position;
                cboTeam.SelectedValue = p.TeamId;
            }
        }

        private bool ValidatePlayer()
        {
            if (txtFirstName.Text.Length < 3) { MessageBox.Show("Поне 3 символа за име!"); return false; }
            if (cboPosition.SelectedIndex == -1 || cboTeam.SelectedValue == null) { MessageBox.Show("Изберете позиция и отбор!"); return false; }
            int age = DateTime.Now.Year - dtpBirthDate.Value.Year;
            if (age < 15 || age > 50) { MessageBox.Show("Възраст между 15 и 50!"); return false; }
            return true;
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (!ValidatePlayer()) return;
            _playersRepo.Add(new Player { FirstName = txtFirstName.Text, LastName = txtLastName.Text, BirthDate = dtpBirthDate.Value, Position = cboPosition.SelectedItem.ToString(), TeamId = (int)cboTeam.SelectedValue });
            LoadPlayersData();
            MessageBox.Show("Добавен!");
        }

        private void btnEditPlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlayerId.Text) || !ValidatePlayer()) return;
            _playersRepo.Update(new Player { PlayerId = int.Parse(txtPlayerId.Text), FirstName = txtFirstName.Text, LastName = txtLastName.Text, BirthDate = dtpBirthDate.Value, Position = cboPosition.SelectedItem.ToString(), TeamId = (int)cboTeam.SelectedValue });
            LoadPlayersData();
            MessageBox.Show("Редактиран!");
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlayerId.Text)) return;
            if (MessageBox.Show("Изтриване?", "Потвърждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _playersRepo.Delete(int.Parse(txtPlayerId.Text)); LoadPlayersData();
            }
        }

        private void btnClearPlayer_Click(object sender, EventArgs e)
        {
            txtPlayerId.Clear(); txtFirstName.Clear(); txtLastName.Clear();
            cboPosition.SelectedIndex = -1;
            if (dtpBirthDate.MaxDate > DateTime.Now.AddYears(-20) && dtpBirthDate.MinDate < DateTime.Now.AddYears(-20))
                dtpBirthDate.Value = DateTime.Now.AddYears(-20);
        }

        // ======================= ФИЛТРИ (СЪБИТИЯ) =======================
        private void cboFilterTeam_SelectedIndexChanged(object sender, EventArgs e) => LoadPlayersData();
        private void cboFilterPosition_SelectedIndexChanged(object sender, EventArgs e) => LoadPlayersData();
        private void txtSearchName_TextChanged(object sender, EventArgs e) => LoadPlayersData();
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cboFilterTeam.SelectedIndex = 0;
            cboFilterPosition.SelectedIndex = 0;
            txtSearchName.Clear(); // <-- Този ред изчиства текстовото поле!
        }
    }
}