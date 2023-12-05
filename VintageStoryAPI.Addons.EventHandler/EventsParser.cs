// using System.Reflection;
// using Vintagestory.API.Common;
// using VintageStoryAPI.Addons.Common;
// using VintageStoryAPI.Addons.Common.Extensions;
// using VintageStoryAPI.Addons.EventHandler.Common;
//
// namespace VintageStoryAPI.Addons.EventHandler;
//
// internal class EventsParser : IParser<Event>
// {
//     public IEnumerable<Event> Parse(Assembly assembly)
//     {
//         var eventMethods = assembly
//             .GetSpecificMethodsFromTypes<EventModule>(method => 
//                 method.GetCustomAttribute(typeof(EventAttribute), true) is not null);
//     }
// }