using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace osurtdd {
partial class osurtdd {

	static Form1 form;
	static string rawformat, parsedformat;
	static int data300, datageki, data100, datakatu, data50, datamiss, datacombo, datatime;
	static double dataacc;

	[STAThread]
	static void Main() {
		form = new Form1();
		rawformat = "300x{_300COUNT_} 100x{_100COUNT_} 50x{_50COUNT_} MISSx{_MISSCOUNT_} "
			+ "{_ACC_}% {_COMBO_}x";
		format_parse();
		listener_init();
		persistence_init();
		Application.VisualStyleState = VisualStyleState.NoneEnabled;
		Application.Run(form);
	}

	static void format_parse() {
		parsedformat = rawformat;
		string[] mapping = {
			"_300COUNT_", "_GEKICOUNT_", "_100COUNT_", "_KATUCOUNT_", "_50COUNT_",
			"_MISSCOUNT_", "_COMBO_", "_ACC_", "_SONGTIME_"
		};
		for (int i = 0; i < mapping.Length; i++) {
			parsedformat = parsedformat.Replace(mapping[i], i.ToString());
		}
	}

	static string format_data() {
		return string.Format(
			parsedformat, data300, datageki, data100, datakatu, data50, datamiss,
			datacombo, dataacc, datatime
		);
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////