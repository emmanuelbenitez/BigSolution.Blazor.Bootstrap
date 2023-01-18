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

namespace BigSolution.Bootstrap.Utilities.Fluent;

internal abstract class PaddingBuilder<TPaddingSide> : SpacingBuilder<Padding, PaddingSide, IPaddingCombiner, ISupportPadding>, IPaddingCombiner, IPaddingBuilder, ISupportPadding
	where TPaddingSide : PaddingSide
{
	protected PaddingBuilder(Padding margin, TPaddingSide marginSide) : base(margin, marginSide) { }

	#region ISupportPadding Members

	public IAutoPaddingBuilder IsAuto()
	{
		return new AutoPaddingBuilder(_spacing);
	}

	#endregion

	#region Base Class Member Overrides

	protected sealed override IPaddingCombiner Combiner => this;

	protected override ISupportPadding Factory => this;

	#endregion

	public IFixedPaddingBuilder IsFixedAt(uint value)
	{
		return new FixedPaddingBuilder(_spacing, value);
	}
}
