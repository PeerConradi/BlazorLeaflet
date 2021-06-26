using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLeaflet.Components
{
    public class LeafMarkerBase : ComponentBase, IDisposable
    {

        [Parameter]public float Latitude { get; set; }

        [Parameter]public float Longitude { get; set; }

        private Models.Icon icon;

        [CascadingParameter]public LeafletMap ParentMap { get; set; }

        [Parameter]public RenderFragment ChildContent { get; set; }

        Models.Marker _marker;

        public LeafMarkerBase() : base()
        {
            if (this.ChildContent != null)
            {
                Console.WriteLine("Child content");
            }
            else
            {
                Console.WriteLine("No child content");
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (ParentMap.Map != null)
            {
                ParentMap.Map.OnInitialized += Map_OnInitialized;
            }
        }

        private void Map_OnInitialized()
        {
            _marker = new Models.Marker(new Models.LatLng(Latitude, Longitude));
            _marker.Icon = icon;
            ParentMap.Map.AddLayer(_marker);
            Console.WriteLine("Map_OnInitialized");
        }

        public void SetIcon(Models.Icon setIcon)
        {
            Console.WriteLine("SetIcon");
            this.icon = setIcon;
            if (_marker != null)
            {
                ParentMap.Map.RemoveLayer(_marker);
                _marker.Icon = setIcon;
                ParentMap.Map.AddLayer(_marker);
                InvokeAsync(StateHasChanged);
                
            }
            
        }

        public void Dispose()
        {
            if (_marker != null)
                ParentMap?.Map?.RemoveLayer(_marker);
        }
    }
}
