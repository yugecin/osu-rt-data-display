using System;
using System.Drawing;
using System.Windows.Forms;

namespace osurtdd {
public partial class Form1 : Form {

	public Form1() {
		InitializeComponent();
	}

	public void SetFont(Font font) {
		fontDialog.Font = l.Font = font;
	}

	public void UpdateText(string txt) {
		Action a = (Action) (() => {l.Text = txt;});
		if (this.InvokeRequired) {
			this.BeginInvoke(a);
			return;
		}
		a();
	}

	private void ChangeForeColor(object sender, EventArgs e) {
		if (colorDialog.ShowDialog() == DialogResult.OK) {
			osurtdd.persistence_OnForeColorChanged(l.ForeColor = colorDialog.Color);
		}
	}

	private void ChangeBackColor(object sender, EventArgs e) {
		if (colorDialog.ShowDialog() == DialogResult.OK) {
			osurtdd.persistence_OnBackColorChanged(l.BackColor = colorDialog.Color);
		}
	}

	private void SizeChangedA(object sender, EventArgs e) {
		osurtdd.persistence_OnSizeChanged(Size.Width, Size.Height);
	}

	public void SetForeColor(Color c) {
		l.ForeColor = c;
	}

	public void SetBackColor(Color c) {
		l.BackColor = c;
	}

	private void d_Click(object sender, EventArgs e) {
		new Form2().ShowDialog();
	}

	private void ChangeTextFont(object sender, EventArgs e) {
		if (fontDialog.ShowDialog() == DialogResult.OK) {
			osurtdd.update_font(l.Font = fontDialog.Font);
		}
	}

	private void EnableExport(object sender, EventArgs e) {
		osurtdd.exportnext = enableexport.Checked = !enableexport.Checked;
		osurtdd.exportfile = exportfilename.Text;
	}

	public void ResetExport() {
		enableexport.Checked = false;
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////