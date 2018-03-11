using System;
using System.Windows.Forms;

namespace osurtdd {
	public partial class Form2 : Form {

		public Form2() {
			InitializeComponent();
			textbox.Text = osurtdd.rawformat;
			textbox_TextChanged(null, null);
			label.Font = osurtdd.currentfont;
			formathelp.Text = ""
				+ "Hit data:\n"
				+ "  {_300COUNT_}  {_GEKICOUNT_}  {_100COUNT_}  {_KATUCOUNT_}"
				+ "  {_50COUNT_}  {_MISSCOUNT_}\n"
				+ "Performance:\n"
				+ "  {_COMBO_}  {_ACC_}\n"
				+ "Beatmap (with U suffix for unicode counterparts):\n"
				+ "  {_BMTITLE_}  {_BMTITLEU_}  {_BMARTIST_}  {_BMARTISTU_}"
				+ "  {_BMCREATOR_}  {_BMDIFF_}\n"
				+ "\n"
				+ "Extra examples:\n"
				+ "300 count with leading zeros: {_300COUNT_:D3}\n"
				+ "300 count with leading spaces: {_300COUNT_,3}\n"
				+ "accuracy with 1 decimal: {_ACC_:F1}";
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