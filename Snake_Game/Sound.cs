using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Sound
    {
        public void music(string link)
        {
            System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
            player.Open(new System.Uri(link));
            player.Play();
        }
    }
}
