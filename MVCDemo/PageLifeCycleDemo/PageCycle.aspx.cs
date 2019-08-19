using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PageLifeCycleDemo
{
    public partial class PageCycle : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Textbox control dynamically.
            TextBox txtbox = new TextBox();
            txtbox.ID = "myTxt";
            txtbox.EnableTheming = true;
            txtbox.Text = "I am Textbox";
            txtbox.TextChanged += new EventHandler(Txtbox_TextChanged);
            this.form1.Controls.Add(txtbox);
            txtbox.Text = "Change text and Press submit";

            //We can set Master page in this event.
            //Page.MasterPageFile = "~/MasterPage.master";

            //Checking whether value is stored from viewstate or not in preInit Event.
            int i = Convert.ToInt32(ViewState["P"]) + 1;
            ViewState["P"] = i.ToString();
            Label lblMsg = new Label();
            lblMsg.ID = "lblMsg";
            lblMsg.Text = "Hi I am in PreInit event and ViewState value is: " + ViewState["P"];

            //Create button control dynamically.
            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.ID = "btnSubmit";

            btnSubmit.Click += new EventHandler(BtnSubmit_Click);
            this.form1.Controls.Add(btnSubmit);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            
            //Checking whether value is stored from ViewState or not in this event.
            
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            
        }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Txtbox_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblMessage = ((Label)Page.FindControl("lblMsg"));
            lblMessage.Text = "I am in Page Init event ";
            if (ViewState["P"].ToString() != null)
            {
                int i = Convert.ToInt32(ViewState["P"]) + 1;
                ViewState["P"] = i.ToString();
            }
            lblMessage.Text += lblMessage.Text + ViewState["P"].ToString();
        }
    }
}