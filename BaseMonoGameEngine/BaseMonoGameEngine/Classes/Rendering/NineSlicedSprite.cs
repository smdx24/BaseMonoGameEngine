﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseMonoGameEngine
{
    public class NineSlicedSprite : SlicedSprite
    {
        public int LeftLine = 0;
        public int RightLine = 0;
        public int TopLine = 0;
        public int BottomLine = 0;

        public override int Slices => 9;

        public NineSlicedSprite(Texture2D tex, Rectangle? sourceRect, int leftCutoff, int rightCutoff, int topCutoff, int bottomCutoff)
            : base(tex, sourceRect)
        {
            SetCutoffRegions(leftCutoff, rightCutoff, topCutoff, bottomCutoff);
        }

        public void SetCutoffRegions(int leftCutoff, int rightCutoff, int topCutoff, int bottomCutoff)
        {
            LeftLine = leftCutoff;
            RightLine = rightCutoff;
            TopLine = topCutoff;
            BottomLine = bottomCutoff;

            Regions = CreateRegions(SourceRect.HasValue ? SourceRect.Value : Tex.Bounds);
        }

        public override Rectangle GetRectForIndex(Rectangle rectangle, int index)
        {
            int x = rectangle.X;
            int y = rectangle.Y;
            int width = rectangle.Width;
            int height = rectangle.Height;
            int middleWidth = width - LeftLine - RightLine;
            int middleHeight = height - TopLine - BottomLine;
            int bottomY = y + height - BottomLine;
            int rightX = x + width - RightLine;
            int leftX = x + LeftLine;
            int topY = y + TopLine;

            switch (index)
            {
                //Upper-region
                case 0: return new Rectangle(x, y, LeftLine, TopLine);
                case 1: return new Rectangle(leftX, y, middleWidth, TopLine);
                case 2: return new Rectangle(rightX, y, RightLine, TopLine);

                //Middle-region
                case 3: return new Rectangle(x, topY, LeftLine, middleHeight);
                case 4: return new Rectangle(leftX, topY, middleWidth, middleHeight);
                case 5: return new Rectangle(rightX, topY, RightLine, middleHeight);

                //Lower-region
                case 6: return new Rectangle(x, bottomY, LeftLine, BottomLine);
                case 7: return new Rectangle(leftX, bottomY, middleWidth, BottomLine);
                case 8: return new Rectangle(rightX, bottomY, RightLine, BottomLine);

                default: return rectangle;
            }
        }
    }
}