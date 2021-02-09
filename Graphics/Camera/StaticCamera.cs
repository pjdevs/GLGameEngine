using OpenTK.Mathematics;

namespace OpenGLGame.Graphics.Camera
{
    class StaticCamera : Camera
    {
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }

        public StaticCamera(float ratio)
            : this(new Vector3(2f, 2f, 2f), Vector3.Zero, ratio)
        {}

        public StaticCamera(Vector3 position, Vector3 target, float ratio)
            : base(ratio)
        {
            Position = position;
            Target = target;
        }

        public override Matrix4 GetView()
        {
            return Matrix4.LookAt(Position, Target, Vector3.UnitY);
        }

        public override Matrix4 GetProjection()
        {
            return Matrix4.CreatePerspectiveFieldOfView(FOV, AspectRatio, Near, Far);
        }
    }
}
