using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniGames.Model
{
    internal class KeyPressedMessage : MessageBase
    {
        public KeyEventArgs keyEventArgs { get; set; }
    }
    internal class CloseSnakeMessage : MessageBase
    {
    }
}
