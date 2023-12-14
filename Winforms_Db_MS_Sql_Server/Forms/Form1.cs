using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winforms_Db_MS_Sql_Server.Classes;

namespace Winforms_Db_MS_Sql_Server.Forms
{
    public partial class Form1 : Form
    {
        public Form1(DataBase db)
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "igors_project_data_baseDataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.igors_project_data_baseDataSet.User);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "igors_project_data_baseDataSet.Task". При необходимости она может быть перемещена или удалена.
            this.taskTableAdapter.Fill(this.igors_project_data_baseDataSet.Task);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "igors_project_data_baseDataSet.ProjectStatus". При необходимости она может быть перемещена или удалена.
            this.projectStatusTableAdapter.Fill(this.igors_project_data_baseDataSet.ProjectStatus);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "igors_project_data_baseDataSet.Project". При необходимости она может быть перемещена или удалена.
            this.projectTableAdapter.Fill(this.igors_project_data_baseDataSet.Project);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
