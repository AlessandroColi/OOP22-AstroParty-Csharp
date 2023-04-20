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
        private Dictionary<PlayerId,string> _map = new Dictionary<PlayerId,string>();

        string GetName( PlayerId id) => _map.TryGetValue( id, "Player " + ((int)id).ToString() );

        void SetName( PlayerId id, string name) => _map.TryAd(id, name); // una volta scelto il nome non si può cambiare
    }
}