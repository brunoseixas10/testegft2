using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trades2.Application.Interfaces;
using Trades2.Entities;

namespace Trades2.Presentation
{
    public partial class Form1 : Form
    {
        private static List<string> tradeCategories;
        private readonly ITradeApp _tradeApp;

        public Form1(ITradeApp tradeApp)
        {
            InitializeComponent();
            _tradeApp = tradeApp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtValor.Text = string.Empty;
            tradeCategories = new List<string>();
            cmbSetor.Items.Add("Public");
            cmbSetor.Items.Add("Private");
            cmbSetor.SelectedIndex = 0;
        }

        private void btnListarCategorias_Click(object sender, EventArgs e)
        {
            tradeCategories = _tradeApp.GetCategories().ToList();
            MessageBox.Show($"Categorias: {string.Join(" ", tradeCategories)}");
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            _tradeApp.Add(new Trade { ClientSector = cmbSetor.SelectedItem.ToString(), Value = Convert.ToDouble(txtValor.Text) });
            MessageBox.Show("Adicionado");
        }
    }
}
