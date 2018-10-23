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
    objComún.cargaDDL(DdlAvales, DSAvales, "Avales", "Nombre");

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

  //Termina de hacer el alta en la tabla: Avalan.
  public void alta() {

    //Recupera a GestorBD.
    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];

    //Recupera la clave del aval seleccionado.
    cadSql = "select * from Avales where Nombre= '" + DdlAvales.Text + "'";
    GestorBD.consBD(cadSql, DSAvales, "Aval");
    fila = DSAvales.Tables["Aval"].Rows[0];
    idAval = Convert.ToInt16(fila["IdAval"]);   

    //Si el monto es >= 50,000, hace el alta.
    if (Convert.ToInt32(TxtMonto.Text) >= 50000) {
      //Inserta en la tabla: Avalan.
      cadSql = "insert into Avalan values(" + DdlPréstamos.Text +
        "," + idAval + "," + TxtMonto.Text + ")";
      if (GestorBD.altaBD(cadSql) == OK) {
        LblMensaje.Text = "Inserción correcta";
        cargaGrid();

        //Oculta/habilita controles.
        desactivaControles();
      }
      else
        LblMensaje.Text = "No se hizo la inserción";
    }
    else {
      LblMensaje.Text = "Dar un monto >= 50,000";
      TxtMonto.Focus();
    }
  }

  //Ejecuta la operación que corresponda.
  protected void BtnEjecuta_Click(object sender, EventArgs e) {
    string oper;

    oper = Session["Operación"].ToString();
    switch (oper) {
      case "Alta":
        alta();
        break;
      case "Cambio":
        //cambio();
        break;
    }
  }

  //Acciones iniciales de la baja.
  protected void BtnBaja_Click(object sender, EventArgs e) {

    //Habilita/deshabilita controles asociados a la baja.
    GrdAvalan.Enabled = true;
    BtnAlta.Enabled = false; BtnBaja.Enabled = false; BtnCambia.Enabled = false;

    LblMensaje.Text = "Operación: baja";
  }
  
  //Elimina a la tupla elegida en el grid cuando se da clic a dicha tupla.
  protected void GrdAvalan_RowDeleting(object sender, GridViewDeleteEventArgs e) {
    int índiceFila;       //Índice de la fila elegida en el grid.
    int índiceColInicial=2; //Columna inicial a usar en el grid.
    GridViewRow filaGrid;   //Tipo de la fila elegida en el grid.

    //Recupera el índice de la fila y la fila de datos elegida en el grid.
    índiceFila = e.RowIndex;
    filaGrid = GrdAvalan.Rows[índiceFila];

    //Borra de la tabla Avalan la fila elegida en el grid.
    cadSql = "delete from Avalan where Folio= " +
      filaGrid.Cells[índiceColInicial].Text + " and IdAval= " +
      filaGrid.Cells[índiceColInicial + 1].Text;

    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    if (GestorBD.bajaBD(cadSql) == OK) {
      cargaGrid();      //Actualiza el contenido del grid.
      GrdAvalan.Enabled = false;
      desactivaControles();   //Habilita/deshabilita controles.
      LblMensaje.Text = "Operación: en espera";
    }
    else
      LblMensaje.Text = "No se pudo eliminar de Avalan";
  }

  //Ejercicio extra: ejemplo de uso de una fila seleccionada en el grid.
  protected void GrdAvalan_SelectedIndexChanged(object sender, EventArgs e) {
    int índiceFila;       //Índice de la fila elegida en el grid.
    int índiceColInicial = 2; //Columna inicial a usar en el grid.
    GridViewRow filaGrid;   //Tipo de la fila elegida en el grid.

    índiceFila = GrdAvalan.SelectedIndex;
    filaGrid = GrdAvalan.Rows[índiceFila];
    GrdAvalan.Enabled = false;
    desactivaControles();   //Habilita/deshabilita controles.

    //Muestra los datos de la fila elegida.
    Response.Write(filaGrid.Cells[índiceColInicial].Text+ " "+
      filaGrid.Cells[índiceColInicial+1].Text);
  }

}

