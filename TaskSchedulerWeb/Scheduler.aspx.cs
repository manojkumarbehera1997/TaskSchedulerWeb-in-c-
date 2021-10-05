using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler;

namespace TaskSchedulerWeb
{
    public partial class Scheduler : System.Web.UI.Page
    {
        TaskSchedulerClass objScheduler;
        //To hold Task Definition
        ITaskDefinition objTaskDef;
        //To hold Trigger Information
        ITimeTrigger objTrigger;
        IDailyTrigger objDailyTrigger;
        IWeeklyTrigger objweeklyTrigger;
        IMonthlyTrigger objMonthlyTrigger;
        IMonthlyDOWTrigger objMonthlyDOWTrigger;
        IRegisteredTask registeredTask;
        //To hold Action Information
        IExecAction objAction;
        public string startTrigger;
        public string endDate;

        //public string Name;
        //public string State;
        //public string Triggers;
        //public string NextRunTime;
        //public string LastRunTime;
        //public string LastTaskResult;
        //public string Author;
        //public string Date;
        protected void Page_Load(object sender, EventArgs e)
        {

            GridView1.PreRender += new EventHandler(GridView1_SelectedIndexChanged);
            if (!IsPostBack)
            {
                GetTaskList();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objScheduler = new TaskSchedulerClass();
                if (cnctToSrvrChkBox.Checked == true)
                {
                    objScheduler.Connect(srvrNameTxtBox.Text, userTxtBox.Text, dmnTxtBox.Text, pwdTxtBox.Text);
                }
                else
                {
                    objScheduler.Connect();
                }

                //Setting Task Definition
                SetTaskDefinition();
                //Setting Task Trigger Information
                SetTriggerInfo();
                //Setting Task Action Information
                SetActionInfo();

                //Getting the roort folder
                ITaskFolder root = objScheduler.GetFolder("\\MDM");
                //Registering the task, if the task is already exist then it will be updated
                registeredTask = root.RegisterTaskDefinition(txtTaskName.Text, objTaskDef, (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE, null, null, _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN, "");

                ////To execute the task immediately calling Run()
                //IRunningTask runtask = regTask.Run(null);

                // msgLabel.Text = "Task is created successfully";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Task is created successfully')", true);
                GetTaskList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ////Setting Task Definition
        private void SetTaskDefinition()
        {
            try
            {
                objTaskDef = objScheduler.NewTask(0);
                //Registration Info for task
                //Name of the task Author
                objTaskDef.RegistrationInfo.Author = "TataPower";
                //Description of the task 
                objTaskDef.RegistrationInfo.Description = "MDMTask";
                //Registration date of the task 
                objTaskDef.RegistrationInfo.Date = DateTime.Today.ToString("yyyy-MM-ddTHH:mm:ss"); //Date format 

                //Settings for task
                //Thread Priority
                objTaskDef.Settings.Priority = 7;
                //Enabling the task
                objTaskDef.Settings.Enabled = true;
                //To hide/show the task
                objTaskDef.Settings.Hidden = false;
                //Execution Time Lmit for task
                objTaskDef.Settings.ExecutionTimeLimit = "PT10M"; //10 minutes
                //Specifying no need of network connection
                objTaskDef.Settings.RunOnlyIfNetworkAvailable = false;

                //Set to run on battery and AC power
                objTaskDef.Settings.DisallowStartIfOnBatteries = false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Setting Task Trigger Information
        private void SetTriggerInfo()
        {
            string startDate = Convert.ToDateTime(startDateTxtBox.Text).ToString("yyyy-MM-ddT");
            string startTime = timeTextBox.Text.ToString();
            startTrigger = startDate + startTime;
            endDate = Convert.ToDateTime(endDateTxtBox.Text).ToString("yyyy-MM-ddTHH:mm:ss");
            if (oneTimeRadio.Checked)
            {
                OneTimeTrigger();
            }
            else if (dailyRadio.Checked)
            {
                DailyTrigger();
            }
            else if (weeklyRadio.Checked)
            {
                WeeklyTrigger();
            }
            else if (monthlyRadio.Checked)
            {
                if (monthlyDaysRadio.Checked)
                {
                    MonthlyDays();
                }
                else
                {
                    MonthlyDOW();
                }
            }

        }
        //Setting Task Action Information
        private void SetActionInfo()
        {
            try
            {
                //Action information based on exe- TASK_ACTION_EXEC
                objAction = (IExecAction)objTaskDef.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
                //Action ID
                objAction.Id = "testAction1";
                //Set the path of the exe file to execute, Here mspaint will be opened
                objAction.Path = txtProgramName.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private action methods
        private void OneTimeTrigger()
        {
            try
            {
                //Trigger information based on time - TASK_TRIGGER_TIME
                objTrigger = (ITimeTrigger)objTaskDef.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);
                //Trigger ID
                objTrigger.Id = "MDMTaskTrigger";
                //Start Time
                objTrigger.StartBoundary = startTrigger; //yyyy-MM-ddTHH:mm:ss
                objTrigger.EndBoundary = endDate; //yyyy-MM-ddTHH:mm:ss

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void DailyTrigger()
        {
            try
            {
                //Trigger information based on time - TASK_TRIGGER_TIME
                objDailyTrigger = (IDailyTrigger)objTaskDef.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_DAILY);
                //Trigger ID
                objDailyTrigger.Id = "MDMTaskTrigger";
                //Start Time
                objDailyTrigger.StartBoundary = startTrigger; //yyyy-MM-ddTHH:mm:ss                                                          
                                                              // objTrigger.EndBoundary = endDate; //yyyy-MM-ddTHH:mm:ss
                var interval = Convert.ToInt32(numericUpDownDaily.Text);
                objDailyTrigger.DaysInterval = (short)interval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void WeeklyTrigger()
        {
            try
            {
                //Trigger information based on time - TASK_TRIGGER_TIME
                objweeklyTrigger = (IWeeklyTrigger)objTaskDef.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_WEEKLY);
                //Trigger ID
                objweeklyTrigger.Id = "MDMTaskTrigger";
                //Start Time
                objweeklyTrigger.StartBoundary = startTrigger; //yyyy-MM-ddTHH:mm:ss                                                             //End Time
                objweeklyTrigger.EndBoundary = endDate; //yyyy-MM-ddTHH:mm:ss                                
                var day = 0;
                foreach (ListItem listItem in weeklyLstBox.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Value;
                        day += Convert.ToInt32(val);
                    }
                }
                objweeklyTrigger.DaysOfWeek = (short)day;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void MonthlyDays()
        {
            try
            {
                //Trigger information based on time - TASK_TRIGGER_TIME
                objMonthlyTrigger = (IMonthlyTrigger)objTaskDef.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_MONTHLY);
                //Start Time
                objMonthlyTrigger.StartBoundary = startTrigger; //yyyy-MM-ddTHH:mm:ss                                                            
                objMonthlyTrigger.EndBoundary = endDate; //yyyy-MM-ddTHH:mm:ss
                int month = 0;
                foreach (ListItem listItem in monthlyLstBox.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Value;
                        month += Convert.ToInt32(val);
                    }
                }
                objMonthlyTrigger.MonthsOfYear = (short)month;
                int day = 0;
                foreach (ListItem listItem in monthlyDaysLstBox.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Value;
                        if (val.Contains("Last Day"))
                        {
                            objMonthlyTrigger.RunOnLastDayOfMonth = true;

                        }
                        else
                        {
                            day += Convert.ToInt32(val);
                        }
                    }
                }
                objMonthlyTrigger.DaysOfMonth = day;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void MonthlyDOW()
        {
            try
            {
                //Trigger information based on time - TASK_TRIGGER_TIME
                objMonthlyDOWTrigger = (IMonthlyDOWTrigger)objTaskDef.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_MONTHLYDOW);
                //Start Time
                objMonthlyDOWTrigger.StartBoundary = startTrigger; //yyyy-MM-ddTHH:mm:ss                                                            
                objMonthlyDOWTrigger.EndBoundary = endDate; //yyyy-MM-ddTHH:mm:ss
                int month = 0;
                foreach (ListItem listItem in monthlyLstBox.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Value;
                        month += Convert.ToInt32(val);
                    }
                }
                objMonthlyDOWTrigger.MonthsOfYear = (short)month;

                int day = 0;
                foreach (ListItem listItem in OnWeekDaysLstBox.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Value;
                        day += Convert.ToInt32(val);
                    }
                }
                objMonthlyDOWTrigger.DaysOfWeek = (short)day;

                short week = 0;
                foreach (ListItem listItem in onWeekNumberLstBox.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Text;
                        if (val.Contains("First"))
                        {
                            week += 1;
                        }
                        else if (val.Contains("Second"))
                        {
                            week += 2;
                        }
                        else if (val.Contains("Third"))
                        {
                            week += 4;
                        }
                        else if (val.Contains("Fourth"))
                        {
                            week += 8;
                        }
                    }
                }
                objMonthlyDOWTrigger.WeeksOfMonth = week;
                foreach (ListItem listItem in onWeekNumberLstBox.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Text;
                        if (val.Contains("Last"))
                        {
                            objMonthlyDOWTrigger.RunOnLastWeekOfMonth = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        public void GetTaskList()
        {

            objScheduler = new TaskSchedulerClass();

            if (cnctToSrvrChkBox.Checked == true)
            {
                objScheduler.Connect(srvrNameTxtBox.Text, userTxtBox.Text, dmnTxtBox.Text, pwdTxtBox.Text);
            }
            else
            {
                objScheduler.Connect();
            }

            //objScheduler.Connect();
            ITaskFolder root = objScheduler.GetFolder("\\MDM");
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Name", typeof(string)),
                    new DataColumn("State", typeof(string)),
                    new DataColumn("Triggers",typeof(string)),
                new DataColumn("NextRunTime",typeof(string)),
                new DataColumn("LastRunTime",typeof(string)),
                new DataColumn("LastTaskResult",typeof(string)),
                new DataColumn("Author",typeof(string)),
                new DataColumn("Date",typeof(string))});

            foreach (IRegisteredTask task in root.GetTasks(1))
            {
                DataRow dr = null;
                dr = dt.NewRow();
                dr["Name"] = task.Name.ToString();
                dr["State"] = ConvertState(task.State.ToString());
                dr["Triggers"] = ConvertTriggerInfo(task.Definition.Triggers);
                dr["NextRunTime"] = task.NextRunTime.ToString();
                dr["LastRunTime"] = task.LastRunTime.ToString();
                dr["LastTaskResult"] = task.LastTaskResult.ToString();
                dr["Author"] = task.Definition.RegistrationInfo.Author.ToString();
                dr["Date"] = task.Definition.RegistrationInfo.Date.ToString();
                dt.Rows.Add(dr);
                ViewState["CurrentTable"] = dt;
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //Determine the RowIndex of the Row whose Button was clicked.              
                var rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];
                string Name = row.Cells[0].Text;
                objScheduler = new TaskSchedulerClass();
                objScheduler.Connect();
                ITaskFolder containingFolder = objScheduler.GetFolder("\\MDM");
                //Deleting the task
                containingFolder.DeleteTask(Name, 0);  //Give name of the Task
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Name + " is deleted successfully')", true);
                GetTaskList();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private string ConvertTriggerInfo(ITriggerCollection trigger)
        {
            string triggerInfo = "";

            switch (trigger[1].Type)
            {
                case _TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME:
                    triggerInfo += "One Time;";
                    triggerInfo += " At " + Convert.ToDateTime(trigger[1].StartBoundary).ToShortTimeString();
                    break;
                case _TASK_TRIGGER_TYPE2.TASK_TRIGGER_DAILY:
                    triggerInfo += "Daily;";
                    triggerInfo += " At " + Convert.ToDateTime(trigger[1].StartBoundary).ToShortTimeString();
                    break;
                case _TASK_TRIGGER_TYPE2.TASK_TRIGGER_WEEKLY:
                    triggerInfo += "Weekly;";
                    triggerInfo += " At " + Convert.ToDateTime(trigger[1].StartBoundary).ToShortTimeString();
                    break;
                case _TASK_TRIGGER_TYPE2.TASK_TRIGGER_MONTHLY:
                    triggerInfo += "Monthly;";
                    break;
                case _TASK_TRIGGER_TYPE2.TASK_TRIGGER_MONTHLYDOW:
                    triggerInfo += "Monthly;";
                    triggerInfo += " At " + Convert.ToDateTime(trigger[1].StartBoundary).ToShortTimeString();
                    break;
                default:
                    triggerInfo += "";
                    break;
            }

            //switch (trigger[1].Day)
            //{

            //}




            return triggerInfo;
        }

        private string ConvertState(string state)
        {
            string state_out = "";
            switch (state)
            {
                case "TASK_STATE_UNKNOWN":
                    state_out = "Unknown";
                    break;
                case "TASK_STATE_DISABLED":
                    state_out = "Disabled";
                    break;
                case "TASK_STATE_QUEUED":
                    state_out = "Queued";
                    break;
                case "TASK_STATE_READY":
                    state_out = "Ready";
                    break;
                case "TASK_STATE_RUNNING":
                    state_out = "Running";
                    break;
                default:
                    state_out = "";
                    break;
            }
            return state_out;
        }
    }
}