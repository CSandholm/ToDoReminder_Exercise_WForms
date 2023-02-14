using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class TaskItem
    {
        private string description;
        private PriorityType priority;
        private DateTime date;

        //constructor with three parameters
        public TaskItem(string name, PriorityType priority, DateTime date)
        {
            this.description = name;
            this.priority = priority;
            this.date = date;
        }
        //construct without parameters
        public TaskItem()
        {

        }

        //properties for description
        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    description = value;
                }
            }
        }
        //properties for priority
        public PriorityType Priority
        {
            get { return priority; }
            set
            {
                if(Enum.IsDefined(typeof(PriorityType), value))
                {
                    priority = value;
                }
            }
        }

        //properties for date
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
            }
        }

        //method for getting time as a string
        private string GetTimeString()
        {
            string dateHolder;
            dateHolder = this.date.ToShortTimeString();
            return dateHolder;
        }

        //method for getting priority as a string
        private string GetPriorityString()
        {
            string prio;
            prio = this.priority.ToString();
            prio = prio.Replace("_", " "); //replacing '_' with ' '
            return prio;
        }

        //ToString method to present results in the list
        public override string ToString()
        {
            string outText = string.Empty;

            outText = $"{date.ToShortDateString(),-12}" +
                $"{GetTimeString(),-7}" +
                $"{GetPriorityString(), -16}" +
                $"{description}";

            return outText;
        }
    }
}
