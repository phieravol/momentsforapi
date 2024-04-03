using System.Reflection;

namespace MomentsFor.Infrastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
