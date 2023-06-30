using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Webservicedemo
{
    /// <summary>
    /// Summary description for Calculaterwebservice
    /// </summary>
    [WebService(Namespace = "http://calculater.com/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Calculaterwebservice : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public int Add(int Firstnumber, int Secondnumber)
        {
            List<string> calculations;

            if (Session["CALCULATIONS"] == null)
            {
                calculations = new List<string>();
            }
            else
            {
                calculations = (List<string>)Session["CALCULATIONS"];

            }
            string strResentcalations = Firstnumber.ToString() + "+" + Secondnumber.ToString() + "=" +
                (Firstnumber + Secondnumber).ToString();
            calculations.Add(strResentcalations);
            Session["CALCULATIONS"]= calculations;

            return Firstnumber + Secondnumber;
        }

        [WebMethod(EnableSession = true)]
        public List<string> Getcalculations()
        {
            if (Session["CALCULATIONS"] == null)
            {
                List <string> calculations = new List<string>();
                calculations.Add("Youre not perform any calculations");
                return calculations;
            }
            else
            {
                return (List<string>)Session["CALCULATIONS"];
            }


        }
    }
}
