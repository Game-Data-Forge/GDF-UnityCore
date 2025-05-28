using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GDFUnity.Editor
{
    public static class GDFGUIUtility
    {
        static private Dictionary<string, GUIContent> _cache = new Dictionary<string, GUIContent>();

        static public GUIContent IconContent(string name)
        {
            GUIContent content;
            Texture texture;

            if (_cache.TryGetValue(name, out content))
            {
                return content;
            }

            if (EditorGUIUtility.isProSkin)
            {
                texture = Resources.Load<Texture>("Icons/d_" + name);
            }
            else
            {
                texture = Resources.Load<Texture>("Icons/" + name);
            }

            if (texture == null) return EditorGUIUtility.IconContent(name);

            content = new GUIContent() {
                image = texture
            };
            _cache.Add(name, content);

            return content;
        }
    }
}
