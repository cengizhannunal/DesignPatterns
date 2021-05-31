using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperations fileOperations = new FileOperations();
            FileManager fileManager = new FileManager();

            fileManager.CreateCommand(new ExcelCommand(fileOperations));
            fileManager.Execute();

            fileManager.CreateCommand(new WordCommand(fileOperations));
            fileManager.Execute();

            Console.ReadLine();
        }

        //Receiver
        class FileOperations
        {
            public void Excel()
            {
                Console.WriteLine("Excel dosyası oluşturuldu.");
            }
            public void Word()
            {
                Console.WriteLine("Word dosyası oluşturuldu.");
            }
        }

        //Command
        interface ICommand
        {
            void Execute();
        }

        //Concrete Command
        class ExcelCommand : ICommand
        {
            readonly FileOperations _fileOperations;

            public ExcelCommand(FileOperations fileOperations)
            {
                _fileOperations = fileOperations;
            }

            public void Execute()
            {
                _fileOperations.Excel();
            }
        }

        //Concrete Command
        class WordCommand : ICommand
        {
            readonly FileOperations _fileOperations;

            public WordCommand(FileOperations fileOperations)
            {
                _fileOperations = fileOperations;
            }

            public void Execute()
            {
                _fileOperations.Word();
            }
        }

        //Invoker
        class FileManager
        {
            ICommand _command;

            public void CreateCommand(ICommand command)
            {
                _command = command;
            }

            public void Execute()
            {
                _command.Execute();
            }
        }
    }
}
