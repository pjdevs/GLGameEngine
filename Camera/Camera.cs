using OpenTK.Mathematics;

namespace OpenGLGame.Camera
{
    abstract class Camera
    {   
        public virtual float FOV { get; set; }
        public virtual float AspectRatio { get; set; }
        public virtual float Near { get; set; }
        public virtual float Far { get; set; }

        public Camera(float fov, float ratio, float near, float far)
        {
            FOV = fov;
            AspectRatio = ratio;
            Near = near;
            Far = far;
        }

        public Camera(float ratio)
            : this(1f, ratio, 0.1f, 100f)
        {}

        public abstract Matrix4 GetView();
        public abstract Matrix4 GetProjection();
    }
}
