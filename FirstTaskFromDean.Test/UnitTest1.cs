using Bogus;
using Castle.Core.Logging;
using FakeItEasy;
using FirstTaskFromDean.Controllers;
using FirstTaskFromDean.Data;
using FirstTaskFromDean.Models;
using FirstTaskFromDean.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace FirstTaskFromDean.Test
{
    public class RubbersControllerTest
    {
        [Fact]
        public void GetRubbers_Returns_The_Correct_Number_Of_Rubbers()
        {
            //Arrange

            int count = 5;
            FirstTaskDbContext dataStore = new FirstTaskDbContext(MakeRandomList(count));
            var mock = new Mock<ILogger<RubbersController>>();
            ILogger<RubbersController> logger = mock.Object;
            var controller = new RubbersController(logger, dataStore);
            //Act

            var actionResult = controller.GetRubbers();
            //Assert

            var result = actionResult as OkObjectResult;
            var returnRubbers = result?.Value as IEnumerable<Rubber>;
            Assert.Equal(count, returnRubbers.Count());
        }

        private List<Rubber> MakeRandomList(int count)
        {
            List<Rubber> randomList = new List<Rubber>();
            for (int i = 0; i < count; i++)
            {
                var rubber = new Faker<Rubber>()
                    .RuleForType(typeof(string), c => c.Random.Word())
                    .RuleForType(typeof(int), c => c.Random.Number(80, 100))
                    .RuleForType(typeof(Guid), c => c.Random.Guid());
                randomList.Add(rubber.Generate());
                
            }
            
            return randomList;
        }
    }
}

