using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PsychologyApp.code
{
    public abstract class Screen {
        protected List<ScreenObject> objects;

        public Screen(List<ScreenObject> setup) {
            foreach(ScreenObject s in setup) {
                s.setScreen(this);
            }
            this.objects = setup;
        }
    
        public virtual void update(GameTime gameTime, MouseState current, MouseState previous) {
            if(current.LeftButton == ButtonState.Pressed && previous.LeftButton == ButtonState.Released) {
                //click
                foreach(ScreenObject o in objects) {
                    if(o is Button b) {
                        if(b.isHovering(current)) {
                            b.press();
                            b.onPress();
                        }
                    }
                }

            } else if(previous.LeftButton == ButtonState.Pressed && current.LeftButton == ButtonState.Released) {
                //release
                foreach(ScreenObject o in objects) {
                    if(o is Button b && b.isPressedM()) {
                        b.release();
                    }
                }
            }
        }
        public void drawBackground() {

        }
        
        public void draw(GameTime gameTime, SpriteBatch batch) {
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            drawBackground();
            foreach(ScreenObject o in objects) {
                o.draw(gameTime, batch);
            }
            batch.End();
        }
    }
    public abstract class ScreenObject {
        protected Func<Screen> screen;
        protected float x,y;
        public ScreenObject(float x, float y) {
            this.x = x;
            this.y = y;
        }
        public ScreenObject setScreen(Screen s) {
            screen = () => s;
            return this;
        }
        public abstract void draw(GameTime gameTime, SpriteBatch batch);

        public static Rectangle getSpriteDefault(int x, int y, int width, int height) {
            width *= 8;
            height *= 8;
            return new Rectangle(x-width/2, y-height/2, width, height);
        }
    }
}