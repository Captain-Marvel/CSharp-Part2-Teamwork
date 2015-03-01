using System.IO;
using System.Media;

namespace Game
{
	public class Sounds
	{
		private static readonly string rootGameDir = Directory.GetCurrentDirectory();
		
		public static void OverTheGameSound()
		{
			SoundPlayer player = new SoundPlayer(rootGameDir + @"\sounds\game-play.wav");
			player.PlayLooping();
		}

		public static void MainMenuSound(bool isOn)
		{
			SoundPlayer player = new SoundPlayer(rootGameDir + @"\sounds\main-menu.wav");
			if (isOn)
			{
				player.Stop();
			}
			else
			{
				player.PlayLooping();
			}
		}
	}
}
