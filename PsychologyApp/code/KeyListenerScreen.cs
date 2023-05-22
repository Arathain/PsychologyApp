using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychologyApp.code
{
    public interface KeyListenerScreen {
        void addChar(char inputtedChar);
        void clearInput();
    }
}