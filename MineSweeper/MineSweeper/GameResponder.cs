using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public abstract class GameResponder
    {
        public GameNotifier Notifier { get; set; }

        public void RaiseClick(int x, int y)
        {

            if (Notifier != null)
            {
                Notifier.OnClick(x, y);
            }
        }

        public abstract void OnFlagClick(int x, int y, bool set);

        public abstract void OnBombClick(int x, int y, bool set);

        public abstract void OnWin();

        public abstract void OnReveal(int x, int y);
    }
}
