using System.Diagnostics.Metrics;

string way, word, word1, choise, choise1;
int counter;
bool flag = true;

Console.WriteLine("Enter the way to file:");
way = Console.ReadLine();
Console.WriteLine("Enter the word:");
word = Console.ReadLine();
FileInfo Cli;
string[] folders = System.IO.Directory.GetDirectories(way, "*", System.IO.SearchOption.AllDirectories), cleanFolders;

while (flag)
{
    counter = 0;
    for (int i = 0; i < folders.Length; i++)
    {
        if (folders[i].Contains((char)92+word+(char)92))
        {
            counter++;
        }
    }
    cleanFolders = new string[counter];
    Console.WriteLine("Matches found: " + counter);
    counter = 0;
    for (int i = 0; i < folders.Length; i++)
    {
        if (folders[i].Contains((char)92 + word + (char)92))
        {
            cleanFolders[counter] = folders[i];
            Console.WriteLine(counter + 1 + " way: " + folders[i]);
            counter++;
        }
    }

    Console.WriteLine("1 - Replace the word you are looking for\n2 - Delete the word you are looking for\n3 - Change the way\n4 - Change the word\nElse - exit");
    choise = Console.ReadLine();
    if(int.Parse(choise) == 1)
    {
        Console.WriteLine("Enter the way number:");
        choise1 = Console.ReadLine();
        Cli = new FileInfo(cleanFolders[int.Parse(choise1)]);
        Console.WriteLine("Enter the name of the file that will replace:");
        word1 = Console.ReadLine();
        Cli.Replace(word1, word, true);
    }
    else if(int.Parse(choise) == 2)
    {
        Console.WriteLine("Enter the way number:");
        choise1 = Console.ReadLine();
        Cli = new FileInfo(cleanFolders[int.Parse(choise1)]);
        Cli.Delete();
    }
    else if(int.Parse(choise) == 3)
    {
        Console.WriteLine("Enter the way to file:");
        way = Console.ReadLine();
        folders = System.IO.Directory.GetDirectories(way, "*", System.IO.SearchOption.AllDirectories);
    }
    else if(int.Parse(choise) == 4)
    {
        Console.WriteLine("Enter the word:");
        word = Console.ReadLine();
    }
    else
    {
        flag = false;
    }
}