using FirstTaskFromDean.Models;

namespace FirstTaskFromDean.Repositories.Interfaces;

public interface IRubberRepository
{
    public Rubber FindById(Guid id);
    public Rubber Update(Rubber rubber);
}