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
using ATM.Observers;


namespace ATM.States
{
    class SelectionMenu : State
    {
        private Control _ui;
        private StateManager _stateManager;
        ~SelectionMenu()
        {
            Console.WriteLine("SelectionMenu destroyed \n");
        }
        
        public SelectionMenu(Control ui, StateManager stateManager) :   base(ui, stateManager)
        {
            _ui = ui;
            _stateManager = stateManager;


            CurrentMoney coffeeSelectionInterface = new CurrentMoney(100, 0);
            coffeeSelectionInterface.Attach(new ListOptions(this, 100, 100));
            coffeeSelectionInterface.Attach(new MoneyInsertObserver(this, coffeeSelectionInterface, 500, 0));
            coffeeSelectionInterface.Attach(new DisplayCurrentMoney(this, 800, 100));
            coffeeSelectionInterface.Attach(new ReffundUI(this, coffeeSelectionInterface, 200, 600));
            coffeeSelectionInterface.Attach(new CreditCardUi(this, 800, 500));
            coffeeSelectionInterface.Notify();


            


        }


        private void button_click(object sender, EventArgs e)
        {
            Console.WriteLine((sender as Button).Text);
            // regular expression https://www.dotnetperls.com/regex
        }
    }
}
