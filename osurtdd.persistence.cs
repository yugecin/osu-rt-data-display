using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;

namespace osurtdd {
partial class osurtdd {

	const string
		OPT_SIZE_WIDTH = "width",
		OPT_SIZE_HEIGHT = "height",
		OPT_FORECOLOR = "forecolor",
		OPT_BACKCOLOR = "backcolor",
		OPT_FONT = "font",
		OPT_FORMAT = "format",
		settingsfile = "./osu-rt-data-display.ini";
	static Dictionary<string, string> settings;

	static void persistence_loadfile() {
		if (!File.Exists(settingsfile)) {
			return;
		}
		foreach (string line in File.ReadAllLines(settingsfile, Encoding.UTF8)) {
			int idx = line.IndexOf(':');
			if (idx > -1 && idx != line.Length - 1) {
				settings[line.Substring(0, idx)] = line.Substring(idx + 1);	
			}
		}
	}

	static void persistence_savefile() {
		string[] lines = new string[settings.Count];
		int i = 0;
		foreach (string key in settings.Keys) {
			lines[i++] = key + ":" + settings[key];
		}
		File.WriteAllLines(settingsfile, lines, Encoding.UTF8);
	}

	static void persistence_init() {
		settings = new Dictionary<string,string>();
		persistence_setdefaults();
		persistence_loadfile();
		int i;
		if (int.TryParse(settings[OPT_FORECOLOR], out i)) {
			form.SetForeColor(Color.FromArgb(i));
		}
		if (int.TryParse(settings[OPT_BACKCOLOR], out i)) {
			form.SetBackColor(Color.FromArgb(i));
		}
		if (int.TryParse(settings[OPT_SIZE_WIDTH], out i)) {
			form.Size = new Size(i, form.Size.Height);
		}
		if (int.TryParse(settings[OPT_SIZE_HEIGHT], out i)) {
			form.Size = new Size(form.Size.Width, i);
		}
		rawformat = settings[OPT_FORMAT];
		persistence_loadfont();
	}

	static void persistence_setdefaults() {
		settings[OPT_FORECOLOR] = Color.Black.ToArgb().ToString();
		settings[OPT_BACKCOLOR] =
			Color.FromKnownColor(KnownColor.Control).ToArgb().ToString();
		settings[OPT_SIZE_WIDTH] = "391";
		settings[OPT_SIZE_HEIGHT] = "187";
		settings[OPT_FORMAT] = "{_BMARTIST_} - {_BMTITLE_} [{_BMDIFF_}] by {_BMCREATOR_}\\n"
			+ "300x{_300COUNT_} 100x{_100COUNT_} 50x{_50COUNT_} MISSx{_MISSCOUNT_} "
			+ "{_ACC_:F2}% {_COMBO_}x";
		settings[OPT_FONT] = "Tahoma,14.25,y";
	}

	public
	static void persistence_OnSizeChanged(int w, int h) {
		settings[OPT_SIZE_WIDTH] = w.ToString();
		settings[OPT_SIZE_HEIGHT] = h.ToString();
		persistence_savefile();
	}

	public
	static void persistence_OnForeColorChanged(Color col) {
		settings[OPT_FORECOLOR] = col.ToArgb().ToString();
		persistence_savefile();
	}

	public
	static void persistence_OnBackColorChanged(Color col) {
		settings[OPT_BACKCOLOR] = col.ToArgb().ToString();
		persistence_savefile();
	}

	static void persistence_saveformat(string format) {
		settings[OPT_FORMAT] = format;
		persistence_savefile();
	}

	static void persistence_savefont(Font font) {
		string size = font.Size.ToString().Replace(',', '.');
		settings[OPT_FONT] = font.FontFamily.Name + "," + size + ","
			+ (font.Style == FontStyle.Bold ? "y" : "n");
		persistence_savefile();
	}

	static void persistence_loadfont() {
		try {
			string[] parts = settings[OPT_FONT].Split(',');
			if (parts.Length != 3) {
				return;
			}
			var style = parts[2] == "y" ? FontStyle.Bold : FontStyle.Regular;
			string size = parts[1].Replace(
				".",
				Thread.CurrentThread.CurrentCulture.NumberFormat
					.NumberDecimalSeparator
			);
			currentfont = new Font(parts[0], float.Parse(size), style);
		} catch (Exception t) {
			Console.WriteLine("could not load font: {0}", t.Message);
		}
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////