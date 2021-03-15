using System;

namespace Lesson_5_Warehouse.Common_Structs
{
    public struct Size
    {
        public float length;
        public float width;
        public float height;

        public Size(float l, float w, float h)
        {
            length = l; width = w; height = h;
        }
    }
}
