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
    public partial class AllMovies : Form
    {
        public AllMovies()
        {
            InitializeComponent();
        }

        private void AllMovies_Load(object sender, EventArgs e)
        {
            List<Movie> _movies = Business.MovieInfo.GetAll();
            dataGridView1.DataSource = _movies.Select(p => new { p.ID, p.Name, p.Language }).ToList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<Movie> _movies = Business.MovieInfo.GetAll();
            Parallel.ForEach(_movies, _movie =>
            {
                Business.MovieInfo.Print(_movie);
                this.Invoke(new MethodInvoker(delegate () {
                    lblLogs.Text += $"\r\n Print {_movie.Name}";
                }));
            });
        }
    }
}
