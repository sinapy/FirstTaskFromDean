using FakeItEasy;
using FirstTaskFromDean.Controllers;
using FirstTaskFromDean.Repositories.Interfaces;

namespace FirstTaskFromDean_UnitTest;

public class RubbersControllerTests
{
    [Fact]
    public void GetRubbers_Returns_The_Correct_Number_Of_Recipies()
    {
        //Arrange

        var dataStore = A.Fake<IRubberRepository>();
        var controller = new RubbersController();
        //Act


        //Assert
    }
}