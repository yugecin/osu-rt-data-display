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
		form.OnSizeChangedA += persistence_OnSizeChanged;

		StringBuilder sb = new StringBuilder();
		int i;
		if (int.TryParse(persistence_i("color", "fore", sb), out i)) {
			form.SetForeColor(Color.FromArgb(i));
		}
		if (int.TryParse(persistence_i("color", "back", sb), out i)) {
			form.SetBackColor(Color.FromArgb(i));
		}
		if (int.TryParse(persistence_i("size", "width", sb), out i)) {
			form.Size = new Size(i, form.Size.Height);
		}
		if (int.TryParse(persistence_i("size", "height", sb), out i)) {
			form.Size = new Size(form.Size.Width, i);
		}
	}

	static string persistence_i(string section, string key, StringBuilder sb) {
		GetPrivateProfileString(section, key, "", sb, 20, settingsfile);
		return sb.ToString();
	}

	static void persistence_OnSizeChanged(int w, int h) {
		WritePrivateProfileString("size", "width", w.ToString().ToString(), settingsfile);
		WritePrivateProfileString("size", "height", h.ToString().ToString(), settingsfile);
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