namespace _06.Online_Radio_Database
{
    using System;

    public class Song
    {
        private const int MinSongNameLength = 3;
        private const int MaxSongNameLength = 30;
        private const int MinArtistNameLength = 3;
        private const int MaxArtistNameLength = 20;

        private string name;
        private string artistName;
        private TimeSpan length;

        public Song(string artistName, string name, TimeSpan length)
        {
            this.ArtistName = artistName;
            this.Name = name;
            this.Length = length;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < MinSongNameLength || value.Length > MaxSongNameLength)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                this.name = value;
            }
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                if (value.Length < MinArtistNameLength || value.Length > MaxArtistNameLength)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                this.artistName = value;
            }
        }

        public TimeSpan Length
        {
            get { return this.length; }
            set
            {
                this.length = value;
            }
        }
    }
}