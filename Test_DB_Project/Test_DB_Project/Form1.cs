using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleLibrary
{
    public partial class Form1 : Form
    {
        private DatabaseHelper db = new DatabaseHelper();

        public Form1()
        {
            InitializeComponent();

            // Подписка на события
            this.btnAddBook.Click += BtnAddBook_Click;
            this.btnDeleteBook.Click += BtnDeleteBook_Click;
            this.btnEditBook.Click += BtnEditBook_Click;
            this.btnAddReader.Click += BtnAddReader_Click;
            this.btnDeleteReader.Click += BtnDeleteReader_Click;
            this.btnIssueBook.Click += BtnIssueBook_Click;
            this.btnReturnBook.Click += BtnReturnBook_Click;
            this.btnSearch.Click += BtnSearch_Click;
            this.tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            this.txtSearch.Enter += TxtSearch_Enter;
            this.txtSearch.Leave += TxtSearch_Leave;

            // Проверка подключения
            CheckConnection();

            // Загрузка данных
            LoadBooks();
            LoadReaders();
            LoadLoans();
            UpdateStats();
        }

        private void CheckConnection()
        {
            if (!db.TestConnection())
            {
                MessageBox.Show("Не удалось подключиться к базе данных MySQL!\n" +
                    "Проверьте:\n1. Запущен ли MySQL сервер\n2. Правильность пароля в DatabaseHelper.cs",
                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStats()
        {
            try
            {
                DataTable dt = db.GetData(@"
                    SELECT 
                        (SELECT COUNT(*) FROM Books) as Books,
                        (SELECT COUNT(*) FROM Readers) as Readers,
                        (SELECT COUNT(*) FROM Loans WHERE Status = 'active') as Active,
                        (SELECT COUNT(*) FROM Loans WHERE Status = 'overdue') as Overdue");

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblStats.Text = $"📊 Книг: {row["Books"]} | Читателей: {row["Readers"]} | " +
                                   $"Активных выдач: {row["Active"]} | Просрочено: {row["Overdue"]}";
                }
            }
            catch { }
        }

        private void LoadBooks()
        {
            string query = @"
        SELECT 
            b.ID,
            b.Title as 'Название',
            CONCAT(a.FirstName, ' ', a.LastName) as 'Автор',
            b.Genre as 'Жанр',
            b.YearPublished as 'Год',
            b.TotalCopies as 'Всего',
            b.AvailableCopies as 'Доступно'
        FROM Books b
        LEFT JOIN Authors a ON b.AuthorID = a.ID
        WHERE b.IsDeleted = FALSE  -- Только неудаленные книги
        ORDER BY b.Title";

            dgvBooks.DataSource = db.GetData(query);
            if (dgvBooks.Columns["ID"] != null)
                dgvBooks.Columns["ID"].Visible = false;

            // Подкрашиваем строки с 0 доступных книг
            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (row.Cells["Доступно"].Value != null &&
                    Convert.ToInt32(row.Cells["Доступно"].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void LoadReaders()
        {
            string query = @"
                SELECT 
                    ID,
                    FirstName as 'Имя',
                    LastName as 'Фамилия',
                    Email,
                    Phone as 'Телефон',
                    RegistrationDate as 'Дата регистрации'
                FROM Readers
                ORDER BY LastName, FirstName";

            dgvReaders.DataSource = db.GetData(query);
            if (dgvReaders.Columns["ID"] != null)
                dgvReaders.Columns["ID"].Visible = false;
        }

        private void LoadLoans()
        {
            string query = @"
                SELECT 
                    l.ID,
                    b.Title as 'Книга',
                    CONCAT(r.FirstName, ' ', r.LastName) as 'Читатель',
                    l.LoanDate as 'Дата выдачи',
                    l.DueDate as 'Срок возврата',
                    IFNULL(l.ReturnDate, 'Не возвращена') as 'Дата возврата',
                    CASE 
                        WHEN l.Status = 'active' AND l.DueDate < CURDATE() THEN 'Просрочена'
                        WHEN l.Status = 'active' THEN 'Активна'
                        WHEN l.Status = 'overdue' THEN 'Просрочена'
                        ELSE 'Возвращена'
                    END as 'Статус'
                FROM Loans l
                JOIN Books b ON l.BookID = b.ID
                JOIN Readers r ON l.ReaderID = r.ID
                ORDER BY l.LoanDate DESC";

            dgvLoans.DataSource = db.GetData(query);
            if (dgvLoans.Columns["ID"] != null)
                dgvLoans.Columns["ID"].Visible = false;

            // Подкрашиваем просроченные выдачи
            foreach (DataGridViewRow row in dgvLoans.Rows)
            {
                if (row.Cells["Статус"].Value?.ToString() == "Просрочена")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabBooks)
                LoadBooks();
            else if (tabControl1.SelectedTab == tabReaders)
                LoadReaders();
            else
                LoadLoans();

            UpdateStats();
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Поиск...")
                txtSearch.Text = "";
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "Поиск...";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if (searchText == "Поиск..." || string.IsNullOrWhiteSpace(searchText))
            {
                if (tabControl1.SelectedTab == tabBooks)
                    LoadBooks();
                else
                    LoadReaders();
                return;
            }

            if (tabControl1.SelectedTab == tabBooks || cmbSearchType.SelectedIndex == 0)
            {
                string query = @"
                    SELECT 
                        b.ID,
                        b.Title as 'Название',
                        CONCAT(a.FirstName, ' ', a.LastName) as 'Автор',
                        b.Genre as 'Жанр',
                        b.YearPublished as 'Год',
                        b.TotalCopies as 'Всего',
                        b.AvailableCopies as 'Доступно'
                    FROM Books b
                    LEFT JOIN Authors a ON b.AuthorID = a.ID
                    WHERE b.Title LIKE '%" + searchText + @"%' 
                       OR a.FirstName LIKE '%" + searchText + @"%'
                       OR a.LastName LIKE '%" + searchText + @"%'
                    ORDER BY b.Title";

                dgvBooks.DataSource = db.GetData(query);
            }
            else
            {
                string query = @"
                    SELECT 
                        ID,
                        FirstName as 'Имя',
                        LastName as 'Фамилия',
                        Email,
                        Phone as 'Телефон',
                        RegistrationDate as 'Дата регистрации'
                    FROM Readers
                    WHERE FirstName LIKE '%" + searchText + @"%' 
                       OR LastName LIKE '%" + searchText + @"%'
                       OR Email LIKE '%" + searchText + @"%'
                    ORDER BY LastName, FirstName";

                dgvReaders.DataSource = db.GetData(query);
            }
        }

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            // Сначала показываем список авторов для выбора
            DataTable authors = db.GetData("SELECT ID, FirstName, LastName FROM Authors ORDER BY LastName");

            Form selectAuthorForm = new Form();
            selectAuthorForm.Text = "Выберите автора";
            selectAuthorForm.Size = new Size(400, 300);
            selectAuthorForm.StartPosition = FormStartPosition.CenterParent;

            ListBox lbAuthors = new ListBox();
            lbAuthors.Dock = DockStyle.Fill;
            lbAuthors.DisplayMember = "FullName";

            foreach (DataRow row in authors.Rows)
            {
                lbAuthors.Items.Add(new AuthorItem(
                    Convert.ToInt32(row["ID"]),
                    $"{row["LastName"]} {row["FirstName"]}"
                ));
            }

            Button btnOk = new Button();
            btnOk.Text = "Выбрать";
            btnOk.Dock = DockStyle.Bottom;
            btnOk.Height = 30;
            btnOk.DialogResult = DialogResult.OK;

            selectAuthorForm.Controls.Add(lbAuthors);
            selectAuthorForm.Controls.Add(btnOk);

            if (selectAuthorForm.ShowDialog() == DialogResult.OK && lbAuthors.SelectedItem != null)
            {
                AuthorItem selectedAuthor = (AuthorItem)lbAuthors.SelectedItem;

                SimpleInputForm form = new SimpleInputForm("Добавить книгу",
                    new string[] { "Название:", "Жанр:", "Год:", "ISBN:", "Количество:" });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    string[] values = form.Values;
                    string query = $@"
                        INSERT INTO Books (Title, AuthorID, Genre, YearPublished, ISBN, TotalCopies, AvailableCopies) 
                        VALUES (
                            '{values[0]}', 
                            {selectedAuthor.Id}, 
                            '{values[1]}', 
                            {values[2]}, 
                            '{values[3]}', 
                            {values[4]}, 
                            {values[4]})";

                    db.ExecuteQuery(query);
                    LoadBooks();
                    UpdateStats();
                    MessageBox.Show("Книга успешно добавлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["ID"].Value);
                string title = dgvBooks.SelectedRows[0].Cells["Название"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Пометить книгу '{title}' как удаленную?\n" +
                    "Она будет скрыта из списка, но история выдач сохранится.",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Помечаем как удаленную, но не удаляем физически
                    db.ExecuteQuery($"UPDATE Books SET IsDeleted = TRUE WHERE ID = {id}");
                    LoadBooks(); // Перезагрузить с учетом IsDeleted = FALSE
                    UpdateStats();

                    MessageBox.Show("Книга помечена как удаленная!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["ID"].Value);
                string title = dgvBooks.SelectedRows[0].Cells["Название"].Value.ToString();
                int currentCount = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["Всего"].Value);

                // Простая форма для ввода нового количества
                Form inputForm = new Form();
                inputForm.Text = "Изменить количество";
                inputForm.Size = new Size(350, 150);
                inputForm.StartPosition = FormStartPosition.CenterParent;
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.MaximizeBox = false;

                Label lblMessage = new Label();
                lblMessage.Text = $"Книга: {title}\nТекущее количество: {currentCount}";
                lblMessage.Location = new Point(10, 10);
                lblMessage.Size = new Size(300, 40);

                Label lblCount = new Label();
                lblCount.Text = "Новое количество:";
                lblCount.Location = new Point(10, 60);
                lblCount.Size = new Size(100, 20);

                TextBox txtCount = new TextBox();
                txtCount.Text = currentCount.ToString();
                txtCount.Location = new Point(120, 60);
                txtCount.Size = new Size(150, 20);

                Button btnOk = new Button();
                btnOk.Text = "OK";
                btnOk.Location = new Point(120, 90);
                btnOk.Size = new Size(75, 23);
                btnOk.DialogResult = DialogResult.OK;

                Button btnCancel = new Button();
                btnCancel.Text = "Отмена";
                btnCancel.Location = new Point(205, 90);
                btnCancel.Size = new Size(75, 23);
                btnCancel.DialogResult = DialogResult.Cancel;

                inputForm.Controls.AddRange(new Control[] {
                    lblMessage, lblCount, txtCount, btnOk, btnCancel
                });

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int newCount = Convert.ToInt32(txtCount.Text);
                        int diff = newCount - currentCount;

                        string query = $@"
                            UPDATE Books 
                            SET TotalCopies = {newCount}, 
                                AvailableCopies = AvailableCopies + {diff}
                            WHERE ID = {id}";

                        db.ExecuteQuery(query);
                        LoadBooks();
                        UpdateStats();
                        MessageBox.Show("Количество обновлено!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Введите корректное число!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAddReader_Click(object sender, EventArgs e)
        {
            SimpleInputForm form = new SimpleInputForm("Добавить читателя",
                new string[] { "Имя:", "Фамилия:", "Email:", "Телефон:" });

            if (form.ShowDialog() == DialogResult.OK)
            {
                string[] values = form.Values;
                string query = $@"
                    INSERT INTO Readers (FirstName, LastName, Email, Phone, RegistrationDate) 
                    VALUES ('{values[0]}', '{values[1]}', '{values[2]}', '{values[3]}', CURDATE())";

                db.ExecuteQuery(query);
                LoadReaders();
                UpdateStats();
                MessageBox.Show("Читатель успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDeleteReader_Click(object sender, EventArgs e)
        {
            if (dgvReaders.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvReaders.SelectedRows[0].Cells["ID"].Value);
                string name = dgvReaders.SelectedRows[0].Cells["Имя"].Value.ToString() + " " +
                             dgvReaders.SelectedRows[0].Cells["Фамилия"].Value.ToString();

                if (MessageBox.Show($"Удалить читателя '{name}'?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExecuteQuery($"DELETE FROM Readers WHERE ID = {id}");
                    LoadReaders();
                    UpdateStats();
                }
            }
            else
            {
                MessageBox.Show("Выберите читателя для удаления!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnIssueBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу на вкладке 'Книги'!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedTab = tabBooks;
                return;
            }

            if (dgvReaders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите читателя на вкладке 'Читатели'!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedTab = tabReaders;
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["ID"].Value);
            int readerId = Convert.ToInt32(dgvReaders.SelectedRows[0].Cells["ID"].Value);
            string bookTitle = dgvBooks.SelectedRows[0].Cells["Название"].Value.ToString();
            string readerName = dgvReaders.SelectedRows[0].Cells["Имя"].Value.ToString() + " " +
                               dgvReaders.SelectedRows[0].Cells["Фамилия"].Value.ToString();
            int available = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["Доступно"].Value);

            if (available > 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Выдать книгу '{bookTitle}'\nчитателю '{readerName}'?",
                    "Подтверждение выдачи",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Уменьшаем количество доступных книг
                    db.ExecuteQuery($"UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE ID = {bookId}");

                    // Добавляем запись о выдаче
                    db.ExecuteQuery($@"
                        INSERT INTO Loans (BookID, ReaderID, LoanDate, DueDate, Status) 
                        VALUES ({bookId}, {readerId}, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY), 'active')");

                    LoadBooks();
                    LoadLoans();
                    UpdateStats();

                    MessageBox.Show($"Книга выдана!\nСрок возврата: через 14 дней",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Эта книга временно недоступна!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите выдачу на вкладке 'Выдачи'!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedTab = tabLoans;
                return;
            }

            string status = dgvLoans.SelectedRows[0].Cells["Статус"].Value.ToString();
            if (status == "Возвращена")
            {
                MessageBox.Show("Эта книга уже возвращена!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string bookTitle = dgvLoans.SelectedRows[0].Cells["Книга"].Value.ToString();
            string readerName = dgvLoans.SelectedRows[0].Cells["Читатель"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Подтвердить возврат книги '{bookTitle}'\nот читателя '{readerName}'?",
                "Подтверждение возврата",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Получаем ID книги
                DataTable dt = db.GetData($"SELECT ID FROM Books WHERE Title = '{bookTitle}'");
                if (dt.Rows.Count > 0)
                {
                    int bookId = Convert.ToInt32(dt.Rows[0]["ID"]);

                    // Увеличиваем количество доступных книг
                    db.ExecuteQuery($"UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE ID = {bookId}");

                    // Обновляем запись о выдаче
                    db.ExecuteQuery($@"
                        UPDATE Loans 
                        SET ReturnDate = CURDATE(), Status = 'returned' 
                        WHERE BookID = {bookId} AND ReturnDate IS NULL");

                    LoadBooks();
                    LoadLoans();
                    UpdateStats();

                    MessageBox.Show("Книга успешно возвращена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    // Вспомогательный класс для выбора автора
    public class AuthorItem
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public AuthorItem(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}