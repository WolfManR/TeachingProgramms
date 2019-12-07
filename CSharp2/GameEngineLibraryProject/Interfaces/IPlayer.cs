using GameEngineLibraryProject.Archetipes;

namespace GameEngineLibraryProject
{
    public interface IPlayer
    {
        GameObject ControlledObject { get; set; }
        string Name { get; set; }
    }
}
