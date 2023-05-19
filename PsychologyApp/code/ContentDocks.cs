using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace PsychologyApp.code
{
    public class ContentDocks {
        public static Texture2D BUTTON_0;
        public static Texture2D BUTTON_1;
        public static Texture2D START_0;
        public static Texture2D START_1;
        public static Texture2D LIGHT_0;
        public static Texture2D LIGHT_1;
        public static Texture2D OLIGHT_0;
        public static Texture2D OLIGHT_1;
        public static SoundEffect BUZZ;
        public static void load(ContentManager cnt) {
            BUTTON_0 = cnt.Load<Texture2D>("button_0");
            BUTTON_1 = cnt.Load<Texture2D>("button_1");
            START_0 = cnt.Load<Texture2D>("start_button");
            START_1 = cnt.Load<Texture2D>("start_button_pressed");
            LIGHT_0 = cnt.Load<Texture2D>("light_0");
            LIGHT_1 = cnt.Load<Texture2D>("light_1");
            OLIGHT_0 = cnt.Load<Texture2D>("olight_0");
            OLIGHT_1 = cnt.Load<Texture2D>("olight_1");
            BUZZ = cnt.Load<SoundEffect>("1kHz");
        }

        public static void unload() {
            START_0.Dispose();
            START_1.Dispose();
            BUTTON_0.Dispose();
            BUTTON_1.Dispose();
            LIGHT_0.Dispose();
            LIGHT_1.Dispose();
            OLIGHT_0.Dispose();
            OLIGHT_1.Dispose();
            BUZZ.Dispose();
        }
        
        // private Texture2D haul(String descriptor) {
        // }
    }
}