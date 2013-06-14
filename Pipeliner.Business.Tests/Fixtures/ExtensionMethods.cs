using NSubstitute;

namespace Pipeliner.Business.Tests.Fixtures
{
    public static class ExtensionMethods
    {
        public static void EmulatePipelineInstanceEvent(this IPipelineStarter starter, InstanceCreateEventArgs args = null)
        {
            starter.OnPipelineInstanceCreate += Raise.EventWith(args);
        }
    }
}