using System.Collections.Immutable;
using System.Net.Sockets;
using FirstTaskFromDean.Models;

namespace FirstTaskFromDean.Data
{
    public class FirstTaskDbContext
    {
        public static readonly List<Rubber> Rubbers = new List<Rubber>();

        public FirstTaskDbContext()
        {
            Rubbers.Add(new()
            {
                id = Guid.NewGuid(),
                name = "T-Energy50",
                brand = "Butterfly",
                power = 89,
                speed = 91,
                spin = 89,
                touch = 70
            });
        }

        public FirstTaskDbContext(List<Rubber> newRubbers)
        {
            foreach (Rubber rubber in newRubbers)
            {
                Rubbers.Add(rubber);
            }
        }

        public List<Rubber> getRubbers()
        {
            return Rubbers;
        }

        public void Add (Rubber rubber)
        {
            Rubbers.Add(rubber);
        }

        public void Remove(Rubber rubber)
        {
            Rubbers.Remove(rubber);
        }

        public void Remove(Guid id)
        {
            foreach (Rubber rubber in Rubbers)
            {
                if (rubber.id == id)
                {
                    Rubbers.Remove(rubber);
                    return;
                }
            }
            
            
        }
        
        
    }
}

