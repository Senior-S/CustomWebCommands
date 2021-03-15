using System;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Plugins;
using OpenMod.API.Plugins;

[assembly: PluginMetadata("SS.CustomWebCommands", DisplayName = "CustomWebCommands")]
namespace CustomWebCommands
{
    public class CustomWebCommands : OpenModUnturnedPlugin
    {
        private readonly ILogger<CustomWebCommands> m_Logger;

        public CustomWebCommands(
            ILogger<CustomWebCommands> logger,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Logger = logger;
        }

        protected override async UniTask OnLoadAsync()
        {
            // await UniTask.SwitchToMainThread();
            m_Logger.LogInformation(" Plugin loaded correctly!");

            // await UniTask.SwitchToThreadPool();
        }

        protected override async UniTask OnUnloadAsync()
        {
            // await UniTask.SwitchToMainThread();
            m_Logger.LogInformation(" Plugin unloaded correctly!");
        }
    }
}
