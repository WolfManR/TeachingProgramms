using System;

namespace GameEngineLibraryProject
{
    [Obsolete("Interface name may be changed")]
    interface IGameEngineObject
    {
        void Draw();
        void Update();
    }
}
