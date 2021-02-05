#region Copyright & License

// Copyright © 2020 - 2021 Emmanuel Benitez
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using BigSolution.Blazor;
using BlazorComponentUtilities;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BigSolution.Bootstrap
{
    public class ActivatableDynamicElement : DynamicElement, IDisposable
    {
        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Base Class Member Overrides

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += OnLocationChanged;
        }

        #endregion

        #region Base Class Member Overrides

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass(() => ActiveClass ?? "active", IsActive());

        #endregion

        [Parameter]
        public string ActiveClass { get; set; }

        [Parameter]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "Required for Blazor")]
        public string ActivePath
        {
            get => _activePath;
            set
            {
                _activePath = value;
                StateHasChanged();
            }
        }

        [Inject]
        private NavigationManager NavigationManager { get; [UsedImplicitly] set; }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                NavigationManager.LocationChanged -= OnLocationChanged;
            }
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        protected bool IsActive()
        {
            return NavigationManager != null
                && !string.IsNullOrWhiteSpace(ActivePath)
                && NavigationManager.Uri.StartsWith(NavigationManager.ToAbsoluteUri(ActivePath).ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            StateHasChanged();
        }

        private string _activePath;
    }
}
