using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FootballProject // Увери се, че името тук съвпада с твоя проект
{
    public partial class Form1 : Form
    {
        // Създаваме връзката към репозиторито (където са SQL заявките)
        private TeamsRepository _repo;

        public Form1()
        {
            InitializeComponent();
            _repo = new TeamsRepository();
        }

        // 1. Зареждане на формата
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Помощен метод за презареждане на таблицата
        // Помощен метод за презареждане на таблицата
        private void LoadData()
        {
            try
            {
                // 1. Зареждаме данните в таблицата
                dgvTeams.DataSource = _repo.GetAll();

                // 2. ПРЕМАХВАМЕ маркировката от първия ред
                dgvTeams.ClearSelection();

                // 3. Изчистваме текстовите полета, за да са напълно празни при стартиране
                txtTeamId.Clear();
                txtName.Clear();
                txtCity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на данните: " + ex.Message);
            }
        }

        // 2. Клик върху ред в DataGridView (пълни полетата)
        private void dgvTeams_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeams.SelectedRows.Count > 0)
            {
                var row = dgvTeams.SelectedRows[0];
                var team = (Team)row.DataBoundItem;

                txtTeamId.Text = team.TeamId.ToString();
                txtName.Text = team.Name;
                txtCity.Text = team.City;
            }
        }

        // 3. Логика за бутона ДОБАВИ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Валидация: Името не може да е празно
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Името на отбора е задължително!");
                return;
            }

            try
            {
                // Създаваме нов обект отбор с въведените данни
                var newTeam = new Team
                {
                    Name = txtName.Text,
                    City = txtCity.Text
                };

                // Извикваме Add() от репозиторито
                _repo.Add(newTeam);

                MessageBox.Show("Отборът е добавен успешно!");

                // Изчистваме полетата и презареждаме таблицата
                txtName.Clear();
                txtCity.Clear();
                txtTeamId.Clear();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при добавяне: " + ex.Message);
            }
        }

        // 4. Логика за бутона РЕДАКТИРАЙ
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Проверяваме дали има избрано ID
            if (string.IsNullOrWhiteSpace(txtTeamId.Text))
            {
                MessageBox.Show("Моля, изберете отбор от таблицата, който да редактирате!");
                return;
            }

            try
            {
                // Създаваме обект с новите данни и СТАРОТО ID
                var teamToUpdate = new Team
                {
                    TeamId = int.Parse(txtTeamId.Text),
                    Name = txtName.Text,
                    City = txtCity.Text
                };

                // Извикваме Update() от репозиторито
                _repo.Update(teamToUpdate);

                MessageBox.Show("Отборът е редактиран успешно!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при редакция: " + ex.Message);
            }
        }

        // 5. Логика за бутона ИЗТРИЙ
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeamId.Text))
            {
                MessageBox.Show("Моля, изберете отбор от таблицата, който да изтриете!");
                return;
            }

            // Питаме потребителя дали е сигурен
            var confirm = MessageBox.Show("Сигурни ли сте, че искате да изтриете този отбор?",
                                          "Потвърждение",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtTeamId.Text);

                    // Извикваме Delete() от репозиторито
                    _repo.Delete(id);

                    MessageBox.Show("Отборът е изтрит успешно!");

                    // Изчистваме текстовите полета
                    txtName.Clear();
                    txtCity.Clear();
                    txtTeamId.Clear();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка при изтриване! Възможно е отборът да има свързани играчи.\nДетайли: " + ex.Message);
                }
            }
        }
    }
}