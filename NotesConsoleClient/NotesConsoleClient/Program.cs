using NotesConsoleClient;


"\n\t\tLogin Menu".ColorWriteLine(ConsoleColor.DarkBlue);
" Enter Username:".ColorWriteLine(ConsoleColor.Blue);
var username = Console.ReadLine();

"\n  Enter Password:".ColorWriteLine(ConsoleColor.Blue);
var password = Console.ReadLine();  

Console.Clear();

var noteService = new NotesAppService();


try
{
     await noteService.UserloginAsync(username, password);
    await noteService.GetNotesAsync();
}

catch(Exception ex)
{
    Console.Clear();
    ex.Message.ColorWriteLine(ConsoleColor.Red);    
}


Console.Read();