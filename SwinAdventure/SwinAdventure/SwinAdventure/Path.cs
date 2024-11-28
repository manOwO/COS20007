using System;
namespace SwinAdventure
{
    public class Path : Game_Object
    {
        
        private Location _destination;
        private bool _locked;

        public Path(string[] ids, string name, string desc, Location destination) : base(ids, name, desc)
        {
            _destination = destination;
            _locked = false;
        }

        public override string FullDescription
        {
            get
            {
                return $"move {Name} to {_destination.Name}";
            }
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

        public bool Locked
        {
            get
            {
                return _locked;
            }
            set
            {
                _locked = value;
            }
        }

        public void MovePlayer(Player player)
        {
            if (_locked == true)
            {
                Console.WriteLine("The path is locked.");
            }
            else
            {
                player.Location = _destination;
            }
        }
    }
}

