using OsuRTDataProvider;
using OsuRTDataProvider.BeatmapInfo;
using OsuRTDataProvider.Listen;
using System;
using System.IO;

namespace osurtdd {
partial class osurtdd {

	static BinaryWriter exporter;
	public
	static string exportfile = "export";
	public
	static bool exportnext;
	static OsuListenerManager lm;

	static void listener_init() {
		OsuRTDataProviderPlugin p = new OsuRTDataProviderPlugin();
		p.OnEnable();
		lm = p.ListenerManager;
		lm.OnStatusChanged += listener_OnStatusChanged;
		lm.OnCount300Changed += listener_OnCount300Changed;
		lm.OnCountGekiChanged += listener_OnCountGekiChanged;
		lm.OnCount100Changed += listener_OnCount100Changed;
		lm.OnCountKatuChanged += listener_OnCountKatuChanged;
		lm.OnCount50Changed += listener_OnCount50Changed;
		lm.OnCountMissChanged += listener_OnCountMissChanged;
		lm.OnComboChanged += listener_OnComboChanged;
		lm.OnAccuracyChanged += listener_OnAccuracyChanged;
		lm.OnPlayingTimeChanged += listener_OnPlayingTimeChanged;
		lm.OnBeatmapChanged += listener_OnBeatmapChanged;
		lm.OnPlayModeChanged += listener_OnPlayModeChanged;
		lm.Start();
	}

	static void listener_OnBeatmapChanged(Beatmap map) {
		databmtitle = map.Title;
		databmtitleunicode = map.TitleUnicode;
		databmartist = map.Artist;
		databmartistunicode = map.ArtistUnicode;
		databmcreator = map.Creator;
		databmdiff = map.Difficulty;
		update_display();
	}

	static void listener_OnCountMissChanged(int hit) {
		datamiss = hit;
	}

	static void listener_OnCountKatuChanged(int hit) {
		datakatu = hit;
	}

	static void listener_OnCountGekiChanged(int hit) {
		datageki = hit;
	}

	static void listener_OnAccuracyChanged(double acc) {
		export_data(10, BitConverter.GetBytes((float) acc));
		dataacc = acc;
	}

	static void listener_OnComboChanged(int combo) {
		export_data(12, BitConverter.GetBytes(combo));
		datacombo = combo;
	}

	static void listener_OnCount50Changed(int hit) {
		export_data(5, BitConverter.GetBytes(hit));
		data50 = hit;
	}

	static void listener_OnCount300Changed(int hit) {
		export_data(3, BitConverter.GetBytes(hit));
		data300 = hit;
	}

	static void listener_OnCount100Changed(int hit) {
		export_data(1, BitConverter.GetBytes(hit));
		data100 = hit;
	}

	static void listener_OnPlayingTimeChanged(int ms) {
		datatime = ms;
	}

	static void listener_OnPlayModeChanged(OsuPlayMode last, OsuPlayMode mode) {
		update_display();
	}

	static void export_data(byte type, byte[] data) {
		if (exporter == null) {
			return;
		}
		int time = lm.GetCurrentData(ProvideDataMask.Time).Time;
		exporter.Write(BitConverter.GetBytes(time));
		exporter.Write(type);
		exporter.Write(data);
	}

	static void listener_OnStatusChanged(
		OsuListenerManager.OsuStatus from,
		OsuListenerManager.OsuStatus to)
	{
		update_display();
		if (exporter != null && from == OsuListenerManager.OsuStatus.Playing) {
			exporter.Close();
			exporter = null;
		}
		if (exportnext && to == OsuListenerManager.OsuStatus.Playing) {
			exportnext = false;
			FileStream fs = new FileStream(exportfile + ".ope", FileMode.Create);
			exporter = new BinaryWriter(fs);
			form.ResetExport();
		}
		Console.WriteLine("status changed {0} -> {1}", from, to);
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////
