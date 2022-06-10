using FirstTaskFromDean.Controllers;
using FirstTaskFromDean.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FirstTaskFromDeanUnitTest;

[TestClass]
public class RubbersControllerTest
{
    private Rubber _rubber = new()
    {
        brand = "Butterfly",
        id = Guid.NewGuid(),
        name = "Tenergy80",
        power = 91,
        speed = 94,
        spin = 91,
        touch = 87
    };

    private Rubber _updateRubber = new()
    {
        brand = "Update - Butterfly",
        id = Guid.NewGuid(),
        name = "Update - Tenergy80",
        power = 80,
        speed = 82,
        spin = 90,
        touch = 88
    };

    [TestMethod]
    public void Rubbers_GetAll_Success()
    {
        // IQueryable<Rubber> data = new List<Rubber>
        // {
        //     new Rubber
        //     {
        //         brand = "Joola",
        //         id = new Guid("8AA66937-D5EC-4F0E-D459-08D801D5FB62"),
        //         name = "Joola-333",
        //         power = 70,
        //         speed = 88,
        //         spin = 85,
        //         touch = 90
        //     }
        // }.AsQueryable();

        var mock = new Mock<ILogger<RubbersController>>();
        var logger = mock.Object;

        var controller = new RubbersController(logger);
        var result = controller.GetRubbers() as ObjectResult;

        Assert.That(result?.StatusCode, Is.EqualTo(200));
        Assert.IsNotNull(result?.Value);
    }
}