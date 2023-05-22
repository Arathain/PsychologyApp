using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PsychologyApp.code
{
    public class TransScreen : Screen, KeyListenerScreen {
        private Action dyingBreath;
        private List<char> input = new List<char>();
        public void addChar(char inputtedChar) {
            if(input.Count < 5) {
                input.Add(inputtedChar);
                if(new string(input.ToArray()).ToLower() == "xyzzy") {
                    dyingBreath.Invoke();
                    clearInput();
                }
            }
        }
        public void clearInput() {
            input.Clear();
        }
        public TransScreen(List<ScreenObject> setup, Action end) : base(setup) {
            dyingBreath = end;
        }

        public override void drawBackground(SpriteBatch batch) {
            base.drawBackground(batch);
            Vector2 centre = Program.gameInstance.getCentre();
            batch.Draw(ContentDocks.COMPLETED, ScreenObject.getSpriteDefault((int)(centre.X), (int)(centre.Y), 96, 64), Color.GreenYellow);
        }
    }
}