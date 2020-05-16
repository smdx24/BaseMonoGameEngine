﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseMonoGameEngine
{
    /// <summary>
    /// Represents an animation frame.
    /// </summary>
    public struct AnimationFrame : ICopyable<AnimationFrame>
    {
        public Rectangle DrawRegion;
        public double Duration;
        public Vector2 Pivot;

        public AnimationFrame(Rectangle drawRegion, double duration)
        {
            DrawRegion = drawRegion;
            Duration = duration;
            Pivot = new Vector2(.5f, .5f);
        }

        public AnimationFrame(Rectangle drawRegion, double duration, Vector2 pivot)
        {
            DrawRegion = drawRegion;
            Duration = duration;
            Pivot = pivot;
        }

        public AnimationFrame Copy()
        {
            return new AnimationFrame(DrawRegion, Duration, Pivot);
        }
    }
}
