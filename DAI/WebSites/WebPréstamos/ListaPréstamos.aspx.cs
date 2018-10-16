using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaPréstamos : System.Web.UI.Page {

  //Variables de la clase.
  GestorBD.GestorBD GestorBD;
  DataSet DsUsuarios = new DataSet(), DsPréstamos= new DataSet();
  DataRow fila;
  Comunes común = new Comunes();
  string cadSql, rfc;

  //Acciones iniciales.
  protected void Page_Load(object sender, EventArgs e) {

    if (!IsPostBack) {
      //Recupera objetos de Session.
      GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
      rfc = Session["rfc"].ToString();

      //Lee y muestra datos del usuario.
      cadSql = "select * from Clientes where Rfc='" + rfc + "'";
      GestorBD.consBD(cadSql, DsUsuarios, "Usuario");
      fila = DsUsuarios.Tables["Usuario"].Rows[0];
      TblUsuario.Rows[1].Cells[0].Text = fila["Rfc"].ToString();
      TblUsuario.Rows[1].Cells[1].Text = fila["Nombre"].ToString();
      TblUsuario.Rows[1].Cells[2].Text = fila["Domicilio"].ToString();

      //Lee sus préstamos y carga los folios en el DDL de préstamos.
      cadSql = "select * from Préstamos where Rfc='" + rfc + "'";
      GestorBD.consBD(cadSql, DsPréstamos, "Préstamos");
      común.cargaDDL(DdlPréstamos, DsPréstamos, "Préstamos", "Folio");
    }
  }

  //Muestra datos asociados al préstamo elegido en el DDL de préstamos.
  protected void DdlPréstamos_SelectedIndexChanged(object sender, EventArgs e) {

    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];

  }
}















