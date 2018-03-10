using OsuRTDataProvider;
using OsuRTDataProvider.Listen;
using System;

namespace osurtdd {
partial class osurtdd {

	static void listener_init() {
		OsuRTDataProviderPlugin p = new OsuRTDataProviderPlugin();
		p.OnEnable();
		OsuListenerManager lm = p.ListenerManager;
		lm.OnStatusChanged += listener_OnStatusChanged;
		lm.OnCount100Changed += listener_OnCount100Changed;
		lm.OnCount300Changed += listener_OnCount300Changed;
		lm.OnCount50Changed += listener_OnCount50Changed;
		lm.OnComboChanged += listener_OnComboChanged;
		lm.OnAccuracyChanged += listener_OnAccuracyChanged;
		lm.OnPlayingTimeChanged += listener_OnPlayingTimeChanged;
		lm.Start();
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
		Console.WriteLine("status changed {0} -> {1}", from, to);
	}

}
}
////////////////////////////////////////////////////////////////////////////////////////////////////
