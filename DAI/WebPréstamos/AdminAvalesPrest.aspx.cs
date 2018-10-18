using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAvalesPrest : System.Web.UI.Page {
  //Atributos de la clase.
  private DataSet DSPréstamos = new DataSet();
  private DataSet DSAvales= new DataSet(), DSAvalan= new DataSet();
  private DataRow fila;
  private GestorBD.GestorBD GestorBD;       //Para manejar la BD.
  private Comunes objComún = new Comunes();     //Para manejar las rutinas de uso común.
  private String cadSql, rfc;
  private int idAval;
  private const int OK = 1;


  //Acciones iniciales.
  protected void Page_Load(object sender, EventArgs e) {
    cargaGrid();
  }

  //Carga el grid con el contenido de la tabla Avalan.
  public void cargaGrid() {

    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    cadSql = "select * from Avalan";
    GestorBD.consBD(cadSql, DSAvalan, "Avalan");
    GrdAvalan.DataSource = DSAvalan.Tables["Avalan"];
    GrdAvalan.DataBind();
  }

  //Activa los controles que corresponda.
  public void activaControles() {
    BtnAlta.Enabled = false; BtnBaja.Enabled = false; BtnCambia.Enabled = false;
    DdlPréstamos.Visible = true; DdlAvales.Visible = true;
    TxtMonto.Visible = true; BtnEjecuta.Visible = true;
    Label2.Visible = true; Label3.Visible = true; Label4.Visible = true;
  }

  //Desactiva los controles que corresponda.
  public void desactivaControles() {
    BtnAlta.Enabled = true; BtnBaja.Enabled = true; BtnCambia.Enabled = true;
    DdlPréstamos.Visible = false;
    DdlAvales.Visible = false; DdlAvales.Enabled = false;
    TxtMonto.Visible = false; TxtMonto.Enabled = false;
    BtnEjecuta.Visible = false;
    Label2.Visible = false; Label3.Visible = false; Label4.Visible = false;
  }

  //========================================================================
  //Parte 1a: acciones relacionadas con el alta de avales-préstamos.
  protected void BtnAlta_Click(object sender, EventArgs e) {

    //Recupera objetos de Session.
    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    rfc = Session["rfc"].ToString();

    //Muestra/deshabilita controles asociados al alta.
    activaControles();

    //Carga los folios de los préstamos del cliente en DdlPréstamos.
    cadSql = "select * from Préstamos where Rfc='" + rfc + "'";
    GestorBD.consBD(cadSql, DSPréstamos, "Préstamos");
    objComún.cargaDDL(DdlPréstamos, DSPréstamos, "Préstamos", "Folio");

    //Carga el nombre de todos los avales en DdlAvales.
    cadSql = "select * from Avales";
    GestorBD.consBD(cadSql, DSAvales, "Avales");
    objComún.cargaDDL(DdlAvales, DSAvales, "Avales", "IdAval");

    //Indica la operación actual.
    LblMensaje.Text = "Operación: Alta";
    Session["Operación"] = "Alta";
  }

  //Habilita el DDL de Avales.
  protected void DdlPréstamos_SelectedIndexChanged(object sender, EventArgs e) {
    DdlAvales.Enabled = true;
  }

  //Habilita el monto y el botón de ejecutar.
  protected void DdlAvales_SelectedIndexChanged(object sender, EventArgs e) {

    TxtMonto.Enabled = true;
    BtnEjecuta.Enabled = true;
  }



  protected void BtnEjecuta_Click(object sender, EventArgs e) {

  }
}

