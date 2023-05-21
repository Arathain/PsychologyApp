using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PsychologyApp.code
{
    public abstract class LetterDocks {
        private static Dictionary<char, Texture2D> CHARACTERS = new Dictionary<char, Texture2D>();
        private static char[] LETTERS = new char[]{
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        public static void load(ContentManager cnt) {
            foreach(char letter in LETTERS) {
                CHARACTERS.Add(letter, cnt.Load<Texture2D>("letters/" + letter.ToString()));
            }
        }
        public static bool isSupported(char letter) {
            return LETTERS.Contains(letter);
        }
        public static Texture2D getTextureForChar(char letter) {
            if(!isSupported(letter)) {
                return null;
            }
            return CHARACTERS[letter];
        }

        public static void unload() {
            foreach(Texture2D tex in CHARACTERS.Values) {
                tex.Dispose();
            }
        }
    }
}