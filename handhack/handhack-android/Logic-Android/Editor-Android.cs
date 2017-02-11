using Android.Graphics;
using NativeColor = Android.Graphics.Color;

namespace handhack
{
    public partial class Editor
    {
        Bitmap secondBitmap;
        Canvas secondCanvas;

        void ResetSecondCanvas()
        {
            secondBitmap = Bitmap.CreateBitmap((int)realsize.dx, (int)realsize.dy, Bitmap.Config.Rgb565);
            secondCanvas = new Canvas(secondBitmap);
            secondCanvas.DrawColor(NativeColor.White);

            SetGrid();
            secondCanvas.Draw(grid, transform);

            MoveDrawnShapesToUndrawn();
            DrawUndrawnShapesOnSecondCanvas();
        }
        void DrawUndrawnShapesOnSecondCanvas()
        {
            foreach (var shape in undrawnShapes) secondCanvas.Draw(shape, transform);
            MoveUndrawnShapesToDrawn();
        }
        public void Draw(Canvas canvas)
        {
            DrawUndrawnShapesOnSecondCanvas();
            canvas.DrawBitmap(secondBitmap, 0, 0, null);
            if (shapeCreator != null) canvas.Draw(shapeCreator, transform);
        }
    }
}