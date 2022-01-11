using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BibReader.Analysis
{
    class Circle
    {
        public Color SunSpotColor = Color.White;
        public Color TextColor = Color.Black;
        public int SunSpotDiameter = 10;

        public void Draw(
            Graphics gr,
            string text,
            float radius,
            Color fillColor,
            Color fillColor2,
            Font font,
            PointF pos)
        {
            var rect = new RectangleF(pos.X - radius, pos.Y - radius, 2 * radius, 2 * radius);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                using (var brush = new PathGradientBrush(path))
                {
                    brush.CenterPoint = new PointF(pos.X - radius / 2, pos.Y - radius / 2);
                    brush.CenterColor = fillColor2;
                    brush.SurroundColors = new[] { fillColor };

                    gr.FillEllipse(brush, rect);
                }

                using (var brush = new PathGradientBrush(path))
                {
                    brush.CenterPoint = new PointF(pos.X - radius / 2, pos.Y - radius / 2);
                    brush.CenterColor = SunSpotColor;
                    brush.SurroundColors = new[] { fillColor };

                    gr.FillEllipse(brush, rect);
                }

                using (Brush brush = new SolidBrush(Color.FromArgb(70, 105, 105, 105)))
                {
                    gr.FillEllipse(
                        brush,
                        pos.X - radius / 2, 
                        pos.Y - radius / 2, 
                        SunSpotDiameter, 
                        SunSpotDiameter);
                }

                using (var brush = new SolidBrush(TextColor))
                {
                    gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    gr.DrawString( 
                        text,  
                        font,  
                        brush, 
                        rect, 
                        new StringFormat { 
                            Alignment = StringAlignment.Center, 
                            LineAlignment = StringAlignment.Center 
                        });
                }
            }
        }
    }
}
