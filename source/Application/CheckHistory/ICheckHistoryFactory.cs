using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public interface ICheckHistoryFactory
    {
        CheckHistory Create(CheckHistoryModel model);
    }
}
