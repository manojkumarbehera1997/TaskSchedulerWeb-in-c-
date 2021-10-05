using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler;

namespace TriggerInfo
{
    public class Triggers
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
        //To hold Action Information
        IExecAction objAction;
        
        public void OneTimeScheduler(OneTime oneTime)
        {
            try
            {
                objScheduler = new TaskSchedulerClass();
                objScheduler.Connect();
                SetTaskDefinition();
                //Setting Task Action Information
                SetActionInfo();
                //Trigger information based on time - TASK_TRIGGER_TIME
                objTrigger = (ITimeTrigger)objTaskDef.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);
                //Trigger ID
                objTrigger.Id = oneTime.Id;
                //Start Time
                objTrigger.StartBoundary = oneTime.StartTrigger; //yyyy-MM-ddTHH:mm:ss
                objTrigger.EndBoundary = oneTime.EndTrigger; //yyyy-MM-ddTHH:mm:ss

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        private void SetActionInfo()
        {
            try
            {
                //Action information based on exe- TASK_ACTION_EXEC
                objAction = (IExecAction)objTaskDef.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
                //Action ID
                objAction.Id = "testAction1";
                //Set the path of the exe file to execute, Here mspaint will be opened
                objAction.Path = "mspaint";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
