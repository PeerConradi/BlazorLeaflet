using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlazorLeaflet.Components
{
    public class LeafIcon : ComponentBase, IDisposable
    {
        [CascadingParameter]public LeafMarkerBase ParentMarker { get; set; }

        /// <summary>
        /// (required) The URL to the icon image (absolute or relative to your script path).
        /// </summary>
        [Parameter] public string Url { get; set; }

        /// <summary>
        /// The URL to a retina sized version of the icon image (absolute or relative to your script path). Used for Retina screen devices.
        /// </summary>
        [Parameter] public string RetinalUrl { get; set; }

        /// <summary>
        /// Size of the icon image in pixels.
        /// </summary>
        [Parameter] public Size? Size { get; set; }

        /// <summary>
        /// The coordinates of the "tip" of the icon (relative to its top left corner). The icon will be aligned so that this point is at the marker's geographical location. Centered by default if size is specified, also can be set in CSS with negative margins.
        /// </summary>
        [Parameter] public Point? Anchor { get; set; }

        /// <summary>
        /// The coordinates of the point from which popups will "open", relative to the icon anchor.
        /// </summary>
        [Parameter] public Point PopupAnchor { get; set; } = Point.Empty;

        /// <summary>
        /// The coordinates of the point from which tooltips will "open", relative to the icon anchor.
        /// </summary>
        [Parameter] public Point TooltipAnchor { get; set; } = Point.Empty;

        /// <summary>
        /// The URL to the icon shadow image. If not specified, no shadow image will be created.
        /// </summary>
        [Parameter] public string ShadowUrl { get; set; }

        [Parameter] public string ShadowRetinalUrl { get; set; }

        /// <summary>
        /// Size of the shadow image in pixels.
        /// </summary>
        [Parameter] public Size? ShadowSize { get; set; }

        /// <summary>
        /// The coordinates of the "tip" of the shadow (relative to its top left corner) (the same as iconAnchor if not specified).
        /// </summary>
        [Parameter] public Size? ShadowAnchor { get; set; }

        /// <summary>
        /// A custom class name to assign to both icon and shadow images. Empty by default.
        /// </summary>
        [Parameter] public string ClassName { get; set; } = string.Empty;

        private Models.Icon icon;

        protected override void OnParametersSet()
        {
            Console.WriteLine("OnParametersSet");
            this.icon = new Models.Icon()
            {
                Anchor = this.Anchor,
                ClassName = this.ClassName,
                PopupAnchor = this.PopupAnchor,
                RetinalUrl = this.RetinalUrl,
                ShadowAnchor = this.ShadowAnchor,
                ShadowRetinalUrl = this.ShadowRetinalUrl,
                ShadowSize = this.ShadowSize,
                ShadowUrl = this.ShadowUrl,
                Size = this.Size,
                TooltipAnchor = this.TooltipAnchor,
                Url = this.Url
            };
            ParentMarker?.SetIcon(icon);
        }

        public void Dispose()
        {
            if (ParentMarker != null)
            {
                ParentMarker?.SetIcon(null);
            }
        }
    }
}
