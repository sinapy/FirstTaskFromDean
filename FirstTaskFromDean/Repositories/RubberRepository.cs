using FirstTaskFromDean.Data;
using FirstTaskFromDean.Models;
using FirstTaskFromDean.Repositories.Interfaces;

namespace FirstTaskFromDean.Repositories;

public class RubberRepository : IRubberRepository
{
    private readonly FirstTaskDbContext _context;

    public RubberRepository(FirstTaskDbContext context)
    {
        _context = context;
    }
    public virtual Rubber FindById(Guid id)
    {
        foreach (Rubber rubber in _context.getRubbers())
        {
            if (rubber.id == id)
            {
                return rubber;
            }
        }

        return new Rubber
        {
            id = Guid.Empty
        };
    }

    public Rubber Update(Rubber rubber)
    {
        // Not yet implemented
        return rubber;
    }
}
