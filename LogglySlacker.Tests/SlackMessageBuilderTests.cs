using System;
using FluentAssertions;
using LogglySlacker.Model;
using NUnit.Framework;

namespace LogglySlacker.Tests
{
    [TestFixture]
    public class SlackMessageBuilderTests
    {
        private readonly SlackMessageBuilder _messageBuilder;

        public SlackMessageBuilderTests()
        {
            _messageBuilder = new SlackMessageBuilder();
        }

        [Test]
        public void should_handle_null_message()
        {
            var hits = new[]
            {
                new LogglyHit()
            };

            Action act = () => _messageBuilder.GetSlackAttachment(new LogglyAlert(), hits);
            act.ShouldNotThrow();
        }
    }
}