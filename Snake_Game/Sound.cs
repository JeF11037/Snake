using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Sound
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake\JeF11037-Guitar8D.wav");
        public void background_music()
        {
            player.PlayLooping();
        }

        public void chewing()
        {
            System.Media.SoundPlayer sound_chewing = new System.Media.SoundPlayer(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake_Game\429593__inspectorj__chewing-breadstick-single-b.wav");
            sound_chewing.Play();
        }

        public void game_over()
        {
            System.Media.SoundPlayer sound_go = new System.Media.SoundPlayer(@"C:\Users\levpe\Documents\Project_CS\Snake\Snake_Game\76376__deleted-user-877451__game-over.wav");
            sound_go.Play();
        }

        public void stop()
        {
            player.Stop();
        }
    }
}
