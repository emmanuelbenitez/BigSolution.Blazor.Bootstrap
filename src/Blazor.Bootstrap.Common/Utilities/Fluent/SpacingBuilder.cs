#region Copyright & License

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

using System;
using System.Linq;

namespace BigSolution.Bootstrap.Utilities.Fluent;

internal abstract class SpacingBuilder<TSpacing, TSpacingSide, TCombiner, TSupportSpacing> :
	ISupportSideDefinition<TCombiner>,
	ISpacingCombiner<TSupportSpacing, TSpacing, TSpacingSide>
	where TSpacing : Spacing<TSpacingSide>
	where TSpacingSide : SpacingSide
{
	protected SpacingBuilder(TSpacing spacing, TSpacingSide spacingSide)
	{
		_spacing = spacing;
		_spacingSide = spacingSide;
		_spacing.Sides = (_spacing.Sides ?? Array.Empty<TSpacingSide>()).Concat(new[] { _spacingSide }).ToArray();
	}

	#region ISpacingCombiner<TSupportSpacing,TSpacing,TSpacingSide> Members

	public TSpacing Build()
	{
		return _spacing;
	}

	public TSupportSpacing And => Factory;

	#endregion

	#region ISupportSideDefinition<TCombiner> Members

	public TCombiner On(Sides sides)
	{
		_spacingSide.ImpactedSides = sides;
		return Combiner;
	}

	public TCombiner OnAll()
	{
		return On(Sides.All);
	}

	public TCombiner OnBottom()
	{
		return On(Sides.Bottom);
	}

	public TCombiner OnEnd()
	{
		return On(Sides.End);
	}

	public TCombiner OnStart()
	{
		return On(Sides.Start);
	}

	public TCombiner OnStartEnd()
	{
		return On(Sides.Start | Sides.End);
	}

	public TCombiner OnTop()
	{
		return On(Sides.Top);
	}

	public TCombiner OnTopBottom()
	{
		return On(Sides.Top | Sides.Bottom);
	}

	#endregion

	protected abstract TCombiner Combiner { get; }

	protected abstract TSupportSpacing Factory { get; }

	protected readonly TSpacing _spacing;
	private readonly TSpacingSide _spacingSide;
}
