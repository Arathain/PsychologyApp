using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PsychologyApp.code {
    public abstract class Button : ScreenObject{
        protected bool isPressed = false;

        public Button(float x, float y) : base(x, y) {
            
        }

        public virtual void onPress() {

        }
        public bool isPressedM() {
            return isPressed;
        }

        public abstract Boolean isHovering(MouseState mouse);

        public void setPressed(bool ean) {
            isPressed = ean;
        }
        
        public virtual void release() {
            setPressed(false);
        }
        
        public virtual void press() {
            if(!isPressed) {
                setPressed(true);
            }
        }
    }
}