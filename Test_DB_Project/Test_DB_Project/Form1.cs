using System;
using System.Data;
using System.Windows.Forms;

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
            this.btnAddReader.Click += BtnAddReader_Click;
            this.btnDeleteReader.Click += BtnDeleteReader_Click;
            this.btnIssueBook.Click += BtnIssueBook_Click;
            this.btnReturnBook.Click += BtnReturnBook_Click;
            this.btnSearch.Click += BtnSearch_Click;
            this.btnEditBook.Click += BtnEditBook_Click; // Новая кнопка
            this.tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            // Разрешаем редактирование в DataGridView для книг
            this.dgvBooks.ReadOnly = false;
            this.dgvBooks.CellEndEdit += DgvBooks_CellEndEdit;

            // Загрузка данных
            LoadBooks();
            LoadReaders();
            LoadLoans();
        }

        private void LoadBooks()
        {
            string query = "SELECT ID, Title as 'Название', Author as 'Автор', Year as 'Год', Genre as 'Жанр', Count as 'Количество' FROM Books";
            dgvBooks.DataSource = db.GetData(query);
            if (dgvBooks.Columns["ID"] != null)
                dgvBooks.Columns["ID"].Visible = false;
        }

        private void LoadReaders()
        {
            string query = "SELECT ID, FirstName as 'Имя', LastName as 'Фамилия', Phone as 'Телефон' FROM Readers";
            dgvReaders.DataSource = db.GetData(query);
            if (dgvReaders.Columns["ID"] != null)
                dgvReaders.Columns["ID"].Visible = false;
        }

        private void LoadLoans()
        {
            string query = @"SELECT 
                b.Title as 'Книга',
                CONCAT(r.FirstName, ' ', r.LastName) as 'Читатель',
                l.LoanDate as 'Дата выдачи',
                IFNULL(l.ReturnDate, 'Не возвращена') as 'Дата возврата'
                FROM Loans l
                JOIN Books b ON l.BookID = b.ID
                JOIN Readers r ON l.ReaderID = r.ID
                ORDER BY l.LoanDate DESC";
            dgvLoans.DataSource = db.GetData(query);
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabBooks)
                LoadBooks();
            else if (tabControl1.SelectedTab == tabReaders)
                LoadReaders();
            else
                LoadLoans();
        }

        // НОВЫЙ МЕТОД: Редактирование количества книг прямо в таблице
        private void DgvBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Проверяем, что редактировали колонку "Количество"
                if (dgvBooks.Columns[e.ColumnIndex].Name == "Количество")
                {
                    int id = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells["ID"].Value);
                    int newCount = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    // Обновляем количество в базе данных
                    string query = $"UPDATE Books SET Count = {newCount} WHERE ID = {id}";
                    db.ExecuteQuery(query);

                    MessageBox.Show("Количество обновлено!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}. Введите число!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadBooks(); // Перезагружаем данные
            }
        }

        // НОВЫЙ МЕТОД: Кнопка для быстрого изменения количества (используя SimpleInputForm)
        private void BtnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["ID"].Value);
                string title = dgvBooks.SelectedRows[0].Cells["Название"].Value.ToString();
                int currentCount = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["Количество"].Value);

                // Создаем форму с одним полем ввода
                Form form = new Form();
                form.Text = "Изменение количества";
                form.Size = new System.Drawing.Size(300, 150);
                form.StartPosition = FormStartPosition.CenterParent;

                Label lbl = new Label();
                lbl.Text = $"Книга: {title}\nТекущее количество: {currentCount}";
                lbl.Location = new System.Drawing.Point(10, 10);
                lbl.Size = new System.Drawing.Size(260, 40);

                TextBox txt = new TextBox();
                txt.Location = new System.Drawing.Point(10, 60);
                txt.Size = new System.Drawing.Size(260, 20);
                txt.Text = currentCount.ToString();

                Button btnOk = new Button();
                btnOk.Text = "OK";
                btnOk.Location = new System.Drawing.Point(100, 90);
                btnOk.Size = new System.Drawing.Size(75, 23);
                btnOk.DialogResult = DialogResult.OK;

                Button btnCancel = new Button();
                btnCancel.Text = "Отмена";
                btnCancel.Location = new System.Drawing.Point(185, 90);
                btnCancel.Size = new System.Drawing.Size(75, 23);
                btnCancel.DialogResult = DialogResult.Cancel;

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnCancel);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int newCount = Convert.ToInt32(txt.Text);
                        string query = $"UPDATE Books SET Count = {newCount} WHERE ID = {id}";
                        db.ExecuteQuery(query);
                        LoadBooks();
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

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            SimpleInputForm form = new SimpleInputForm("Добавить книгу",
                new string[] { "Название:", "Автор:", "Год:", "Жанр:", "Количество:" });

            if (form.ShowDialog() == DialogResult.OK)
            {
                string[] values = form.Values;
                string query = $"INSERT INTO Books (Title, Author, Year, Genre, Count) VALUES (" +
                    $"'{values[0]}', '{values[1]}', {values[2]}, '{values[3]}', {values[4]})";
                db.ExecuteQuery(query);
                LoadBooks();
            }
        }

        private void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["ID"].Value);
                if (MessageBox.Show("Удалить книгу?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExecuteQuery($"DELETE FROM Books WHERE ID = {id}");
                    LoadBooks();
                }
            }
        }

        private void BtnAddReader_Click(object sender, EventArgs e)
        {
            SimpleInputForm form = new SimpleInputForm("Добавить читателя",
                new string[] { "Имя:", "Фамилия:", "Телефон:" });

            if (form.ShowDialog() == DialogResult.OK)
            {
                string[] values = form.Values;
                string query = $"INSERT INTO Readers (FirstName, LastName, Phone) VALUES " +
                    $"('{values[0]}', '{values[1]}', '{values[2]}')";
                db.ExecuteQuery(query);
                LoadReaders();
            }
        }

        private void BtnDeleteReader_Click(object sender, EventArgs e)
        {
            if (dgvReaders.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvReaders.SelectedRows[0].Cells["ID"].Value);
                if (MessageBox.Show("Удалить читателя?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExecuteQuery($"DELETE FROM Readers WHERE ID = {id}");
                    LoadReaders();
                }
            }
        }

        private void BtnIssueBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0 || dgvReaders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу и читателя!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["ID"].Value);
            int readerId = Convert.ToInt32(dgvReaders.SelectedRows[0].Cells["ID"].Value);
            string bookTitle = dgvBooks.SelectedRows[0].Cells["Название"].Value.ToString();

            // Проверяем, есть ли книга в наличии
            DataTable dt = db.GetData($"SELECT Count FROM Books WHERE ID = {bookId}");
            int currentCount = Convert.ToInt32(dt.Rows[0]["Count"]);

            if (currentCount > 0)
            {
                // Уменьшаем количество книг
                db.ExecuteQuery($"UPDATE Books SET Count = Count - 1 WHERE ID = {bookId}");
                // Добавляем запись о выдаче
                db.ExecuteQuery($"INSERT INTO Loans (BookID, ReaderID, LoanDate) VALUES ({bookId}, {readerId}, CURDATE())");

                MessageBox.Show($"Книга '{bookTitle}' выдана!\nОсталось экземпляров: {currentCount - 1}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBooks();
                LoadLoans();
            }
            else
            {
                MessageBox.Show("Книга отсутствует в библиотеке!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите выдачу в списке!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string bookTitle = dgvLoans.SelectedRows[0].Cells["Книга"].Value.ToString();
            string readerName = dgvLoans.SelectedRows[0].Cells["Читатель"].Value.ToString();

            // Получаем ID книги по названию
            DataTable dt = db.GetData($"SELECT ID FROM Books WHERE Title = '{bookTitle}'");
            if (dt.Rows.Count > 0)
            {
                int bookId = Convert.ToInt32(dt.Rows[0]["ID"]);

                // Увеличиваем количество книг
                db.ExecuteQuery($"UPDATE Books SET Count = Count + 1 WHERE ID = {bookId}");
                // Обновляем дату возврата
                db.ExecuteQuery($"UPDATE Loans SET ReturnDate = CURDATE() WHERE BookID = {bookId} AND ReturnDate IS NULL");

                MessageBox.Show($"Книга '{bookTitle}' возвращена читателем {readerName}!",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBooks();
                LoadLoans();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadBooks();
                LoadReaders();
                return;
            }

            if (cmbSearchType.SelectedIndex == 0) // Книги
            {
                string query = $"SELECT ID, Title as 'Название', Author as 'Автор', Year as 'Год', Genre as 'Жанр', Count as 'Количество' " +
                    $"FROM Books WHERE Title LIKE '%{searchText}%' OR Author LIKE '%{searchText}%'";
                dgvBooks.DataSource = db.GetData(query);
            }
            else // Читатели
            {
                string query = $"SELECT ID, FirstName as 'Имя', LastName as 'Фамилия', Phone as 'Телефон' " +
                    $"FROM Readers WHERE FirstName LIKE '%{searchText}%' OR LastName LIKE '%{searchText}%'";
                dgvReaders.DataSource = db.GetData(query);
            }
        }
    }
}