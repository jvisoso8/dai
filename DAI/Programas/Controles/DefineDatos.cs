using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles {
  class DefineDatos {
   //Tipo para guardar información de los artículos.
    public struct TArt {
      public string nombre;
      public string tipo;    //Tipo de artículo.
      public decimal precio;
    }

    //Arreglo global para guardar datos de los artículos.
    public TArt[] arts= new TArt[20];
    public int totArts;

    //Rutina para guardar datos de los artículos en el arreglo arts.
    public DefineDatos() {
      arts[1].nombre = "Taladro"; arts[1].tipo = "Herramientas";
      arts[1].precio = 1000;
      arts[2].nombre = "Cubeta Vinílica"; arts[2].tipo = "Pinturas";
      arts[2].precio = 1200;
      arts[3].nombre = "Cemento"; arts[3].tipo = "Construcción";
      arts[3].precio = 1700;
      arts[4].nombre = "Varilla"; arts[4].tipo = "Construcción";
      arts[4].precio = 5200;
      arts[5].nombre = "Pasta muros"; arts[5].tipo = "Pinturas";
      arts[5].precio = 800;
      arts[6].nombre = "Juego pinzas"; arts[6].tipo = "Herramientas";
      arts[6].precio = 350;
      arts[7].nombre = "Grava"; arts[7].tipo = "Construcción";
      arts[7].precio = 800;
      arts[8].nombre = "Pulidora"; arts[8].tipo = "Herramientas";
      arts[8].precio = 2500;
      arts[9].nombre = "Anticorrosivo"; arts[9].tipo = "Pinturas";
      arts[9].precio = 700;

      totArts = 9;
    }
    
  }
}
