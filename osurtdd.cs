using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace osurtdd {
partial class osurtdd {

	static Form1 form;
	static string rawformat, parsedformat;
	static int data300, datageki, data100, datakatu, data50, datamiss, datacombo, datatime;
	static string databmtitle, databmtitleunicode, databmartist, databmartistunicode;
	static string databmcreator, databmdiff;
	static double dataacc;

	[STAThread]
	static void Main() {
		form = new Form1();
		rawformat = "{_BMARTIST_} - {_BMTITLE_} [{_BMDIFF_}] by {_BMCREATOR_}\\n"
			+ "300x{_300COUNT_} 100x{_100COUNT_} 50x{_50COUNT_} MISSx{_MISSCOUNT_} "
			+ "{_ACC_:.00}% {_COMBO_}x";
		format_parse();
		listener_init();
		persistence_init();
		Application.VisualStyleState = VisualStyleState.NoneEnabled;
		Application.Run(form);
	}

	static void format_parse() {
		parsedformat = rawformat.Replace("\\n", "\n");
		string[] mapping = {
			"_300COUNT_", "_GEKICOUNT_", "_100COUNT_", "_KATUCOUNT_", "_50COUNT_",
			"_MISSCOUNT_", "_COMBO_", "_ACC_", "_SONGTIME_",
			"_BMTITLE_", "_BMTITLEU_", "_BMARTIST_", "_BMARTISTU_",
			"_BMCREATOR_", "_BMDIFF_"
		};
		for (int i = 0; i < mapping.Length; i++) {
			parsedformat = parsedformat.Replace(mapping[i], i.ToString());
		}
	}

	static string format_data() {
		return string.Format(
			parsedformat, data300, datageki, data100, datakatu, data50, datamiss,
			datacombo, dataacc, datatime,
			databmtitle, databmtitleunicode, databmartist, databmartistunicode,
			databmcreator, databmdiff
		);
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////