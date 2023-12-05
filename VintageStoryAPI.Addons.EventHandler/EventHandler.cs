// using System.Reflection;
// using Vintagestory.API.Common;
// using VintageStoryAPI.Addons.Common;
// using VintageStoryAPI.Addons.EventHandler.Common;
//
// namespace VintageStoryAPI.Addons.EventHandler;
//
// public class EventHandler<T> : IHandler<T> where T :  ICoreAPI
// {
//     private readonly IParser<Event> _eventsParser = new EventsParser();
//
//     public void RegisterAll(Assembly assembly)
//     {
//         var events = _eventsParser.Parse<T>(assembly);
//         foreach (var @event in events)
//         {
//             
//         }
//         // var eventInfo = client.GetType().GetEvent(@event.EventType.ToString());
//         // var handlerType = eventInfo!.EventHandlerType!;
//         // Delegate handler;
//         // try
//         // {
//         //     handler = Delegate.CreateDelegate(handlerType, eventModule, @event.MethodInfo);
//         // }
//         // catch (ArgumentException)
//         // {
//         //     _logger.LogError(
//         //         $"Your {@event.MethodInfo.Name} method from {eventModule.GetType().Name} class has a bad signature.");
//         //     continue;
//         // }
//         //
//         // eventInfo.AddEventHandler(client, handler);
//     }
// }