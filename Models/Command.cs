using System;

namespace CustomWebCommands.Models
{
    public class Command
    {
        public string CommandName { get; set; } = "discord";

        public string WebUrl { get; set; } = "http://discord.dvtserver.xyz/";

        public string Description { get; set; } = "Enter to this discord to be more special :)";
    }
}
