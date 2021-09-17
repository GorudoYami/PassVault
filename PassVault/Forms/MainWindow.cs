using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassVault {
    public partial class MainWindow : Form {
        private bool vaultOpen;
        private bool changesMade;

        private SQLiteDatabase db;

        public MainWindow() {
            InitializeComponent();
            vaultOpen = false;
            changesMade = false;
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            if (textBoxLogin.Text == string.Empty)
                MessageBox.Show("Login field is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBoxPassword.Text == string.Empty)
                MessageBox.Show("Password field is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                int index = dataGridView.Rows.Add(textBoxDescription.Text, textBoxLogin.Text, "**********", false);
                textBoxDescription.Text = string.Empty;
                textBoxLogin.Text = string.Empty;
                dataGridView.Rows[index].Tag = Encrypt(textBoxPassword.Text);
                textBoxPassword.Text = string.Empty;
                changesMade = true;
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e) {
            dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            changesMade = true;
        }

        private void ButtonChange_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void NewMenuItem_Click(object sender, EventArgs e) {
            var dialog = new NewDialog();
            dialog.ShowDialog();
        }
    }
}
