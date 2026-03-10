namespace FootballProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.txtTeamId = new System.Windows.Forms.TextBox();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.txtTeamCity = new System.Windows.Forms.TextBox();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.btnEditTeam = new System.Windows.Forms.Button();
            this.btnDeleteTeam = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditPlayer = new System.Windows.Forms.Button();
            this.btnDeletePlayer = new System.Windows.Forms.Button();
            this.btnClearPlayer = new System.Windows.Forms.Button();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.cboTeam = new System.Windows.Forms.ComboBox();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtPlayerId = new System.Windows.Forms.TextBox();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.cboFilterPosition = new System.Windows.Forms.ComboBox();
            this.cboFilterTeam = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cboFilterTransferTeam = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvTransfers = new System.Windows.Forms.DataGridView();
            this.cboTransferPlayer = new System.Windows.Forms.ComboBox();
            this.cboTransferToTeam = new System.Windows.Forms.ComboBox();
            this.txtCurrentTeam = new System.Windows.Forms.TextBox();
            this.numTransferFee = new System.Windows.Forms.NumericUpDown();
            this.dtpTransferDate = new System.Windows.Forms.DateTimePicker();
            this.btnMakeTransfer = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvLeagues = new System.Windows.Forms.DataGridView();
            this.txtLeagueId = new System.Windows.Forms.TextBox();
            this.txtLeagueSeason = new System.Windows.Forms.TextBox();
            this.txtLeagueName = new System.Windows.Forms.TextBox();
            this.btnAddLeague = new System.Windows.Forms.Button();
            this.btnEditLeague = new System.Windows.Forms.Button();
            this.btnDeleteLeague = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dgvParticipants = new System.Windows.Forms.DataGridView();
            this.cboAvailableClubs = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnRemoveClubFromLeague = new System.Windows.Forms.Button();
            this.btnAddClubToLeague = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransferFee)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeagues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeams
            // 
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeams.Location = new System.Drawing.Point(0, 0);
            this.dgvTeams.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.ReadOnly = true;
            this.dgvTeams.RowHeadersWidth = 51;
            this.dgvTeams.RowTemplate.Height = 24;
            this.dgvTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeams.Size = new System.Drawing.Size(776, 351);
            this.dgvTeams.TabIndex = 0;
            this.dgvTeams.SelectionChanged += new System.EventHandler(this.dgvTeams_SelectionChanged);
            // 
            // txtTeamId
            // 
            this.txtTeamId.Enabled = false;
            this.txtTeamId.Location = new System.Drawing.Point(1, 376);
            this.txtTeamId.Margin = new System.Windows.Forms.Padding(2);
            this.txtTeamId.Name = "txtTeamId";
            this.txtTeamId.ReadOnly = true;
            this.txtTeamId.Size = new System.Drawing.Size(147, 20);
            this.txtTeamId.TabIndex = 1;
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(152, 376);
            this.txtTeamName.Margin = new System.Windows.Forms.Padding(2);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(147, 20);
            this.txtTeamName.TabIndex = 2;
            // 
            // txtTeamCity
            // 
            this.txtTeamCity.Location = new System.Drawing.Point(303, 376);
            this.txtTeamCity.Margin = new System.Windows.Forms.Padding(2);
            this.txtTeamCity.Name = "txtTeamCity";
            this.txtTeamCity.Size = new System.Drawing.Size(144, 20);
            this.txtTeamCity.TabIndex = 3;
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.Location = new System.Drawing.Point(1, 400);
            this.btnAddTeam.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(147, 19);
            this.btnAddTeam.TabIndex = 4;
            this.btnAddTeam.Text = "Добави";
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // btnEditTeam
            // 
            this.btnEditTeam.Location = new System.Drawing.Point(152, 400);
            this.btnEditTeam.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditTeam.Name = "btnEditTeam";
            this.btnEditTeam.Size = new System.Drawing.Size(147, 19);
            this.btnEditTeam.TabIndex = 5;
            this.btnEditTeam.Text = "Редактирай";
            this.btnEditTeam.UseVisualStyleBackColor = true;
            this.btnEditTeam.Click += new System.EventHandler(this.btnEditTeam_Click);
            // 
            // btnDeleteTeam
            // 
            this.btnDeleteTeam.Location = new System.Drawing.Point(303, 400);
            this.btnDeleteTeam.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteTeam.Name = "btnDeleteTeam";
            this.btnDeleteTeam.Size = new System.Drawing.Size(144, 19);
            this.btnDeleteTeam.TabIndex = 6;
            this.btnDeleteTeam.Text = "Изтрий";
            this.btnDeleteTeam.UseVisualStyleBackColor = true;
            this.btnDeleteTeam.Click += new System.EventHandler(this.btnDeleteTeam_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 448);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.btnAddTeam);
            this.tabPage1.Controls.Add(this.dgvTeams);
            this.tabPage1.Controls.Add(this.txtTeamCity);
            this.tabPage1.Controls.Add(this.btnDeleteTeam);
            this.tabPage1.Controls.Add(this.txtTeamId);
            this.tabPage1.Controls.Add(this.btnEditTeam);
            this.tabPage1.Controls.Add(this.txtTeamName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Отбори";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnEditPlayer);
            this.tabPage2.Controls.Add(this.btnDeletePlayer);
            this.tabPage2.Controls.Add(this.btnClearPlayer);
            this.tabPage2.Controls.Add(this.btnAddPlayer);
            this.tabPage2.Controls.Add(this.cboTeam);
            this.tabPage2.Controls.Add(this.cboPosition);
            this.tabPage2.Controls.Add(this.dtpBirthDate);
            this.tabPage2.Controls.Add(this.txtLastName);
            this.tabPage2.Controls.Add(this.txtFirstName);
            this.tabPage2.Controls.Add(this.txtPlayerId);
            this.tabPage2.Controls.Add(this.dgvPlayers);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnClearFilters);
            this.tabPage2.Controls.Add(this.txtSearchName);
            this.tabPage2.Controls.Add(this.cboFilterPosition);
            this.tabPage2.Controls.Add(this.cboFilterTeam);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Играчи";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.Location = new System.Drawing.Point(106, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Име:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(212, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Фамилия:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(318, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "Дата на Раждане:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(524, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Позиция:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(655, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Отбор:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(0, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "ID:";
            // 
            // btnEditPlayer
            // 
            this.btnEditPlayer.Location = new System.Drawing.Point(148, 396);
            this.btnEditPlayer.Name = "btnEditPlayer";
            this.btnEditPlayer.Size = new System.Drawing.Size(139, 23);
            this.btnEditPlayer.TabIndex = 18;
            this.btnEditPlayer.Text = "Редактирай";
            this.btnEditPlayer.UseVisualStyleBackColor = true;
            this.btnEditPlayer.Click += new System.EventHandler(this.btnEditPlayer_Click);
            // 
            // btnDeletePlayer
            // 
            this.btnDeletePlayer.Location = new System.Drawing.Point(293, 396);
            this.btnDeletePlayer.Name = "btnDeletePlayer";
            this.btnDeletePlayer.Size = new System.Drawing.Size(139, 23);
            this.btnDeletePlayer.TabIndex = 17;
            this.btnDeletePlayer.Text = "Изтрий";
            this.btnDeletePlayer.UseVisualStyleBackColor = true;
            this.btnDeletePlayer.Click += new System.EventHandler(this.btnDeletePlayer_Click);
            // 
            // btnClearPlayer
            // 
            this.btnClearPlayer.Location = new System.Drawing.Point(438, 396);
            this.btnClearPlayer.Name = "btnClearPlayer";
            this.btnClearPlayer.Size = new System.Drawing.Size(139, 23);
            this.btnClearPlayer.TabIndex = 16;
            this.btnClearPlayer.Text = "Изчисти полетата";
            this.btnClearPlayer.UseVisualStyleBackColor = true;
            this.btnClearPlayer.Click += new System.EventHandler(this.btnClearPlayer_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(3, 396);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(139, 23);
            this.btnAddPlayer.TabIndex = 15;
            this.btnAddPlayer.Text = "Добави";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // cboTeam
            // 
            this.cboTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeam.FormattingEnabled = true;
            this.cboTeam.Location = new System.Drawing.Point(658, 369);
            this.cboTeam.Name = "cboTeam";
            this.cboTeam.Size = new System.Drawing.Size(132, 21);
            this.cboTeam.TabIndex = 14;
            // 
            // cboPosition
            // 
            this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Location = new System.Drawing.Point(527, 370);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(125, 21);
            this.cboPosition.TabIndex = 13;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(321, 370);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBirthDate.TabIndex = 12;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(215, 370);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 11;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(109, 370);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 10;
            // 
            // txtPlayerId
            // 
            this.txtPlayerId.Enabled = false;
            this.txtPlayerId.Location = new System.Drawing.Point(3, 370);
            this.txtPlayerId.Name = "txtPlayerId";
            this.txtPlayerId.ReadOnly = true;
            this.txtPlayerId.Size = new System.Drawing.Size(100, 20);
            this.txtPlayerId.TabIndex = 9;
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(0, 48);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(793, 268);
            this.dgvPlayers.TabIndex = 8;
            this.dgvPlayers.Click += new System.EventHandler(this.dgvPlayers_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label4.Location = new System.Drawing.Point(303, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "По име:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.Location = new System.Drawing.Point(193, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "По позиция:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label2.Location = new System.Drawing.Point(86, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "По отбор:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Филтри:";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Location = new System.Drawing.Point(409, 6);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(123, 39);
            this.btnClearFilters.TabIndex = 3;
            this.btnClearFilters.Text = "Изчисти филтри";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(303, 22);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(100, 20);
            this.txtSearchName.TabIndex = 2;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // cboFilterPosition
            // 
            this.cboFilterPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterPosition.FormattingEnabled = true;
            this.cboFilterPosition.Location = new System.Drawing.Point(196, 21);
            this.cboFilterPosition.Name = "cboFilterPosition";
            this.cboFilterPosition.Size = new System.Drawing.Size(101, 21);
            this.cboFilterPosition.TabIndex = 1;
            this.cboFilterPosition.SelectedIndexChanged += new System.EventHandler(this.cboFilterPosition_SelectedIndexChanged);
            // 
            // cboFilterTeam
            // 
            this.cboFilterTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterTeam.FormattingEnabled = true;
            this.cboFilterTeam.Location = new System.Drawing.Point(89, 21);
            this.cboFilterTeam.Name = "cboFilterTeam";
            this.cboFilterTeam.Size = new System.Drawing.Size(101, 21);
            this.cboFilterTeam.TabIndex = 0;
            this.cboFilterTeam.SelectedIndexChanged += new System.EventHandler(this.cboFilterTeam_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.btnMakeTransfer);
            this.tabPage3.Controls.Add(this.dtpTransferDate);
            this.tabPage3.Controls.Add(this.numTransferFee);
            this.tabPage3.Controls.Add(this.txtCurrentTeam);
            this.tabPage3.Controls.Add(this.cboTransferToTeam);
            this.tabPage3.Controls.Add(this.cboTransferPlayer);
            this.tabPage3.Controls.Add(this.dgvTransfers);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.cboFilterTransferTeam);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(793, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Трансфери";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cboFilterTransferTeam
            // 
            this.cboFilterTransferTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterTransferTeam.FormattingEnabled = true;
            this.cboFilterTransferTeam.Location = new System.Drawing.Point(73, 29);
            this.cboFilterTransferTeam.Name = "cboFilterTransferTeam";
            this.cboFilterTransferTeam.Size = new System.Drawing.Size(121, 21);
            this.cboFilterTransferTeam.TabIndex = 0;
            this.cboFilterTransferTeam.SelectedIndexChanged += new System.EventHandler(this.cboFilterTransferTeam_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(3, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Филтри:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label12.Location = new System.Drawing.Point(70, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "По трансферен отбор:";
            // 
            // dgvTransfers
            // 
            this.dgvTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransfers.Location = new System.Drawing.Point(0, 56);
            this.dgvTransfers.Name = "dgvTransfers";
            this.dgvTransfers.ReadOnly = true;
            this.dgvTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransfers.Size = new System.Drawing.Size(793, 313);
            this.dgvTransfers.TabIndex = 3;
            // 
            // cboTransferPlayer
            // 
            this.cboTransferPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransferPlayer.FormattingEnabled = true;
            this.cboTransferPlayer.Location = new System.Drawing.Point(9, 392);
            this.cboTransferPlayer.Name = "cboTransferPlayer";
            this.cboTransferPlayer.Size = new System.Drawing.Size(121, 21);
            this.cboTransferPlayer.TabIndex = 4;
            this.cboTransferPlayer.SelectedIndexChanged += new System.EventHandler(this.cboTransferPlayer_SelectedIndexChanged);
            // 
            // cboTransferToTeam
            // 
            this.cboTransferToTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransferToTeam.FormattingEnabled = true;
            this.cboTransferToTeam.Location = new System.Drawing.Point(263, 393);
            this.cboTransferToTeam.Name = "cboTransferToTeam";
            this.cboTransferToTeam.Size = new System.Drawing.Size(121, 21);
            this.cboTransferToTeam.TabIndex = 5;
            // 
            // txtCurrentTeam
            // 
            this.txtCurrentTeam.Enabled = false;
            this.txtCurrentTeam.Location = new System.Drawing.Point(136, 393);
            this.txtCurrentTeam.Name = "txtCurrentTeam";
            this.txtCurrentTeam.ReadOnly = true;
            this.txtCurrentTeam.Size = new System.Drawing.Size(121, 20);
            this.txtCurrentTeam.TabIndex = 6;
            // 
            // numTransferFee
            // 
            this.numTransferFee.Location = new System.Drawing.Point(390, 394);
            this.numTransferFee.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numTransferFee.Name = "numTransferFee";
            this.numTransferFee.Size = new System.Drawing.Size(57, 20);
            this.numTransferFee.TabIndex = 7;
            // 
            // dtpTransferDate
            // 
            this.dtpTransferDate.Location = new System.Drawing.Point(453, 394);
            this.dtpTransferDate.Name = "dtpTransferDate";
            this.dtpTransferDate.Size = new System.Drawing.Size(200, 20);
            this.dtpTransferDate.TabIndex = 8;
            // 
            // btnMakeTransfer
            // 
            this.btnMakeTransfer.Location = new System.Drawing.Point(659, 375);
            this.btnMakeTransfer.Name = "btnMakeTransfer";
            this.btnMakeTransfer.Size = new System.Drawing.Size(125, 39);
            this.btnMakeTransfer.TabIndex = 9;
            this.btnMakeTransfer.Text = "Финализирай Трансфер";
            this.btnMakeTransfer.UseVisualStyleBackColor = true;
            this.btnMakeTransfer.Click += new System.EventHandler(this.btnMakeTransfer_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label13.Location = new System.Drawing.Point(9, 376);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Играч:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label14.Location = new System.Drawing.Point(450, 375);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 15);
            this.label14.TabIndex = 11;
            this.label14.Text = "Дата на трансфера:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label15.Location = new System.Drawing.Point(387, 375);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "Сума:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label16.Location = new System.Drawing.Point(260, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 15);
            this.label16.TabIndex = 13;
            this.label16.Text = "Нов отбор:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label17.Location = new System.Drawing.Point(133, 375);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 15);
            this.label17.TabIndex = 14;
            this.label17.Text = "Текущ отбор:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label18.Location = new System.Drawing.Point(-2, 359);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 15);
            this.label18.TabIndex = 7;
            this.label18.Text = "ID:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label19.Location = new System.Drawing.Point(300, 359);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 15);
            this.label19.TabIndex = 8;
            this.label19.Text = "Град:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label20.Location = new System.Drawing.Point(149, 359);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 15);
            this.label20.TabIndex = 9;
            this.label20.Text = "Отбор:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnAddClubToLeague);
            this.tabPage4.Controls.Add(this.btnRemoveClubFromLeague);
            this.tabPage4.Controls.Add(this.label26);
            this.tabPage4.Controls.Add(this.cboAvailableClubs);
            this.tabPage4.Controls.Add(this.dgvParticipants);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.btnDeleteLeague);
            this.tabPage4.Controls.Add(this.btnEditLeague);
            this.tabPage4.Controls.Add(this.btnAddLeague);
            this.tabPage4.Controls.Add(this.txtLeagueName);
            this.tabPage4.Controls.Add(this.txtLeagueSeason);
            this.tabPage4.Controls.Add(this.txtLeagueId);
            this.tabPage4.Controls.Add(this.dgvLeagues);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(793, 422);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Лиги";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvLeagues
            // 
            this.dgvLeagues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeagues.Location = new System.Drawing.Point(0, 23);
            this.dgvLeagues.Name = "dgvLeagues";
            this.dgvLeagues.ReadOnly = true;
            this.dgvLeagues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeagues.Size = new System.Drawing.Size(360, 326);
            this.dgvLeagues.TabIndex = 0;
            this.dgvLeagues.SelectionChanged += new System.EventHandler(this.dgvLeagues_SelectionChanged);
            // 
            // txtLeagueId
            // 
            this.txtLeagueId.Enabled = false;
            this.txtLeagueId.Location = new System.Drawing.Point(3, 370);
            this.txtLeagueId.Name = "txtLeagueId";
            this.txtLeagueId.ReadOnly = true;
            this.txtLeagueId.Size = new System.Drawing.Size(100, 20);
            this.txtLeagueId.TabIndex = 1;
            // 
            // txtLeagueSeason
            // 
            this.txtLeagueSeason.Location = new System.Drawing.Point(215, 370);
            this.txtLeagueSeason.Name = "txtLeagueSeason";
            this.txtLeagueSeason.Size = new System.Drawing.Size(100, 20);
            this.txtLeagueSeason.TabIndex = 2;
            // 
            // txtLeagueName
            // 
            this.txtLeagueName.Location = new System.Drawing.Point(109, 370);
            this.txtLeagueName.Name = "txtLeagueName";
            this.txtLeagueName.Size = new System.Drawing.Size(100, 20);
            this.txtLeagueName.TabIndex = 4;
            // 
            // btnAddLeague
            // 
            this.btnAddLeague.Location = new System.Drawing.Point(3, 396);
            this.btnAddLeague.Name = "btnAddLeague";
            this.btnAddLeague.Size = new System.Drawing.Size(100, 23);
            this.btnAddLeague.TabIndex = 5;
            this.btnAddLeague.Text = "Добави";
            this.btnAddLeague.UseVisualStyleBackColor = true;
            this.btnAddLeague.Click += new System.EventHandler(this.btnAddLeague_Click);
            // 
            // btnEditLeague
            // 
            this.btnEditLeague.Location = new System.Drawing.Point(109, 396);
            this.btnEditLeague.Name = "btnEditLeague";
            this.btnEditLeague.Size = new System.Drawing.Size(100, 23);
            this.btnEditLeague.TabIndex = 6;
            this.btnEditLeague.Text = "Редактирай";
            this.btnEditLeague.UseVisualStyleBackColor = true;
            this.btnEditLeague.Click += new System.EventHandler(this.btnEditLeague_Click);
            // 
            // btnDeleteLeague
            // 
            this.btnDeleteLeague.Location = new System.Drawing.Point(215, 396);
            this.btnDeleteLeague.Name = "btnDeleteLeague";
            this.btnDeleteLeague.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteLeague.TabIndex = 7;
            this.btnDeleteLeague.Text = "Изтрий";
            this.btnDeleteLeague.UseVisualStyleBackColor = true;
            this.btnDeleteLeague.Click += new System.EventHandler(this.btnDeleteLeague_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label21.Location = new System.Drawing.Point(0, 352);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(22, 15);
            this.label21.TabIndex = 8;
            this.label21.Text = "ID:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label22.Location = new System.Drawing.Point(212, 352);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 15);
            this.label22.TabIndex = 9;
            this.label22.Text = "Сезон:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label23.Location = new System.Drawing.Point(106, 352);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 15);
            this.label23.TabIndex = 10;
            this.label23.Text = "Име:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label24.Location = new System.Drawing.Point(140, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 20);
            this.label24.TabIndex = 11;
            this.label24.Text = "Лиги:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label25.Location = new System.Drawing.Point(489, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(203, 20);
            this.label25.TabIndex = 12;
            this.label25.Text = "Играчи в избраната лига:";
            // 
            // dgvParticipants
            // 
            this.dgvParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipants.Location = new System.Drawing.Point(366, 23);
            this.dgvParticipants.Name = "dgvParticipants";
            this.dgvParticipants.ReadOnly = true;
            this.dgvParticipants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParticipants.Size = new System.Drawing.Size(427, 326);
            this.dgvParticipants.TabIndex = 13;
            // 
            // cboAvailableClubs
            // 
            this.cboAvailableClubs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAvailableClubs.FormattingEnabled = true;
            this.cboAvailableClubs.Location = new System.Drawing.Point(366, 369);
            this.cboAvailableClubs.Name = "cboAvailableClubs";
            this.cboAvailableClubs.Size = new System.Drawing.Size(121, 21);
            this.cboAvailableClubs.TabIndex = 14;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label26.Location = new System.Drawing.Point(363, 351);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(112, 15);
            this.label26.TabIndex = 15;
            this.label26.Text = "Свободни отбори:";
            // 
            // btnRemoveClubFromLeague
            // 
            this.btnRemoveClubFromLeague.Location = new System.Drawing.Point(587, 391);
            this.btnRemoveClubFromLeague.Name = "btnRemoveClubFromLeague";
            this.btnRemoveClubFromLeague.Size = new System.Drawing.Size(203, 23);
            this.btnRemoveClubFromLeague.TabIndex = 16;
            this.btnRemoveClubFromLeague.Text = "Изтрий";
            this.btnRemoveClubFromLeague.UseVisualStyleBackColor = true;
            this.btnRemoveClubFromLeague.Click += new System.EventHandler(this.btnRemoveClubFromLeague_Click);
            // 
            // btnAddClubToLeague
            // 
            this.btnAddClubToLeague.Location = new System.Drawing.Point(366, 391);
            this.btnAddClubToLeague.Name = "btnAddClubToLeague";
            this.btnAddClubToLeague.Size = new System.Drawing.Size(215, 23);
            this.btnAddClubToLeague.TabIndex = 17;
            this.btnAddClubToLeague.Text = "Добави";
            this.btnAddClubToLeague.UseVisualStyleBackColor = true;
            this.btnAddClubToLeague.Click += new System.EventHandler(this.btnAddClubToLeague_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 448);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransferFee)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeagues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTeams;
        private System.Windows.Forms.TextBox txtTeamId;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.TextBox txtTeamCity;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.Button btnEditTeam;
        private System.Windows.Forms.Button btnDeleteTeam;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cboFilterTeam;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.ComboBox cboFilterPosition;
        private System.Windows.Forms.ComboBox cboTeam;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPlayerId;
        private System.Windows.Forms.Button btnEditPlayer;
        private System.Windows.Forms.Button btnDeletePlayer;
        private System.Windows.Forms.Button btnClearPlayer;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cboFilterTransferTeam;
        private System.Windows.Forms.Button btnMakeTransfer;
        private System.Windows.Forms.DateTimePicker dtpTransferDate;
        private System.Windows.Forms.NumericUpDown numTransferFee;
        private System.Windows.Forms.TextBox txtCurrentTeam;
        private System.Windows.Forms.ComboBox cboTransferToTeam;
        private System.Windows.Forms.ComboBox cboTransferPlayer;
        private System.Windows.Forms.DataGridView dgvTransfers;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAddLeague;
        private System.Windows.Forms.TextBox txtLeagueName;
        private System.Windows.Forms.TextBox txtLeagueSeason;
        private System.Windows.Forms.TextBox txtLeagueId;
        private System.Windows.Forms.DataGridView dgvLeagues;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnDeleteLeague;
        private System.Windows.Forms.Button btnEditLeague;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnAddClubToLeague;
        private System.Windows.Forms.Button btnRemoveClubFromLeague;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cboAvailableClubs;
        private System.Windows.Forms.DataGridView dgvParticipants;
    }
}

