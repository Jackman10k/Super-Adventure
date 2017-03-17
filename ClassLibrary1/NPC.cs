using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class NPC
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Dialogue { get; set; }

        public NPC(int id, string name, string dialogue)
        {
            ID = id;
            Name = name;
            Dialogue = dialogue;
        }
    }
}
