using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        List<Asistencia> asistencias = new List<Asistencia>();
        public Form1()
        {
            InitializeComponent();
        }
        public void cargar_Empleados()
        {
            //cargar empleados
            string fileName = "Empleados.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)

            {
                //leer los datos de un empleado
                Empleado empleado = new Empleado();
                empleado.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                empleado.Nombre = reader.ReadLine();
                empleado.SueldoHora = Convert.ToDecimal(reader.ReadLine());

                //guardar el empleado a la lista de empleados
                empleados.Add(empleado);
            }
            reader.Close();


        }
        public void cargar_Asistencia()
        {
            string fileName = "Asistencia.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)

            {
                //leer los datos de un empleado
                Asistencia asistencia1 = new Asistencia();
                asistencia1.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                asistencia1.HorasMes = Convert.ToInt16(reader.ReadLine());
                asistencia1.Mes = Convert.ToInt16(reader.ReadLine());

                //guardar el empleado a la lista de empleados
                asistencias.Add(asistencia1);
            }
            reader.Close();
        }
        public void Mostrar_Asistencia()
        {
            dataGridViewAsistencia.DataSource = null;
            dataGridViewAsistencia.DataSource = asistencias;
            dataGridViewAsistencia.Refresh();
        }
        public void Mostrar_Empleados()
        {
            dataGridViewEmpleado.DataSource = null;
            dataGridViewEmpleado.DataSource = empleados;
            dataGridViewEmpleado.Refresh();
        }
        private void buttonleer_Click(object sender, EventArgs e)
        {
            cargar_Empleados();
            Mostrar_Empleados();
            cargar_Asistencia();
            Mostrar_Asistencia();

        }

        private void buttonSueldo_Click(object sender, EventArgs e)
        {
            List<Reporte> reportes = new List<Reporte>();

            foreach (Empleado empleado in empleados)
            {

                foreach (Asistencia asistencia in asistencias)
                {
                    if (empleado.NoEmpleado == asistencia.NoEmpleado)
                    {
                        
                        Reporte reporte = new Reporte();
                        reporte.NombreEmpleado = empleado.Nombre;
                        reporte.Mes = asistencia.Mes;
                        reporte.SueldoMensual = empleado.SueldoHora * asistencia.HorasMes;

                        reportes.Add(reporte);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }
    }
}
