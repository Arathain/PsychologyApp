using System;
using System.Timers;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PsychologyApp.code
{
    public class StartScreen : Screen {
        public SoundEffectInstance sound;
        public StartScreen(List<ScreenObject> setup) : base(setup) {

        }
    }

    public class StartButton : Button {
        private int prog = 0;
        private Timer cooldown;
        public StartButton(float x, float y) : base(x, y) {
            
        }
        private void makeCD() {
            cooldown = new Timer(500);
            cooldown.Start();
            cooldown.AutoReset = false;
            cooldown.Elapsed += ( sender, e ) => {
                setPressed(false);
                if(this.screen.Invoke() is StartScreen scr) {
                    List<ScreenObject> s = new List<ScreenObject>();
			        s.Add(new StopButton(0, 0));
			        s.Add(new BlueLight(-30, -20));
			        s.Add(new OrangeLight(30, -20));
			        Program.gameInstance.currentScreen = new InstTestScreen(s);
                }
            };
        }
        public override void press() {
            if(!isPressed) {
                setPressed(true);
            }
        }
        public override void release(){
            makeCD();
        }
        public override void onPress() {
            
        }
        public override bool isHovering(MouseState mouse) {
            Vector2 centre = Program.gameInstance.getCentre();
            return Math.Abs(mouse.X-(int)(centre.X+this.x)) < 14*8 && Math.Abs(mouse.Y-(int)(centre.Y+this.y)) < 12*8;
        }
        public override void draw(GameTime gameTime, SpriteBatch b) {
            Vector2 centre = Program.gameInstance.getCentre();
            if(isPressed) {
                b.Draw(ContentDocks.START_1, ScreenObject.getSpriteDefault((int)(centre.X+this.x*8), (int)(centre.Y+this.y*8), 32, 32), Color.White);
            } else {
                b.Draw(ContentDocks.START_0, ScreenObject.getSpriteDefault((int)(centre.X+this.x*8), (int)(centre.Y+this.y*8), 32, 32), Color.White);
            }
        }
    }
}