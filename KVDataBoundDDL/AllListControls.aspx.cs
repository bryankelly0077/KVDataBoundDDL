using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KVDataBoundDDL
{
    public partial class AllListControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddListItems(DropDownList1);
                AddListItems(CheckBoxList1);
                AddListItems(RadioButtonList1);
                AddListItems(ListBox1);
                AddListItems(BulletedList1);
            }
        }
        private void AddListItems(ListControl listControl)
        {
            ListItem li1 = new ListItem("Item1", "1");
            ListItem li2 = new ListItem("Item2", "2");
            ListItem li3 = new ListItem("Item3", "3");

            listControl.Items.Add(li1);
            listControl.Items.Add(li2);
            listControl.Items.Add(li3);
        }

        private void RetrieveMultipleSelections(ListControl listControl)
        {
            foreach (ListItem li in listControl.Items)
            {
                if (li.Selected)
                {
                    Response.Write("Text = " + li.Text + ", Value = " + li.Value +
                        ", Index = " + listControl.Items.IndexOf(li).ToString() + "<br/>");
                }
            }
        }

        private void RetrieveSelectedItemTextValueandIndex(ListControl listControl)
        {
            if (listControl.SelectedIndex != -1)
            {
                Response.Write("Text = " + listControl.SelectedItem.Text + "<br/>");
                Response.Write("Value = " + listControl.SelectedItem.Value + "<br/>");
                Response.Write("Index = " + listControl.SelectedIndex.ToString());
            }
        }

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {
            ListItem li = BulletedList1.Items[e.Index];
            Response.Write("Text = " + li.Text + "<br/>");
            Response.Write("Value = " + li.Value + "<br/>");
            Response.Write("Index = " + e.Index.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RetrieveMultipleSelections(CheckBoxList1);
            RetrieveSelectedItemTextValueandIndex(DropDownList1);
            RetrieveSelectedItemTextValueandIndex(ListBox1);
            RetrieveSelectedItemTextValueandIndex(BulletedList1);
            RetrieveSelectedItemTextValueandIndex(RadioButtonList1);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RetrieveSelectedItemTextValueandIndex(DropDownList1);
            RetrieveSelectedItemTextValueandIndex(BulletedList1);
            RetrieveSelectedItemTextValueandIndex(RadioButtonList1);
        }
    }
}