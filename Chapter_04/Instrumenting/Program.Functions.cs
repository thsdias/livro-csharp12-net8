using System.Diagnostics; // To use Trace.
using System.Runtime.CompilerServices; // To use [CallerX] attributes

partial class Program
{
    /*
        [CallerMemberName] string member = ""
        Define o parâmetro string nomeado member como o nome do método ou propriedade que está executando o método que define esse parâmetro.

        [CallerFilePath] string filepath = ""
        Define o parâmetro string nomeado filepath como o nome do arquivo de código-fonte que contém a instrução que está executando o método que define esse parâmetro.

        [CallerLineNumber] int line = 0
        Define o parâmetro int nomeado line para o número da linha no arquivo de código-fonte da instrução que está executando o método que define esse parâmetro.

        [CallerArgumentExpression(nameof(argumentExpression))]
        string expression = ""
        Define o parâmetro string nomeado expression para a expressão que foi passada para o parâmetro nomeado argumentExpression.
    */

    static void LogSourceDetails(bool condition,
        [CallerMemberName] string member = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int line = 0,
        [CallerArgumentExpression(nameof(condition))] string expression = "")
    {
        Trace.WriteLine(string.Format("[{0}]\n  {1} on line {2}. Expression: {3}", filePath, member, line, expression));

        // Close the text file (also flushes) and release resources.
        Debug.Close();
        Trace.Close();
    }
}