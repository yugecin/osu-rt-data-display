using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace osurtdd {
partial class osurtdd {

	const string settingsfile = "./osu-rt-data-display.ini";

	[DllImport("kernel32")]
	private static extern long WritePrivateProfileString(
		string section,
		string key,
		string val,
		string filePath
	);

	[DllImport("kernel32")]
	private static extern int GetPrivateProfileString(
		string section,
		string key,
		string def,
		StringBuilder retVal,
		int size,
		string filePath
	);

	static void persistence_init() {
		form.OnBackColorChangedA += persistence_OnBackColorChanged;
		form.OnForeColorChangedA += persistence_OnForeColorChanged;

		StringBuilder sb = new StringBuilder();
		int i;
		GetPrivateProfileString("color", "fore", "", sb, 20, settingsfile);
		if (int.TryParse(sb.ToString(), out i)) {
			form.SetForeColor(Color.FromArgb(i));
		}
		GetPrivateProfileString("color", "back", "", sb, 20, settingsfile);
		if (int.TryParse(sb.ToString(), out i)) {
			form.SetBackColor(Color.FromArgb(i));
		}
	}

	static void persistence_OnForeColorChanged(Color col) {
		WritePrivateProfileString("color", "fore", col.ToArgb().ToString(), settingsfile);
	}

	static void persistence_OnBackColorChanged(Color col) {
		WritePrivateProfileString("color", "back", col.ToArgb().ToString(), settingsfile);
	}


}
}
////////////////////////////////////////////////////////////////////////////////////////////////////