namespace MusicPlayer.Model
{
    internal class MusicInfo
    {
        public Dictionary<string, int> Music { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// Gets the TimeInterval for each note.
        /// Hardcoded for all the note as same one.
        /// </summary>
        public int TimeInterval { get; } = 1;
        public void IntializeMusic()
        {
            Music.Add("C", 261);
            Music.Add("C#", 261);
            Music.Add("D", 277);
            Music.Add("D#", 293);
            Music.Add("E", 311);
            Music.Add("F", 329);
            Music.Add("F#", 349);
            Music.Add("G", 369);
        }
    }
}
