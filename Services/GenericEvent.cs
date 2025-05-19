using System;

namespace Services
{
    /*
        Anforderungen:

        Die Klasse sollte ein generisches Ereignis haben, das unterschiedliche Datentypen akzeptieren kann.

        Der Handler des Ereignisses sollte eine Methode sein, die einen generischen Parameter empfängt.

        Sie sollte sicherstellen, dass der Ereignishandler nur dann ausgeführt wird, wenn es gültige Abonnenten gibt.

        ####################################################################################################################
        ####################################################################################################################
    
        Erklärung der GenericEvent<TEventArgs>-Klasse

        _event: Ein privates Feld, das das eigentliche Ereignis-Delegate speichert. Dieses Feld speichert alle abonnierten Ereignishandler.

        Event: Ein öffentliches Ereignis, das es ermöglicht, Ereignishandler hinzuzufügen oder zu entfernen. Wenn ein Handler hinzugefügt 
        wird, wird er dem privaten Ereignis-Delegate (_event) hinzugefügt. Wenn ein Handler entfernt wird, wird er aus diesem Delegate entfernt.

        Raise: Diese Methode löst das Ereignis aus und gibt das Ereignis weiter. Sie nimmt zwei Parameter an: den sender (Ursprung des 
        Ereignisses) und ein Ereignisargument e vom Typ TEventArgs. Dies ermöglicht es, benutzerdefinierte Daten zu übergeben, wenn das 
        Ereignis ausgelöst wird.
     */


    public class GenericEvent<TEventArgs>
    {
        // Privates Event, das die Event-Handler speichert
        private event EventHandler<TEventArgs> _event;

        // Öffentliches Event-Property
        public event EventHandler<TEventArgs> Event
        {
            add
            {
                // Hinzufügen eines neuen Handlers
                _event += value;
            }
            remove
            {
                // Entfernen eines Handlers
                _event -= value;
            }
        }

        // Methode, um das Ereignis auszulösen
        public void Raise(object sender, TEventArgs e)
        {
            _event?.Invoke(sender, e);
        }
    }
}
