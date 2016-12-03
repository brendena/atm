using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Observers
{
    class CurrentMoney
    {
        private int _moneyHave; //totall Amount of money
        private int _moneySpent;

        private List<Observer> _uiItems = new List<Observer>();

        public CurrentMoney(int moneyHave, int moneySpent) {
            this._moneyHave = moneyHave;
            this._moneySpent = moneySpent;
        }

        public void Attach(Observer ui) {
            _uiItems.Add(ui);
        }
        public void Detach(Observer ui) {
            _uiItems.Remove(ui);
        }
        public void Notify()
        {
            foreach (Observer ui in _uiItems)
            {
                //this is weird
                ui.Update(this);
            }

            Console.WriteLine("updated the UI");
            Console.WriteLine("" + _moneyHave + "   ms " + _moneySpent);
        }

        public int MoneyHave
        {
            get { return _moneyHave; }
            set
            {
                if (_moneyHave != value)
                {
                    _moneyHave = value;
                    Notify();
                }
            }
        }
        public int MoneySpent
        {
            get { return _moneySpent; }
            set
            {
                if (_moneySpent != value)
                {
                    Console.WriteLine(_moneySpent + "this is moneySpent");
                    _moneySpent = value;
                    Notify();
                }
            }
        }
        public int getMoneyLeft()
        {
            return _moneyHave - _moneySpent;
        }

        public void refund() {
            MoneySpent = 0;
        }

    }
}
