using OsuRTDataProvider;
using OsuRTDataProvider.BeatmapInfo;
using OsuRTDataProvider.Listen;
using System;

namespace osurtdd {
partial class osurtdd {

	static void listener_init() {
		OsuRTDataProviderPlugin p = new OsuRTDataProviderPlugin();
		p.OnEnable();
		OsuListenerManager lm = p.ListenerManager;
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
		lm.Start();
	}

	static void listener_OnBeatmapChanged(Beatmap map) {
		databmtitle = map.Title;
		databmtitleunicode = map.TitleUnicode;
		databmartist = map.Artist;
		databmartistunicode = map.ArtistUnicode;
		databmcreator = map.Creator;
		databmdiff = map.Difficulty;
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
		dataacc = acc;
	}

	static void listener_OnComboChanged(int combo) {
		datacombo = combo;
	}

	static void listener_OnCount50Changed(int hit) {
		data50 = hit;
	}

	static void listener_OnCount300Changed(int hit) {
		data300 = hit;
	}

	static void listener_OnCount100Changed(int hit) {
		data100 = hit;
	}

	static void listener_OnPlayingTimeChanged(int ms) {
		datatime = ms;
		form.UpdateText(format_data());
	}

	static void listener_OnStatusChanged(
		OsuListenerManager.OsuStatus from,
		OsuListenerManager.OsuStatus to)
	{
		form.UpdateText(format_data());
		Console.WriteLine("status changed {0} -> {1}", from, to);
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////
