using NUnit.Framework;
using Pipeliner.Business.Providers.Starters;

namespace Pipeliner.Business.Providers.Tests.Starters
{
    [TestFixture]
    public class ManualPipelineStarterTests
    {
        [Test]
        public void EnsureStarterFiresWhenManuallyTriggered()
        {
            var trigger = new ManualPipelineStarter();
        }
    }
}
