using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nona3
{
	public class human : human1
	{
		public int id { get; set; }
		public string name { get; set; }
		public string family { get; set; }
		public byte age { get; set; }
		
	}

	public class human1
	{
		public bool exist(string name, string family)
		{
			db db1 = new db();
			var q = db1.human.Where(i => i.name == name && i.family == family);
			if (q.Count() == 1)
			{
				return true;
			}

			return false;
		}
		public human Register(human form)
		{
			if (exist(form.name, form.family) != true)
			{
				if (form.age >= 18)
				{
					db db1 = new db();
					db1.human.Add(form);
					db1.SaveChanges();
					return form;
				}
			}
			return form;
		}
		public List<human> read()
		{
			return (new db()).human.ToList();
		}
		public human read(int id)
		{

			return (from i in (new db()).human where i.id == id select i).Single();
		}
		public List<human> read(string text)
		{
			return (from i in (new db()).human
					where i.name.Contains(text) || i.family.Contains(text) select i).ToList();
		}
		public void update(int id, human newhuman)
		{
			if (exist(newhuman.name, newhuman.family) == true)
			{
				db db1 = new db();
				var q = db1.human.Where(i => i.id == id);
				if (q.Count() == 1)
				{
					human h = new human();
					h = q.Single();
					h.name = newhuman.name;
					h.family = newhuman.family;
					h.age = newhuman.age;
					db1.SaveChanges();
				}

			}
		}
	}
	
}
