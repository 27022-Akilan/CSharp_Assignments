using MusicPlayer.Model;
using MusicPlayer.MusicSevice;

namespace MusicPlayer.View
{
    internal class MusicView
    {
        private MusicService _musicService;

        private MusicInfo _musicInfo;
        public MusicView(MusicService musicService, MusicInfo musicInfo)
        {
            _musicService = musicService;
            _musicInfo = musicInfo;
        }



        public void StartPlaying()
        {
            Console.WriteLine("======================== MUSIC PLAYER ========================");
            DisplayNotes();
            List<string> notesRead = GetNotesFromUser();
            if (notesRead == null || notesRead.Count() == 0)
            {
                Console.WriteLine("No notes entered by you , So cant play music");
                return;
            }
            Console.WriteLine("Started playing ...");
            _musicService.PlayMusic(notesRead);

        }

        private void DisplayNotes()
        {
            Console.WriteLine("The notes keys are : ");
            foreach (string noteKey in _musicInfo.Music.Keys)
            {
                Console.WriteLine($"{noteKey}");
            }
        }

        private List<string> GetNotesFromUser()
        {
            List<string> notes = new List<string>();
            Console.WriteLine("Enter -1 after completing notes.");
            bool continueGetting = true;
            while (continueGetting)
            {
                string key = Console.ReadLine() ?? string.Empty;
                if (key == "-1")
                {
                    break;
                }
                notes.Add(key);
            }

            return notes;
        }
    }
}
