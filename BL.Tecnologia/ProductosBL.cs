using BL.Tecnologia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Tecnologia
{
    public class ProductosBL
    {

        public BindingList<Producto> ListaProductos { get; set; }
        public ProductosBL()
        {
            ListaProductos = new BindingList<Producto>();

            var Producto1 = new Producto();
            Producto1.Codigo = 0101;
            Producto1.Descripcion = "Televisor LG 50 Pulgadas";
            Producto1.Precio = 12500;
            Producto1.Inventario = 4;
            Producto1.Activo = true;

            ListaProductos.Add(Producto1);


            var Producto2 = new Producto();
            Producto2.Codigo = 0102;
            Producto2.Descripcion = "Televisor Sonic 48 Pulgadas";
            Producto2.Precio = 12000;
            Producto2.Inventario = 4;
            Producto2.Activo = true;

            ListaProductos.Add(Producto2);



            var Producto3 = new Producto();
            Producto3.Codigo = 0103;
            Producto3.Descripcion = "Televisor RCA 59 Pulgadas";
            Producto3.Precio = 13000;
            Producto3.Inventario = 2;
            Producto3.Activo = true;

            ListaProductos.Add(Producto3);


            var Producto4 = new Producto();
            Producto4.Codigo = 0104;
            Producto4.Descripcion = "Smartwatch Huawei Watch GT 2 ";
            Producto4.Precio = 6000;
            Producto4.Inventario = 7;
            Producto4.Activo = true;

            ListaProductos.Add(Producto4);


            var Producto5 = new Producto();
            Producto5.Codigo = 0105;
            Producto5.Descripcion = "Laptop Dell 15, core i7";
            Producto5.Precio = 18000;
            Producto5.Inventario = 2;
            Producto5.Activo = true;

            ListaProductos.Add(Producto5);


            var Producto6 = new Producto();
            Producto6.Codigo = 0106;
            Producto6.Descripcion = "Camara Digital SLR Canon ";
            Producto6.Precio = 8500;
            Producto6.Inventario = 0;
            Producto6.Activo = true;

            ListaProductos.Add(Producto6);


        }

        public BindingList<Producto> ObtenerProductos()
        {
            return ListaProductos;
        }

        public Resultado GuardarProducto(Producto Producto)
        {
            var resultado = validar(Producto);
            if( resultado.Correcto == false)
            {
                return resultado;
            }
            if (Producto.Codigo == 0)
            {
                Producto.Codigo = ListaProductos.Max(item => item.Codigo) + 1;
            }
            resultado.Correcto = true;
            return resultado; ;
        }

        public void AgregarProducto()
        {
            var NuevoProducto = new Producto();
            ListaProductos.Add(NuevoProducto);

        }

        public bool Eliminar(int codigo)
        {
            foreach (var item in ListaProductos)
            {
                if (item.Codigo == codigo)
                {
                    ListaProductos.Remove(item);
                    return true;
                }

            }
            return false;
        }


        private Resultado validar(Producto Producto)
        {
            var resultado = new Resultado();
            resultado.Correcto = true;

            if(string.IsNullOrEmpty(Producto.Descripcion) == true )
            {
                resultado.Incorrecto = "Ingrese un Producto";
                resultado.Correcto = false;
            }

            if (Producto.Inventario <=0)
            {
                resultado.Incorrecto = "El Producto debe ser mayor a cero";
                resultado.Correcto = false;
            }

            if (Producto.Precio <=0)
            {
                resultado.Incorrecto = "El Producto debe contener un Precio mayor a cero";
                resultado.Correcto = false;
            }

            return resultado;
        }
    }


    public class Producto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Inventario { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado
    {
      public bool Correcto{ get; set;}
      public string Incorrecto { get; set;}
    }
}
