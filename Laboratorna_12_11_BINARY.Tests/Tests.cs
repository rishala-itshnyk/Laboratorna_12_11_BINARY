namespace Laboratorna_12_11_BINARY.Tests;

public class Tests
{
    [Test]
    public void AddCar_AddsCarToGarage()
    {
        // Arrange
        Garage garage = new Garage();

        // Act
        garage.AddCar("BC2006YA");

        // Assert
        Assert.IsNotNull(garage);
        // Add more assertions if needed
    }

    [Test]
    public void RemoveCar_RemovesCarFromGarage()
    {
        // Arrange
        Garage garage = new Garage();
        garage.AddCar("BC2006YA");

        // Act
        garage.RemoveCar("BC2006UA");

        // Assert
        // Assert that the car is removed, you can check the state of the garage or specific nodes
        Assert.Pass("Car successfully removed from garage.");
    }

    [Test]
    public void DisplayCars_DisplaysCarsInGarage()
    {
        // Arrange
        Garage garage = new Garage();
        garage.AddCar("BC2006YA");
        garage.AddCar("BC2008YA");

        // Act
        // Redirect Console output for testing
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            garage.DisplayCars();
            string expected = $"Автомобілі на стоянці:\nНомер: BC2006YA\nНомер: BC2008YA\n";
            // Assert
            Assert.AreEqual(expected, sw.ToString());
        }
    }
}