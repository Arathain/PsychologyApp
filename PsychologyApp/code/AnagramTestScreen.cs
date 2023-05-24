using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PsychologyApp.code
{
    public class AnagramTestScreen : Screen, KeyListenerScreen {
        private static string[] anagrams = new string[] {
            "Blood",
            "Jolly",
            "Bling",
            "Heart",
            "Since",
            "Metal",
            "Class",
            "Grief",
            "Dream",
            "Angry",
            "Bread",
            "Black",
            "Clean",
            "Erase",
            "Laser",
            "Smart",
            "Piano",
            "Sleep",
            "Drone",
            "Train"
        };
        //THE TIME ZONE
        private DateTime startTime;
        public TimeSpan getRunning() {
            return DateTime.Now - startTime;
        }

        //END TIME ZONE
        private int currentAnagram = 0;
        private List<char> input = new List<char>();

        Random rand = new Random();
        public AnagramTestScreen(List<ScreenObject> setup) : base(setup) {
            //Shuffle<string>(rand, anagrams);
            startTime = DateTime.Now;
        }

        public void sendData(int responseTime) {
            Program.gameInstance.anagramResponseIntervalTotallyNotTelemetry.Add(responseTime);
        }
        public void addChar(char inputtedChar) {
            if(input.Count < 5) {
                input.Add(inputtedChar);
                if(new string(input.ToArray()).ToLower() == anagrams[currentAnagram].ToLower()) {
                    currentAnagram++;
                    sendData(getRunning().Minutes*60*1000+getRunning().Seconds*1000+getRunning().Milliseconds);
                    clearInput();
                    startTime = DateTime.Now;
                    if(anagrams.Length <= currentAnagram) {
                        Program.gameInstance.currentScreen = new TransScreen(new List<ScreenObject>(), () => {
                        Program.gameInstance.DoStorageContainerThing();
                    });
                    }
                }
            }
        }
        public void clearInput() {
            input.Clear();
        }
        public static void Shuffle<T> (Random rng, T[] array) {
            int n = array.Length;
            while (n > 1) 
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
        public static string ShuffleString(string str) {
            return (str[4].ToString() + str[2].ToString() + str[1].ToString() + str[0].ToString() + str[3].ToString()).ToLower();
        }

        public override void drawBackground(SpriteBatch batch) {
            base.drawBackground(batch);
            Vector2 centre = Program.gameInstance.getCentre();
            string anagram = ShuffleString(anagrams[currentAnagram]);
            for (int i = 0; i < anagram.Length; i++){
                batch.Draw(LetterDocks.getTextureForChar(anagram[i]), ScreenObject.getSpriteDefault((int)(centre.X-40*8+i*20*8), (int)(centre.Y-10*8), 16, 16), Color.Black);
            }
            for (int i = 0; i < input.Count; i++){
                batch.Draw(LetterDocks.getTextureForChar(input[i]), ScreenObject.getSpriteDefault((int)(centre.X-40*8+i*20*8), (int)(centre.Y+15*8), 16, 16), Color.Black);
            }
            if((double) ((DateTime.Now.Second*1000+DateTime.Now.Millisecond) % 1800) / 900 > 1) {
                batch.Draw(ContentDocks.UNDERSCORE, ScreenObject.getSpriteDefault((int)(centre.X-40*8+input.Count*20*8), (int)(centre.Y+21*8), 16, 16), Color.Black);
            }
        }

        public override void update(GameTime gameTime, MouseState current, MouseState previous) {
            base.update(gameTime, current, previous);
            if(getRunning().Minutes*60+getRunning().Seconds+getRunning().Milliseconds/1000f > 30) {
                currentAnagram++;
                    sendData(getRunning().Minutes*60*1000+getRunning().Seconds*1000+getRunning().Milliseconds);
                    clearInput();
                    startTime = DateTime.Now;
                    if(anagrams.Length <= currentAnagram) {
                        Program.gameInstance.currentScreen = new TransScreen(new List<ScreenObject>(), () => {
                        Program.gameInstance.DoStorageContainerThing();
                    });
                }
            }
        }
    }
}