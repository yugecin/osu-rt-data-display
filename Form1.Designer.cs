namespace osurtdd {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.l = new System.Windows.Forms.Label();
			this.c = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.a = new System.Windows.Forms.ToolStripMenuItem();
			this.b = new System.Windows.Forms.ToolStripMenuItem();
			this.d = new System.Windows.Forms.ToolStripMenuItem();
			this.c.SuspendLayout();
			this.SuspendLayout();
			// 
			// l
			// 
			this.l.Dock = System.Windows.Forms.DockStyle.Fill;
			this.l.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l.Location = new System.Drawing.Point(0, 0);
			this.l.Name = "l";
			this.l.Padding = new System.Windows.Forms.Padding(5);
			this.l.Size = new System.Drawing.Size(383, 160);
			this.l.TabIndex = 0;
			this.l.Text = "label1";
			// 
			// c
			// 
			this.c.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.a,
            this.b,
            this.d});
			this.c.Name = "c";
			this.c.Size = new System.Drawing.Size(157, 70);
			// 
			// a
			// 
			this.a.Name = "a";
			this.a.Size = new System.Drawing.Size(156, 22);
			this.a.Text = "text color";
			// 
			// b
			// 
			this.b.Name = "b";
			this.b.Size = new System.Drawing.Size(156, 22);
			this.b.Text = "background color";
			// 
			// d
			// 
			this.d.Name = "d";
			this.d.Size = new System.Drawing.Size(156, 22);
			this.d.Text = "text format";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(383, 160);
			this.Controls.Add(this.l);
			this.Name = "Form1";
			this.Text = "osu-rt-data-display";
			this.c.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label l;
		private System.Windows.Forms.ContextMenuStrip c;
		private System.Windows.Forms.ToolStripMenuItem a;
		private System.Windows.Forms.ToolStripMenuItem b;
		private System.Windows.Forms.ToolStripMenuItem d;
	}
}