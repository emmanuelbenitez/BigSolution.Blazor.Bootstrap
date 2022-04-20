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

using System.Collections.Generic;
using Blazor.Bootstrap.Documentation.Client.Models;

namespace Blazor.Bootstrap.Documentation.Client.Services;

public sealed class SideBarContentProvider : ISideBarContentProvider
{
    #region ISideBarContentProvider Members

    public IEnumerable<SideBarItemGroup> GetItemGroups()
    {
        return _itemGroups;
    }

    #endregion

    private readonly SideBarItemGroup[] _itemGroups = {
        new() {
            Display = "Getting Started",
            Link = "/getting-started/introduction",
            ActivePath = "/getting-started",
            Items = {
                new SideBarItem { Display = "Introduction", Link = "/getting-started/introduction" }
            }
        },
        new() {
            Display = "Layout",
            Link = "/layout/overview",
            ActivePath = "/layout",
            Items = {
                new SideBarItem { Display = "Overview", Link = "/layout/overview" },
                new SideBarItem { Display = "Grid", Link = "/layout/grid" }
            }
        },
    };
}