using BeispielMediatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielMediatorPattern.Classes
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<string, IView> _views = new Dictionary<string, IView>();
        private IView _currentView;

        public void RegisterView(string key, IView view)
        {
            if (!_views.ContainsKey(key))
            {
                _views.Add(key, view);
            }
        }

        public void SwitchView(string key)
        {
            if (_views.ContainsKey(key))
            {
                _currentView?.Hide(); // Die aktuelle View ausblenden
                _currentView = _views[key];
                _currentView.Show(); // Die neue View anzeigen
            }
        }
    }
}
