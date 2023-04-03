using System;
using System.IO;
using System.Windows.Forms;

namespace New_Splash_Screen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Add Button
        private void AddButton_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount++;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Name = textBox1.Text;
            textBox1.Clear();
        }
        // Delete Button
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.SelectedCells[0].ColumnIndex);
            }
        }
        // New Tool Strip Item 
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
        }
        // Open Tool Strip Item 
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Columns.Clear();

                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    string line;
                    string[] fields;

                    if ((line = reader.ReadLine()) != null)
                    {
                        fields = line.Split(',');
                        foreach (string field in fields)
                        {
                            dataGridView1.Columns.Add(field, field);
                        }
                    }

                    while ((line = reader.ReadLine()) != null)
                    {
                        fields = line.Split(',');
                        dataGridView1.Rows.Add(fields);
                    }
                }
            }
        }
        // Save Tool Strip Item
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numRows = dataGridView1.Rows.Count;
            int numCols = dataGridView1.Columns.Count;
            string[,] array = new string[numRows + 1, numCols];

            for (int j = 0; j < numCols; j++)
            {
                array[0, j] = dataGridView1.Columns[j].HeaderText;
            }


            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        array[i + 1, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        array[i + 1, j] = string.Empty;
                    }
                }
            }
            // Open Tool Strip Item
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int i = 0; i < numRows + 1; i++)
                    {
                        for (int j = 0; j < numCols; j++)
                        {
                            sw.Write(array[i, j]);
                            if (j < numCols - 1)
                            {
                                sw.Write(",");
                            }
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        // Close Tool Strip Item
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String text = "SpreadSheetExcel Pro+ Beta 1.1";
            MessageBox.Show(text);
        }
    }
}
