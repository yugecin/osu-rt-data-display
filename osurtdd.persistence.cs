using System;
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
		persistence_loadformat(sb);
	}

	static string persistence_i(string section, string key, StringBuilder sb) {
		GetPrivateProfileString(section, key, "", sb, 20, settingsfile);
		return sb.ToString();
	}
	public
	static void persistence_OnSizeChanged(int w, int h) {
		WritePrivateProfileString("size", "width", w.ToString().ToString(), settingsfile);
		WritePrivateProfileString("size", "height", h.ToString().ToString(), settingsfile);
	}

	public
	static void persistence_OnForeColorChanged(Color col) {
		WritePrivateProfileString("color", "fore", col.ToArgb().ToString(), settingsfile);
	}

	public
	static void persistence_OnBackColorChanged(Color col) {
		WritePrivateProfileString("color", "back", col.ToArgb().ToString(), settingsfile);
	}

	static void persistence_loadformat(StringBuilder sb) {
		StringBuilder format = new StringBuilder();
		int parts;
		if (!int.TryParse(persistence_i("format", "format", sb), out parts)) {
			return;
		}
		int i = 0;
	_1:
		GetPrivateProfileString("format", "format" + i, "", sb, 35, settingsfile);
		if (sb.Length == 0 || parts < i) {
			if (format.Length > 0) {
				rawformat = format.ToString();
			}
			return;
		}
		format.Append(sb.ToString());
		i++;
		goto _1;
	}

	static void persistence_saveformat(string format) {
		int i = 0;
	_1:
		string part = format.Length > 29 ? format.Substring(0, 30) : format;
		WritePrivateProfileString("format", "format" + i, part, settingsfile);
		if (format.Length <= 30) {
			WritePrivateProfileString("format", "format", i.ToString(), settingsfile);
			return;
		}
		format = format.Substring(30);
		i++;
		goto _1;
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////