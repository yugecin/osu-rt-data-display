using System;
using System.Drawing;
using System.Windows.Forms;

namespace osurtdd {
public partial class Form1 : Form {

	public Form1() {
		InitializeComponent();
	}

	public void UpdateText(string txt) {
		l.Text = txt;
	}

	private void ChangeForeColor(object sender, EventArgs e) {
		if (colorDialog.ShowDialog() == DialogResult.OK) {
			l.ForeColor = colorDialog.Color;
		}
	}

	private void ChangeBackColor(object sender, EventArgs e) {
		if (colorDialog.ShowDialog() == DialogResult.OK) {
			l.BackColor = colorDialog.Color;
		}
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////
