namespace DP_HIT_2020A_Ex03
{
    partial class SmartCalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.comboBoxCalendarSelection = new System.Windows.Forms.ComboBox();
            this.menuItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewFriendsBirthdayInTheDate = new System.Windows.Forms.DataGridView();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profilePicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBoxCalender = new System.Windows.Forms.GroupBox();
            this.monthCalendarView = new System.Windows.Forms.MonthCalendar();
            this.textBoxCalenderDateText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFriendsBirthdayInTheDate)).BeginInit();
            this.groupBoxCalender.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.buttonHelp.Location = new System.Drawing.Point(20, 16);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(137, 43);
            this.buttonHelp.TabIndex = 17;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // comboBoxCalendarSelection
            // 
            this.comboBoxCalendarSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.comboBoxCalendarSelection.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxCalendarSelection.DataSource = this.menuItemBindingSource;
            this.comboBoxCalendarSelection.DisplayMember = "Text";
            this.comboBoxCalendarSelection.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.comboBoxCalendarSelection.FormattingEnabled = true;
            this.comboBoxCalendarSelection.Location = new System.Drawing.Point(402, 73);
            this.comboBoxCalendarSelection.Name = "comboBoxCalendarSelection";
            this.comboBoxCalendarSelection.Size = new System.Drawing.Size(171, 29);
            this.comboBoxCalendarSelection.TabIndex = 16;
            // 
            // menuItemBindingSource
            // 
            this.menuItemBindingSource.DataSource = typeof(DP_HIT_2020A_Ex03.CommandFolder.MenuItem);
            // 
            // dataGridViewFriendsBirthdayInTheDate
            // 
            this.dataGridViewFriendsBirthdayInTheDate.AllowUserToAddRows = false;
            this.dataGridViewFriendsBirthdayInTheDate.AllowUserToDeleteRows = false;
            this.dataGridViewFriendsBirthdayInTheDate.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridViewFriendsBirthdayInTheDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFriendsBirthdayInTheDate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstName,
            this.lastName,
            this.profilePicture});
            this.dataGridViewFriendsBirthdayInTheDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewFriendsBirthdayInTheDate.Location = new System.Drawing.Point(20, 73);
            this.dataGridViewFriendsBirthdayInTheDate.Name = "dataGridViewFriendsBirthdayInTheDate";
            this.dataGridViewFriendsBirthdayInTheDate.ReadOnly = true;
            this.dataGridViewFriendsBirthdayInTheDate.RowTemplate.DefaultCellStyle.Format = "N2";
            this.dataGridViewFriendsBirthdayInTheDate.RowTemplate.Height = 100;
            this.dataGridViewFriendsBirthdayInTheDate.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFriendsBirthdayInTheDate.Size = new System.Drawing.Size(343, 365);
            this.dataGridViewFriendsBirthdayInTheDate.TabIndex = 12;
            this.dataGridViewFriendsBirthdayInTheDate.Visible = false;
            // 
            // firstName
            // 
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            // 
            // lastName
            // 
            this.lastName.HeaderText = "Last Name";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            // 
            // profilePicture
            // 
            this.profilePicture.HeaderText = "Profile Picture";
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.ReadOnly = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonSearch.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.buttonSearch.Location = new System.Drawing.Point(601, 73);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(99, 31);
            this.buttonSearch.TabIndex = 15;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // groupBoxCalender
            // 
            this.groupBoxCalender.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBoxCalender.Controls.Add(this.monthCalendarView);
            this.groupBoxCalender.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.groupBoxCalender.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxCalender.Location = new System.Drawing.Point(402, 183);
            this.groupBoxCalender.Name = "groupBoxCalender";
            this.groupBoxCalender.Size = new System.Drawing.Size(298, 255);
            this.groupBoxCalender.TabIndex = 14;
            this.groupBoxCalender.TabStop = false;
            this.groupBoxCalender.Text = "MONTH";
            // 
            // monthCalendarView
            // 
            this.monthCalendarView.BackColor = System.Drawing.SystemColors.MenuBar;
            this.monthCalendarView.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.monthCalendarView.Location = new System.Drawing.Point(12, 34);
            this.monthCalendarView.Margin = new System.Windows.Forms.Padding(15);
            this.monthCalendarView.Name = "monthCalendarView";
            this.monthCalendarView.TabIndex = 0;
            this.monthCalendarView.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarView_DateChanged);
            // 
            // textBoxCalenderDateText
            // 
            this.textBoxCalenderDateText.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxCalenderDateText.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.textBoxCalenderDateText.Location = new System.Drawing.Point(402, 134);
            this.textBoxCalenderDateText.Multiline = true;
            this.textBoxCalenderDateText.Name = "textBoxCalenderDateText";
            this.textBoxCalenderDateText.Size = new System.Drawing.Size(298, 36);
            this.textBoxCalenderDateText.TabIndex = 13;
            this.textBoxCalenderDateText.Text = "01/01/2019 00:00:00";
            // 
            // SmartCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.comboBoxCalendarSelection);
            this.Controls.Add(this.dataGridViewFriendsBirthdayInTheDate);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.groupBoxCalender);
            this.Controls.Add(this.textBoxCalenderDateText);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(198, 111);
            this.Name = "SmartCalendar";
            this.Size = new System.Drawing.Size(721, 455);
            ((System.ComponentModel.ISupportInitialize)(this.menuItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFriendsBirthdayInTheDate)).EndInit();
            this.groupBoxCalender.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.ComboBox comboBoxCalendarSelection;
        private System.Windows.Forms.DataGridView dataGridViewFriendsBirthdayInTheDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewImageColumn profilePicture;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBoxCalender;
        private System.Windows.Forms.MonthCalendar monthCalendarView;
        private System.Windows.Forms.TextBox textBoxCalenderDateText;
        private System.Windows.Forms.BindingSource menuItemBindingSource;
    }
}
