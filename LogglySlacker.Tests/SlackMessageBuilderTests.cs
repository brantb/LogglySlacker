using System;
using System.Linq;
using FakeItEasy;
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
        public void should_handle_null_message_and_null_messageObject()
        {
            var hits = new[]
            {
                new LogglyHit()
            };

            Action act = () => _messageBuilder.GetSlackAttachment(new LogglyAlert(), hits);
            act.ShouldNotThrow();
        }

        [Test]
        public void should_concat_message_and_messageObject()
        {
            var theMessage = "theMessage";
            var theMessageObject = "theMessageObject";
            var hits = new[]
            {
                new LogglyHit {message = theMessage, messageObject = theMessageObject}
            };

            var slackAttachment = _messageBuilder.GetSlackAttachment(A.Dummy<LogglyAlert>(), hits);

            slackAttachment.fields.First().value.Should().Be(theMessage + theMessageObject);
        }

        [Test]
        public void should_handle_null_message_when_message_object_present()
        {
            var theMessageObject = "theMessageObject";
            var hits = new[]
            {
                new LogglyHit {messageObject = theMessageObject}
            };

            var slackAttachment = _messageBuilder.GetSlackAttachment(A.Dummy<LogglyAlert>(), hits);

            slackAttachment.fields.First().value.Should().Be(theMessageObject);
        }

        [Test]
        public void should_handle_null_messageObject_when_message_is_present()
        {
            var theMessage = "theMessage";
            var hits = new[]
            {
                new LogglyHit {message = theMessage}
            };

            var slackAttachment = _messageBuilder.GetSlackAttachment(A.Dummy<LogglyAlert>(), hits);

            slackAttachment.fields.First().value.Should().Be(theMessage);
        }
    }
}