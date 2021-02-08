using System;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGLGame.Mesh
{
    class MeshObject
    {
        private float[] vertices;
        private int vbo;
        private int vao;

        public Vector3 Rotation;
        public Vector3 Scale;
        public Vector3 Position;

        public MeshObject(float[] meshVertices)
        {
            vertices = meshVertices;

            Rotation = Vector3.Zero;
            Position = Vector3.Zero;
            Scale = new Vector3(1f, 1f, 1f);

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);

            GL.EnableVertexArrayAttrib(vao, 0);
        }

        ~MeshObject()
        {
            GL.DeleteBuffer(vbo);
            GL.DeleteVertexArray(vao);
        }

        public void Bind()
        {
            GL.BindVertexArray(vao);
        }

        public void Draw()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length / 3);
        }

        public Matrix4 GetTransform() =>
              Matrix4.CreateTranslation(Position) 
            * Matrix4.CreateRotationX(Rotation.X) * Matrix4.CreateRotationY(Rotation.Y) * Matrix4.CreateRotationZ(Rotation.Z)
            * Matrix4.CreateScale(Scale);
    }
}
