namespace EnetCNMAUI.Services.Local
{
    public interface ILocationState
    {
        Location? CurrentPosition { get; set; }
        Location DefaultPosition { get; }
    }
}
