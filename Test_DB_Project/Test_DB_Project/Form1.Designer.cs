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
        private System.Windows.Forms.Button btnEditBook; // НОВАЯ КНОПКА
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSearchType;

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
            this.topPanel = new System.Windows.Forms.Panel();
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
            this.tabControl1.Location = new System.Drawing.Point(0, 56);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 505);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 22);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Size = new System.Drawing.Size(976, 479);
            this.tabBooks.TabIndex = 0;
            this.tabBooks.Text = "Книги";
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Location = new System.Drawing.Point(0, 0);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(976, 479);
            this.dgvBooks.TabIndex = 0;
            // 
            // tabReaders
            // 
            this.tabReaders.Controls.Add(this.dgvReaders);
            this.tabReaders.Location = new System.Drawing.Point(4, 22);
            this.tabReaders.Name = "tabReaders";
            this.tabReaders.Size = new System.Drawing.Size(992, 534);
            this.tabReaders.TabIndex = 1;
            this.tabReaders.Text = "Читатели";
            // 
            // dgvReaders
            // 
            this.dgvReaders.AllowUserToAddRows = false;
            this.dgvReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReaders.Location = new System.Drawing.Point(0, 0);
            this.dgvReaders.MultiSelect = false;
            this.dgvReaders.Name = "dgvReaders";
            this.dgvReaders.ReadOnly = true;
            this.dgvReaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReaders.Size = new System.Drawing.Size(992, 534);
            this.dgvReaders.TabIndex = 0;
            // 
            // tabLoans
            // 
            this.tabLoans.Controls.Add(this.dgvLoans);
            this.tabLoans.Location = new System.Drawing.Point(4, 22);
            this.tabLoans.Name = "tabLoans";
            this.tabLoans.Size = new System.Drawing.Size(992, 534);
            this.tabLoans.TabIndex = 2;
            this.tabLoans.Text = "Выдачи";
            // 
            // dgvLoans
            // 
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoans.Location = new System.Drawing.Point(0, 0);
            this.dgvLoans.MultiSelect = false;
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(992, 534);
            this.dgvLoans.TabIndex = 0;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(10, 5);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(110, 30);
            this.btnAddBook.TabIndex = 0;
            this.btnAddBook.Text = "➕ Добавить книгу";
            // 
            // btnAddReader
            // 
            this.btnAddReader.Location = new System.Drawing.Point(390, 5);
            this.btnAddReader.Name = "btnAddReader";
            this.btnAddReader.Size = new System.Drawing.Size(120, 30);
            this.btnAddReader.TabIndex = 3;
            this.btnAddReader.Text = "➕ Добавить читателя";
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.Location = new System.Drawing.Point(650, 5);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(90, 30);
            this.btnIssueBook.TabIndex = 5;
            this.btnIssueBook.Text = "📕 Выдать книгу";
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(750, 5);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(90, 30);
            this.btnReturnBook.TabIndex = 6;
            this.btnReturnBook.Text = "📗 Вернуть книгу";
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(130, 5);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteBook.TabIndex = 1;
            this.btnDeleteBook.Text = "🗑 Удалить книгу";
            // 
            // btnDeleteReader
            // 
            this.btnDeleteReader.Location = new System.Drawing.Point(520, 5);
            this.btnDeleteReader.Name = "btnDeleteReader";
            this.btnDeleteReader.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteReader.TabIndex = 4;
            this.btnDeleteReader.Text = "🗑 Удалить читателя";
            // 
            // btnEditBook
            // 
            this.btnEditBook.BackColor = System.Drawing.Color.LightGray;
            this.btnEditBook.ForeColor = System.Drawing.Color.Black;
            this.btnEditBook.Location = new System.Drawing.Point(250, 5);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(130, 30);
            this.btnEditBook.TabIndex = 2;
            this.btnEditBook.Text = "✏ Изменить количество";
            this.btnEditBook.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(850, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 20);
            this.txtSearch.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(940, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 21);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "🔍";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.Items.AddRange(new object[] {
            "Книги",
            "Читатели"});
            this.cmbSearchType.Location = new System.Drawing.Point(850, 30);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(80, 21);
            this.cmbSearchType.TabIndex = 8;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.LightGray;
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
            this.topPanel.Size = new System.Drawing.Size(984, 56);
            this.topPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.topPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Библиотека";
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
    }
}