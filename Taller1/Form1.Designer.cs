namespace Taller1
{
    partial class ControlTareas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTarea = new TextBox();
            btnAgregar = new Button();
            flowPanelTareaPendiente = new FlowLayoutPanel();
            flowPanelTareaProceso = new FlowLayoutPanel();
            flowPanelTareaHechas = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // txtTarea
            // 
            txtTarea.Location = new Point(21, 26);
            txtTarea.Margin = new Padding(4, 4, 4, 4);
            txtTarea.Name = "txtTarea";
            txtTarea.PlaceholderText = "Ingrese su tarea";
            txtTarea.Size = new Size(434, 23);
            txtTarea.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(544, 21);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.RightToLeft = RightToLeft.No;
            btnAgregar.Size = new Size(117, 31);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // flowPanelTareaPendiente
            // 
            flowPanelTareaPendiente.FlowDirection = FlowDirection.TopDown;
            flowPanelTareaPendiente.Location = new Point(24, 70);
            flowPanelTareaPendiente.Margin = new Padding(3, 2, 3, 2);
            flowPanelTareaPendiente.Name = "flowPanelTareaPendiente";
            flowPanelTareaPendiente.Size = new Size(181, 396);
            flowPanelTareaPendiente.TabIndex = 2;
            // 
            // flowPanelTareaProceso
            // 
            flowPanelTareaProceso.Location = new Point(231, 72);
            flowPanelTareaProceso.Name = "flowPanelTareaProceso";
            flowPanelTareaProceso.Size = new Size(200, 394);
            flowPanelTareaProceso.TabIndex = 3;
            // 
            // flowPanelTareaHechas
            // 
            flowPanelTareaHechas.Location = new Point(462, 73);
            flowPanelTareaHechas.Name = "flowPanelTareaHechas";
            flowPanelTareaHechas.Size = new Size(200, 393);
            flowPanelTareaHechas.TabIndex = 4;
            // 
            // ControlTareas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 590);
            Controls.Add(flowPanelTareaHechas);
            Controls.Add(flowPanelTareaProceso);
            Controls.Add(flowPanelTareaPendiente);
            Controls.Add(btnAgregar);
            Controls.Add(txtTarea);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ControlTareas";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTarea;
        private Button btnAgregar;
        private FlowLayoutPanel flowPanelTareaPendiente;
        private FlowLayoutPanel flowPanelTareaProceso;
        private FlowLayoutPanel flowPanelTareaHechas;
    }
}
