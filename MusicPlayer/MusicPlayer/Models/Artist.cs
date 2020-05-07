using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Models
{
    public class Artist
    {
        string Name { get; set; }

        string Biography { get; set; }

        string Tags { get; set; }

        string Genre { get; set; }

        object Image { get; set; }

        string ImageUri { get; set; }

        object Rating { get; set; }

        IList<Album> Albums { get; set; }

        IList<Song> TopTracks { get; set; }

        IList<Song> AllTracks { get; }
    }
}
