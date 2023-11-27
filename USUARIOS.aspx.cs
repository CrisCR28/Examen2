using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace examenII
{
    public partial class USUARIOS1 : System.Web.UI.Page
    {
        private int v1;
        private string v2;

        public USUARIOS1(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}