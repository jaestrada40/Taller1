using System.Diagnostics.Eventing.Reader;
using System.Drawing.Printing;
using Taller1.Clases;

namespace Taller1
{
    public partial class ControlTareas : Form
    {
        List<Tarea> tareas = new List<Tarea>();
        public ControlTareas()
        {
            InitializeComponent();

            this.KeyPreview = true; 
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.AcceptButton = btnAgregar;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Si el txtTarea esta en blanco mostrar mensaje
            if (txtTarea.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un nombre para la tarea ");
                return;
            }

            Tarea nuevaTarea = new Tarea(txtTarea.Text, "Pendiente");
            tareas.Add(nuevaTarea);
            this.renderizarTarea();
            //Limpia el textbox
            txtTarea.Clear();
        }

        private void renderizarTarea()
        {
            flowPanelTareaPendiente.Controls.Clear();
            flowPanelTareaProceso.Controls.Clear();
            flowPanelTareaHechas.Controls.Clear();

            foreach (Tarea tarea in tareas)
            {
                Label tarjeta = new Label();
                tarjeta.Text = tarea.nombre;
                tarjeta.AutoSize = true;
                tarjeta.Padding = new Padding(5);
                tarjeta.Margin = new Padding(2);
                tarjeta.BackColor = Color.White;
                tarjeta.ForeColor = Color.Black;
                tarjeta.BorderStyle = BorderStyle.FixedSingle;

                tarjeta.MouseHover += (color, e) =>
                {
                    tarjeta.BackColor = Color.LightGray;
                };

                tarjeta.MouseLeave += (color, e) =>
                {
                    tarjeta.BackColor = Color.White;
                };

                tarjeta.DoubleClick += (evento, e) =>
                {
                    Label TareaSeleccionar = evento as Label;
                    if (TareaSeleccionar != null)
                    {
                        Tarea tareaSeleccionada = tareas.FirstOrDefault(t => t.nombre == TareaSeleccionar.Text);
                        if (tareaSeleccionada != null)
                        {
                            tareas.Remove(tareaSeleccionada);
                            renderizarTarea();
                        }
                    }
                };

                tarjeta.Click += (evento, e) =>
                {
                    Label TareaSeleccionar = evento as Label;
                    if (TareaSeleccionar != null)
                    {
                        Tarea tareaSeleccionada = tareas.FirstOrDefault(t => t.nombre == TareaSeleccionar.Text);
                        if (tareaSeleccionada != null)
                        {
                            // Cambia el estado de la tarea y renderiza nuevamente según el estado actual
                            switch (tareaSeleccionada.estado)
                            {
                                case "Pendiente":
                                    tareaSeleccionada.estado = "En Proceso";
                                    break;
                                case "En Proceso":
                                    tareaSeleccionada.estado = "Hecha";
                                    break;
                            }
                            renderizarTarea();
                        }
                    }
                };

                // Agrega la tarjeta al panel correspondiente según el estado de la tarea
                switch (tarea.estado)
                {
                    case "Pendiente":
                        flowPanelTareaPendiente.Controls.Add(tarjeta);
                        break;
                    case "En Proceso":
                        flowPanelTareaProceso.Controls.Add(tarjeta);
                        break;
                    case "Hecha":
                        flowPanelTareaHechas.Controls.Add(tarjeta);
                        break;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Verifica si la tecla presionada es Enter
            if (e.KeyCode == Keys.Enter)
            {
                //Llama al método btnAgregar_Click
                btnAgregar_Click(this, EventArgs.Empty);

            }
        }

        private void btnMover_Click(object sender, EventArgs e)
        {

        }
    }
}