﻿#region Copyright & License

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

namespace BigSolution.Bootstrap;

public enum HeadingSize
{
    [CssClassPart("h1")]
    One,

    [CssClassPart("h2")]
    Two,

    [CssClassPart("h3")]
    Three,

    [CssClassPart("h4")]
    Four,

    [CssClassPart("h5")]
    Five,

    [CssClassPart("h6")]
    Six,
}