namespace MusicPlayer.MusicSevice
{
    internal class MusicService
    {
        private Dictionary<string, int> _notes;
        private int _timeInterval;

        public MusicService(Dictionary<string, int> notes, int timeInterval)
        {
            _notes = notes;
            _timeInterval = timeInterval;
        }

        public void PlayMusic(List<string> notesToBePlayed)
        {
            foreach (string note in notesToBePlayed)
            {
                if (_notes.TryGetValue(note, out int freq))
                {
                    Console.Beep(freq, _timeInterval * 1000);
                }
            }
        }
    }
}
