using System.Text.Json;

namespace WireMockDemo.Entities
{
    public static class EntityExtension
    {
        public static T? Copy<T>(T itemToCopy) where T : IEntity
        {
            var json = JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        } 
    }
    
}