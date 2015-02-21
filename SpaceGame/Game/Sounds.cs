using System;
using System.IO;
using System.Media;
using System.Threading;

namespace Game
{
	public class Sounds
	{
		private static readonly string rootGameDir = Directory.GetCurrentDirectory();
		public static void GameOverSound()
		{
			SoundPlayer player = new SoundPlayer(rootGameDir + @"\sounds\Game_Over_sound_effect.wav");
			player.PlayLooping();
		}
		public static void OverTheGameSound()
		{
			SoundPlayer player = new SoundPlayer(rootGameDir + @"\sounds\The_Legend_of_Zelda-_Link_39_s_Awakening_-_Overwor.wav");
			player.PlayLooping();
		}
		public static void MainMenuSound(bool isOn)
		{
			SoundPlayer player = new SoundPlayer(rootGameDir + @"\sounds\02-wild-plains.wav");
			if (isOn)
			{
				player.Stop();
			}
			else
			{
				player.PlayLooping();
			}
		}
		public static void LevelClear()
		{
			SoundPlayer player = new SoundPlayer(rootGameDir + @"\sounds\Juicy_M_4_decks.wav");
			player.Play();
		}
		public static void JumpSound()
		{
			Console.Beep(700, 10);
		}
		public static void End()
		{
			SoundPlayer player = new SoundPlayer(rootGameDir + @"\sounds\FAR_CRY_4_Theme_-_soundtrack.wav");
			player.Play();
			Thread.Sleep(700);
		}
	}
}
