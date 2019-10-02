using BLL;
using Entities;
using RegistroSugerencia.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroSugerencia.Registros
{
    public partial class rSugerencias : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
       

        }
        public Sugerencia LlenarClase()
        {
            Sugerencia sugerrencias = new Sugerencia();

            sugerrencias.SugerenciaId = Utils.ToInt(IdTextBox.Text);
            bool resultado = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            sugerrencias.Fecha = fecha;
            sugerrencias.Descripcion = DescripcionTextBox.Text;

            return sugerrencias;
        }
        public void LlenarCampos(Sugerencia sugerencia)
        {
            FechaTextBox.Text = sugerencia.Fecha.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = sugerencia.Descripcion;
        }

        protected void Limpiar()
        {
            IdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = "";
        }

        private bool Validar()
        {
            bool estado = false;
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un id válido.", "Error", "error");
                estado = true;
            }
            if (String.IsNullOrWhiteSpace(FechaTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener una Fecha", "Error", "error");
                estado = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener una Descripcion.", "Error", "error");
                estado = true;
            }
            return estado;
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Sugerencia> repositorio = new Repositorio<Sugerencia>();

            var sugerencia = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            if (sugerencia != null)
            {
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                LlenarCampos(sugerencia);
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No existe la Factura especificada", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guadarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Sugerencia> repositorio = new Repositorio<Sugerencia>();
            Sugerencia sugerencia = new Sugerencia();

            if (Validar())
            {
                return;
            }
            else
            {
                sugerencia = LlenarClase();

                if (Utils.ToInt(IdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(sugerencia);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Repositorio<Sugerencia> repository = new Repositorio<Sugerencia>();
                    int id = Utils.ToInt(IdTextBox.Text);
                    sugerencia = repository.Buscar(id);

                    if (sugerencia != null)
                    {
                        paso = SugerenciaBLL.Modificar(LlenarClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                        Limpiar();
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                }

                if (paso)
                {
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Sugerencia> repositorio = new Repositorio<Sugerencia>();
            int id = Utils.ToInt(IdTextBox.Text);

            var sugerencia = repositorio.Buscar(id);

            if (sugerencia != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
}