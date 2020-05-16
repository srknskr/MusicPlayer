using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MusicPlayer.Droid;
using MusicPlayer.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetPath))]

namespace MusicPlayer.Droid
{
    public class GetPath : getPath
    {

        public string GetMusicPath()
        {
            string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).ToString();
            string directory = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryMusic);
            string file = Path.Combine(directory, "audio.mp3");

            var isexi = File.Exists(file);
           return file;



          
        }
}
}