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
    public partial class ViewForm : Form
    {
        Movie movie;
        Form parentForm;
        public ViewForm(Form callingForm, Movie _movie)
        {
            this.movie = _movie;
            this.parentForm = callingForm;
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            lblName.Text = movie.Name;
            lblBudget.Text = movie.Budget.ToString();
            lblDescription.Text = movie.Description;
            lblFormat.Text = movie.Format;
            lblGenre.Text = String.Join(", ", movie.Genre.ToArray());
            lblLanguage.Text = movie.Language;
            lblLength.Text = movie.MovieLength;
            lblType.Text = movie.Type;
        }

        private void ViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            (parentForm.Controls.Find("btnSubmit", true)[0] as Button).Enabled = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to register this movie ??",
                                     "Confirm Save!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
            }
            else
            {
                return;
            }
            Business.MovieInfo.Add(movie);

            StringBuilder _messageBuilder = new StringBuilder();
            _messageBuilder.Append($"• Movie '{movie.Name}' has been Registered in {movie.Type} Resolution.");
            _messageBuilder.Append(Environment.NewLine);
            _messageBuilder.Append(Environment.NewLine);
            _messageBuilder.Append($"• You have Selected { String.Join(", ", movie.Genre.ToArray()) } Genres.");
            _messageBuilder.Append(Environment.NewLine);
            _messageBuilder.Append(Environment.NewLine);
            _messageBuilder.Append($"• Movie format {movie.Format} of length {movie.MovieLength} has been added.");

            MessageBox.Show(_messageBuilder.ToString());

            (parentForm.Controls.Find("btnSubmit", true)[0] as Button).Enabled = true;
            foreach (Control control in parentForm.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.Text = string.Empty;
                }
                else if (control is CheckBox)
                {
                    CheckBox chkbox = (CheckBox)control;
                    chkbox.Checked = false;
                }
                else if (control is CheckedListBox)
                {
                    CheckedListBox chklistbox = (CheckedListBox)control;
                    while (chklistbox.CheckedIndices.Count > 0)
                        chklistbox.SetItemChecked(chklistbox.CheckedIndices[0], false);

                }
                else if (control is ComboBox)
                {
                    ComboBox cmbBox = (ComboBox)control;
                    cmbBox.SelectedIndex = 1;
                }
                else if (control is GroupBox)
                {
                    GroupBox grpBox = (GroupBox)control;
                    foreach (Control _subCntrl in grpBox.Controls)
                    {
                        if (_subCntrl is RadioButton)
                        {
                            RadioButton rdbtn = (RadioButton)_subCntrl;
                            rdbtn.Checked = false;
                        }
                    }
                }
                else if (control is RadioButton)
                {
                    RadioButton rdbtn = (RadioButton)control;
                    rdbtn.Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)control;
                    dtp.Value = DateTime.Today.AddHours(01).AddMinutes(00);
                }
            }
            this.Close();
        }
    }
}
