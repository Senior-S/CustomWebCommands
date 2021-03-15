using CustomWebCommands.Models;
using Microsoft.Extensions.Configuration;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Players.Chat.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCommands
{
    public class Events
    {
        public class PlayerChatted : IEventListener<UnturnedPlayerChattingEvent>
        {
            private readonly IConfiguration m_Configuration;

            public PlayerChatted(IConfiguration configuration)
            {
                m_Configuration = configuration;
            }

            public async Task HandleEventAsync(object? sender, UnturnedPlayerChattingEvent @event)
            {
                if (@event.Message.StartsWith("/"))
                {
                    string msg = @event.Message.Replace("/", "");
                    var commands = m_Configuration.GetSection("commands").Get<List<Command>>();
                    if (commands.Where(k => k.CommandName.ToLower() == msg.ToLower()).FirstOrDefault() != null)
                    {
                        @event.IsCancelled = true;
                        var command = commands.Where(k => k.CommandName.ToLower() == msg.ToLower()).First();
                        @event.Player.Player.sendBrowserRequest(command.Description, command.WebUrl);
                    }
                }
            }
        }
    }
}
