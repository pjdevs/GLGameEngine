using System.Collections.Generic;

namespace OpenGLGame.Graphics
{
    public abstract class Scene
    {
        protected Dictionary<string, Shader> shaders;

        public Scene()
        {
            shaders = new Dictionary<string, Shader>();
        }

        public abstract void Load();
        public abstract void Update();

        public abstract void Render();

        public abstract void OnUnload();
    }
}
