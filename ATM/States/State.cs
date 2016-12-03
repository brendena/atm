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
    abstract class State
    {
        protected List<Control> uiElements;
        protected Control ui;
        protected StateManager _stateManager;
        static public string _topURLDomain = "../../";
        static private string pictureURL = _topURLDomain + "pictures/";
        static public int width = Screen.PrimaryScreen.Bounds.Width;
        static public int height = Screen.PrimaryScreen.Bounds.Height;

        public State(Control UI, StateManager stateManager) {
            this.ui = UI;
            this.uiElements = new List<Control>();
            _stateManager = stateManager;
        }

        protected void cleanState() {

        }

        //maby this should be a dictonary
        public void UiInitHelperConstructor(Control UiElement, string text, 
                                                System.Drawing.Point location, System.Drawing.Size size) {
            UiElement.Parent = this.ui;
            UiElement.Text = text;
            UiElement.Location = location;
            UiElement.Size = size;
            this.uiElements.Add(UiElement);
            //return UiElement;
        }



        

        protected void cleanUiElements() {
            foreach (var uiE in uiElements) {
                this.ui.Controls.Remove(uiE);
            }
        }
        public string TopURLDomain
        {
            get { return _topURLDomain; }
        }
        public string PictureURL
        {
            get { return pictureURL; }
        }
    }
}
