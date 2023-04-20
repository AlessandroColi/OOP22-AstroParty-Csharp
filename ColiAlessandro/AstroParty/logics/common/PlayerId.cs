using System.Collections.Generic;
namespace AstroParty
{
    public enum PlayerId
    {
        PLAYER1,
        PLAYER2,
        PLAYER3,
        PLAYER4
    }

    public static class PlayerIdExtension
    {
        private static Dictionary<PlayerId,string> _map = new Dictionary<PlayerId,string>();

        public static string GetName( PlayerId id) => _map.TryGetValue( id, $"Player {((int)id).ToString()}" );

        public static void SetName( PlayerId id, string name) => _map.TryAdd(id, name); // una volta scelto il nome non si può cambiare
    }
}