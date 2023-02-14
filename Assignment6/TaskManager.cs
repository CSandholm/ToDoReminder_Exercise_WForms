using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class TaskManager
    {
        //desclare a new list object
        private List<TaskItem> taskList;

        //constructor
        public TaskManager()
        {
            taskList = new List<TaskItem>();
        }

        //property for returning the amount of items in the list
        public int Count
        {
            get { return taskList.Count; }
        }

        //method for adding a task to the list
        public bool AddTask(TaskItem taskIn)
        {
            bool ok = false;

            if(taskIn != null)
            {
                taskList.Add(taskIn);
                ok = true;
            }
            return ok;
        }

        //method to make sure every task if respresented by a string for the GUI list
        public string[] ListToString()
        {
            string[] taskArray = new string[taskList.Count];

            for(int i = 0; i < Count; i++)
            {
                taskArray[i] = taskList[i].ToString();
            }
            return taskArray;
        }
        public void ClearList()
        {
            taskList.Clear();
        }
    }

}
