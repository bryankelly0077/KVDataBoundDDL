using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace KVDataBoundDDL
{
    public partial class Location : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlContinents.DataSource = GetData("spGetContinents", null);
                ddlContinents.DataBind();
                ListItem liContinent = new ListItem("Select Continent", "-1");
                //use 'insert' so its at the top. 'add' puts it at the bottom
                ddlContinents.Items.Insert(0, liContinent);

                ListItem liCountry = new ListItem("Select Country", "-1");
                ddlCountries.Items.Insert(0, liCountry);
                //disable until selection is made
                ddlCountries.Enabled = false;

                ListItem liCity = new ListItem("Select City", "-1");
                ddlCities.Items.Insert(0, liCity);
                ddlCities.Enabled = false;
            }

        }

        //GetData method where passes appropiate parameter
        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            //tell the data adapter that SPName is a store procedure
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //the continent sp does not take a parameter so only add the parameter if it's not null
            if (SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }

            DataSet DS = new DataSet();
            da.Fill(DS);

            return DS;
        }

        protected void ddlContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlContinents.SelectedIndex == 0)
            {
                ddlCountries.SelectedIndex = 0;
                ddlCountries.Enabled = false;

                //ddlCities.SelectedIndex = 0;
                //ddlCities.Enabled = false;
            }
            else
            {
                ddlCountries.Enabled = true;
                //GetData needs to take a parameter.The paraneter needs a name and a value
                SqlParameter parameter = new SqlParameter("@ContinentId", ddlContinents.SelectedValue);
                DataSet DS = GetData("spGetCountriesByContinentId",parameter);

                ddlCountries.DataSource = DS;
                ddlCountries.DataBind();

                ListItem liCountry = new ListItem("Select Country", "-1");
                ddlCountries.Items.Insert(0, liCountry);

                ddlCities.SelectedIndex = 0;
                ddlCities.Enabled = false;
            }
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountries.SelectedIndex == 0)
            {
                ddlCities.SelectedIndex = 0;
                ddlCities.Enabled = false;
            }
            else
            {
                ddlCities.Enabled = true;
                //GetData needs to take a parameter.The paraneter needs a name and a value
                SqlParameter parameter = new SqlParameter("@CountryId", ddlCountries.SelectedValue);
                DataSet DS = GetData("spGetCitiesByCountryId", parameter);

                ddlCities.DataSource = DS;
                ddlCities.DataBind();

                ListItem liCity = new ListItem("Select City", "-1");
                ddlCities.Items.Insert(0, liCity);
            }
        }
    }
}