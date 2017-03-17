using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Inn
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WelcomeMessage { get; set; }
        public string RestMessage { get; set; }
        public string NotEnoughGoldMessage { get; set; }
        public int Cost { get; set; }

        public Inn(string name, string description, string welcomeMessage, string restMessage, string notEnoughGoldMessage, int cost)
        {
            Name = name;
            Description = description;
            WelcomeMessage = welcomeMessage;
            RestMessage = restMessage;
            NotEnoughGoldMessage = notEnoughGoldMessage;
            Cost = cost;
        }
    }
}
