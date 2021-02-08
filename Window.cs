using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL4;

using OpenGLGame.Models;
using OpenGLGame.Utils;
using OpenGLGame.Mesh;
using OpenGLGame.Camera;

namespace OpenGLGame
{
    class Window : GameWindow
    {
        private Shader shader;
        private StaticCamera camera;
        private MeshObject cube;

        public Window(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = new Vector2i(width, height), Title = title})
        {}

        protected override void OnLoad()
        {
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Enable(EnableCap.DepthTest);

            shader = new Shader("assets/shaders/shader.vert", "assets/shaders/shader.frag");
            cube = new MeshObject(ModelsGallery.Cube);
            camera = new StaticCamera((float)Size.X / (float)Size.Y);

            base.OnLoad();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (KeyboardState.IsKeyReleased(Keys.Escape))
                Close();
        
            cube.Rotation.Y += (float)e.Time * 0.1f;

            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            shader.Use();
            shader.SetMatrix4("view", camera.GetView());
            shader.SetMatrix4("projection", camera.GetProjection());

            DrawMesh(cube);

            SwapBuffers();

            base.OnRenderFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            camera.AspectRatio = (float)Size.X / (float)Size.Y;
            
            base.OnResize(e);
        }

        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
            GL.DeleteProgram(shader.Handle);

            base.OnUnload();
        }

        protected void DrawMesh(MeshObject mesh)
        {
            mesh.Bind();
            shader.SetMatrix4("model", mesh.GetTransform());
            mesh.Draw();
        }
    }
}
