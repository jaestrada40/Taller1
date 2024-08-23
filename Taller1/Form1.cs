using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Taller1.Clases;

namespace Taller1
{
    public partial class ControlTareas : Form
    {
        private List<Tarea> tareas = new List<Tarea>();
        private System.Windows.Forms.Timer clickTimer;
        private Label clickedLabel;

        public ControlTareas()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.AcceptButton = btnAgregar;

            flowPanelTareaPendiente.AllowDrop = true;
            flowPanelTareaProceso.AllowDrop = true;
            flowPanelTareaHechas.AllowDrop = true;

            flowPanelTareaPendiente.DragEnter += new DragEventHandler(FlowPanel_DragEnter);
            flowPanelTareaProceso.DragEnter += new DragEventHandler(FlowPanel_DragEnter);
            flowPanelTareaHechas.DragEnter += new DragEventHandler(FlowPanel_DragEnter);

            flowPanelTareaPendiente.DragDrop += new DragEventHandler(FlowPanel_DragDrop);
            flowPanelTareaProceso.DragDrop += new DragEventHandler(FlowPanel_DragDrop);
            flowPanelTareaHechas.DragDrop += new DragEventHandler(FlowPanel_DragDrop);

            // Configuración del temporizador para diferenciar entre clic y doble clic
            clickTimer = new System.Windows.Forms.Timer();  
            clickTimer.Interval = SystemInformation.DoubleClickTime;
            clickTimer.Tick += ClickTimer_Tick;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtTarea.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un nombre para la tarea");
                return;
            }

            Tarea nuevaTarea = new Tarea(txtTarea.Text, "Pendiente");
            tareas.Add(nuevaTarea);
            this.renderizarTarea();
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

                tarjeta.MouseDown += (sender, e) =>
                {
                    clickedLabel = tarjeta;
                    clickTimer.Start();
                };

                tarjeta.MouseUp += (sender, e) =>
                {
                    clickTimer.Stop();
                };

                tarjeta.MouseMove += (sender, e) =>
                {
                    // Si se detecta movimiento, iniciar arrastre y cancelar el temporizador
                    if (e.Button == MouseButtons.Left)
                    {
                        clickTimer.Stop();
                        clickedLabel.DoDragDrop(clickedLabel, DragDropEffects.Move);
                    }
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

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            clickTimer.Stop();
            clickedLabel = null;
        }

        private void FlowPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Label)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FlowPanel_DragDrop(object sender, DragEventArgs e)
        {
            Label tarjeta = e.Data.GetData(typeof(Label)) as Label;
            FlowLayoutPanel destino = sender as FlowLayoutPanel;

            if (tarjeta != null && destino != null)
            {
                Tarea tareaSeleccionada = tareas.FirstOrDefault(t => t.nombre == tarjeta.Text);
                if (tareaSeleccionada != null)
                {
                    if (destino == flowPanelTareaPendiente)
                    {
                        tareaSeleccionada.estado = "Pendiente";
                    }
                    else if (destino == flowPanelTareaProceso)
                    {
                        tareaSeleccionada.estado = "En Proceso";
                    }
                    else if (destino == flowPanelTareaHechas)
                    {
                        tareaSeleccionada.estado = "Hecha";
                    }

                    renderizarTarea();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar_Click(this, EventArgs.Empty);
            }
        }
    }
}
