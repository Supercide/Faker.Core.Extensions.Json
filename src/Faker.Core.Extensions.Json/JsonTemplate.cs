namespace Faker.Core.Extensions.Json {
    public class JsonTemplate : ITemplate
    {
        public IRequest Request { get; set; }
        public IResponse Response { get; set; }
    }
}