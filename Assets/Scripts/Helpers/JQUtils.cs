using UnityEngine;
using System.Collections;

namespace com.javierquevedo
{

    public class JQUtils
    {

        // http://answers.unity3d.com/questions/56429/enum-choose-random-.html
        public static T GetRandomEnum<T>()
        {
            System.Array A = System.Enum.GetValues(typeof(T));
            T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
            return V;
        }

        public static Color ColorForBubbleColor(BubbleColor color)
        {
            switch (color)
            {
                case BubbleColor.Purple:
                    return new Color(1.0f, 0.494f, 0.761f);
                case BubbleColor.Blue:
                    return new Color(0.333f, 0.941f, 1.0f);
                case BubbleColor.Red:
                    return new Color(1.0f, 0.357f, 0.322f);
                case BubbleColor.White:
                    return new Color(1.0f, 1.0f, 1.0f);
                case BubbleColor.Yellow:
                    return new Color(0.757f, 1.0f, 0.322f);
                case BubbleColor.Orange:
                    return new Color(1.0f, 0.643f, 0.323f);
                default:
                    return new Color(0.0f, 1.0f, 1.0f);
            }
            //	= Vector4(1.0, 0.0, 0.0, 1.0)	
        }

        public static ArrayList FilterByColor(ArrayList bubbles, BubbleColor color)
        {
            ArrayList filtered = new ArrayList();
            foreach (Bubble bubble in bubbles)
            {
                if (bubble.color == color)
                    filtered.Add(bubble);
            }
            return filtered;
        }
    }
}
