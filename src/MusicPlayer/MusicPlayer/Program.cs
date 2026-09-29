using MusicPlayer.Model;
using MusicPlayer.MusicSevice;
using MusicPlayer.View;

namespace MusicPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicInfo musicInfo = new MusicInfo();
            musicInfo.IntializeMusic();
            int time = musicInfo.TimeInterval;

            MusicService musicService = new MusicService(musicInfo.Music, time);
            MusicView musicView = new MusicView(musicService, musicInfo);
            musicView.StartPlaying();
        }
    }
}
