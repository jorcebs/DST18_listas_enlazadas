using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Inventario
    {
        public Producto primero { private set; get; }

        public bool agregar(Producto producto)
        {
            if (primero == null || producto.código < primero.código)
            {
                producto.siguiente = primero;
                primero = producto;
                return true;
            }
            else if (buscarProducto(producto.código) == null)
            {
                Producto aux = primero;
                while (aux != null)
                {
                    if (producto.código > aux.código && (aux.siguiente == null || producto.código < aux.siguiente.código))
                    {
                        producto.siguiente = aux.siguiente;
                        aux.siguiente = producto;
                        return true;
                    }
                    aux = aux.siguiente;
                }
                return false;
            }
            else
                return false;
        }

        public Producto buscarProducto(int código)
        {
            Producto aux = primero;
            while (aux != null)
            {
                if (aux.código == código)
                    return aux;
                aux = aux.siguiente;
            }
            return null;
        }

        public bool eliminar(int código)
        {
            if (buscarProducto(código) != null)
            {
                if (primero.código == código)
                {
                    primero = primero.siguiente;
                    return true;
                }
                else
                {
                    Producto aux = primero;
                    while (aux.siguiente != null)
                    {
                        if (aux.siguiente.código == código)
                        {
                            aux.siguiente = aux.siguiente.siguiente;
                            return true;
                        }
                        aux = aux.siguiente;
                    }
                    return false;
                }
            }
            else
                return false;
        }

        public override string ToString()
        {
            Producto aux = primero;
            string reporte = "";
            while (aux != null)
            {
                reporte += aux.ToString() + Environment.NewLine;
                aux = aux.siguiente;
            }
            return reporte;
        }

        private bool estáDesordenado()
        {
            int num = 0;
            Producto aux = primero;
            while (aux != null)
            {
                if (num > aux.código)
                    return true;
                num = aux.código;
                aux = aux.siguiente;
            }
            return false;
        }
    }
}