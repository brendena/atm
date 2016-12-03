using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ATM.States;


namespace ATM.Observers
{
    class ListOptions : InterfaceUiElements
    {
        private List<CoffeeName> _currentCoffeOffers;
        public ListOptions(State currentState, int x, int y) : base(currentState, x, y)
        {
            LoadJson();
            int i = 0;
            foreach (CoffeeName coffee in _currentCoffeOffers) {


                Button button = new Button();
                button.Click += this.button_click;

                _currentState.UiInitHelperConstructor(button,coffee.Name + " Price " + coffee.Price,
                                        new System.Drawing.Point(x, y + (100 * i)),
                                        new System.Drawing.Size(100, 100));

                _uiItems.Add(button);
                i++;
            }

        }

        public override void Update(CurrentMoney currentMoney) {
            int i = 0;
            foreach (Button button in _uiItems) {
                if (_currentCoffeOffers[i].Price > currentMoney.MoneySpent)
                {
                    button.Enabled = false;
                }
                else
                {
                    button.Enabled = true;
                }
                Console.WriteLine("price " + currentMoney.MoneySpent);
                i++;
            }
            Console.WriteLine("ListOptions got updated");
        }

        public void button_click(object sender, EventArgs e) {
            Console.WriteLine("ListOption Clicked");
        }
        public void LoadJson()
        {
            
            string path = Path.GetFullPath(_currentState.TopURLDomain + "Observers/coffeeNames.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Console.WriteLine(json);

                AllCoffee mi = JsonConvert.DeserializeObject<AllCoffee>(json);

                _currentCoffeOffers = mi.AmericanNames;
            }

        }

        public class CoffeeName {
            public string Name;
            public int Price;
        }
        public class AllCoffee {
            public List<CoffeeName> AmericanNames;
            public List<CoffeeName> BritishNames;
        }
    }
}
