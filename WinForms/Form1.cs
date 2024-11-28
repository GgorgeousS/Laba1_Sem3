using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLogic.Logic;
using Ninject;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private Logic logic;
        private IKernel kernel;
        public Form1()
        {
            // Создание IoC-контейнера и настройка внедрения зависимостей
            IKernel kernel = new StandardKernel(new SimpleConfigModule());

            // Получение экземпляра Logic через Ninject
            logic = kernel.Get<Logic>();

            InitializeComponent();
            InitializeListView();
            LoadStudents();
        }

        /// <summary>
        /// Инициализация ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeListView()
        {
            listViewStudents.View = View.Details;
            listViewStudents.FullRowSelect = true;
            listViewStudents.GridLines = true;
            listViewStudents.Columns.Clear();
            listViewStudents.Columns.Add("Номер", 100);
            listViewStudents.Columns.Add("Имя", 100);
            listViewStudents.Columns.Add("Специальность", 100);
            listViewStudents.Columns.Add("Группа", 100);
        }

        /// <summary>
        /// Подгрузка студентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadStudents()
        {
            listViewStudents.Items.Clear();

            foreach (var student in logic.GetAllStudents())
            {
                var item = new ListViewItem(student[0]);
                item.SubItems.Add(student[1]);
                item.SubItems.Add(student[2]);
                item.SubItems.Add(student[3]);
                listViewStudents.Items.Add(item);
            }
        }
        /// <summary>
        /// Обработчик кнопки добавления студентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Addbutton_Click(object sender, EventArgs e)
        {
            var addForm = new AddStudentForm();
            addForm.ShowDialog();
            RefreshStudentList();
        }


        /// <summary>
        /// Обработчик кнопки обновления студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshStudentList()
        {
            listViewStudents.Items.Clear();

            foreach (var student in logic.GetAllStudents())
            {
                var item = new ListViewItem(student[0]);
                item.SubItems.Add(student[1]);
                item.SubItems.Add(student[2]);
                item.SubItems.Add(student[3]);
                listViewStudents.Items.Add(item);
            }
        }
        /// <summary>
        /// Обработчик кнопки удаления студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try { var SelectedIt = listViewStudents.SelectedItems[0]; }
            catch
            {
                MessageBox.Show("Вы не выбрали студента, которого нужно удалить. Попробуйте еще раз.");
                return;
            }

            logic.RemoveStudent(Convert.ToInt32(listViewStudents.SelectedItems[0].Text));
            RefreshStudentList();
        }
        /// <summary>
        /// Обработчик кнопки изменения студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var updateForm = new UpdateStudentForm(Convert.ToInt32(listViewStudents.SelectedItems[0].Text));
                updateForm.ShowDialog();
                RefreshStudentList();
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Выберите студента, данные которого хотите изменить.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Обработчик кнопки вывода гистаграммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try { logic.GetSpecialityDistribution(); }
            catch
            {
                MessageBox.Show("К сожалению, в списке нет ни одного студента, чтобы построить гистограмму.");
                return;
            }
            var distributionForm = new DistributionForm(logic.GetSpecialityDistribution());
            distributionForm.ShowDialog();
        }
        /// <summary>
        /// Подсветка кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveButton.BackColor = Color.Plum;
        }

        private void RemoveButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveButton.BackColor = Color.White;
        }

        private void ButtonUpdate_MouseEnter(object sender, EventArgs e)
        {
            ButtonUpdate.BackColor = Color.Plum;
        }

        private void ButtonUpdate_MouseLeave(object sender, EventArgs e)
        {
            ButtonUpdate.BackColor = Color.White;
        }

        private void Addbutton_MouseEnter(object sender, EventArgs e)
        {
            Addbutton.BackColor = Color.Plum;
        }

        private void Addbutton_MouseLeave(object sender, EventArgs e)
        {
            Addbutton.BackColor = Color.White;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            buttonDis.BackColor = Color.Plum;
        }

        private void buttonDis_MouseLeave(object sender, EventArgs e)
        {
            buttonDis.BackColor = Color.White;
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
