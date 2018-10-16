using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {

  //Variables de clase.
  GestorBD.GestorBD GestorBD;
  DataSet DsGeneral = new DataSet();
  string cadSql;

  //Acciones iniciales.
  protected void Page_Load(object sender, EventArgs e) {

    //NOTA: La propiedad IsPostBack, de la página, tiene un valor False la 1a.
    //vez que se carga la página; tiene True, en las veces subsecuentes.
    if (!IsPostBack) {
      GestorBD = new GestorBD.GestorBD("SQLNCLI11", "localhost",
        "sa", "sqladmin", "Préstamos");
      Session["GestorBD"] = GestorBD;
    }
  }

  //Verifica que el usuario exista.
  protected void Login1_Authenticate(object sender, AuthenticateEventArgs e) {

    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    //Verifica en la BD si hay coincidencia de Rfc y Contraseña.
    cadSql = "select * from Clientes where Rfc='" + Login1.UserName + "' and " +
      "Contraseña= '" + Login1.Password + "'";
    GestorBD.consBD(cadSql, DsGeneral, "Usuario");
    if (DsGeneral.Tables["Usuario"].Rows.Count != 0) {
      Session["rfc"] = Login1.UserName;         //Sí existe, pasa a la página
      Server.Transfer("ListaPréstamos.aspx");   //de lista de préstamos.
    }
  }
}
















