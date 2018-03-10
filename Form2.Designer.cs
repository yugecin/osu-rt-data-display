namespace osurtdd {
	partial class Form2 {
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
			this.label = new System.Windows.Forms.Label();
			this.cancel = new System.Windows.Forms.Button();
			this.save = new System.Windows.Forms.Button();
			this.textbox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label
			// 
			this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label.Location = new System.Drawing.Point(12, 9);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(560, 109);
			this.label.TabIndex = 0;
			this.label.Text = "label1";
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(416, 205);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 1;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// save
			// 
			this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.save.Location = new System.Drawing.Point(497, 205);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(75, 23);
			this.save.TabIndex = 2;
			this.save.Text = "Save";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// textbox
			// 
			this.textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textbox.Location = new System.Drawing.Point(12, 121);
			this.textbox.Multiline = true;
			this.textbox.Name = "textbox";
			this.textbox.Size = new System.Drawing.Size(560, 78);
			this.textbox.TabIndex = 3;
			this.textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			// 
			// Form2
			// 
			this.AcceptButton = this.save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(584, 240);
			this.Controls.Add(this.textbox);
			this.Controls.Add(this.save);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.label);
			this.Name = "Form2";
			this.Text = "osu-rt-data-display";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.TextBox textbox;
	}
}