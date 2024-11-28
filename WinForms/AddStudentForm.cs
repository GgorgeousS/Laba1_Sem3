using BusinessLogic;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinForms
{
    public partial class AddStudentForm : Form
    {
        private Logic logic;
        private IKernel kernel;

        public AddStudentForm()
        {
            IKernel kernel = new StandardKernel(new SimpleConfigModule());

            // Получение экземпляра Logic через Ninject
            logic = kernel.Get<Logic>();

            InitializeComponent();
        }
 
       
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string speciality = textSpeciality.Text;
            string group = textGroup.Text;
            int number = logic.GetAllStudents().Count;
            try { logic.AddStudent(number, name, speciality, group); }
            catch
            {
                MessageBox.Show("Невозможно добавить студента, заполнены не все поля.");
                return;
            }
            this.Close();
        }
        /// <summary>
        /// Подсвечивание кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            AddButton.BackColor = Color.Plum;
        }

        /// <summary>
        /// Подсвечивание кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_MouseLeave(object sender, EventArgs e)
        {
            AddButton.BackColor = Color.White;
        }
    }
}
