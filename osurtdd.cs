using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace osurtdd {
partial class osurtdd {

	static Form1 form;
	static Font currentfont;
	static string rawformat, parsedformat;
	static int data300, datageki, data100, datakatu, data50, datamiss, datacombo, datatime;
	static string databmtitle, databmtitleunicode, databmartist, databmartistunicode;
	static string databmcreator, databmdiff;
	static double dataacc;

	[STAThread]
	static void Main() {
		form = new Form1();
		currentfont = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
		rawformat = "{_BMARTIST_} - {_BMTITLE_} [{_BMDIFF_}] by {_BMCREATOR_}\\n"
			+ "300x{_300COUNT_} 100x{_100COUNT_} 50x{_50COUNT_} MISSx{_MISSCOUNT_} "
			+ "{_ACC_:F2}% {_COMBO_}x";
		listener_init();
		persistence_init();
		update_raw_format(rawformat);
		form.SetFont(currentfont);
		Application.VisualStyleState = VisualStyleState.NoneEnabled;
		Application.Run(form);
	}

	static string format_parse(string rawformat) {
		string parsedformat = rawformat.Replace("\\n", "\n");
		string[] mapping = {
			"_300COUNT_", "_GEKICOUNT_", "_100COUNT_", "_KATUCOUNT_", "_50COUNT_",
			"_MISSCOUNT_", "_COMBO_", "_ACC_", "_SONGTIME_",
			"_BMTITLE_", "_BMTITLEU_", "_BMARTIST_", "_BMARTISTU_",
			"_BMCREATOR_", "_BMDIFF_"
		};
		for (int i = 0; i < mapping.Length; i++) {
			parsedformat = parsedformat.Replace(mapping[i], i.ToString());
		}
		return parsedformat;
	}

	public
	static void update_font(Font font) {
		currentfont = font;
		persistence_savefont(font);
	}

	public
	static Font get_font() {
		return currentfont;
	}

	public
	static string get_raw_format() {
		return rawformat;
	}

	public
	static void update_raw_format(string format) {
		persistence_saveformat(format);
		parsedformat = format_parse(rawformat = format);
		update_display();
	}

	public
	static string format_raw_data(string rawformat) {
		return format_data(format_parse(rawformat));
	}

	static string format_data(string format) {
		try {
			return string.Format(
				format, data300, datageki, data100, datakatu, data50, datamiss,
				datacombo, dataacc, datatime,
				databmtitle, databmtitleunicode, databmartist, databmartistunicode,
				databmcreator, databmdiff
			);
		} catch (Exception) {
			return "<invalid format>";
		}
	}

	static void update_display() {
		form.UpdateText(format_data(parsedformat));
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////