using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightNotes
{
    public partial class ListPrefab : UserControl
    {
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private DataTable dt;

        public ListPrefab()
        {
            InitializeComponent();
        }

        private void ListPrefab_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows[0].Height = 35;
            dataGridView1.Rows[0].Cells[0].Value = "1.";
            dataGridView1.Rows[0].Cells["tabName"].Value = this.Parent.Text;
            dataGridView1.Rows[0].Cells["tabIndex"].Value = this.Parent.TabIndex;

            ListControl listControl = (ListControl)this.Parent.Parent.Parent;

            //dataGridView1.AutoGenerateColumns = false;
            
            dt = new DataTable();
            
            dt = listControl.dt;
            //dataGridView1.DataSource = dt;
            //dataGridView1.Columns["index"].DataPropertyName = "index";
            //dataGridView1.Columns["value"].DataPropertyName = "value";
            //dataGridView1.Columns["tabName"].DataPropertyName = "tabName";
            //dataGridView1.Columns["tabIndex"].DataPropertyName = "tabIndex";
            //dataGridView1.Update();
            //dataGridView1.DataSource = null;

            this.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i].ItemArray);
            }
            dt.Clear();

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString() + '.';
                }
            }
            
            //int lastRowIndex = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            //dataGridView1.Rows[lastRowIndex].Cells[0].Value = (lastRowIndex + 1).ToString() + '.';


        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(
                    dataGridView1.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
                dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;



            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                if (rowIndexOfItemUnderMouseToDrop < 0)
                {
                    return;
                }
                dataGridView1.Rows.RemoveAt(rowIndexFromMouseDown);
                dataGridView1.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
            }
        }
    }
}
