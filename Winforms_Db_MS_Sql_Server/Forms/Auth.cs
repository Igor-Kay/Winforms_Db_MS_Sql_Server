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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            string email = textBox1.Text;
            string password = textBox2.Text;
            
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Вы не ввели почту или пароль", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dataBase.SqlSelect("select * from [dbo].[Tasks] where Deadline = '" + email + "' and UserPassword = '" + password + "'").Rows.Count > 0)
                {
                    DataTable dt = dataBase.SqlSelect($"select [Deadline] from [dbo].[Tasks] where [Salary] = '" + email + "'");
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
                }
                else
                {
                    MessageBox.Show("Данные введены некорректно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
