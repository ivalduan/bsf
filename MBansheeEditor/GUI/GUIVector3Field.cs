﻿using System;
using System.Runtime.CompilerServices;
using BansheeEngine;

namespace BansheeEditor
{
    /// <summary>
    /// Editor GUI element that displays a 3D vector input field and an optional label.
    /// </summary>
    public sealed class GUIVector3Field : GUIElement
    {
        public delegate void OnChangedDelegate(Vector3 newValue);

        /// <summary>
        /// Triggered when the value in the field changes.
        /// </summary>
        public event OnChangedDelegate OnChanged;

        /// <summary>
        /// Value displayed by the field input box.
        /// </summary>
        public Vector3 Value
        {
            get
            {
                Vector3 value;
                Internal_GetValue(mCachedPtr, out value);
                return value;
            }

            set { Internal_SetValue(mCachedPtr, value); }
        }

        /// <summary>
        /// Creates a new 3D vector field element with a label.
        /// </summary>
        /// <param name="title">Content to display on the label.</param>
        /// <param name="titleWidth">Width of the title label in pixels.</param>
        /// <param name="style">Optional style to use for the element. Style controls the look of the element, as well as 
        ///                     default layout options. Style will be retrieved from the active GUISkin. If not specified 
        ///                     default element style is used.</param>
        /// <param name="options">Options that allow you to control how is the element  positioned and sized. This will 
        ///                       override any similar options set by style.</param>
        public GUIVector3Field(GUIContent title, int titleWidth = 100, string style = "", params GUIOption[] options)
        {
            Internal_CreateInstance(this, title, titleWidth, style, options, true);
        }

        /// <summary>
        /// Creates a new 3D vector field element without a label.
        /// </summary>
        /// <param name="style">Optional style to use for the element. Style controls the look of the element, as well as 
        ///                     default layout options. Style will be retrieved from the active GUISkin. If not specified 
        ///                     default element style is used.</param>
        /// <param name="options">Options that allow you to control how is the element  positioned and sized. This will 
        ///                       override any similar options set by style.</param>
        public GUIVector3Field(string style = "", params GUIOption[] options)
        {
            Internal_CreateInstance(this, null, 0, style, options, false);
        }

        /// <summary>
        /// Checks does the element currently has input focus. Input focus means the element has an input caret displayed
        /// and will accept input from the keyboard.
        /// </summary>
        /// <returns>True if the element has input focus.</returns>
        public bool HasInputFocus()
        {
            bool value;
            Internal_HasInputFocus(mCachedPtr, out value);
            return value;
        }

        /// <summary>
        /// Colors the element with a specific tint.
        /// </summary>
        /// <param name="color">Tint to apply to the element.</param>
        public void SetTint(Color color)
        {
            Internal_SetTint(mCachedPtr, color);
        }

        /// <summary>
        /// Triggered by the runtime when the value of the field changes.
        /// </summary>
        /// <param name="newValue">New value of the field.</param>
        private void DoOnChanged(Vector3 newValue)
        {
            if (OnChanged != null)
                OnChanged(newValue);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void Internal_CreateInstance(GUIVector3Field instance, GUIContent title, int titleWidth,
            string style, GUIOption[] options, bool withTitle);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void Internal_GetValue(IntPtr nativeInstance, out Vector3 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void Internal_SetValue(IntPtr nativeInstance, Vector3 value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void Internal_HasInputFocus(IntPtr nativeInstance, out bool value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void Internal_SetTint(IntPtr nativeInstance, Color color);
    }
}
