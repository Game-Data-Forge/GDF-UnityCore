using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    static public class VisualElementExtension 
    {
        static public void IconContent(this IStyle self, string name)
        {
            Texture2D texture = EditorGUIUtility.IconContent(name).image as Texture2D;
            self.backgroundImage = texture;
            self.backgroundSize = new BackgroundSize(texture.width, texture.height);
            self.backgroundPositionX = new BackgroundPosition(BackgroundPositionKeyword.Center);
            self.backgroundPositionY = new BackgroundPosition(BackgroundPositionKeyword.Center);
            
            self.minHeight = texture.height;
            self.minWidth = texture.width;
        }
    }
}