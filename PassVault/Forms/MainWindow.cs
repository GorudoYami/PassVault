using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassVault {
    public partial class MainWindow : Form {
        private bool vaultOpen;
        private bool changesMade;
        private string filePath;

        private Crypto crypto;

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
                dataGridView.Rows[index].Tag = crypto.Encrypt(textBoxPassword.Text);
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
            crypto = new Crypto(dialog.Password);
        }

        private async void Save() {
            // Read grid to list
            List<Entry> entryList = new();
            foreach (DataGridViewRow row in dataGridView.Rows) {
                entryList.Add(new Entry() {
                    Description = (string)row.Cells["columnDescription"].Value,
                    Login = (string)row.Cells["columnLogin"].Value,
                    Password = (string)row.Tag
                });
            }
            dataGridView.Rows.Clear();

            // Serialize it and save to json
            var json = JsonSerializer.Serialize(entryList);
            using StreamWriter writer = new(filePath);
            await writer.WriteAsync(json);
            writer.Close();
        }

        private async void Load() {
            using StreamReader reader = new(filePath);
            var json = await reader.ReadToEndAsync();
            reader.Close();
            var entryList = JsonSerializer.Deserialize<List<Entry>>(json);
            foreach (var entry in entryList) {
                dataGridView.Rows.Clear();
            }
        }
    }
}
