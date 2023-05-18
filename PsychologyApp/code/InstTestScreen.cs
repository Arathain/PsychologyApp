using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System.Timers;

namespace PsychologyApp.code
{
    public class InstTestScreen : Screen {
       
        private System.Timers.Timer timer;
        private System.Timers.Timer sfxTimer;
        public SoundEffectInstance sound;
        Random rand = new Random();
        private int trialCounter = 0;
        public InstTestScreen(List<ScreenObject> setup) : base(setup) {
            resetTimer();
        }
        public bool sufficientTrials() {
            return trialCounter <= 25;
        }
        private System.Timers.Timer makeTimer() {
            System.Timers.Timer time = new System.Timers.Timer(PsychologyAppGame.intervals[trialCounter]);
            time.Elapsed += ( sender, e ) => {
                sound = ContentDocks.BUZZ.CreateInstance();
                sound.Play();
                sfxTimer = new Timer(5000);
                sfxTimer.AutoReset = false;
                sfxTimer.Start();
                sfxTimer.Elapsed += ( sss, eb ) => { 
                    foreach(ScreenObject s in objects) {
                        if(s is OrangeLight b) {
                            b.activate();
                        }
                    }
                };
                trialCounter++;
            };
            time.AutoReset = true;
            return time;
        }
        public void escape() {
            sfxTimer.Stop();
            sfxTimer.Dispose();
            foreach(ScreenObject s in objects) {
                if(s is BlueLight b) {
                    b.activate();
                }
            }
        }
    
        public override void update(GameTime gameTime, MouseState current, MouseState previous) {
            base.update(gameTime, current, previous);
        }
        public void resetTimer() {
            timer = makeTimer();
            timer.Start();
        }
    }
    
    public class StopButton : Button {
        private int prog = 0;
        private Timer cooldown;
        public StopButton(float x, float y) : base(x, y) {
            
        }
        private void makeCD() {
            cooldown = new Timer(1000);
            cooldown.Start();
            cooldown.AutoReset = false;
            cooldown.Elapsed += ( sender, e ) => {
                setPressed(false);
            };
        }
        public override void press() {
            if(!isPressed) {
                setPressed(true);
                makeCD();
            }
        }
        public override void onPress() {
            if(this.screen.Invoke() is InstTestScreen scr && scr.sound != null && scr.sound.State == SoundState.Playing) {
                prog++;
                if(prog > 3) {
                    scr.sound.Pause();
                    scr.sound.Dispose();
                    scr.escape();
                    prog = 0;
                }
            }
            
        }
        public override bool isHovering(MouseState mouse) {
            Vector2 centre = Program.gameInstance.getCentre();
            return Math.Abs(mouse.X-(int)(centre.X+this.x)) < 12*8 && Math.Abs(mouse.Y-(int)(centre.Y+this.y)) < 11*8;
        }
        public override void draw(GameTime gameTime, SpriteBatch b) {
            Vector2 centre = Program.gameInstance.getCentre();
            if(isPressed) {
                b.Draw(ContentDocks.BUTTON_1, ScreenObject.getSpriteDefault((int)(centre.X+this.x*8), (int)(centre.Y+this.y*8), 32, 32), Color.White);
            } else {
                b.Draw(ContentDocks.BUTTON_0, ScreenObject.getSpriteDefault((int)(centre.X+this.x*8), (int)(centre.Y+this.y*8), 32, 32), Color.White);
            }
        }
    }
    public class BlueLight : Light {
        public BlueLight(float x, float y) : base(x, y) {
            
        }
        public override void draw(GameTime gameTime, SpriteBatch b) {
            Vector2 centre = Program.gameInstance.getCentre();
            if(on) {
                b.Draw(ContentDocks.LIGHT_1, ScreenObject.getSpriteDefault((int)(centre.X+this.x*8), (int)(centre.Y+this.y*8), 32, 32), Color.White);
            } else {
                b.Draw(ContentDocks.LIGHT_0, ScreenObject.getSpriteDefault((int)(centre.X+this.x*8), (int)(centre.Y+this.y*8), 32, 32), Color.White);
            }
        }
    }
    public class OrangeLight : Light {
        public OrangeLight(float x, float y) : base(x, y) {
            
        }
        public override void draw(GameTime gameTime, SpriteBatch b) {
            Vector2 centre = Program.gameInstance.getCentre();
            if(on) {
                b.Draw(ContentDocks.OLIGHT_1, ScreenObject.getSpriteDefault((int)(centre.X+this.x*8), (int)(centre.Y+this.y*8), 32, 32), Color.White);
            } else {
                b.Draw(ContentDocks.OLIGHT_0, ScreenObject.getSpriteDefault((int)(centre.X+this.x*8), (int)(centre.Y+this.y*8), 32, 32), Color.White);
            }
        }
    }
    public abstract class Light : ScreenObject {
        protected bool on = false;
        private Timer cooldown;
        public Light(float x, float y) : base(x, y) {
            
        }
        public void activate() {
            on = true;
            makeCD();
        }
        private void makeCD() {
            cooldown = new Timer(1000);
            cooldown.Start();
            cooldown.AutoReset = false;
            cooldown.Elapsed += ( sender, e ) => {
                on = false;
            };
        }
    }
}