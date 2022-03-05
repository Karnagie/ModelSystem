using System;
using System.Text.RegularExpressions;

namespace GameModels.ConsoleEssence
{
    public class ConsoleCommandReader
    {
        public ConsoleCommand Read(string command)
        {
            try
            {
                var words = SplitWords(command.ToLower());

                foreach (var info in ConsoleActions.Infos)
                {
                    if (words[0] == info.name)
                    {
                        return new ConsoleCommand(info, info.args.Invoke(words));
                    }
                }
                throw new Exception($"The command {words[0]} not found!");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        private string[] SplitWords(string command)
        {
            var words = Regex.Replace(command ,@"\\s+", "  ");
            words = words.Trim();
            return words.Split(' ');
        }
    }
}