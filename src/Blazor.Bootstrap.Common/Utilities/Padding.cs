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

using BigSolution.Bootstrap.Utilities.Fluent;

namespace BigSolution.Bootstrap.Utilities;

public class Padding : Spacing<PaddingSide>
{
	#region Operators

	public static implicit operator Padding(PaddingSide paddingSide)
	{
		return ToPadding(paddingSide);
	}

	public static implicit operator Padding(uint value)
	{
		return ToPadding(value);
	}

	public static implicit operator Padding(string value)
	{
		return ToPadding(value);
	}

	#endregion

	public static IAutoPaddingBuilder IsAuto()
	{
		return new AutoPaddingBuilder(new Padding());
	}

	public static IFixedPaddingBuilder IsFixedAt(uint value)
	{
		return new FixedPaddingBuilder(new Padding(), value);
	}

	private static Padding ToPadding(string value)
	{
		return (PaddingSide)value;
	}

	private static Padding ToPadding(uint value)
	{
		return (FixedPaddingSide)value;
	}

	private static Padding ToPadding(PaddingSide paddingSide)
	{
		return new Padding { Sides = new[] { paddingSide } };
	}
}