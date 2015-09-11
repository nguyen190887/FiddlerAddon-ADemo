namespace FiddlerAddon.ADemo
{
    partial class GptViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstvGpt = new System.Windows.Forms.ListView();
            this.Field = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstvGpt
            // 
            this.lstvGpt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Field,
            this.Value});
            this.lstvGpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvGpt.Location = new System.Drawing.Point(0, 0);
            this.lstvGpt.Name = "lstvGpt";
            this.lstvGpt.Size = new System.Drawing.Size(340, 210);
            this.lstvGpt.TabIndex = 0;
            this.lstvGpt.UseCompatibleStateImageBehavior = false;
            this.lstvGpt.View = System.Windows.Forms.View.Details;
            // 
            // GptViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstvGpt);
            this.Name = "GptViewer";
            this.Size = new System.Drawing.Size(340, 210);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvGpt;
        private System.Windows.Forms.ColumnHeader Field;
        private System.Windows.Forms.ColumnHeader Value;

    }
}
