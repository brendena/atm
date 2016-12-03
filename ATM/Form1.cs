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

namespace ATM
{
    //This is the context
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            StateManager state = new StateManager(this);
            state.state = new IntroState(this, state);
        }
    }
}
