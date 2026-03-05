namespace SimpleLibrary
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.TabPage tabReaders;
        private System.Windows.Forms.TabPage tabLoans;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.DataGridView dgvReaders;
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnAddReader;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnDeleteReader;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label lblStats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.tabReaders = new System.Windows.Forms.TabPage();
            this.dgvReaders = new System.Windows.Forms.DataGridView();
            this.tabLoans = new System.Windows.Forms.TabPage();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnAddReader = new System.Windows.Forms.Button();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnDeleteReader = new System.Windows.Forms.Button();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.lblStats = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tabReaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaders)).BeginInit();
            this.tabLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBooks);
            this.tabControl1.Controls.Add(this.tabReaders);
            this.tabControl1.Controls.Add(this.tabLoans);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 110);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1084, 501);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 26);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Size = new System.Drawing.Size(1076, 471);
            this.tabBooks.TabIndex = 0;
            this.tabBooks.Text = "📚 Книги";
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Location = new System.Drawing.Point(0, 0);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(1076, 471);
            this.dgvBooks.TabIndex = 0;
            // 
            // tabReaders
            // 
            this.tabReaders.Controls.Add(this.dgvReaders);
            this.tabReaders.Location = new System.Drawing.Point(4, 26);
            this.tabReaders.Name = "tabReaders";
            this.tabReaders.Size = new System.Drawing.Size(1076, 471);
            this.tabReaders.TabIndex = 1;
            this.tabReaders.Text = "👥 Читатели";
            // 
            // dgvReaders
            // 
            this.dgvReaders.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvReaders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReaders.BackgroundColor = System.Drawing.Color.White;
            this.dgvReaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReaders.Location = new System.Drawing.Point(0, 0);
            this.dgvReaders.MultiSelect = false;
            this.dgvReaders.Name = "dgvReaders";
            this.dgvReaders.ReadOnly = true;
            this.dgvReaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReaders.Size = new System.Drawing.Size(1076, 471);
            this.dgvReaders.TabIndex = 0;
            // 
            // tabLoans
            // 
            this.tabLoans.Controls.Add(this.dgvLoans);
            this.tabLoans.Location = new System.Drawing.Point(4, 26);
            this.tabLoans.Name = "tabLoans";
            this.tabLoans.Size = new System.Drawing.Size(1076, 471);
            this.tabLoans.TabIndex = 2;
            this.tabLoans.Text = "📋 Выдачи";
            // 
            // dgvLoans
            // 
            this.dgvLoans.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvLoans.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoans.Location = new System.Drawing.Point(0, 0);
            this.dgvLoans.MultiSelect = false;
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(1076, 471);
            this.dgvLoans.TabIndex = 0;
            // 
            // btnAddBook
            // 
            this.btnAddBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.Location = new System.Drawing.Point(450, 10);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(130, 30);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "➕ Добавить книгу";
            this.btnAddBook.UseVisualStyleBackColor = false;
            // 
            // btnAddReader
            // 
            this.btnAddReader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddReader.ForeColor = System.Drawing.Color.White;
            this.btnAddReader.Location = new System.Drawing.Point(590, 45);
            this.btnAddReader.Name = "btnAddReader";
            this.btnAddReader.Size = new System.Drawing.Size(130, 30);
            this.btnAddReader.TabIndex = 5;
            this.btnAddReader.Text = "➕ Добавить читателя";
            this.btnAddReader.UseVisualStyleBackColor = false;
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnIssueBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueBook.ForeColor = System.Drawing.Color.White;
            this.btnIssueBook.Location = new System.Drawing.Point(730, 45);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(130, 30);
            this.btnIssueBook.TabIndex = 7;
            this.btnIssueBook.Text = "📕 Выдать книгу";
            this.btnIssueBook.UseVisualStyleBackColor = false;
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.ForeColor = System.Drawing.Color.White;
            this.btnReturnBook.Location = new System.Drawing.Point(870, 10);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(130, 30);
            this.btnReturnBook.TabIndex = 8;
            this.btnReturnBook.Text = "📗 Вернуть книгу";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBook.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBook.Location = new System.Drawing.Point(450, 45);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(130, 30);
            this.btnDeleteBook.TabIndex = 3;
            this.btnDeleteBook.Text = "🗑 Удалить книгу";
            this.btnDeleteBook.UseVisualStyleBackColor = false;
            // 
            // btnDeleteReader
            // 
            this.btnDeleteReader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteReader.ForeColor = System.Drawing.Color.White;
            this.btnDeleteReader.Location = new System.Drawing.Point(730, 10);
            this.btnDeleteReader.Name = "btnDeleteReader";
            this.btnDeleteReader.Size = new System.Drawing.Size(130, 30);
            this.btnDeleteReader.TabIndex = 6;
            this.btnDeleteReader.Text = "🗑 Удалить читателя";
            this.btnDeleteReader.UseVisualStyleBackColor = false;
            // 
            // btnEditBook
            // 
            this.btnEditBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEditBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBook.ForeColor = System.Drawing.Color.Black;
            this.btnEditBook.Location = new System.Drawing.Point(590, 10);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(130, 30);
            this.btnEditBook.TabIndex = 4;
            this.btnEditBook.Text = "✏ Изменить книгу";
            this.btnEditBook.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(870, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 20);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.Text = "Поиск...";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(975, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 21);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "🔍 Найти";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.Items.AddRange(new object[] {
            "Книги",
            "Читатели"});
            this.cmbSearchType.Location = new System.Drawing.Point(870, 70);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(100, 21);
            this.cmbSearchType.TabIndex = 10;
            // 
            // lblStats
            // 
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblStats.Location = new System.Drawing.Point(10, 45);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(400, 20);
            this.lblStats.TabIndex = 1;
            this.lblStats.Text = "Загрузка...";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.lblStats);
            this.topPanel.Controls.Add(this.btnAddBook);
            this.topPanel.Controls.Add(this.btnDeleteBook);
            this.topPanel.Controls.Add(this.btnEditBook);
            this.topPanel.Controls.Add(this.btnAddReader);
            this.topPanel.Controls.Add(this.btnDeleteReader);
            this.topPanel.Controls.Add(this.btnIssueBook);
            this.topPanel.Controls.Add(this.btnReturnBook);
            this.topPanel.Controls.Add(this.txtSearch);
            this.topPanel.Controls.Add(this.cmbSearchType);
            this.topPanel.Controls.Add(this.btnSearch);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10);
            this.topPanel.Size = new System.Drawing.Size(1084, 110);
            this.topPanel.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📚 БИБЛИОТЕЧНАЯ СИСТЕМА";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.topPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Библиотечная система";
            this.tabControl1.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.tabReaders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaders)).EndInit();
            this.tabLoans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
    }
}