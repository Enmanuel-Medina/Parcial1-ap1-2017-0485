using PArcial1_ap1_2017_0485.BLL;
using PArcial1_ap1_2017_0485.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PArcial1_ap1_2017_0485
{
    public partial class rCiudades : Form
    {
        public rCiudades()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            NombreTextBox.Text = String.Empty;
        }

        private Ciudades LlenaClase()
        {
            Ciudades ciudad = new Ciudades();

            ciudad.CuidadId = Convert.ToInt32(IdNumericUpDown.Value);
            ciudad.Nombre = NombreTextBox.Text;
            return ciudad;
        }

        private void LlenaCampo(Ciudades ciudad) 
        {
            IdNumericUpDown.Value = ciudad.CuidadId;
            NombreTextBox.Text = ciudad.Nombre;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo Nombre  no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Ciudades ciudad = CiudadesBLL.Buscar((int)IdNumericUpDown.Value);
            return (ciudad != null);
        }


        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Ciudades ciudad = new Ciudades();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();
            ciudad = CiudadesBLL.Buscar(id);

            if (ciudad != null)
                LlenaCampo(ciudad);
            else
                MessageBox.Show("Ciudad no encontrada ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Ciudades ciudad;

            if (!Validar())
                return;
            ciudad = LlenaClase();

            if (IdNumericUpDown.Value == 0)
                paso = CiudadesBLL.Guardar(ciudad);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar la ciudad que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = CiudadesBLL.Modificar(ciudad);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();
            if (CiudadesBLL.Buscar(id) != null)
            {
                if (CiudadesBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("No se puede eliminar la ciudad que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
 }


