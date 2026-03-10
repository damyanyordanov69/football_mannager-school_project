using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootballProject
{
    public partial class Form1 : Form
    {
        private TeamsRepository _teamsRepo = new TeamsRepository();
        private PlayersRepository _playersRepo = new PlayersRepository();
        private TransfersRepository _transfersRepo = new TransfersRepository();
        private LeaguesRepository _leaguesRepo = new LeaguesRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTeamsData();
            LoadPlayersDropdowns();
            LoadPlayersData();
            LoadTransferDropdowns();
            LoadTransfersData();
            LoadLeaguesData();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Този код се изпълнява ВСЕКИ ПЪТ, когато смениш таба!

            // Зареждаме Отборите
            LoadTeamsData();

            // Зареждаме Играчите и техните падащи менюта
            LoadPlayersDropdowns();
            LoadPlayersData();

            // Зареждаме Трансферите и техните падащи менюта
            LoadTransferDropdowns();
            LoadTransfersData();

            LoadLeaguesData();
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




        // ====================================================================
        //                       ТАБ 3: ТРАНСФЕРИ
        // ====================================================================

        private void LoadTransferDropdowns()
        {
            var teams = _teamsRepo.GetAll();

            // Филтър за историята
            var filterTeams = new List<Team> { new Team { TeamId = 0, Name = "Всички" } };
            filterTeams.AddRange(teams);
            cboFilterTransferTeam.DataSource = filterTeams;
            cboFilterTransferTeam.DisplayMember = "Name";
            cboFilterTransferTeam.ValueMember = "TeamId";

            // Отбори за "Към клуб"
            cboTransferToTeam.DataSource = new List<Team>(teams);
            cboTransferToTeam.DisplayMember = "Name";
            cboTransferToTeam.ValueMember = "TeamId";

            // Играчи за трансфер
            var players = _playersRepo.GetPlayers();
            cboTransferPlayer.DataSource = players;
            cboTransferPlayer.DisplayMember = "FullName"; // Ползваме новото свойство от Player.cs!
        }

        private void LoadTransfersData()
        {
            try
            {
                int? teamId = cboFilterTransferTeam.SelectedValue as int?;
                dgvTransfers.DataSource = _transfersRepo.GetTransfers(teamId);

                // Скриваме ID колоните за красота
                if (dgvTransfers.Columns.Contains("PlayerId")) dgvTransfers.Columns["PlayerId"].Visible = false;
                if (dgvTransfers.Columns.Contains("FromTeamId")) dgvTransfers.Columns["FromTeamId"].Visible = false;
                if (dgvTransfers.Columns.Contains("ToTeamId")) dgvTransfers.Columns["ToTeamId"].Visible = false;
            }
            catch { }
        }

        // Когато изберем играч от падащото меню, автоматично показваме текущия му отбор
        private void cboTransferPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTransferPlayer.SelectedItem is Player selectedPlayer)
            {
                txtCurrentTeam.Text = selectedPlayer.TeamName;
            }
        }

        // Филтър история
        private void cboFilterTransferTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransfersData();
        }

        // Самият трансфер!
        private void btnMakeTransfer_Click(object sender, EventArgs e)
        {
            if (cboTransferPlayer.SelectedItem is Player p && cboTransferToTeam.SelectedValue != null)
            {
                int toTeamId = (int)cboTransferToTeam.SelectedValue;

                // ВАЛИДАЦИЯ 1: Не към същия клуб!
                if (p.TeamId == toTeamId)
                {
                    MessageBox.Show("Грешка: Играчът вече играе в този клуб! Не може да се трансферира в същия клуб.", "Бизнес правило", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ВАЛИДАЦИЯ 2: Сумата
                decimal fee = numTransferFee.Value;
                if (fee < 0)
                {
                    MessageBox.Show("Сумата не може да бъде отрицателна!");
                    return;
                }

                try
                {
                    // Правим трансфера (Транзакцията)
                    _transfersRepo.PerformTransfer(p.PlayerId, p.TeamId, toTeamId, fee, dtpTransferDate.Value);
                    MessageBox.Show("Успешен трансфер! Играчът смени отбора си.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Презареждаме ВСИЧКО, защото данните са се променили!
                    LoadTransfersData();
                    LoadPlayersData();
                    LoadTransferDropdowns();

                    numTransferFee.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        // ====================================================================
        //                       ТАБ 4: ЛИГИ И УЧАСТНИЦИ
        // ====================================================================

        private void LoadLeaguesData()
        {
            try
            {
                dgvLeagues.DataSource = _leaguesRepo.GetAllLeagues();
                dgvLeagues.ClearSelection();
                txtLeagueId.Clear(); txtLeagueName.Clear(); txtLeagueSeason.Clear();

                // Изчистваме дясната част, когато няма избрана лига
                dgvParticipants.DataSource = null;
                cboAvailableClubs.DataSource = null;
            }
            catch (Exception ex) { MessageBox.Show("Грешка при зареждане на лиги: " + ex.Message); }
        }

        // Когато кликнем на лига -> зареждаме участниците й в дясната таблица
        private void dgvLeagues_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLeagues.SelectedRows.Count > 0)
            {
                var league = (League)dgvLeagues.SelectedRows[0].DataBoundItem;
                txtLeagueId.Text = league.LeagueId.ToString();
                txtLeagueName.Text = league.Name;
                txtLeagueSeason.Text = league.Season;

                LoadParticipantsAndAvailableClubs(league.LeagueId);
            }
        }

        private void LoadParticipantsAndAvailableClubs(int leagueId)
        {
            // Зареждаме тези, които вече са вътре
            dgvParticipants.DataSource = _leaguesRepo.GetParticipants(leagueId);
            dgvParticipants.ClearSelection();

            // Зареждаме тези, които са свободни (в падащото меню)
            var available = _leaguesRepo.GetAvailableClubs(leagueId);
            cboAvailableClubs.DataSource = available;
            cboAvailableClubs.DisplayMember = "Name";
            cboAvailableClubs.ValueMember = "TeamId";
        }

        private bool ValidateLeague()
        {
            if (string.IsNullOrWhiteSpace(txtLeagueName.Text)) { MessageBox.Show("Името е задължително!"); return false; }

            // Проверка за формат на сезона YYYY/YYYY
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtLeagueSeason.Text, @"^\d{4}/\d{4}$"))
            {
                MessageBox.Show("Сезонът трябва да е във формат YYYY/YYYY (напр. 2024/2025).");
                return false;
            }
            return true;
        }

        private void btnAddLeague_Click(object sender, EventArgs e)
        {
            if (!ValidateLeague()) return;
            try
            {
                _leaguesRepo.AddLeague(new League { Name = txtLeagueName.Text, Season = txtLeagueSeason.Text });
                LoadLeaguesData();
            }
            catch (Exception ex) { MessageBox.Show("Грешка! Вероятно вече има такава лига за този сезон.\n" + ex.Message); }
        }

        private void btnEditLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeagueId.Text) || !ValidateLeague()) return;
            try
            {
                _leaguesRepo.UpdateLeague(new League { LeagueId = int.Parse(txtLeagueId.Text), Name = txtLeagueName.Text, Season = txtLeagueSeason.Text });
                LoadLeaguesData();
            }
            catch (Exception ex) { MessageBox.Show("Грешка при редакция: " + ex.Message); }
        }

        private void btnDeleteLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeagueId.Text)) return;
            if (MessageBox.Show("Изтриване на лига?", "Потвърждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try { _leaguesRepo.DeleteLeague(int.Parse(txtLeagueId.Text)); LoadLeaguesData(); }
                catch (Exception ex) { MessageBox.Show("Не може да се изтрие лига с отбори/мачове!\n" + ex.Message); }
            }
        }

        // ДОБАВЯНЕ И ПРЕМАХВАНЕ НА УЧАСТНИЦИ
        private void btnAddClubToLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeagueId.Text)) { MessageBox.Show("Изберете лига първо!"); return; }
            if (cboAvailableClubs.SelectedValue == null) { MessageBox.Show("Няма избрани свободни клубове!"); return; }

            int leagueId = int.Parse(txtLeagueId.Text);
            int teamId = (int)cboAvailableClubs.SelectedValue;

            _leaguesRepo.AddClubToLeague(leagueId, teamId);
            LoadParticipantsAndAvailableClubs(leagueId); // Презареждаме веднага дясната част
        }

        private void btnRemoveClubFromLeague_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeagueId.Text)) return;
            if (dgvParticipants.SelectedRows.Count == 0) { MessageBox.Show("Изберете участник от дясната таблица за премахване!"); return; }

            int leagueId = int.Parse(txtLeagueId.Text);
            var team = (Team)dgvParticipants.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Сигурни ли сте, че искате да премахнете {team.Name} от тази лига?", "Премахване", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _leaguesRepo.RemoveClubFromLeague(leagueId, team.TeamId);
                    LoadParticipantsAndAvailableClubs(leagueId); // Презареждаме веднага дясната част
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Бизнес правило", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}