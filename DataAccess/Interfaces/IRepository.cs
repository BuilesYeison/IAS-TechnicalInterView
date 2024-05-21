using Infrastructure.Models;

namespace DataAccess.Interfaces;

public interface IRepository{
    void InsertData(IEnumerable<Automovil> automoviles);
}