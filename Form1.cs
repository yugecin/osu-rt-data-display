using System;
using System.Drawing;
using System.Windows.Forms;

namespace osurtdd {
public partial class Form1 : Form {

	public delegate void OnForeColorChangedEvent(Color col);
	public delegate void OnBackColorChangedEvent(Color col);

	public event OnForeColorChangedEvent OnForeColorChangedA;
	public event OnBackColorChangedEvent OnBackColorChangedA;

	public Form1() {
		InitializeComponent();
	}

	public void UpdateText(string txt) {
		l.Text = txt;
	}

	private void ChangeForeColor(object sender, EventArgs e) {
		if (colorDialog.ShowDialog() == DialogResult.OK) {
			OnForeColorChangedA(l.ForeColor = colorDialog.Color);
		}
	}

	private void ChangeBackColor(object sender, EventArgs e) {
		if (colorDialog.ShowDialog() == DialogResult.OK) {
			OnBackColorChangedA(l.BackColor = colorDialog.Color);
		}
	}

	public void SetForeColor(Color c) {
		l.ForeColor = c;
	}

	public void SetBackColor(Color c) {
		l.BackColor = c;
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////