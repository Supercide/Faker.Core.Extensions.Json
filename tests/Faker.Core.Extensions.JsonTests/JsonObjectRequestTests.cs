using System;
using System.Collections.Generic;
using System.Text;
using Faker.Core.Extensions.Json;
using NUnit.Framework;

namespace Faker.Core.Extensions.JsonTests
{
    public class JsonObjectRequestTests
    {
        [Test]
        public void GivenValidJson_WhenCreatingJsonObjectRequest_ThenCreatesObject()
        {
            var request = JsonRequest.Create("{ \"a\": 1, \"b\": 2}");
            
            var properties = request.GetProperties();

            string[] expected = { "a", "b" };

            Assert.That(properties, Is.EquivalentTo(expected));
        }

        [Test]
        public void GivenInValidJson_WhenCreatingJsonObjectRequest_ThenThrowsException()
        {
            Assert.Throws<ArgumentException>(() => JsonRequest.Create("a"));
        }
    }
}
