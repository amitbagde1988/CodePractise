using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.ProdHouse.Models;

namespace Test.ProdHouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            drpLanguage.SelectedIndex = 1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                btnSubmit.Enabled = false;
                int.TryParse(txtBudget.Text, out int _length);
                Movie newMovie = new Movie()
                {
                    Name = txtMovieName.Text,
                    Type = GetValueFromGrpBox(grpTypes),
                    Budget = _length,
                    MovieLength = dateTimePicker1.Text,
                    Format = GetValueFromGrpBox(grpFormats),
                    Description = txtDescription.Text,
                    Language = drpLanguage.SelectedItem.ToString(),
                    Genre = chkGenre.CheckedItems.Cast<string>().ToList(),
                    Status = "Draft"
                };

                ViewForm _form = new ViewForm(this, newMovie);
                _form.Show();
            }
        }

        string GetValueFromGrpBox(GroupBox grpBox)
        {
            foreach (var _controls in grpBox.Controls)
            {
                if ((_controls is RadioButton))
                    if ((_controls as RadioButton).Checked)
                        return (_controls as RadioButton).Text;
            }
            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllMovies _form = new AllMovies();
            _form.Show();
            //this.Close();
        }

        private void txtMovieName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMovieName.Text))
            {
                e.Cancel = true;
                txtMovieName.Focus();
                errorProviderApp.SetError(txtMovieName, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderApp.SetError(txtMovieName, "");
            }
        }

        private void txtBudget_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBudget.Text))
            {
                e.Cancel = true;
                txtBudget.Focus();
                errorProviderApp.SetError(txtBudget, "Budget should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderApp.SetError(txtBudget, "");
            }
        }

        private void grpTypes_Validating(object sender, CancelEventArgs e)
        {
            if(sender is GroupBox)
            {
                foreach(var _control in (sender as GroupBox).Controls)
                {
                    if((_control as RadioButton).Checked)
                    {
                        e.Cancel = false;
                        errorProviderApp.SetError(grpTypes, "");
                        return;
                    }
                }
            }
            e.Cancel = true;
            errorProviderApp.SetError(grpTypes, "Select Types!");
        }

        private void grpFormats_Validating(object sender, CancelEventArgs e)
        {
            if (sender is GroupBox)
            {
                foreach (var _control in (sender as GroupBox).Controls)
                {
                    if ((_control as RadioButton).Checked)
                    {
                        e.Cancel = false;
                        errorProviderApp.SetError(grpFormats, "");
                        return;
                    }
                }
            }
            e.Cancel = true;
            errorProviderApp.SetError(grpFormats, "Select Formats!");
        }

        private void txtMovieName_TextChanged(object sender, EventArgs e)
        {
            Movie _movie = Business.MovieInfo.GetOne(txtMovieName.Text);
            if(_movie != null)
            {
                var arr = _movie.MovieLength.Split(new char[] { ':' });
                txtBudget.Text = _movie.Budget.ToString();
                txtDescription.Text = _movie.Description;
                dateTimePicker1.Value = DateTime.Today.AddHours(Convert.ToInt32(arr[0])).AddMinutes(Convert.ToInt32(arr[1]));
            }
        }
    }
}
