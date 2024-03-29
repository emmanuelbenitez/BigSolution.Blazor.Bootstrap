﻿#region Copyright & License

// Copyright © 2020 - 2023 Emmanuel Benitez
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

/// <summary>
/// Defines the Bootstrap button size.
/// </summary>
/// <seealso href="https://getbootstrap.com/docs/5.2/components/buttons/#sizes">Bootstrap button size - documentation</seealso>
public enum ButtonSize
{
	/// <summary>
	/// No size is defined.
	/// </summary>
	None,

	/// <summary>
	/// A smaller button.
	/// </summary>
	[CssClassPart("sm")]
	Small,

	/// <summary>
	/// A larger button.
	/// </summary>
	[CssClassPart("lg")]
	Large
}
