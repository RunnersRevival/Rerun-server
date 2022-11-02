namespace Rerun_Editor;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalPage = new System.Windows.Forms.TabPage();
            this.energyRecoveryTimeField = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.energyRecoveryMaxField = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.preventDataVersionIncrementCheckBox = new System.Windows.Forms.CheckBox();
            this.numContinuesField = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mysqlPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.mysqlUsernameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mysqlDbNameTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mysqlHostnameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sqliteDbFilenameTextBox = new System.Windows.Forms.TextBox();
            this.sqliteFileExtensionLabel = new System.Windows.Forms.Label();
            this.sqliteFileNameLabel = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dbMySqlRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.resetDataVersionButton = new System.Windows.Forms.Button();
            this.dataVersionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mileageRewardsPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.charaCostsPage = new System.Windows.Forms.TabPage();
            this.levelupCostsPage = new System.Windows.Forms.TabPage();
            this.itemCostsPage = new System.Windows.Forms.TabPage();
            this.roulettePage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.chaoRoulettePage = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.eventSpecificOddsPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.raidBossPage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.storePage = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.generalPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.energyRecoveryTimeField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.energyRecoveryMaxField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContinuesField)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.mileageRewardsPage.SuspendLayout();
            this.roulettePage.SuspendLayout();
            this.chaoRoulettePage.SuspendLayout();
            this.eventSpecificOddsPage.SuspendLayout();
            this.raidBossPage.SuspendLayout();
            this.storePage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalPage);
            this.tabControl1.Controls.Add(this.mileageRewardsPage);
            this.tabControl1.Controls.Add(this.charaCostsPage);
            this.tabControl1.Controls.Add(this.levelupCostsPage);
            this.tabControl1.Controls.Add(this.itemCostsPage);
            this.tabControl1.Controls.Add(this.roulettePage);
            this.tabControl1.Controls.Add(this.chaoRoulettePage);
            this.tabControl1.Controls.Add(this.eventSpecificOddsPage);
            this.tabControl1.Controls.Add(this.raidBossPage);
            this.tabControl1.Controls.Add(this.storePage);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // generalPage
            // 
            this.generalPage.Controls.Add(this.label16);
            this.generalPage.Controls.Add(this.energyRecoveryTimeField);
            this.generalPage.Controls.Add(this.label15);
            this.generalPage.Controls.Add(this.energyRecoveryMaxField);
            this.generalPage.Controls.Add(this.label13);
            this.generalPage.Controls.Add(this.button1);
            this.generalPage.Controls.Add(this.preventDataVersionIncrementCheckBox);
            this.generalPage.Controls.Add(this.numContinuesField);
            this.generalPage.Controls.Add(this.label12);
            this.generalPage.Controls.Add(this.groupBox1);
            this.generalPage.Controls.Add(this.resetDataVersionButton);
            this.generalPage.Controls.Add(this.dataVersionLabel);
            this.generalPage.Controls.Add(this.label1);
            this.generalPage.Location = new System.Drawing.Point(4, 44);
            this.generalPage.Name = "generalPage";
            this.generalPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalPage.Size = new System.Drawing.Size(592, 389);
            this.generalPage.TabIndex = 0;
            this.generalPage.Text = "General";
            this.generalPage.UseVisualStyleBackColor = true;
            // 
            // energyRecoveryTimeField
            // 
            this.energyRecoveryTimeField.Location = new System.Drawing.Point(380, 116);
            this.energyRecoveryTimeField.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.energyRecoveryTimeField.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.energyRecoveryTimeField.Name = "energyRecoveryTimeField";
            this.energyRecoveryTimeField.Size = new System.Drawing.Size(206, 23);
            this.energyRecoveryTimeField.TabIndex = 11;
            this.energyRecoveryTimeField.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(241, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 15);
            this.label15.TabIndex = 10;
            this.label15.Text = "Energy regen time (secs):";
            // 
            // energyRecoveryMaxField
            // 
            this.energyRecoveryMaxField.Location = new System.Drawing.Point(380, 86);
            this.energyRecoveryMaxField.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.energyRecoveryMaxField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.energyRecoveryMaxField.Name = "energyRecoveryMaxField";
            this.energyRecoveryMaxField.Size = new System.Drawing.Size(206, 23);
            this.energyRecoveryMaxField.TabIndex = 9;
            this.energyRecoveryMaxField.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(241, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "Maximum regen energy:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Edit...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // preventDataVersionIncrementCheckBox
            // 
            this.preventDataVersionIncrementCheckBox.AutoSize = true;
            this.preventDataVersionIncrementCheckBox.Location = new System.Drawing.Point(253, 11);
            this.preventDataVersionIncrementCheckBox.Name = "preventDataVersionIncrementCheckBox";
            this.preventDataVersionIncrementCheckBox.Size = new System.Drawing.Size(196, 19);
            this.preventDataVersionIncrementCheckBox.TabIndex = 6;
            this.preventDataVersionIncrementCheckBox.Text = "Don\'t increment version on save";
            this.preventDataVersionIncrementCheckBox.UseVisualStyleBackColor = true;
            // 
            // numContinuesField
            // 
            this.numContinuesField.Location = new System.Drawing.Point(369, 57);
            this.numContinuesField.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numContinuesField.Name = "numContinuesField";
            this.numContinuesField.Size = new System.Drawing.Size(217, 23);
            this.numContinuesField.TabIndex = 5;
            this.numContinuesField.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "Maximum Continues:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mysqlPasswordTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.mysqlUsernameTextBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.mysqlDbNameTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.mysqlHostnameTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.sqliteDbFilenameTextBox);
            this.groupBox1.Controls.Add(this.sqliteFileExtensionLabel);
            this.groupBox1.Controls.Add(this.sqliteFileNameLabel);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.dbMySqlRadioButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 288);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Options";
            // 
            // mysqlPasswordTextBox
            // 
            this.mysqlPasswordTextBox.Location = new System.Drawing.Point(7, 255);
            this.mysqlPasswordTextBox.Name = "mysqlPasswordTextBox";
            this.mysqlPasswordTextBox.Size = new System.Drawing.Size(218, 23);
            this.mysqlPasswordTextBox.TabIndex = 13;
            this.mysqlPasswordTextBox.Text = "EnterPasswordHere";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 237);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Password:";
            // 
            // mysqlUsernameTextBox
            // 
            this.mysqlUsernameTextBox.Location = new System.Drawing.Point(7, 211);
            this.mysqlUsernameTextBox.Name = "mysqlUsernameTextBox";
            this.mysqlUsernameTextBox.Size = new System.Drawing.Size(218, 23);
            this.mysqlUsernameTextBox.TabIndex = 11;
            this.mysqlUsernameTextBox.Text = "outrun";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Username:";
            // 
            // mysqlDbNameTextBox
            // 
            this.mysqlDbNameTextBox.Location = new System.Drawing.Point(7, 167);
            this.mysqlDbNameTextBox.Name = "mysqlDbNameTextBox";
            this.mysqlDbNameTextBox.Size = new System.Drawing.Size(218, 23);
            this.mysqlDbNameTextBox.TabIndex = 9;
            this.mysqlDbNameTextBox.Text = "outrun";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Database name:";
            // 
            // mysqlHostnameTextBox
            // 
            this.mysqlHostnameTextBox.Location = new System.Drawing.Point(7, 120);
            this.mysqlHostnameTextBox.Name = "mysqlHostnameTextBox";
            this.mysqlHostnameTextBox.Size = new System.Drawing.Size(216, 23);
            this.mysqlHostnameTextBox.TabIndex = 7;
            this.mysqlHostnameTextBox.Text = "localhost:3306";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Hostname:";
            // 
            // sqliteDbFilenameTextBox
            // 
            this.sqliteDbFilenameTextBox.Enabled = false;
            this.sqliteDbFilenameTextBox.Location = new System.Drawing.Point(7, 67);
            this.sqliteDbFilenameTextBox.Name = "sqliteDbFilenameTextBox";
            this.sqliteDbFilenameTextBox.Size = new System.Drawing.Size(179, 23);
            this.sqliteDbFilenameTextBox.TabIndex = 5;
            this.sqliteDbFilenameTextBox.Text = "RerunDB";
            // 
            // sqliteFileExtensionLabel
            // 
            this.sqliteFileExtensionLabel.AutoSize = true;
            this.sqliteFileExtensionLabel.Enabled = false;
            this.sqliteFileExtensionLabel.Location = new System.Drawing.Point(185, 72);
            this.sqliteFileExtensionLabel.Name = "sqliteFileExtensionLabel";
            this.sqliteFileExtensionLabel.Size = new System.Drawing.Size(38, 15);
            this.sqliteFileExtensionLabel.TabIndex = 4;
            this.sqliteFileExtensionLabel.Text = ".sqlite";
            // 
            // sqliteFileNameLabel
            // 
            this.sqliteFileNameLabel.AutoSize = true;
            this.sqliteFileNameLabel.Enabled = false;
            this.sqliteFileNameLabel.Location = new System.Drawing.Point(7, 49);
            this.sqliteFileNameLabel.Name = "sqliteFileNameLabel";
            this.sqliteFileNameLabel.Size = new System.Drawing.Size(152, 15);
            this.sqliteFileNameLabel.TabIndex = 3;
            this.sqliteFileNameLabel.Text = "Database filename (SQLite):";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(165, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 19);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "SQLite";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // dbMySqlRadioButton
            // 
            this.dbMySqlRadioButton.AutoSize = true;
            this.dbMySqlRadioButton.Checked = true;
            this.dbMySqlRadioButton.Location = new System.Drawing.Point(96, 19);
            this.dbMySqlRadioButton.Name = "dbMySqlRadioButton";
            this.dbMySqlRadioButton.Size = new System.Drawing.Size(63, 19);
            this.dbMySqlRadioButton.TabIndex = 1;
            this.dbMySqlRadioButton.TabStop = true;
            this.dbMySqlRadioButton.Text = "MySQL";
            this.dbMySqlRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Database type:";
            // 
            // resetDataVersionButton
            // 
            this.resetDataVersionButton.Location = new System.Drawing.Point(141, 8);
            this.resetDataVersionButton.Name = "resetDataVersionButton";
            this.resetDataVersionButton.Size = new System.Drawing.Size(51, 23);
            this.resetDataVersionButton.TabIndex = 2;
            this.resetDataVersionButton.Text = "Reset";
            this.resetDataVersionButton.UseVisualStyleBackColor = true;
            // 
            // dataVersionLabel
            // 
            this.dataVersionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataVersionLabel.Location = new System.Drawing.Point(92, 10);
            this.dataVersionLabel.Name = "dataVersionLabel";
            this.dataVersionLabel.Size = new System.Drawing.Size(43, 20);
            this.dataVersionLabel.TabIndex = 1;
            this.dataVersionLabel.Text = "000";
            this.dataVersionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data version:";
            // 
            // mileageRewardsPage
            // 
            this.mileageRewardsPage.Controls.Add(this.label3);
            this.mileageRewardsPage.Location = new System.Drawing.Point(4, 44);
            this.mileageRewardsPage.Name = "mileageRewardsPage";
            this.mileageRewardsPage.Padding = new System.Windows.Forms.Padding(3);
            this.mileageRewardsPage.Size = new System.Drawing.Size(592, 389);
            this.mileageRewardsPage.TabIndex = 1;
            this.mileageRewardsPage.Text = "Mileage Rewards";
            this.mileageRewardsPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(215, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Coming soon!";
            // 
            // charaCostsPage
            // 
            this.charaCostsPage.Location = new System.Drawing.Point(4, 44);
            this.charaCostsPage.Name = "charaCostsPage";
            this.charaCostsPage.Size = new System.Drawing.Size(592, 389);
            this.charaCostsPage.TabIndex = 6;
            this.charaCostsPage.Text = "Character Unlock Costs";
            this.charaCostsPage.UseVisualStyleBackColor = true;
            // 
            // levelupCostsPage
            // 
            this.levelupCostsPage.Location = new System.Drawing.Point(4, 44);
            this.levelupCostsPage.Name = "levelupCostsPage";
            this.levelupCostsPage.Size = new System.Drawing.Size(592, 389);
            this.levelupCostsPage.TabIndex = 2;
            this.levelupCostsPage.Text = "Character Level-up Costs";
            this.levelupCostsPage.UseVisualStyleBackColor = true;
            // 
            // itemCostsPage
            // 
            this.itemCostsPage.Location = new System.Drawing.Point(4, 44);
            this.itemCostsPage.Name = "itemCostsPage";
            this.itemCostsPage.Size = new System.Drawing.Size(592, 389);
            this.itemCostsPage.TabIndex = 5;
            this.itemCostsPage.Text = "Item Costs";
            this.itemCostsPage.UseVisualStyleBackColor = true;
            // 
            // roulettePage
            // 
            this.roulettePage.Controls.Add(this.label4);
            this.roulettePage.Location = new System.Drawing.Point(4, 44);
            this.roulettePage.Name = "roulettePage";
            this.roulettePage.Size = new System.Drawing.Size(592, 389);
            this.roulettePage.TabIndex = 3;
            this.roulettePage.Text = "Item Roulette";
            this.roulettePage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(219, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "Coming soon!";
            // 
            // chaoRoulettePage
            // 
            this.chaoRoulettePage.Controls.Add(this.label5);
            this.chaoRoulettePage.Location = new System.Drawing.Point(4, 44);
            this.chaoRoulettePage.Name = "chaoRoulettePage";
            this.chaoRoulettePage.Size = new System.Drawing.Size(592, 389);
            this.chaoRoulettePage.TabIndex = 4;
            this.chaoRoulettePage.Text = "Chao Roulette";
            this.chaoRoulettePage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(219, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Coming soon!";
            // 
            // eventSpecificOddsPage
            // 
            this.eventSpecificOddsPage.Controls.Add(this.label6);
            this.eventSpecificOddsPage.Location = new System.Drawing.Point(4, 44);
            this.eventSpecificOddsPage.Name = "eventSpecificOddsPage";
            this.eventSpecificOddsPage.Size = new System.Drawing.Size(592, 389);
            this.eventSpecificOddsPage.TabIndex = 7;
            this.eventSpecificOddsPage.Text = "Event-specific Odds";
            this.eventSpecificOddsPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(219, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "Coming soon!";
            // 
            // raidBossPage
            // 
            this.raidBossPage.Controls.Add(this.label7);
            this.raidBossPage.Location = new System.Drawing.Point(4, 44);
            this.raidBossPage.Name = "raidBossPage";
            this.raidBossPage.Size = new System.Drawing.Size(592, 389);
            this.raidBossPage.TabIndex = 8;
            this.raidBossPage.Text = "Raid Boss Config";
            this.raidBossPage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(219, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 30);
            this.label7.TabIndex = 1;
            this.label7.Text = "Coming soon!";
            // 
            // storePage
            // 
            this.storePage.Controls.Add(this.label14);
            this.storePage.Location = new System.Drawing.Point(4, 44);
            this.storePage.Name = "storePage";
            this.storePage.Size = new System.Drawing.Size(592, 389);
            this.storePage.TabIndex = 9;
            this.storePage.Text = "Store";
            this.storePage.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(219, 179);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 30);
            this.label14.TabIndex = 2;
            this.label14.Text = "Coming soon!";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(161, 17);
            this.toolStripStatusLabel1.Text = "Non-functional UI prototype!";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(243, 226);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(314, 90);
            this.label16.TabIndex = 12;
            this.label16.Text = resources.GetString("label16.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 491);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Rerun Editor - Pre-Alpha";
            this.tabControl1.ResumeLayout(false);
            this.generalPage.ResumeLayout(false);
            this.generalPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.energyRecoveryTimeField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.energyRecoveryMaxField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContinuesField)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mileageRewardsPage.ResumeLayout(false);
            this.mileageRewardsPage.PerformLayout();
            this.roulettePage.ResumeLayout(false);
            this.roulettePage.PerformLayout();
            this.chaoRoulettePage.ResumeLayout(false);
            this.chaoRoulettePage.PerformLayout();
            this.eventSpecificOddsPage.ResumeLayout(false);
            this.eventSpecificOddsPage.PerformLayout();
            this.raidBossPage.ResumeLayout(false);
            this.raidBossPage.PerformLayout();
            this.storePage.ResumeLayout(false);
            this.storePage.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TabControl tabControl1;
    private TabPage generalPage;
    private TabPage mileageRewardsPage;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem exitToolStripMenuItem;
    private TabPage charaCostsPage;
    private TabPage levelupCostsPage;
    private TabPage itemCostsPage;
    private TabPage roulettePage;
    private TabPage chaoRoulettePage;
    private Label label1;
    private TabPage eventSpecificOddsPage;
    private TabPage raidBossPage;
    private Button resetDataVersionButton;
    private Label dataVersionLabel;
    private GroupBox groupBox1;
    private RadioButton radioButton1;
    private RadioButton dbMySqlRadioButton;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private TextBox sqliteDbFilenameTextBox;
    private Label sqliteFileExtensionLabel;
    private Label sqliteFileNameLabel;
    private TextBox mysqlHostnameTextBox;
    private Label label8;
    private Label label9;
    private TextBox mysqlDbNameTextBox;
    private TextBox mysqlPasswordTextBox;
    private Label label11;
    private TextBox mysqlUsernameTextBox;
    private Label label10;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private NumericUpDown numContinuesField;
    private Label label12;
    private Button button1;
    private CheckBox preventDataVersionIncrementCheckBox;
    private NumericUpDown energyRecoveryMaxField;
    private Label label13;
    private NumericUpDown energyRecoveryTimeField;
    private Label label15;
    private TabPage storePage;
    private Label label14;
    private Label label16;
}