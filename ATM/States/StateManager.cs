using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATM.States;

namespace ATM.States
{
    class StateManager
    {
        private State _state;
        private Control _ui;

        public StateManager(Control ui) {
            this._ui = ui;
        }

        public State state
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
