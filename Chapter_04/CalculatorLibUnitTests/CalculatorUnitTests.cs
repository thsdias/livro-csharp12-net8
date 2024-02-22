using CalculatorLib;

namespace CalculatorLibUnitTests;

public class CalculatorUnitTests
{
    /*
        Arrange : Esta parte irá declarar e instanciar variáveis ​​para entrada e saída.
        Act : Esta parte executará a unidade que você está testando. No nosso caso, isso significa chamar o método que queremos testar.
        Assert : Esta parte fará uma ou mais afirmações sobre a saída. Uma afirmação é uma crença que, se não for verdadeira, indica um teste que falhou. 
        Por exemplo, ao somar 2 e 2, esperaríamos que o resultado fosse 4.
    */

    [Fact]
    public void TestAdding2And2()
    {
        // Arrage: Set up the inputs and the unit under test.
        double a = 2;
        double b = 2;
        double expected = 4;

        Calculator calc = new();

        // Act: Execute the function to test.
        double actual = calc.Add(a, b);

        // Assert: Make assertions to compare expected to actual results.
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAdding2And3()
    {
        double a = 2;
        double b = 3;
        double expected = 5;

        Calculator calc = new();
        double actual = calc.Add(a, b);

        Assert.Equal(expected, actual);
    }
}