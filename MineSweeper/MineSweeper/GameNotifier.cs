using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public abstract class GameNotifier
    {

        public GameResponder Responder { get; set; }

      
        public GameNotifier() {

        }

        public abstract void OnClick(int x, int y);

        public void RaiseFlagClick(int x, int y, bool set) {

            if (Responder != null) {
                Responder.OnFlagClick(x, y, set);
            }
        }

        public void RaiseBombClick(int x, int y, bool set)
        {
            if (Responder != null)
            {
                Responder.OnBombClick(x, y, set);
            }
        }

        public void RaiseWin()
        {
            if (Responder != null)
            {
                Responder.OnWin();
            }
        }

        public void RaiseReveal(int x, int y) {
            if (Responder != null)
            {
                Responder.OnReveal(x, y);
            }
        }
    }
}
