namespace _06.Online_Radio_Database
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Globalization;

    public class Startup
    {
        public static void Main()
        {
            var playlist = new List<Song>();
            var songsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < songsCount; i++)
            {
                try
                {
                    var songArgs = Console.ReadLine().Split(';');
                    if (songArgs.Length == 3)
                    {
                        var artistName = songArgs[0];
                        var songName = songArgs[1];
                        var songLengthArgs = songArgs[2].Split(':');
                        if (songLengthArgs.Length == 2)
                        {
                            int songMinutesLength;
                            var songMinutesLengthTry = int.TryParse(songLengthArgs[0], out songMinutesLength);
                            int songSecondsLength;
                            var songSecondsLengthTry = int.TryParse(songLengthArgs[1], out songSecondsLength);
                            ValidateSongMinutesAndSeconds(songMinutesLength, songSecondsLength, songArgs[2]);
                            var length = new TimeSpan(0, songMinutesLength, songSecondsLength);
                            var song = new Song(artistName, songName, length);
                            playlist.Add(song);
                            Console.WriteLine("Song added.");
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            PrintResult(playlist);
        }

        public static ArgumentException ValidateSongMinutesAndSeconds(int songMinutesLength, int songSecondsLength, string timeArgs)
        {
            if (songMinutesLength < 0 || songMinutesLength > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }

            DateTime timeCheck;
            var timeCheckTry = DateTime.TryParseExact(timeArgs, "m:s",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out timeCheck);
            if (!timeCheckTry)
            {
                throw new ArgumentException("Invalid song length.");
            }
            return null;
        }

        public static void PrintResult(List<Song> songs)
        {
            var hours = (int)songs.Select(s => s.Length.TotalHours).Sum();
            var minutes =  (int)songs.Select(s => s.Length.TotalMinutes ).Sum() % 60;
            var seconds = (int)songs.Select(s => s.Length.TotalSeconds ).Sum() % 60;

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }
    }
}