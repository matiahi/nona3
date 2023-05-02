using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace nona3
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}





		bool b = false;
		private void buttonX1_Click(object sender, EventArgs e)
		{
			
			if (b == false)
					{
						human h = new human();
		                h.name = textBoxX1.Text;
						h.family = textBoxX2.Text;
						h.age = Convert.ToByte(textBoxX3.Text);
						h = h.Register(h);
				
						dataGridViewX1.DataSource = null;
						dataGridViewX1.DataSource = h.read();
				        textBoxX1.Clear();
				        textBoxX2.Clear();
				        textBoxX3.Clear();


					}
					else
					{
						human h = new human();
                    	h.name = textBoxX1.Text;
						h.family = textBoxX2.Text;
						h.age = Convert.ToByte(textBoxX3.Text);
						h.update(id, h);
						dataGridViewX1.DataSource = null;
						dataGridViewX1.DataSource = h.read();
						buttonX1.Text = "Submit";
						b = false;

					}


		}

		int id;
		private int rowIndex;
		private void dataGridViewX1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{

			if (e.Button == MouseButtons.Right)
			{
				this.dataGridViewX1.Rows[e.RowIndex].Selected = true;
				this.rowIndex = e.RowIndex;
				this.dataGridViewX1.CurrentCell = this.dataGridViewX1.Rows[e.RowIndex].Cells[1];
				this.contextMenuStrip1.Show(this.dataGridViewX1, e.Location);
				contextMenuStrip1.Show(Cursor.Position);
			}
			id = (int)(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value);

		}
		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{

			b = true;
			
			human h = new human();
			h = h.read(id);
			textBoxX1.Text = h.name;
			textBoxX2.Text = h.family;
			textBoxX3.Text = h.age.ToString();
			buttonX1.Text = "Edit";

		}
		
		private void buttonX2_Click(object sender, EventArgs e)
		{
			db db1 = new db();
			human h = new human();
			dataGridViewX1.DataSource = null;
			dataGridViewX1.DataSource = h.read(textBoxX4.Text);
			

		}

	
		
	
	}
}
