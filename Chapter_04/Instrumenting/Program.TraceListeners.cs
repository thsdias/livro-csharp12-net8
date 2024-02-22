using System.Diagnostics;

partial class Program
{
    static void TraceListeners()
    {
        string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
        Console.WriteLine($"Writting to: {logPath}");
        TextWriterTraceListener logFile = new(File.CreateText(logPath));
        Trace.Listeners.Add(logFile);

        #if DEBUG
        // Text writer is buffered, so this option calls
        // Flush() on all listeners after writing.
        /*
        Boa Prática : Qualquer tipo que represente um arquivo geralmente implementa um buffer para melhorar o desempenho. 
        Em vez de gravar imediatamente no arquivo, os dados são gravados em um buffer na memória e somente quando o buffer 
        estiver cheio eles serão gravados em um bloco no arquivo. Esse comportamento pode ser confuso durante a depuração porque 
        não vemos os resultados imediatamente! Ativar AutoFlush significa que o método Flush é chamado automaticamente após cada gravação. 
        Isso reduz o desempenho, portanto, você só deve ativá-lo durante a depuração e não na produção.
        */
        Trace.AutoFlush = true;
        #endif

        Debug.WriteLine("Debug says, I'm watching!");
        Trace.WriteLine("Trace says, I'm watching!");

        // Close the text file (also flushes) and release resources.
        Debug.Close();
        Trace.Close();


        // execute: dotnet run --configuration Release 
        // or
        // dotnet run --configuration Debug

        /*
        Boas Práticas: 
        Ao executar com a Debug configuration, ambos Debug e Trace estão ativos e gravarão em qualquer ouvinte de rastreamento. 
        Ao executar com a Release configuration, apenas Trace gravará em qualquer ouvinte de rastreamento. 
        Portanto, você pode usar chamadas Debug.WriteLine livremente em todo o seu código, sabendo que elas serão eliminadas 
        automaticamente quando você criar a versão de lançamento do seu aplicativo e, portanto, não afetarão o desempenho.
        */
    }
}