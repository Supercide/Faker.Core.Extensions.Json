using System;
using System.Linq;
using Faker.Core.Extensions.Json;
using NUnit.Framework;

namespace Faker.Core.Extensions.JsonTests
{
    public class JsonArrayRequestTests
    {
        [Test]
        public void GivenValidJson_WhenCreatingJsonArrayRequest_ThenCreatesObject()
        {
            var request = JsonRequest.Create("[ \"a\", \"b\"]");

            var properties = request.GetProperties();

            string[] expected = { "0", "1" };

            Assert.That(properties, Is.EquivalentTo(expected));
        }

        [Test]
        public void GivenInValidJson_WhenCreatingJsonArrayRequest_ThenThrowsException()
        {
            Assert.Throws<ArgumentException>(() => JsonRequest.Create("a"));
        }
    }
}
