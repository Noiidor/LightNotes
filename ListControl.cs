using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtentionMethods;
using System.IO;

namespace LightNotes
{
    public partial class ListControl : UserControl
    {

        public DataTable dt;
        private AppBase app;
        private TextBox rename_tbox;
        private string listDataPath;
        private string folderPath;

        private string[] listDataFiles;

        private int CorruptIndex;

        public ListControl()
        {
            InitializeComponent();
        }


        private void ListControl_Load(object sender, EventArgs e)
        {
            app = (AppBase)this.Parent.Parent;
            folderPath = app.folderPath;

            dt = new DataTable();

            listDataFiles = Directory.GetFiles(folderPath, "*.xml", SearchOption.TopDirectoryOnly);
            CreateListsFromXml();

            this.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
        }

        private void button_add_tab_Click(object sender, EventArgs e)
        {
            AddTab("New Tab");
        }

        private void AddTab(string tabName)
        {
            //TabPage newPage = new TabPage("TabPage" + (tabControl1.TabCount + 1).ToString());
            TabPage newPage = new TabPage(tabName);
            newPage.BackColor = Color.PeachPuff;
            newPage.Controls.Add(new ListPrefab());
            tabControl1.TabPages.Add(newPage);
        }

        private void button_delete_tab_Click(object sender, EventArgs e)
        {
            //File.Delete(listDataFiles[(tabControl1.SelectedIndex )]);
            if (tabControl1.TabCount != 0)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                tabControl1.Refresh();
            }
            
            
            
        }

        public void SaveLists()
        {
            dt = new DataTable("penis");
            int i = 0;

            // Костыль...maybe?
            //Удаляет все файлы и сохраняет по новой
            foreach (String file in listDataFiles)
            {
                File.Delete(file);
            }

            foreach (TabPage tab in tabControl1.TabPages)
            {
                DataGridView dataGrid = tab.Controls.OfType<ListPrefab>().First().Controls.OfType<DataGridView>().First();
                dataGrid.Rows[0].Cells["tabName"].Value = tab.Text;
                dt.FromDataGridView(dataGrid);
                listDataPath = folderPath + @"\list" + i.ToString() + ".xml";
                if (dt.Rows.Count != 0)
                {
                    dt.WriteXml(listDataPath);
                }
                
                dt.Clear();
                i += 1;
            }
        }

        private void CreateListsFromXml()
        {
            if (listDataFiles.Length != 0)
            {
                for (int i = 0; i < listDataFiles.Length; i++)
                {
                    try
                    {
                        CorruptIndex = i;
                        dt = new DataTable("penis");
                        dt.ReadXmlSchema(listDataFiles[i]);
                        dt.ReadXml(listDataFiles[i]);
                        AddTab(dt.Rows[0].Field<string>("tabName"));
                    }
                    catch
                    {
                        tabControl1.TabPages.Clear();
                        FileCorruptionPopup pop = new FileCorruptionPopup();
                        pop.button_corruptClick += Pop_button_corruptClick;
                        pop.ShowDialog();
                        
                    }
                    
                }
            }
        }

        private void Pop_button_corruptClick(object sender, EventArgs e)
        {
            
            File.Delete(listDataFiles[CorruptIndex]);
            List<string> filesList = listDataFiles.ToList();
            filesList.RemoveAt(CorruptIndex);
            listDataFiles = filesList.ToArray();
            CreateListsFromXml();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveLists();
            tabControl1.TabPages.Clear();
            CreateListsFromXml();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            CreateListsFromXml();
        }

        private void button_rename_tab_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedTab.Name =
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabControl tc = sender as TabControl;
            if (tc != null)
            {
                for (int i = 0; i < tc.TabCount; ++i)
                {
                    if (tc.GetTabRect(i).Contains(e.Location))
                    {
                        TabPage tp = tc.TabPages[i];

                        rename_tbox = new TextBox();
                        
                        this.Controls.Add(rename_tbox);

                        label1.Text = Controls.Count.ToString();

                        rename_tbox.Parent = tp;
                        rename_tbox.Size = new Size(100, 100);
                        rename_tbox.Location = tc.GetTabRect(i).Location;
                        rename_tbox.Multiline = false;
                        rename_tbox.BringToFront();
                        
                        rename_tbox.Focus();
                        rename_tbox.LostFocus += PenisFunc;
                        //rename_tbox.KeyPress += rename_tbox_KeyPress;
                        rename_tbox.KeyDown += rename_tbox_KeyDown;

                    }
                }
            }
        }

        private void PenisFunc(object sender, EventArgs e)
        {
            rename_tbox.Dispose();
            //this.Controls.Remove(rename_tbox);
            label1.Text = Controls.Count.ToString();

        }

        private void rename_tbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox tbox = sender as TextBox;
                TabPage tp = tbox.Parent as TabPage;
                tp.Text = tbox.Text;
                tabControl1.Refresh();
                
            }
        }
    }
    
}
