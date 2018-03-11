using System;
using System.Windows.Forms;

namespace osurtdd {
	public partial class Form2 : Form {

		public Form2() {
			InitializeComponent();
			textbox.Text = osurtdd.get_raw_format();
			textbox_TextChanged(null, null);
			label.Font = osurtdd.get_font();
		}

		private void textbox_TextChanged(object sender, EventArgs e) {
			label.Text = osurtdd.format_raw_data(textbox.Text);
		}

		private void save_Click(object sender, EventArgs e) {
			osurtdd.update_raw_format(textbox.Text);
			this.Close();
		}

		private void cancel_Click(object sender, EventArgs e) {
			this.Close();
		}

	}
}
////////////////////////////////////////////////////////////////////////////////////////////////////