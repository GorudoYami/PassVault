using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassVault {
    public partial class NewDialog : Form {
        public string Password { get; private set; }
        public NewDialog() {
            InitializeComponent();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e) {
            // Validate password
            if (inputPass1.Text.Length == 0)
                labelInfo.Text = "You need to set a password!";
            else if (inputPass2.Text.Length == 0)
                labelInfo.Text = "Please repeat your password!";
            else if (inputPass1.Text != inputPass2.Text)
                labelInfo.Text = "Passwords do not match!";
            else if (inputPass1.Text.Length < 8)
                labelInfo.Text = "Minimum eight characters!";
            else {
                Password = inputPass1.Text;
                Close();
            }
        }
    }
}
