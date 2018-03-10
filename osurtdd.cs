using OsuRTDataProvider;
using OsuRTDataProvider.Listen;
using System;
using System.Windows.Forms;

namespace osurtdd {
class osurtdd {

	[STAThread]
	static void Main() {
		OsuRTDataProviderPlugin p = new OsuRTDataProviderPlugin();
		p.OnEnable();
		p.ListenerManager.OnStatusChanged += RTDP_OnStatusChanged;
		p.ListenerManager.OnPlayingTimeChanged += RTDP_OnPlayingTimeChanged;
		p.ListenerManager.Start();
		Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
		Application.Run(new Form1());
	}

	static void RTDP_OnPlayingTimeChanged(int ms) {
		Console.WriteLine("time {0}", ms);
	}

	static void RTDP_OnStatusChanged(
		OsuListenerManager.OsuStatus from,
		OsuListenerManager.OsuStatus to)
	{
		Console.WriteLine("status {0} to {1}", from, to);
	}

}
}
