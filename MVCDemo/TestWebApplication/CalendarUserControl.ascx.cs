using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebApplication
{
    public partial class CalendarUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                calendarCtrl.Visible = false;

        }

        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {
            if (calendarCtrl.Visible)
            { 
                calendarCtrl.Visible = false;
                CalendarVisibilityChangedEventArgs calendarVisibilityChangedEventData = new CalendarVisibilityChangedEventArgs(false);
                
            }
            else
                calendarCtrl.Visible = true;
        }

        protected void calendarCtrl_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = calendarCtrl.SelectedDate.ToShortDateString();
            calendarCtrl.Visible = false;
        }

        public string SelectedDate
        {
            get { return txtDate.Text; }
            set { txtDate.Text = value; }
        }
    }

    public class CalendarVisibilityChangedEventArgs: EventArgs
    {
        private bool _isCalendarVisible;
        // Constructor to initialize event data

        public CalendarVisibilityChangedEventArgs(bool isCalendarVisible)
        {
            this._isCalendarVisible = isCalendarVisible;
        }

        // Returns true if the calendar is visible otherwise false
        public bool IsCalendarVisible
        {
            get { return this._isCalendarVisible; }
        }

        public delegate void CalendarVisibilityChangedEventHandler(object sender, CalendarVisibilityChangedEventArgs e);
        public event CalendarVisibilityChangedEventHandler CalendarVisibilityChanged;

        protected virtual void OnCalendarVisibilityChanged(CalendarVisibilityChangedEventArgs e)
        {
            if(CalendarVisibilityChanged !=null)
            {
                CalendarVisibilityChanged(this, e);
            }
        }
    }

}