namespace LFY.Controls
{
    using System;
    using System.Collections;
    using System.Reflection;

    internal class Layers
    {
        private LayeredImage _image;
        private ArrayList _layers = new ArrayList();

        public Layers(LayeredImage image)
        {
            this._image = image;
        }

        public Layer Add()
        {
            Layer layer = new Layer(this._image.Width, this._image.Height);
            this._layers.Add(layer);
            return layer;
        }

        public Layer Add(FastBitmap bitmap)
        {
            Layer layer = new Layer(bitmap);
            this._layers.Add(layer);
            return layer;
        }

        public Layer Add(int width, int height)
        {
            Layer layer = new Layer(width, height);
            this._layers.Add(layer);
            return layer;
        }

        public Layer Copy(Layer layer)
        {
            Layer layer2 = (Layer) layer.Clone();
            this._layers.Add(layer2);
            return layer2;
        }

        public int Count
        {
            get
            {
                return this._layers.Count;
            }
        }

        public Layer this[int i]
        {
            get
            {
                return (Layer) this._layers[i];
            }
        }
    }
}

