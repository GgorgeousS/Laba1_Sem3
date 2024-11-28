using BusinessLogic;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;


namespace WinForms
{
    public partial class DistributionForm : Form
    {
        private Logic logic;
        private IKernel kernel;
        public DistributionForm(Dictionary<string, int> specialityCounts)
        {
            // Создание IoC-контейнера и настройка внедрения зависимостей
            IKernel kernel = new StandardKernel(new SimpleConfigModule());

            // Получение экземпляра Logic через Ninject
            logic = kernel.Get<Logic>();
            InitializeComponent();
            LoadChart(specialityCounts);
        }
        /// <summary>
        /// Построение графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadChart(Dictionary<string, int> specialityCounts)
        {
            chart1.Series.Clear();

            foreach (var speciality in specialityCounts)
            {
                Series series = chart1.Series.Add(speciality.Key);
                series.Points.Add(speciality.Value);
            }

            chart1.ChartAreas[0].AxisX.Title = "Специальность";
            chart1.ChartAreas[0].AxisY.Title = "Количество студентов";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
        }

    }
}
