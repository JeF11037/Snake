using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Snake
{
    class Sound
    {
        public System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
        public void Play(string link)
        {
            System.Windows.Media.MediaPlayer sound = new System.Windows.Media.MediaPlayer();
            sound.Open(new System.Uri(link));
            sound.Volume = 100;
            sound.Play();
        }
        public void PlayMusic(string link)
        {
            player.Open(new System.Uri(link));
            player.Volume = 100;
            player.Play();
        }
        public void Stop()
        {
            player.Stop();
        }
        public void Pause()
        {
            player.Pause();
        }

        public void Unpause()
        {
            player.Play();
        }

        public void SetVolume(int vol)
        {
            Pause();
            player.Volume = vol;
            Unpause();
        }
    }
}
