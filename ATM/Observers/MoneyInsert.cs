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

namespace ATM.Observers
{
    class MoneyInsertObserver : InterfaceUiElements
    {
        CurrentMoney _currentMoney;
        public MoneyInsertObserver(State currentState, CurrentMoney currentMoney, int x, int y) : base(currentState, x, y)
        {
            _currentMoney = currentMoney;
            for (int i = 1; i < 5; i++)
            {
                
                Button button = new Button();
                button.Click += this.button_click;

                _currentState.UiInitHelperConstructor(button,  (i *5) + "",
                                        new System.Drawing.Point(x, y + (100 * i)),
                                        new System.Drawing.Size(100, 100));

                _uiItems.Add(button);

                Console.WriteLine("asdf");
            }
            
        }

        public override void Update(CurrentMoney currentMoney)
        {
            Console.WriteLine("MoneyInsertObserver got updated");
            foreach (Button button in _uiItems)
            {
                if (_currentMoney.MoneyHave - _currentMoney.MoneySpent < Int32.Parse(button.Text))
                {
                    button.Enabled = false;
                }
                else {
                    button.Enabled = true;
                }
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            _currentMoney.MoneySpent += Int32.Parse(btn.Text);
            Console.WriteLine("clicked Button");
        }


    }
}
