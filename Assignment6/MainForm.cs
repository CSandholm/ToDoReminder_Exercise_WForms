using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class MainForm : Form
    {
        //declaration new TaskManager object
        TaskManager taskManager = new TaskManager();

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            //clear To do list
            lstToDo.Items.Clear();

            //fill combobox with priority options
            cmbPrio.Items.AddRange(Enum.GetNames(typeof(PriorityType)));

            //remove '_' with ' ' in combobox priorites
            cmbPrio.Items.Clear();
            string[] priority = Enum.GetNames(typeof(PriorityType));
            foreach (var item in priority) cmbPrio.Items.Add(item.Replace("_", " "));

            //set default priority
            cmbPrio.SelectedIndex = (int)PriorityType.Normal;
            //set default description selection, empty
            txtDesc.Text = string.Empty;
            //set keybinding for menu strip new, ctrl+n
            toolStripNew.ShortcutKeys = Keys.Control | Keys.N;

            //set default date, today current time
            dateTimePicker1.Value = DateTime.Now;
            //set datepicker format
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd    HH:mm";
            //tooltip for DateTimePicker
            ToolTip dateToolTip = new ToolTip();
            dateToolTip.ShowAlways = true;
            dateToolTip.SetToolTip(dateTimePicker1, "Click the icon to open calendar and choose date, write time here. " +
                "Make sure you don't change date by mistake");
        }

        //method for updating ToDo list and emptying textboxes
        private void UpdateGUI()
        {
            lstToDo.Items.Clear();
            lstToDo.Items.AddRange(taskManager.ListToString());
        }
        //timer tick
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongTimeString();
        }

        //add taskitem to list
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success = false;

            TaskItem item = ReadInput(out success);

            taskManager.AddTask(item);
            UpdateGUI();

        }

        //method for reading input from user
        private TaskItem ReadInput(out bool success)
        {
            TaskItem task = new TaskItem();
            task.Description = txtDesc.Text;
            task.Date = dateTimePicker1.Value;
            task.Priority = (PriorityType)cmbPrio.SelectedIndex;
            success = true;

            return task;
        }

        //from menu: new >> clear list and initialize GUI
        private void toolStripNew_Click(object sender, EventArgs e)
        {
            taskManager.ClearList();
            InitializeGUI();
        }

        //methods for closing app and giving option to cancel(menu exit click)
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //method for FormClosing, will trigger everytime before app is shut down
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ResultFromQuitDialog();
        }

        //method for dialog choice exit or cancel before app is terminated
        private bool ResultFromQuitDialog()
        {
            return MessageBox.Show("Do you really want to quit?", "Exit", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK;
        }

        //calls the about box
        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }
        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
