using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public interface ITargetAppFactory
    {
        TargetApp Create(TargetAppModel model);
    }
}
