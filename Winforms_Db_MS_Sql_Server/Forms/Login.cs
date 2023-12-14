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
    public partial class Login : Form
    {
        private DataBase dataBase;
        public Login(DataBase db)
        {
            InitializeComponent();
            dataBase = db;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Вы не ввели почту или пароль", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dataBase.SqlSelect($"select * from [dbo].[User] where Email  =  '{email}' or Login  = '{email}' and Password = '{password}'").Rows.Count > 0)
                {
                    DataTable dt = dataBase.SqlSelect($"select [RoleID] from [dbo].[User] where [Login] = '" + email + "'");
                    int role = Convert.ToInt32(dt.Rows[0][0]);
                    if (role == 1)
                    {
                        MessageBox.Show("Administrator", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (role == 2)
                    {
                        MessageBox.Show("Manager", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (role == 3)
                    {
                        MessageBox.Show("Client", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Forms.Form1 form1 = new Forms.Form1(dataBase);
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("Данные введены некорректно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
