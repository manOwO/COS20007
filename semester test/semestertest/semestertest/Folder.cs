using System;
namespace semestertest
{
	public class Folder : Thing
	{
		private List<Thing> _contents;

		public Folder(string name) : base(name)
		{
			_contents = new List<Thing>();
		}


		public void Add(Thing toAdd)
		{
			_contents.Add(toAdd);
		}

		public override int Size()
		{
			int _size = 0;
			foreach (File thing in _contents)
			{
				_size += thing.Size();
			}
			return _size;
		}

		public override void Print()
		{
			if (_contents.Count == 0)
			{
				Console.WriteLine($"The folder '{Name}' is empty!");
			}
			else
			{
                Console.WriteLine($"The folder '{Name}' contains {Size()} bytes total:");
				foreach (File thing in _contents)
				{
					thing.Print();
				}
            }
			
		}

	}
}

