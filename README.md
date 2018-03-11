## osu-rt-data-display
Dead simple [citation needed] osu! data display with song info and hit counts, accuracy, combo.

This program basically just uses the OsuRTDataProvider plugin, without having to use osu!Sync (because what is that program even?).

## Why
The osu!Sync thing doesn't work for me and I wanted to export dumps of plays. (What is osu!Sync even? Apparently it used to export/manage beatmaps, now it just 'syncs' live chat or something? It has random plugins that have nothing to do with it? It's too confusing to me, it doesn't appear to do anything useful except having a 'facy' UI (which is subjective, I don't even like it) and crashing when I try to use the OsuRTDataProvider plugin.)

## Preview
![rtdd](https://user-images.githubusercontent.com/12662260/37252828-9abaf55a-2528-11e8-9a37-72e835156b6d.gif)

colors/font/format can be adjusted

## Download/'installation'/usage
* See [Releases](https://github.com/yugecin/osu-rt-data-display/releases/latest/) to download `osu-rt-data-display.exe`
* Download [OsuRTDataProvider v1.2.3](https://github.com/OsuSync/OsuRTDataProvider-Release/releases/tag/v1.2.3)
* Copy `Plugins/OsuRTDataProviderRelease.dll` to the same folder as `osu-rt-data-display.exe` and rename it to `OsuRTDataProvider.dll`
* Download [Sync v2.16.1](https://github.com/OsuSync/Sync/releases/tag/v2.16.1)
* Copy `Sync.exe` to the same folder as `osu-rt-data-display.exe`
* Run `osu-rt-data-display.exe`
* Right click the main window to access a menu that does stuff

## Will this get me banned
[People say no](https://puu.sh/yT9X9/388a67eb1f.png) but don't take my word for it. I am not resposible for your account, computer, dog or marriage.

The OsuRTDataProvider thing is a heavily obfuscated dll that you download from the interwebs, either trust it or not. No guarantees.

## Powered by
* [osu!Sync](https://github.com/OsuSync/Sync) ([osu! forum thread](https://osu.ppy.sh/forum/t/270446/))
* [OsuRTDataProvider](https://github.com/OsuSync/OsuRTDataProvider-Release)
