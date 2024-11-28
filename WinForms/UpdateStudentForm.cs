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

namespace WinForms
{
    public partial class UpdateStudentForm : Form
    {
        private Logic logic;
        private IKernel kernel;
        private int id;
       
        public UpdateStudentForm(int Id)
        {
            // Создание IoC-контейнера и настройка внедрения зависимостей
            IKernel kernel = new StandardKernel(new SimpleConfigModule());

            // Получение экземпляра Logic через Ninject
            logic = kernel.Get<Logic>();
            InitializeComponent();
            this.id = Id;
        }
       

        

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string newname = textNameUp.Text;
            string newSpeciality = textSpecialityUp.Text;
            string newGroup = textGroupUp.Text;
            try { logic.UpdateStudent(id, newname, newSpeciality, newGroup); }
            catch
            {
                MessageBox.Show("Возникло пустое поле, повторите еще раз.");
                return;
            }
            this.Close();
        }

        private void buttonUpdate_MouseEnter(object sender, EventArgs e)
        {
            buttonUpdate.BackColor = Color.Plum;
        }

        private void buttonUpdate_MouseLeave(object sender, EventArgs e)
        {
            buttonUpdate.BackColor = Color.White;
        }
    }
    
}
